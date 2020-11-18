using System;
using System.Collections.Generic;
using System.Text;

namespace DispurWirelessCommunicationManagment
{
    class TarrifPlan
    {
        private int planId;
        private string name;
        private string type;
        private int tarrif;
        private int validity;
        private int rental;
        public int PlanId { get => planId; set => planId = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get =>type; set => type = value; }
        public int Tarrif { get => tarrif; set => tarrif = value; }
        public int Validity { get => validity; set => validity = value; }
        public int Rental { get => rental; set => rental = value; }

        public TarrifPlan(string name,string type,int tarrif,int validity,int rental)
        {
            Globals.pId++;
            this.planId = Globals.pId;
            this.name = name;
            this.type = type;
            this.tarrif = tarrif;
            this.validity = validity;
            this.rental = rental;
        }
    }

}
