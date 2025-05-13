using Dal;
using Dal.API;
using Dal.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Modeles;
using BL.API;
using BL;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IBLAppointment appointment;
       
        public AppointmentController(IBL bl) 
        { 
        appointment=bl.blAppointment;
        }
        [HttpGet]
        public ActionResult<List<Appointment>> GetAppointments() => appointment.Read();

        [HttpPost]
        public void CreateAppointment([FromBody] Appointment newAppointment)
        {
            appointment.Create(newAppointment);
        }

        [HttpPut]
        public void UpdateAppointment([FromBody] Appointment updatedAppointment)
        {
            appointment.Update(updatedAppointment);
        }
        [HttpDelete]
        public void DeleteAppointment([FromBody] Appointment deleteAppointment)
        {

            appointment.Delete(deleteAppointment);
        }

    }
}
