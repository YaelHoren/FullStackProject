using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.API
{
    public interface IDal
    {
        public ICustomer customer { get;}
        public IAppointment appointment { get; }
        public IWorker worker { get; }
    }
}
