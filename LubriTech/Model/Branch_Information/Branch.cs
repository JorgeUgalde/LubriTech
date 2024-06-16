using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Branch_Information
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Branch() { }

        public Branch(int id, string name, string address, string phone, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
        }

        public Branch(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        override
        public string ToString()
        {
            return "Id: " + Id + "\nNombre: " + Name + "\nDirección: " + Address + "\nTeléfono: " + Phone + "\nCorreo: " + Email;
        }
    }
}
