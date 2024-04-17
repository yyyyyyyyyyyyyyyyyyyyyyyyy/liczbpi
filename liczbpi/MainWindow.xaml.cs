using System;
using System.Windows;
using System.Windows.Controls;

namespace liczbpi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void obliczButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(promienTextBox.Text, out double promien) &&
              
                int.TryParse(punktyTextBox.Text, out int liczbaPunktow))
            {
                double punktyWewnatrzKola = 0;
                Random random = new Random();

                for (int i = 0; i < liczbaPunktow; i++)
                {
                    double x = random.NextDouble() * (2 * promien) - promien;
                    double y = random.NextDouble() * (2 * promien) - promien;

                    if (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(promien, 2))
                    {
                        punktyWewnatrzKola++;
                    }
                }

                double przyblizonaWartoscPi = (4 * punktyWewnatrzKola) / liczbaPunktow;
                piResultLabel.Content = $"Przybliżona wartość Pi: {przyblizonaWartoscPi}";
            }
            else
            {
                MessageBox.Show("Nie podałeś wszystkich danych", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
