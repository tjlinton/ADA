using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adaOrderingSys.business_objects
{
    class order
    {
        private int orderID { get; set; }
        private int custID { get; set; }
        private string truckNo { get; set; }
        private DateTime orderDate { get; set; }

        public order() { }
    }
}
