using BL.API;
using Dal.API;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Modeles
{
    public class CustomerAppointment { 
        public int Id { get; set; }
        public string DoctorsName { get; set; }
        public DateTime AppointmentsTime { get; set; }
        public int AppointmentsDuration { get; set; }

        
    }
}
