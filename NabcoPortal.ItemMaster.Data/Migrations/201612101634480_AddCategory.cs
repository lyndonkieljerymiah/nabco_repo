namespace NabcoPortal.ItemMaster.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Master.Items");

            CreateTable(
                "Master.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("Master.Items", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("Master.Items", "CategoryId");
            AddForeignKey("Master.Items", "CategoryId", "Master.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Master.Items", "CategoryId", "Master.Categories");
            DropIndex("Master.Items", new[] { "CategoryId" });
            DropColumn("Master.Items", "CategoryId");
            DropTable("Master.Categories");
        }
    }
}
