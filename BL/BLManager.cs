using Dal.API;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using BL.Services;
using BL.API;

namespace BL
{
    public class BLManager:IBL
    {
        IDal dal;
        public IBLAppointment blAppointment { get; }

        public IBLCustomer blCustomer { get; }

        public IBLWorker blWorker { get; }

        public BLManager() { 
        ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IBLCustomer,BLCustomerService>();
            services.AddSingleton<IBLAppointment, BLAppointmentService>();
            services.AddSingleton<IBLWorker, BLWorkerService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            blAppointment = serviceProvider.GetService<IBLAppointment>();
            blCustomer = serviceProvider.GetService<IBLCustomer>();
            blWorker = serviceProvider.GetService<IBLWorker>();
        }

        
    }
}
