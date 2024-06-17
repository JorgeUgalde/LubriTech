using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Supplier_Information
{
    public class Supplier
    {

        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public long phone { get; set; }

        public Supplier(string id, string name, string email, long phone)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public Supplier() { }

        override
        public string ToString()
        {
            return "Id: " + id + "\nName: " + name + "\nEmail: " + email + "\nPhone number: " + phone;
        }
    }
}
