using LubriTech.Model.Branch_Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Controller
{
    public class Schedule_Controller
    {
        public List<Schedule> loadAll()
        {
            return new Schedule_Model().loadAllSchedules();
        }

        public Schedule get(int id)
        {
            return new Schedule_Model().getSchedule(id);
        }

        public bool UpSert(Schedule schedule)
        {   
            return new Schedule_Model().Upsert(schedule);
        }
    }
}
