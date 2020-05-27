using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PeanutButter.Toast;

namespace ToastReminders
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : Window
	{
		public Settings()
		{
			InitializeComponent();
			ToastType.SelectedIndex = (int)Properties.Settings.Default["ToastType"];
			DisplayTime.Text = (Properties.Settings.Default["DisplayTime"] as TimeSpan?).Value.TotalSeconds.ToString();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (DisplayTime.Text != null && DisplayTime.Text != "" && DisplayTime.Text != DisplayTime.Tag.ToString())
					Properties.Settings.Default["DisplayTime"] = new TimeSpan(0, 0, int.Parse(DisplayTime.Text));
				
				
				Properties.Settings.Default["ToastType"] = (ToastTypes)ToastType.SelectedIndex;
				Application.Current.Dispatcher.Invoke((Action)delegate {
					Toaster toaster = new Toaster();
					toaster.Show("Settings", "Saved", ToastTypes.Success, new TimeSpan(0, 0, 5));
				});
			}
			catch (Exception ex)
			{
				Application.Current.Dispatcher.Invoke((Action)delegate {
					Toaster toaster = new Toaster();
					toaster.Show("Settings", "Failed saving", ToastTypes.Error, new TimeSpan(0, 0, 5));
				});
			}
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			CloseWindow();
		}

		void CloseWindow()
		{
			DisplayTime.Text = DisplayTime.Tag.ToString();
			this.Close();
		}

		private void DisplayTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");

			e.Handled = regex.IsMatch(e.Text);
		}
	}
}
