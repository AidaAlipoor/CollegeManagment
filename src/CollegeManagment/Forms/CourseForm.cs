
using DataAccess.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace CollegeManagment.UI.Forms
{
    public partial class CourseForm : BaseForm
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddAsync(CourseNameTextBox.Text);
                await SaveChangesAsync();

                await RefreshDataGridViewAsync();
                MessageBox.Show(MessageProvider.ItemAddedSuccesfully);
            }
            catch (Exception ex)
            {

                ShowErrorMessageBox(ex.Message);
            }
        }
        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                await DeleteAsync();
                await SaveChangesAsync();

                await RefreshDataGridViewAsync();
                MessageBox.Show(MessageProvider.ItemIsDeleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), MessageProvider.ItemIsNotDeletable, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private async void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                await EditAsync();
                await SaveChangesAsync();
                await RefreshDataGridViewAsync();
                MessageBox.Show(MessageProvider.ItemIsEdited);
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex.Message);
            }
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            var mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }

        private async Task CheckIsCourseDeletableAsync()
        {
            var selectedCourseId = CoursesDataGridView.GetId();

            var isCourseUsedAtTeacherCourses = await _dbContext.TeacherCourses
                .Include(tc => tc.Course)
                .AnyAsync(tc => tc.Course.Id == selectedCourseId);

            if (isCourseUsedAtTeacherCourses)
                throw new Exception(MessageProvider.ItemIsNotDeletable);
        }

        private bool IsCourseValid() => !IsCourseNameEmpty() && IsLetter();
        private bool IsCourseNameEmpty() => string.IsNullOrEmpty(CourseNameTextBox.Text);
        private bool IsLetter() => CourseNameTextBox.Text.Count(c => char.IsLetter(c)) == CourseNameTextBox.Text.Length;


        private void AddAsync(string courseName)
        {
            if (!IsCourseValid())
                throw new Exception();

            _dbContext.Courses.Add(new Course { CourseName = courseName });
        }
        private async Task RefreshDataGridViewAsync()
        {
            CoursesDataGridView.Rows.Clear();

            var courses = await _dbContext.Courses.ToArrayAsync();

            foreach (var course in courses)
                CoursesDataGridView.Rows
                    .Add(course.Id, course.CourseName);
        }
        private void AddColumnsToDataGridView()
        {
            var idColumn = nameof(Course.Id);
            var nameColumn = nameof(Course.CourseName);

            var isReadOnly = true;

            CoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = idColumn, ReadOnly = isReadOnly, Visible = false });
            CoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = nameColumn, ReadOnly = isReadOnly });
        }
        private async Task DeleteAsync()
        {
            await CheckIsCourseDeletableAsync();

            var deletedId = CoursesDataGridView.GetId();
            var removeCourse = await _dbContext.Courses.FindAsync(deletedId);

            _dbContext.Courses.Remove(removeCourse);

        }
        private async Task EditAsync()
        {
            if (!IsCourseValid())
                throw new Exception();

            var selectedRowId = CoursesDataGridView.GetId();
            var newData = await _dbContext.Courses.FindAsync(selectedRowId);

            newData.CourseName = CourseNameTextBox.Text;

        }



        private async void Courses_Load(object sender, EventArgs e)
        {
            AddColumnsToDataGridView();
            await RefreshDataGridViewAsync();
        }
        private void CoursesDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string editedCourseName = CoursesDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                CourseNameTextBox.Text = editedCourseName;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("there is no row!", ex.Message);
            }
        }

    }
}
