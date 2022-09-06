namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configurationsUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Grades", "TeacherCourse_Id", "dbo.TeacherCourses");
            DropForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Grades", "Students_Id", "dbo.Students");
            DropIndex("dbo.TeacherCourses", new[] { "Course_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_Id" });
            DropIndex("dbo.Grades", new[] { "Students_Id" });
            DropIndex("dbo.Grades", new[] { "TeacherCourse_Id" });
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false, maxLength: 214));
            AlterColumn("dbo.TeacherCourses", "Course_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TeacherCourses", "Teacher_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Grades", "Students_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Grades", "TeacherCourse_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 64));
            CreateIndex("dbo.TeacherCourses", "Course_Id");
            CreateIndex("dbo.TeacherCourses", "Teacher_Id");
            CreateIndex("dbo.Grades", "Students_Id");
            CreateIndex("dbo.Grades", "TeacherCourse_Id");
            AddForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Grades", "TeacherCourse_Id", "dbo.TeacherCourses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Grades", "Students_Id", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Grades", "TeacherCourse_Id", "dbo.TeacherCourses");
            DropForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "TeacherCourse_Id" });
            DropIndex("dbo.Grades", new[] { "Students_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Course_Id" });
            AlterColumn("dbo.Teachers", "LastName", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Grades", "TeacherCourse_Id", c => c.Int());
            AlterColumn("dbo.Grades", "Students_Id", c => c.Int());
            AlterColumn("dbo.TeacherCourses", "Teacher_Id", c => c.Int());
            AlterColumn("dbo.TeacherCourses", "Course_Id", c => c.Int());
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
            CreateIndex("dbo.Grades", "TeacherCourse_Id");
            CreateIndex("dbo.Grades", "Students_Id");
            CreateIndex("dbo.TeacherCourses", "Teacher_Id");
            CreateIndex("dbo.TeacherCourses", "Course_Id");
            AddForeignKey("dbo.Grades", "Students_Id", "dbo.Students", "Id");
            AddForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Grades", "TeacherCourse_Id", "dbo.TeacherCourses", "Id");
            AddForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
