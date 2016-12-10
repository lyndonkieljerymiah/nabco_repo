namespace NabcoPortal.ItemMaster.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemFields : DbMigration
    {
        public override void Up()
        {
            Sql("Delete FROM Master.Items");
            AddColumn("Master.Items", "ModelNo", c => c.String(nullable: false, maxLength: 50));
            AddColumn("Master.Items", "FinishingCode", c => c.String(nullable: false, maxLength: 50));
            AddColumn("Master.Items", "Composition", c => c.String());
            AddColumn("Master.Items", "UOM", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("Master.Items", "Name", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("Master.Items", "Name", c => c.String());
            DropColumn("Master.Items", "UOM");
            DropColumn("Master.Items", "Composition");
            DropColumn("Master.Items", "FinishingCode");
            DropColumn("Master.Items", "ModelNo");
        }
    }
}
