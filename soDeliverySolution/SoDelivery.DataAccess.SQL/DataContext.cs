using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoDelivery.DataAccess.SQL
{
   public class DataContext: DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Account> Products { get; set; }
        public DbSet<Ticket> ProductCategories { get; set; }
        public DbSet<Contact> Baskets { get; set; }
        public DbSet<Availability> BasketItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
     //   public DbSet<Contact> Contacts { get; set; }

    }
}
