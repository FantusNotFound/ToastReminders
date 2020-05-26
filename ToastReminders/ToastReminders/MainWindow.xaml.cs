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
using PeanutButter.Toast;
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
			App.AddNewReminder(ReminderTitle.Text, this);
			CloseWindow();
		}

		

		public int GetTime()
		{
			//[0-9]+h
			string time = Time.Text;

			if (time == null || time == "" || time == Time.Tag.ToString())
			{
				MessageBox.Show("Failed to get time, make sure you entered a time");
				return 2;
			}
			try
			{
				if (!Regex.IsMatch(time, "[0-9]+h") || !Regex.IsMatch(time, "[0-9]+m"))
					throw new FormatException();
				string minStr = Regex.Replace(time, "[0-9]+h", "");
				string hourStr = Regex.Replace(time, "[0-9]+m", "");
				int.TryParse(minStr.Remove(minStr.Length - 1), out int minutes);
				int.TryParse(hourStr.Remove(hourStr.Length - 1), out int hours);

				int totalMinutes = minutes + (hours * 60);
				int seconds = totalMinutes * 60;
				int milliseconds = seconds * 1000;
				Console.WriteLine(milliseconds);
				if (milliseconds == 0)
					milliseconds = 1;
				
				return milliseconds;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				MessageBox.Show("Failed to get time, make sure you entered a time and it is formatted correctly");
				return 2;
			}
			
		}

		

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			CloseWindow();
		}

		private void CloseWindow()
		{
			Time.Text = Time.Tag.ToString();
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
