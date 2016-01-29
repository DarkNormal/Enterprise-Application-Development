using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Models
{
    class PhoneEntry
    {
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }

        public PhoneEntry(string name, string phone, string address)
        {
            Name = name;
            PhoneNum = phone;
            Address = address;
        }
    }
}
