using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adaOrderingSys.business_objects
{
    class customer
    {
        private byte custID { get; set; }
        private string name  { get; set; }
        private string address  { get; set; }
        private string telephone  { get; set; } 
        private string contactPerson  { get; set; }

        public customer() { }
    }
}
