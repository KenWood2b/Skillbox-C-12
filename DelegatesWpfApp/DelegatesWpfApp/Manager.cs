using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DelegatesWpfApp
{
    public class Manager : Worker
    {

        public override void EditClient(Client client, string field, string newValue)
        {
            switch (field)
            {
                case "Name":
                    client.Name = newValue;
                    break;
                case "PhoneNumber":
                    client.PhoneNumber = newValue;
                    break;
                default:
                    Console.WriteLine($"Поле {field} успешно обновлено.");
                    break;
            }
        }
    }
}
