using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9
{
    public class Contact
    {
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public Contact(string name, string phone_Number)
        {
            Name = name;
            Phone_Number = phone_Number;
        }
    }
}
