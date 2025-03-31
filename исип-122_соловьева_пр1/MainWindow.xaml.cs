using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace исип_122_соловьева_пр1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка заполненности поля ввода
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                MessageBox.Show("Введите значение x!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка на корректность ввода (число)
            if (!double.TryParse(InputTextBox.Text, out double x))
            {
                MessageBox.Show("Значение x должно быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Вычисление функции
            double result = 0;
            if (ShRadioButton.IsChecked == true)
            {
                result = Math.Sinh(x);
            }
            else if (SquareRadioButton.IsChecked == true)
            {
                result = Math.Pow(x, 2);
            }
            else if (ExpRadioButton.IsChecked == true)
            {
                result = Math.Exp(x);
            }
            else
            {
                MessageBox.Show("Выберите функцию для вычисления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Отображение результата
            ResultTextBox.Text = result.ToString("F2");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Очистка всех полей
            InputTextBox.Text = string.Empty;
            ResultTextBox.Text = string.Empty;

            // Сброс выбора радиокнопок
            ShRadioButton.IsChecked = false;
            SquareRadioButton.IsChecked = false;
            ExpRadioButton.IsChecked = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // Отменяем закрытие окна
            }
        }
    }
}
