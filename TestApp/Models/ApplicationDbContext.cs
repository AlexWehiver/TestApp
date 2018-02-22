using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public ApplicationDbContext()
            : base("TestAppDataBase")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual bool SetModified(object entity)
        {
            if (entity != null)
            {
                Entry(entity).State = EntityState.Modified;
                return true;
            }
            else
                return false;

        }
    }
}