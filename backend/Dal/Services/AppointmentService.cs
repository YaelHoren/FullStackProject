using Dal.API;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class AppointmentService : IAppointment
    {
        DatabaseManager dbManager;
        public AppointmentService(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public void Create(Appointment item)
        {
          
            dbManager.Appointments.Add(item);
            dbManager.SaveChanges();
        }

        public void Delete(Appointment item)
        {
       
            var appointmentToDelete = dbManager.Appointments.FirstOrDefault(a => a.Id == item.Id);
            if (appointmentToDelete == null)
            {
                Console.WriteLine("appointment not found");
                return;
            }
            dbManager.Appointments.Remove(item);
            dbManager.SaveChanges();
        }

        public List<Appointment> Read()
        {
            return dbManager.Appointments.ToList();
        }

        public void Update(Appointment item)
        {
           
            var appointmentToUpDate = dbManager.Appointments.FirstOrDefault(a => a.Id == item.Id);
            if (appointmentToUpDate == null)
            {
                Console.WriteLine("appointment not found");
                return;
            }
            dbManager.Appointments.Update(item);
            dbManager.SaveChanges();
        }
        public List<Appointment> GetAppointmentsByCustomerId(int customerId)
        {
            return dbManager.Appointments.Where(a => a.CustomerId == customerId).ToList();
        }
    }
}
