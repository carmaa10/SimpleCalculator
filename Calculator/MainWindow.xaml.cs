using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
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

        #region BUTTONS

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {
            HelpWindow modalHelpWindow = new HelpWindow();

            modalHelpWindow.ShowDialog();
        }
        #endregion

        #region TEXT BOXES

        private void TextBox_TextChanged_Height(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            bool validHeight = double.TryParse(Height.Text, out double temp);
            if (validHeight || Height.Text == "")
            {
                HeightError.Content = "";
                RadioInch.IsEnabled = true;
                RadioCm.IsEnabled = true;
            }
            else
            {
                HeightError.Content = "Please enter only numbers";
                RadioInch.IsEnabled = false;
                RadioCm.IsEnabled = false;
            }
        }

        private void TextBox_TextChanged_Weight(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            bool validWeight = double.TryParse(Weight.Text, out double temp);
            if (validWeight || Weight.Text == "")
            {
                WeightError.Content = "";
                RadioLbs.IsEnabled = true;
                RadioKg.IsEnabled = true;
            }
            else
            {
                WeightError.Content = "Please enter only numbers";
                RadioLbs.IsEnabled = false;
                RadioKg.IsEnabled = false;
            }
        }

        #endregion

        #region RADIO

        private void RadioInch_Checked(object sender, RoutedEventArgs e)
        {
            if (Height.Text != "")
            {
                double.TryParse(Height.Text, out double height);
                double result = height / 2.54;
                Height.Text = Convert.ToString(result);
                HeightLabelUnits.Content = "(Inches)";
            }
        }

        private void RadioCm_Checked(object sender, RoutedEventArgs e)
        {
            double.TryParse(Height.Text, out double height);
            double result = height * 2.54;
            Height.Text = Convert.ToString(result);
            HeightLabelUnits.Content = "(Cm)";
        }

        private void RadioLbs_Checked(object sender, RoutedEventArgs e)
        {
            if (Weight.Text != "")
            {
                double.TryParse(Weight.Text, out double weight);
                double result = weight * 2.205;
                Weight.Text = Convert.ToString(result);
                WeightLabelUnits.Content = "(lbs)";
            }
        }

        private void RadioKg_Checked(object sender, RoutedEventArgs e)
        {
            double.TryParse(Weight.Text, out double weight);
            double result = weight / 2.205;
            Weight.Text = Convert.ToString(result);
            WeightLabelUnits.Content = "(Kg)";
        }

        #endregion

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Height.Text = "";
            Weight.Text = "";
            RadioInch.IsChecked = true;
            RadioCm.IsChecked = false;
            RadioLbs.IsChecked = true;
            RadioKg.IsChecked = false;
            HeightLabelUnits.Content = "(Inches)";
            WeightLabelUnits.Content = "(lbs)";
        }
    }
}
