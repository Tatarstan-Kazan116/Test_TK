using System;
using System.Windows;
using TK.Logic;

namespace TK
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            // Валидация ввода через double.TryParse
            if (!double.TryParse(txtInput.Text, out double input))
            {
                MessageBox.Show("Ошибка: введите корректное числовое значение.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtResult.Text = string.Empty;
                return;
            }

            try
            {
                double result = 0;
                // Выбор метода логики в зависимости от индекса ComboBox
                switch (cmbConversionType.SelectedIndex)
                {
                    case 0: result = ConverterLogic.ConvertMetersToKilometers(input); break;
                    case 1: result = ConverterLogic.ConvertKilometersToMeters(input); break;
                    case 2: result = ConverterLogic.ConvertCelsiusToFahrenheit(input); break;
                    case 3: result = ConverterLogic.ConvertFahrenheitToCelsius(input); break;
                    default:
                        MessageBox.Show("Ошибка: не выбран тип конвертации.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                // Вывод результата
                txtResult.Text = $"Результат: {result:F4}";
            }
            catch (ArgumentException ex)
            {
                // Обработка исключений из логики через MessageBox
                MessageBox.Show($"Ошибка данных: {ex.Message}", "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Error);
                txtResult.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "Системная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}