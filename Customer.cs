using System;
using System.Collections.Generic;
using System.Text;

namespace DispurWirelessCommunicationManagment
{
    class Customer
    {
        private int registrationId;
        private string name;
        private string address;
        private string mailId;
        private long mob;
        private string password;

        public int RegistrationId { get => registrationId; set => registrationId = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string MailId { get => mailId; set => mailId = value; }
        public long Mob { get => mob; set => mob = value; }
        public string Password { get => password; set => password = value; }

        public Customer(string name, string address, string mailId, string password, long mob)
        {
            Globals.id++;
            this.registrationId = Globals.id;
            this.name = name;
            this.address = address;
            this.mailId = mailId;
            this.password = password;
            this.mob = mob;
        }
    }

    public static class Globals {
        public static int id = 100;
    }
}
