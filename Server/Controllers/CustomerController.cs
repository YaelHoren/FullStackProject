using BL.API;
using Dal.API;
using Dal.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomer customer;
        IBLCustomer blCustomer;

        public CustomerController(IBL bL)
        {
           //customer = dal.customer;
            blCustomer = bL.blCustomer;
        }
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers() => blCustomer.Read();

        [HttpPost]
        public void CreateCustomer([FromBody] Customer newCustomer) {
            blCustomer.Create(newCustomer);
        }

        [HttpPut]
        public void UpdateCustomer([FromBody] Customer updatedCustomer)
        {
            blCustomer.Update(updatedCustomer);
        }
        [HttpDelete]
        public void DeleteCustomer([FromBody] Customer deleteCustomer) {

            blCustomer.Delete(deleteCustomer);
        }
        [HttpGet("{id}")]
        public ActionResult<List<Appointment>> GetCustomerAppointmentsById(int id)
        {
            return blCustomer.GetAppointmentList(id);
        }

    }
}
