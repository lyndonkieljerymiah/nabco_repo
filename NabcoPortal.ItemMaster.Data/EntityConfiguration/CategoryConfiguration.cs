using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ItemMaster.Data.EntityConfiguration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.Property(c => c.Name)
                .HasMaxLength(150)
                .IsRequired();

            this.HasMany(c => c.Items)
                .WithRequired();
        }
    }
}
