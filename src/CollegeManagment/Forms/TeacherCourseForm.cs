using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Entities;
using UI.ComboBoxItems;
using CollegeManagment.UI.Extensions;
using UI.Extensions;
using TeacherEntity = DataAccess.Entities.Teacher;
using TeacherCourseEntity = DataAccess.Entities.TeacherCourse;
using CourseEntity = DataAccess.Entities.Course;
using BusinessLogic.Repositories;
using DataAccess.EntitiesConfiguration;

namespace CollegeManagment.UI.Forms
{
    public partial class TeacherCourseForm : BaseForm
    {
        private readonly IRepository<TeacherCourseEntity> _teacherCourseRepository;
        //private readonly IRepository<CourseEntity> _courseRepository;
        private readonly IRepository<TeacherEntity> _teacherRepository;
        public TeacherCourseForm() : base()
        {
            InitializeComponent();
            _teacherCourseRepository = new TeacherCourseRepository(new CollegeManagmentContext());
            _teacherRepository = new TeacherRepository(_dbContext);
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                await InsertTeacherCourseAsync();
                await SaveChangesAsync();
                await RefreshDataGridViewAsync(); 

                MessageBox.Show(MessageProvider.ItemAddedSuccesfully);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), MessageProvider.InvalidFields , MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message.ToString(), MessageProvider.ExceptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private async Task InsertTeacherCourseAsync()
        {
            var teacher = await GetSelectedTeacherEntityAsync();
            var course = await GetSelectedCourseEntityAsync();

            InsertTeacherCourseAsync(teacher, course);

            return;
        }

        private void InsertTeacherCourseAsync(TeacherEntity selectedTeacher, CourseEntity course)
        {
            var addingTeacherCourse = new TeacherCourseEntity
            {
                Teacher = selectedTeacher,
                Course = course
            };

            _teacherCourseRepository.Add(addingTeacherCourse);
        }

        private async Task<CourseEntity> GetSelectedCourseEntityAsync()
        {
            var selectedCourseId = CoursesComboBox.GetSelectedItem().Value;

            return await _dbContext.Courses.FindAsync(selectedCourseId);
        }

        private async Task<TeacherEntity> GetSelectedTeacherEntityAsync()
        {
            var selectedTeacherId = teacherComboBox.GetSelectedItem().Value;

            return await _teacherRepository.GetAsync((int)selectedTeacherId);
        }

        private async Task DeleteAsync()
        {
            if (teacherCoursesDataGridView.SelectedRows.Count < 0)
                throw new Exception();

            var teacherId = teacherCoursesDataGridView.GetId();
            var teacher = await _dbContext.TeacherCourses.FindAsync(teacherId);

            _dbContext.TeacherCourses.Remove(teacher);
        }

        private async Task EditAsync()
        {
            var selectedTeacherCourseId = teacherCoursesDataGridView.GetId();
            var selectedTeacherCourse = await _dbContext.TeacherCourses.FindAsync(selectedTeacherCourseId);


            var selectedTeacherId = teacherComboBox.GetSelectedItem().Value;
            var selectedTeacher = await _dbContext.Teachers.FindAsync(selectedTeacherId);

            var selectedCourseId = CoursesComboBox.GetSelectedItem().Value;
            var selectedCourse = await _dbContext.Courses.FindAsync(selectedCourseId);


            selectedTeacherCourse.Teacher = selectedTeacher;
            selectedTeacherCourse.Course = selectedCourse;
        }

        private async Task RefreshDataGridViewAsync()
        {
            teacherCoursesDataGridView.Rows.Clear();

            var items = await _dbContext.TeacherCourses.ToArrayAsync();

            foreach (var item in items)
                teacherCoursesDataGridView.Rows
                    .Add(item.Id, item.Teacher.TeacherName, item.Teacher.TeacherLastName, item.Course.CourseName);
        }

        private void AddColumnsToDataGridView()
        {
            var idColumn = nameof(TeacherCourse.Id);
            var nameColumn = nameof(TeacherCourse.Teacher.TeacherName);
            var lastNameColumn = nameof(TeacherCourse.Teacher.TeacherLastName);
            var courseNameColumn = nameof(TeacherCourse.Course.CourseName);

            var isReadOnly = true;

            teacherCoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = idColumn, ReadOnly = isReadOnly, Visible = false });
            teacherCoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = nameColumn, ReadOnly = isReadOnly });
            teacherCoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = lastNameColumn, ReadOnly = isReadOnly });
            teacherCoursesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = courseNameColumn, ReadOnly = isReadOnly });
        }



        private async Task LoadDataInTeacherComboBoxAsync()
        {
            var teachers = await _dbContext.Teachers.ToArrayAsync();

            foreach (var teacher in teachers)
                teacherComboBox.Items.Add(
                    new ComboBoxItem
                    {
                        Text = teacher.TeacherName + " " + teacher.TeacherLastName,
                        Value = teacher.Id
                    });

            if (teacherComboBox.Items.Count > 0)
                teacherComboBox.SelectedIndex = 0;
        }

        private async Task LoadDataInCoursesComboBoxAsync()
        {
            var courses = await _dbContext.Courses.ToArrayAsync();

            foreach (var course in courses)
                CoursesComboBox.Items.Add(
                    new ComboBoxItem
                    {
                        Text = course.CourseName,
                        Value = course.Id
                    });
            if (CoursesComboBox.Items.Count > 0)
                CoursesComboBox.SelectedIndex = 0;
        }

        private async void TeacherCourses_Load(object sender, EventArgs e)
        {
            await LoadDataInTeacherComboBoxAsync();
            await LoadDataInCoursesComboBoxAsync();
            AddColumnsToDataGridView();
            await RefreshDataGridViewAsync();
        }

        private void teacherCoursesDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var teacherName = teacherCoursesDataGridView.CurrentRow.Cells[1].Value;
            var teacherLastName = teacherCoursesDataGridView.CurrentRow.Cells[2].Value;
            var courseName = teacherCoursesDataGridView.CurrentRow.Cells[3].Value;
            teacherComboBox.Text = $"{teacherName} {teacherLastName}";
            CoursesComboBox.Text = courseName.ToString();
        }

        private void backPictureBox_Click(object sender, EventArgs e)
        {
            var mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }
    }
}
