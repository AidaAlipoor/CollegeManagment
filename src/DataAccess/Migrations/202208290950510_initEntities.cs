namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class initEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers");
            AddColumn("dbo.Students", "StudentName", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Students", "StudentLastName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Teachers", "TeacherLastName", c => c.String(nullable: false, maxLength: 64));
            AddForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers", "Id");
            DropColumn("dbo.Students", "Name");
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Teachers", "Name");
            DropColumn("dbo.Teachers", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Teachers", "Name", c => c.String(nullable: false, maxLength: 64));
            AddColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 64));
            DropForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses");
            DropColumn("dbo.Teachers", "TeacherLastName");
            DropColumn("dbo.Teachers", "TeacherName");
            DropColumn("dbo.Students", "StudentLastName");
            DropColumn("dbo.Students", "StudentName");
            AddForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
