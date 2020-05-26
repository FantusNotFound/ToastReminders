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

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = ToastReminders.Properties.Resources.ToastIcon;
            _notifyIcon.Visible = true;

            CreateContextMenu();
            
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip =
              new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Add Reminder").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ExitApplication()
        {
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }
        public static void AddNewReminder(string text, MainWindow mainWindow)
        {
            if (mainWindow.GetTime() == 2)
                return;
            Timer timer = new Timer(mainWindow.GetTime());
            timer.Elapsed += (sender, e) => RemindUser(sender, e, text);
            timer.AutoReset = false;
            timer.Start();
        }
        static void RemindUser(Object source, ElapsedEventArgs e, string title)
        {
            string message = "This is a test";
            ToastTypes type = ToastTypes.Info;

            Toaster toaster = new Toaster();
            toaster.Show(title, message, type);
        }
        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
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
