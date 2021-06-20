namespace Lourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigurationToCourse : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentCourses", newName: "CourseStudents");
            DropPrimaryKey("dbo.CourseStudents");
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Courses", "Description", c => c.String(maxLength: 2000));
            AddPrimaryKey("dbo.CourseStudents", new[] { "Course_Id", "Student_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CourseStudents");
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AddPrimaryKey("dbo.CourseStudents", new[] { "Student_Id", "Course_Id" });
            RenameTable(name: "dbo.CourseStudents", newName: "StudentCourses");
        }
    }
}
