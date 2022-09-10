
using BusinessLogic.Repositories;
using DataAccess.Entities;
using DataAccess.EntitiesConfiguration;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;
using CourseEntity = DataAccess.Entities.Course;

namespace CollegeManagment.UI.Forms
{
    public partial class CourseForm : BaseForm
    {
        private readonly IRepository<CourseEntity> _courseRepository = new CourseRepository();
        public CourseForm()
        {
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddAsync(CourseNameTextBox.Text);
                await _courseRepository.SaveAsync();
                await RefreshDataGridViewAsync();
                MessageBox.Show(MessageProvider.ItemAddedSuccesfully);
            }
            catch (Exception)
            {

                ShowErrorMessageBox(MessageProvider.InvalidFields);
            }
        }
        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                await DeleteAsync();
                await _courseRepository.SaveAsync();

                await RefreshDataGridViewAsync();
                MessageBox.Show(MessageProvider.ItemIsDeleted);
            }
            catch (Exception)
            {
                ShowErrorMessageBox(MessageProvider.ItemIsNotDeletable);
            }


        }
        private async void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateAsync();
                await _courseRepository.SaveAsync();
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

        //private async Task CheckIsCourseDeletableAsync()
        //{
        //    var selectedCourseId = CoursesDataGridView.GetId();

        //    var isCourseUsedAtTeacherCourses = await _dbContext.TeacherCourses
        //        .Include(tc => tc.Course)
        //        .AnyAsync(tc => tc.Course.Id == selectedCourseId);

        //    if (isCourseUsedAtTeacherCourses)
        //        throw new Exception(MessageProvider.ItemIsNotDeletable);
        //}

        //private bool IsCourseValid() => !IsCourseNameEmpty() && IsLetter();
        //private bool IsCourseNameEmpty() => string.IsNullOrEmpty(CourseNameTextBox.Text);
        //private bool IsLetter() => CourseNameTextBox.Text.Count(c => char.IsLetter(c)) == CourseNameTextBox.Text.Length;


        private void AddAsync(string courseName)
        {
            //if (!IsCourseValid())
            //    throw new Exception();

            _courseRepository.Add(new CourseEntity { CourseName = courseName });
        }
        private async Task RefreshDataGridViewAsync()
        {
            CoursesDataGridView.Rows.Clear();

            var courses = await _courseRepository.GetAsync();

            foreach (var course in courses)
                CoursesDataGridView.Rows
                    .Add(course.Id, course.CourseName);
        }
        private void AddColumnsToDataGridView()
        {
            var idColumn = nameof(CourseEntity.Id);
            var nameColumn = nameof(CourseEntity.CourseName);

            var isReadOnly = true;

            CoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = idColumn, ReadOnly = isReadOnly, Visible = false });
            CoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = nameColumn, ReadOnly = isReadOnly });
        }
        private async Task DeleteAsync()
        {
            var deletedId = CoursesDataGridView.GetId();
           await _courseRepository.DeleteAsync(deletedId);

        }
        private async Task UpdateAsync()
        {
            //if (!IsCourseValid())
            //    throw new Exception();

            var selectedRowId = CoursesDataGridView.GetId();
            var newData = await _courseRepository.GetAsync(selectedRowId);

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
