using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoDelivery.Core.Models
{
    public class Driver:Person
    {
        public string DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string LicenseImg { get; set; }
        public string LicenseNumber { get; set; }
        public bool Vehicle { get; set; } = false;
        public string CarType { get; set; }
        public string AccountType { get; set; }
    }
}
