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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace исип_122_соловьева_пр1
{
    public partial class MainWindow : Window
    {
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

            // Вычисление функции (пример для sh(x))
            double result = 0;
            if (ShRadioButton.IsChecked == true)
            {
                result = Math.Sinh(x); // Гиперболический синус
            }
            else if (SquareRadioButton.IsChecked == true)
            {
                result = Math.Pow(x, 2); // Квадрат числа
            }
            else if (ExpRadioButton.IsChecked == true)
            {
                result = Math.Exp(x); // Экспонента
            }
            else
            {
                MessageBox.Show("Выберите функцию для вычисления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Отображение результата
            ResultTextBox.Text = result.ToString("F2"); // Формат результата (2 знака после запятой)
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
