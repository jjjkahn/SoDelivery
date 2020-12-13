using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoDelivery.Core.ViewModel
{
    public class CustomerViewModel
    {
        public Customer  customer { get; set; }
        public Account AccountType { get; set; }
    }
}
