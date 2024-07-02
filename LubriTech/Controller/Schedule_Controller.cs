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
        public List<Schedule> loadAll(int? branch)
        {
            return new Schedule_Model().loadAllSchedules(branch);
        }

        public Schedule get(int id , int? branchID)
        {
            return new Schedule_Model().getSchedule(id, branchID);
        }

        public bool UpSert(Schedule schedule)
        {   
            return new Schedule_Model().Upsert(schedule);
        }
    }
}
