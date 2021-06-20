namespace Lourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigToAuthor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String());
        }
    }
}
