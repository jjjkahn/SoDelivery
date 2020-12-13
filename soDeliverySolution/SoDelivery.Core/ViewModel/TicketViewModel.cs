using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoDelivery.Core.ViewModel
{
    public class TicketViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public Customer Customer { get; set; }
    }
}
