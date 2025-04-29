using Dal.API;
using Dal.models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager:IDal
    {

        public ICustomer customer { get; }
        public IWorker worker { get; }
        public IAppointment appointment { get; }
       

        public DalManager()
        {
           
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DatabaseManager>();

            services.AddSingleton<ICustomer, CustomerService>();
            services.AddSingleton<IAppointment, AppointmentService>();
            services.AddSingleton<IWorker, WorkerService>();
           

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            //worker = serviceProvider.GetService<WorkerService>();
            //appointment = serviceProvider.GetService<AppointmentService>();
            customer = serviceProvider.GetService<ICustomer>();
            appointment = serviceProvider.GetService<IAppointment>();
            worker= serviceProvider.GetService<IWorker>();
        }
            

        }
    }
