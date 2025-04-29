using Dal.API;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class WorkerService : IWorker
    {
        DatabaseManager dbManager;
        public WorkerService(DatabaseManager dbManager)
        {
            this.dbManager = dbManager;
        }

        public void Create(Worker item)
        {
        
            dbManager.Workers.Add(item);
            dbManager.SaveChanges();
        }

        public void Delete(Worker item)
        {
            
            var workerToDelete = dbManager.Workers.FirstOrDefault(w => w.Id == item.Id);
            if (workerToDelete == null)
            {
                Console.WriteLine("worker not found");
                return;
            }
            dbManager.Workers.Remove(item);
            dbManager.SaveChanges();
        }

        public List<Worker> Read()
        {
            return dbManager.Workers.ToList();
        }

        public void Update(Worker item)
        {
            
            var workerToUpDate = dbManager.Workers.FirstOrDefault(w => w.Id == item.Id);
            if (workerToUpDate == null)
            {
                Console.WriteLine("Worker not found");
                return;
            }
            dbManager.Workers.Update(item);
            dbManager.SaveChanges();
        }
    }
}
