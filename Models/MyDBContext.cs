using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinksWebApplication.Models
{
    public class MyDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Link> Links { get; set; }
        public MyDBContext()
             : base("DefaultConnection")
        {
        }

        public static MyDBContext Create()
        {
            return new MyDBContext();
        }
    }
}