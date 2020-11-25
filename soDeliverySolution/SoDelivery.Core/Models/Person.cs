using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoDelivery.Core.Models
{
    public abstract class Person
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public double Telephone { get; set; }
        public Person()
        {
            this.Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
