using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesWpfApp
{
    public class Client : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _phoneNumber;
        private List<IAccount<string>> _accounts;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public List<IAccount<string>> Accounts
        {
            get => _accounts;
            private set
            {
                _accounts = value;
                OnPropertyChanged();
            }
        }

        public Client(int id, string name, string phoneNumber = "")
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Accounts = new List<IAccount<string>>();
        }

        public void AddAccount(IAccount<string> account)
        {
            if (Accounts.Exists(a => a.Type == account.Type))
                throw new InvalidOperationException($"У клиента уже есть счёт типа {account.Type}.");

            Accounts.Add(account);

            // Уведомляем интерфейс об изменении списка счетов
            OnPropertyChanged(nameof(Accounts));
        }

        public override string ToString() => $"{Name} (ID: {Id}) — Телефон: {PhoneNumber}, Счета: {Accounts.Count}";

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
