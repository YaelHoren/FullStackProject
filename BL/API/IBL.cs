using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.API
{
    public interface IBL
    {
        public IBLAppointment blAppointment { get; }
        public IBLCustomer blCustomer { get; }
        public IBLWorker blWorker { get; }
    }
}
