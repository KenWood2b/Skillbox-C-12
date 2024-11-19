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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public int ClientId { get; private set; }
        public string ClientName { get; private set; }

        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IdTextBox.Text, out int id) && !string.IsNullOrEmpty(NameTextBox.Text))
            {
                ClientId = id;
                ClientName = NameTextBox.Text;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введите корректные данные.");
            }
        }
    }
}
