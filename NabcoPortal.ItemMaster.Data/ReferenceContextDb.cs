using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabcoPortal.ItemMaster.Domain.Model;

namespace NabcoPortal.ItemMaster.Data
{
    public class ReferenceContextDb : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ReferenceContextDb() : base("NabcoDbConnection")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().ToTable("ActiveItemView", "dbo");
        }
    }
}
