using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoDelivery.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        //Underline DB to check DB conectionstrings
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Driver> driver { get; set; }
      
    }
}
