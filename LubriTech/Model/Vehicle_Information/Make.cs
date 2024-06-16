using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Vehicle_Information
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public Make(int Id, string name, string state)
        {
            this.Id = Id;
            this.Name = name;
            this.State = state;
        }

        public Make()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
