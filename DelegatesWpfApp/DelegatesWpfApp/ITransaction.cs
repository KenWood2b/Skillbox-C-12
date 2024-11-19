using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesWpfApp
{
    public interface ITransaction<in T>
    {
        void TransferFunds(T sender, Account<string> senderAccount, T receiver, Account<string> receiverAccount, decimal amount);
    }
}
