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
        DatabaseManager dbManager;
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
        [HttpGet("check/{id}")]
        public IActionResult CheckCustomerById(int id)
        {
            var customer = blCustomer.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound(new { message = "הלקוח אינו קיים במערכת" });
            }

            return Ok(customer);
        }

    }
}
