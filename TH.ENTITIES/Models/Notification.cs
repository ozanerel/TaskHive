using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.ENTITIES.Models
{
    public class Notification:BaseEntity
    {
        public string Message { get; set; }
        public bool IsRead { get; set; }



    }
}
