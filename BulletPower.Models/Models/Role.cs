using BulletPower.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletPower.Models
{
    public class Role : Entity
    {
        public string RoleName { get; set; }
        public string Desciprtion { get; set; }
        public virtual ICollection<User> Users{ get; set; }
    }
}
