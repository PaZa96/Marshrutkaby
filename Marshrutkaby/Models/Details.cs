using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marshrutkaby.Models
{
    public class Details
    {
        public TransportCompanySet TransportCompany { get; set;}
        public CarSet Car { get; set; }
        public DriversSet Driver { get; set; }
        public RoutesSet Routes { get; set; }
        public DataRoutesSet DataRoutes { get; set; }
    }
}