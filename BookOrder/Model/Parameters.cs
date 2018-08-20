using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookOrder.Model
{
    public class Parameters
    {
        public int PID { get; private set; }
        public string FunctionName { get; set; }
        public string Description { get; set; }

        public Parameters()
        {

        }
    }
}