using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoDelivery.WebUI.Models
{
    public class AvailabilityUserViewModel
    {
        public List<Availability> Availabilities { get; set; }
        public ApplicationUser User { get; set; }
       // public Ticket ticket { get; set; }
    }
}