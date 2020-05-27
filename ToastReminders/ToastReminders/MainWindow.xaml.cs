using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace ToastReminders
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void AddReminder_Click(object sender, RoutedEventArgs e)
		{
			AddNewReminder(ReminderTitle.Text);
			CloseWindow();
		}
		

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			CloseWindow();
		}

		private void CloseWindow()
		{
			TimePicker.Value = null;
			ReminderTitle.Text = ReminderTitle.Tag.ToString();
			Application.Current.MainWindow.Close();
		}

		private void TextLostFocus(object sender, RoutedEventArgs e)
		{
			FocusLost((TextBox)sender);
		}
		private void TextGotFocus(object sender, RoutedEventArgs e)
		{
			FocusGained((TextBox)sender);
		}

		void FocusLost(TextBox textBox)
		{
			if (textBox.Text == "")
			{
				textBox.Text = textBox.Tag.ToString();
				textBox.Foreground = new SolidColorBrush(Color.FromRgb(150, 150, 150));
			}
		}
		public void AddNewReminder(string text)
		{
			if (TimePicker.Value.HasValue)
			{
				App.Reminder reminder = new App.Reminder(TimePicker.Value, text);
				App.reminders.Add(reminder);
			}
			
		}
		
		void FocusGained(TextBox textBox)
		{
			if (textBox.Text == textBox.Tag.ToString())
			{
				textBox.Text = "";
				textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
			}
		}
		
	}
}
