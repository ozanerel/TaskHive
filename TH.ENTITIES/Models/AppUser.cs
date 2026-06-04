using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Interfaces;

namespace TH.ENTITIES.Models
{
    public class AppUser:IdentityUser<int>,IEntity
    {
        public Guid ActivationCode { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime? UpdatedDate { get; set;}
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        //Relational Properties
        public virtual AppUserProfile AppUserProfile { get; set; }
    }
}
