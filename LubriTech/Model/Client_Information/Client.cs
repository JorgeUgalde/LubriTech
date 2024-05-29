using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Client_Information
{
    public class Client
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public int MainPhoneNum { get; set; }

        public int AdditionalPhoneNum { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public Client(string id, string fullName, int mainPhoneNum, int additionalPhoneNum, string email, string address)
        {
            this.Id = id;
            this.FullName = fullName;
            this.MainPhoneNum = mainPhoneNum;
            this.AdditionalPhoneNum = additionalPhoneNum;
            this.Email = email;
            this.Address = address;
        }


    }
}
