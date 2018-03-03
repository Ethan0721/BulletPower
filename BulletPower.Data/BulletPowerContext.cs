using BulletPower.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace BulletPower.Data
{
    

    public class BulletPowerContext : DbContext
    {
        public BulletPowerContext()
            : base("name=BulletPowerContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }   
}