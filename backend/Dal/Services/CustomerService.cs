using Dal.API;
using Dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class CustomerService : ICustomer
    {
        DatabaseManager dbManager;
        public CustomerService(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public void Create(Customer item)
        {
            if (item == null)
            {
                Console.WriteLine("customer is empty");
                return;
            }
            dbManager.Customers.Add(item);
            dbManager.SaveChanges();
        }

        public void Delete(Customer item)
        {

            var customerToDelete = dbManager.Customers.Local.FirstOrDefault(c => c.Id == item.Id)
                                   ?? dbManager.Customers.FirstOrDefault(c => c.Id == item.Id);

            if (customerToDelete == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

          
            dbManager.Customers.Remove(customerToDelete);

            try
            {
                dbManager.SaveChanges();
                Console.WriteLine($"Customer with ID {item.Id} deleted successfully.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"An error occurred while deleting the customer: {ex.InnerException?.Message}");
            }
        }

        public List<Customer> Read()
        {
            return dbManager.Customers.ToList();
        }

        public void Update(Customer item)
        {
            

           
            var existingCustomer = dbManager.Customers.FirstOrDefault(c => c.Id == item.Id);

            if (existingCustomer == null)
            {
                Console.WriteLine($"Customer with ID {item.Id} not found.");
            }

        
            dbManager.Entry(existingCustomer).CurrentValues.SetValues(item);

            try
            {
                dbManager.SaveChanges();
                Console.WriteLine($"Customer with ID {item.Id} updated successfully.");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while updating the customer.");
            }
        }
        public Customer GetCustomerById(int id)
        {
            return dbManager.Customers.FirstOrDefault(c => c.Id == id);
        }

    }
}
