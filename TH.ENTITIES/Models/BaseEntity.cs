using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Interfaces;

namespace TH.ENTITIES.Models
{
    public abstract class BaseEntity:IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public DataStatus Status { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            Status = DataStatus.Inserted;
        }
    }
}
