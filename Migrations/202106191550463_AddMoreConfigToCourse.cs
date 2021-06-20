namespace Lourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreConfigToCourse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 100));
        }
    }
}
