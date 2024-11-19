using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesWpfApp
{
    public class Account<T> : IAccount<T>
    {
        public T Type { get; private set; }
        public decimal Balance { get; private set; }

        public Account(T type, decimal initialBalance = 0)
        {
            Type = type;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма должна быть положительной.");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance) throw new InvalidOperationException("Недостаточно средств.");
            Balance -= amount;
        }

        public override string ToString() => $"{Type} — Баланс: {Balance:C}";
    }
}
