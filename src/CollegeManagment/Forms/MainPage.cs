using System;
using System.Windows.Forms;

namespace CollegeManagment.UI.Forms
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private void TeacherButton_Click(object sender, EventArgs e)
        {
            var teachers = new TeacherForm();
            teachers.Show();
            this.Hide();
        }

        private void StudentButton_Click(object sender, EventArgs e)
        {
            var students = new StudentsForm();
            students.Show();
            this.Hide();
        }

        private void GradeButton_Click(object sender, EventArgs e)
        {
            var grades = new GradeForm();
            grades.Show();
            this.Hide();
        }

        private void CoursesButton_Click(object sender, EventArgs e)
        {
            var courses = new CourseForm();
            courses.Show();
            this.Hide();
        }

        private void TeacherCoursesButton_Click(object sender, EventArgs e)
        {
            var teacherCourses= new TeacherCourseForm();
            teacherCourses.Show();
            this.Hide();
        }
    }
}
