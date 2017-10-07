using Intellectus_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Intellectus_mvc
{
    public class IntellectusDbContext : DbContext
    {
        public IntellectusDbContext() : base(@"Data Source = DESKTOP-5MR17K6; Initial Catalog = IntellectusDbmvc; Integrated Security = True")
        {

        }
        public DbSet<Company> Companies { get; set; }

    }
}