using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.WorkOrder_Information
{
    public class ObservationPhotos
    {
        public int Id { get; set; }
        public int ObservationId { get; set; }
        public byte[] Photo { get; set; }

        public ObservationPhotos() { }

        public ObservationPhotos(int id, int observationId, byte[] photo)
        {
            Id = id;
            ObservationId = observationId;
            Photo = photo;
        }

        public override string ToString()
        {
            return $"Id: {Id}, ObservationId: {ObservationId}, Photo: {Photo}";
        }
    }
}
