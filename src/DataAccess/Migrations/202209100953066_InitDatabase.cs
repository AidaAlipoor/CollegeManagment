namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 214),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Course_Id = c.Int(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Students_Id = c.Int(nullable: false),
                        TeacherCourse_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Students_Id, cascadeDelete: true)
                .ForeignKey("dbo.TeacherCourses", t => t.TeacherCourse_Id, cascadeDelete: true)
                .Index(t => t.Students_Id)
                .Index(t => t.TeacherCourse_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 64),
                        StudentLastName = c.String(nullable: false, maxLength: 128),
                        IdNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false, maxLength: 64),
                        TeacherLastName = c.String(nullable: false, maxLength: 64),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCourses", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Grades", "TeacherCourse_Id", "dbo.TeacherCourses");
            DropForeignKey("dbo.Grades", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.TeacherCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "TeacherCourse_Id" });
            DropIndex("dbo.Grades", new[] { "Students_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherCourses", new[] { "Course_Id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Grades");
            DropTable("dbo.TeacherCourses");
            DropTable("dbo.Courses");
        }
    }
}
