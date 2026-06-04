using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Interfaces;

namespace TH.CONF.Options
{
    public class BaseConfiguration<T>: IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            // Base configuration for all entities can be defined here
            // For example, you can set a default schema or common properties
            // builder.ToTable("DefaultSchema." + typeof(T).Name);
        }
    }
}
