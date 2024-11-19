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
    /// Логика взаимодействия для ManageAccountsWindow.xaml
    /// </summary>
    public partial class ManageAccountsWindow : Window
    {
        private readonly Client client;

        public ManageAccountsWindow(Client client)
        {
            InitializeComponent();
            this.client = client;
            UpdateAccountsList();
        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string accountType = AccountTypeTextBox.Text.Trim();
                if (string.IsNullOrEmpty(accountType))
                {
                    MessageBox.Show("Укажите тип счёта.");
                    return;
                }

                if (!decimal.TryParse(InitialBalanceTextBox.Text.Trim(), out decimal initialBalance) || initialBalance < 0)
                {
                    MessageBox.Show("Укажите корректный начальный баланс.");
                    return;
                }

                // Создание нового счёта
                var newAccount = new Account<string>(accountType, initialBalance);

                // Добавление счёта в список
                client.AddAccount(newAccount);
                UpdateAccountsList();
                MessageBox.Show("Счёт успешно добавлен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void UpdateAccountsList()
        {
            AccountsListBox.ItemsSource = null;
            AccountsListBox.ItemsSource = client.Accounts;
        }
    }
}
