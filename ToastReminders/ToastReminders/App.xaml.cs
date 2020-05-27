using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using PeanutButter.Toast;
using System.Timers;
using System.Windows.Forms;
using Application = System.Windows.Application;
using Timer = System.Timers.Timer;
using MessageBox = System.Windows.MessageBox;

namespace ToastReminders
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindow_Closing;

            _notifyIcon = new NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = ToastReminders.Properties.Resources.ToastIcon;
            _notifyIcon.Text = "Toast Reminders";
            _notifyIcon.Visible = true;

            CreateContextMenu();
            Timer timer = new Timer(5000);
            timer.Elapsed += (sender, f) => Update(sender, f);
            timer.AutoReset = true;
            timer.Start();
        }
        public void Update(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Tracking {reminders.Count} reminders");
            foreach (Reminder reminder in reminders.ToArray())
            {
                if (reminder.time <= DateTime.Now)
                {
                    RemindUser(reminder.title);
                    reminders.Remove(reminder);
                }
            }
        }

        public static void RemindUser(string title)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                string message = "Reminder:";

                Toaster toaster = new Toaster();
                toaster.Show(message, title, (ToastTypes)ToastReminders.Properties.Settings.Default["ToastType"], (TimeSpan)ToastReminders.Properties.Settings.Default["DisplayTime"]);
            });
        }
        public static List<Reminder> reminders = new List<Reminder>();
        public struct Reminder
        {
            public DateTime? time;
            public string title;
            public Reminder(DateTime? _time, string _title)
            {
                time = _time;
                title = _title;
            }
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip =
              new ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Add Reminder").Click += (s, e) => ShowMainWindow();
            ToolStripItem dropdown = _notifyIcon.ContextMenuStrip.Items.Add("Add Quick Reminder", null);
            ToolStripItemCollection dropdownItem = (dropdown as ToolStripMenuItem).DropDownItems;
            dropdownItem.Add("5 minutes").Click += (s, e) => QuickNotification(5);
            dropdownItem.Add("10 minutes").Click += (s, e) => QuickNotification(10);
            dropdownItem.Add("15 minutes").Click += (s, e) => QuickNotification(15);
            dropdownItem.Add("20 minutes").Click += (s, e) => QuickNotification(20);
            dropdownItem.Add("30 minutes").Click += (s, e) => QuickNotification(30);
            dropdownItem.Add("45 minutes").Click += (s, e) => QuickNotification(45);
            dropdownItem.Add("1 hour").Click += (s, e) => QuickNotification(60);
            dropdownItem.Add("2 hours").Click += (s, e) => QuickNotification(120);
            _notifyIcon.ContextMenuStrip.Items.Add("Settings").Click += (s, e) => ShowSettings();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }
        void ShowSettings()
        {
            Window window = new Settings();
            if (window.IsVisible)
            {
                if (window.WindowState == WindowState.Minimized)
                {
                    window.WindowState = WindowState.Normal;
                }
                window.Activate();
            }
            else
            {
                window.Show();
            }
        }
        void QuickNotification(int time)
        {
            var w = new InputBox();
            string title = "";
            if (w.ShowDialog() == true)
            {
                title = w.text;
            }
            // Calculate Time
            DateTime timer = DateTime.Now.AddMinutes(time);
            Reminder reminder = new Reminder(timer, title);
            reminders.Add(reminder);
        }
        private void ExitApplication()
        {
            ToastReminders.Properties.Settings.Default.Save();
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
            Application.Current.Shutdown();
        }
        
        private void ShowMainWindow()
        {
            Window window = new MainWindow();
            if (window.IsVisible)
            {
                if (window.WindowState == WindowState.Minimized)
                {
                    window.WindowState = WindowState.Normal;
                }
                window.Activate();
            }
            else
            {
                window.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide(); // A hidden window can be shown again, a closed one not
            }
        }
    }
}
