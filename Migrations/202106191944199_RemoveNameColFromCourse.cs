namespace Lourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameColFromCourse : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
