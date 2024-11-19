using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DelegatesWpfApp
{
    public class Bank : ITransaction<Client>
    {
        public List<Client> Clients { get; private set; }

        public event Action<LogEntry> OnOperationPerformed;

        public Bank()
        {
            Clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            if (Clients.Exists(c => c.Id == client.Id))
                throw new InvalidOperationException("Клиент с таким ID уже существует.");
            Clients.Add(client);

            OnOperationPerformed?.Invoke(new LogEntry
            {
                Timestamp = DateTime.Now,
                Action = "Добавление клиента",
                PerformedBy = "Система",
                Details = $"Клиент {client.Name} добавлен"
            });
        }

        // Сохранение клиентов в файл
        public void SaveClientsToFile(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(Clients, options);
            File.WriteAllText(filePath, json);
        }

        // Загрузка клиентов из файла
        public void LoadClientsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Clients = JsonSerializer.Deserialize<List<Client>>(json) ?? new List<Client>();
            }
        }

        public void TransferFunds(Client sender, Account<string> senderAccount, Client receiver, Account<string> receiverAccount, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма перевода должна быть положительной.");
            senderAccount.Withdraw(amount);
            receiverAccount.Deposit(amount);

            OnOperationPerformed?.Invoke(new LogEntry
            {
                Timestamp = DateTime.Now,
                Action = "Перевод средств",
                PerformedBy = "Система",
                Details = $"От {sender.Name} к {receiver.Name}, сумма: {amount:C}"
            });
        }
    }
}
