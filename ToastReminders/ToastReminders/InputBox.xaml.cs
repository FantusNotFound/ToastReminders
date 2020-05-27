using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToastReminders
{
	/// <summary>
	/// Interaction logic for InputBox.xaml
	/// </summary>
	public partial class InputBox : Window
	{
		public string text 
		{
			get
			{
				return ReminderTitle.Text;
			}
		}
		public InputBox()
		{
			InitializeComponent();
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
		private void AddReminder_Click(object sender, RoutedEventArgs e)
		{
			Window.GetWindow(this).DialogResult = true;
			this.Close();
		}
	}
}
