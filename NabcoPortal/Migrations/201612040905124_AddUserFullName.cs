namespace NabcoPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("User.Users", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("User.Users", "FullName");
        }
    }
}
