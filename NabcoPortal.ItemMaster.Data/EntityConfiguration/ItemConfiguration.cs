using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ItemMaster.Data.EntityConfiguration
{
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {

        public ItemConfiguration()
        {
            this.Property(i => i.Name)
                .HasMaxLength(150)
                .IsRequired();

            this.Property(i => i.ModelNo)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(i => i.FinishingCode)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(i => i.UOM)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
