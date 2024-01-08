using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace flightbooking_project.Models
{
    public class ContextCS : DbContext
    {
        public ContextCS() : base("cs")
        {

        }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> UserLogins { get; set; }
        public DbSet<AirplaneInfo> PlaneInfo { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }

    }
}