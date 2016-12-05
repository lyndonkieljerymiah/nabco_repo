namespace NabcoPortal.ItemMaster.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Master.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Master.Items");
        }
    }
}
