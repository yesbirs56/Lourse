namespace Lourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigToStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
