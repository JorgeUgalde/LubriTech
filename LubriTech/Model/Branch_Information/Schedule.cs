using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LubriTech.Model.Branch_Information
{
    public class Schedule
    {
        /// <summary>
        ///  Contains the Schedule ID
        /// </summary>
        public int ScheduleID { get; set; }

        /// <summary>
        ///  Instance of the Branch class
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// Contains the Title of the Schedule
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Indicate the start working hour 
        /// </summary>
        public TimeSpan StartHour { get; set; }

        /// <summary>
        /// Indicate the end working hour
        /// </summary>
        public TimeSpan EndHour { get; set; }

        /// <summary>
        /// Specify the duration of the appointment
        /// </summary>
        public int appointmentDuration { get; set; }

        /// <summary>
        /// Constructor for the Schedule class
        /// </summary>
        /// <param name="ScheduleID"></param>
        /// <param name="Branch"></param>
        /// <param name="Title"></param>
        /// <param name="StartHour"></param>
        /// <param name="EndHour"></param>
        /// <param name="appointmentDuration"></param>
        public Schedule(int ScheduleID, Branch Branch, string Title, TimeSpan StartHour, TimeSpan EndHour, int appointmentDuration)
        {
            this.ScheduleID = ScheduleID;
            this.Branch = Branch;
            this.Title = Title;
            this.StartHour = StartHour;
            this.EndHour = EndHour;
            this.appointmentDuration = appointmentDuration;
        }

        /// <summary>
        /// Empty constructor for the Schedule class
        /// </summary>
        public Schedule()
        {
        }

        /// <summary>
        /// Override the ToString method
        /// </summary>
        /// <returns> Title of the Schedule </returns>
        public override string ToString()
        {
            return Title;
        }
    }
}
