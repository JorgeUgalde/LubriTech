using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Supplier
{
    public class Supplier
    {

        private string id {  get; set; }
        private string name { get; set; }
        private string email {  get; set; }
        private int phone { get; set; }

        public Supplier(string id, string name, string email, int phone) {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }

        public string ToString()
        {
            return "Id: " + id + "\nName: " + name + "\nEmail: " + email + "\nPhone number: " + phone;
        }
    }
}
