using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.models;

namespace Dal.API
{
    public interface IWorker:Icrud<Worker>
    {
        public Worker GetWorkerById(int id);
      
    }
}
