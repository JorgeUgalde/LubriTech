using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    public class Observation
    {
        public int Codigo { get; set; }
        public int WorkOrderId { get; set; }
        public string Description { get; set; }
        public string Photos { get; set; }

        public Observation() { }

        public Observation(int codigo, int workOrderId, string description, string photos)
        {
            this.Codigo = codigo;
            this.WorkOrderId = workOrderId;
            this.Description = description;
            this.Photos = photos;
        }

        public Observation(int codigo, string description, string photos)
        {
            this.Codigo = codigo;
            this.Description = description;
            this.Photos = photos;
        }

        override
        public string ToString()
        {
        return "Código: " + Codigo + "\nId de la orden de trabajo: " + WorkOrderId + "\nDescripción: " + Description + "\nFotos: " + Photos;
        }
    }
}
