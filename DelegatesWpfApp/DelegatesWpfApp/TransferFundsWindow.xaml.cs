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

namespace DelegatesWpfApp
{
    /// <summary>
    /// Логика взаимодействия для TransferFundsWindow.xaml
    /// </summary>
    public partial class TransferFundsWindow : Window
    {
        private Bank _bank;

        public TransferFundsWindow(Bank bank)
        {
            InitializeComponent();
            _bank = bank;

            // Заполняем ComboBox клиентами
            SenderComboBox.ItemsSource = _bank.Clients;
            ReceiverComboBox.ItemsSource = _bank.Clients;
        }

        private void SenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SenderComboBox.SelectedItem is Client selectedClient)
            {
                SenderAccountComboBox.ItemsSource = selectedClient.Accounts;
            }
        }

        private void ReceiverComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReceiverComboBox.SelectedItem is Client selectedClient)
            {
                ReceiverAccountComboBox.ItemsSource = selectedClient.Accounts;
            }
        }

        private void TransferFundsButton_Click(object sender, RoutedEventArgs e)
        {
            if (SenderComboBox.SelectedItem is Client senderClient &&
                ReceiverComboBox.SelectedItem is Client receiverClient &&
                SenderAccountComboBox.SelectedItem is Account<string> senderAccount &&
                ReceiverAccountComboBox.SelectedItem is Account<string> receiverAccount &&
                decimal.TryParse(AmountTextBox.Text, out decimal amount))
            {
                try
                {
                    _bank.TransferFunds(senderClient, senderAccount, receiverClient, receiverAccount, amount);
                    MessageBox.Show("Перевод успешно выполнен.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }
    }
}
