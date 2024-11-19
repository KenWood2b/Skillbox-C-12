using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DelegatesWpfApp
{
    public class Consultant : Worker
    {

        public override void EditClient(Client client, string field, string newValue)
        {
            if (field == "PhoneNumber")
            {
                client.PhoneNumber = newValue;
                Console.WriteLine("Номер телефона успешно изменен.");
            }
            else
            {
                Console.WriteLine("Консультант может изменять только номер телефона.");
            }
        }
    }
}
