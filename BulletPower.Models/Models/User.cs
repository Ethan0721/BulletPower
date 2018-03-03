using BulletPower.Models.Common;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BulletPower.Models
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Role> Roles{ get; set; }
    }
}
