using LubriTech.Model.Vehicle_Information;
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

        public int? MainPhoneNum { get; set; }

        public int? AdditionalPhoneNum { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public Vehicle Vehicle { get; set; }

        public Client(string id, string fullName, int mainPhoneNum, int additionalPhoneNum, string email, string address, Vehicle vehicle)
        {
            Id = id;
            FullName = fullName;
            MainPhoneNum = mainPhoneNum;
            AdditionalPhoneNum = additionalPhoneNum;
            Email = email;
            Address = address;
            this.Vehicle = vehicle;
        }

        public Client(string id, string fullName, int? mainPhoneNum, int? additionalPhoneNum, string email, string address)
        {
            Id = id;
            FullName = fullName;
            MainPhoneNum = mainPhoneNum;
            AdditionalPhoneNum = additionalPhoneNum;
            Email = email;
            Address = address;
        }

        override
        public string ToString()
        {
            return FullName;
        }

    }
}
