namespace Lourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameInStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Username", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Username");
        }
    }
}
