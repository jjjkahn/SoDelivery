using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoDelivery.WebUI.Models
{
    public class TicketUserViewModel
    {
       public List<Ticket> Tickets { get; set; }
        public ApplicationUser User { get; set; }

    }
}