namespace NabcoPortal.ItemMaster.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveItemCode : DbMigration
    {
        public override void Up()
        {
            DropColumn("Master.Items", "Code");
        }
        
        public override void Down()
        {
            AddColumn("Master.Items", "Code", c => c.String());
        }
    }
}
