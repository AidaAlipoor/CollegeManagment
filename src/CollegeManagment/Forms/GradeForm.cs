using DataAccess.Entities;
using UI.ComboBoxItems;
using CollegeManagment.UI.Extensions;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;
using BusinessLogic.Repositories;
using TeacherCourseEntity = DataAccess.Entities.TeacherCourse;
using GradeEntity = DataAccess.Entities.Grade;
using StudentEntity = DataAccess.Entities.Student;
using DataAccess.EntitiesConfiguration;
using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.Repositories.TeacherCourse;
using BusinessLogic.Repositories.Grade;
using BusinessLogic.Repositories.Student;

namespace CollegeManagment.UI.Forms
{
    public partial class GradeForm : BaseForm
    {
        private readonly IRepository<GradeEntity> _gradeRepository;
        private readonly IRepository<TeacherCourseEntity> _teacherCourseRepository;
        private readonly IRepository<StudentEntity> _studentRepository;


        public GradeForm()
        {
            InitializeComponent();

            //TODO: should be fixed with ioc container
            //var dbContext = CollegeManagmentContext.GetInstance();

            //_teacherCourseRepository = new TeacherCourseRepository();
            //_gradeRepository = new GradeRepository();
            //_studentRepository = new StudentRepository();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                await InsertGradeAsync();
                await _gradeRepository.SaveAsync();
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
                await _gradeRepository.SaveAsync();
                await RefreshDataGridViewAsync();
                MessageBox.Show(MessageProvider.ItemIsDeleted);
            }
            catch (Exception)
            {
                MessageBox.Show(MessageProvider.ItemIsNotDeletable);
            }
        }
        private async void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                await UpdateAsync();
                await _gradeRepository.SaveAsync();

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


        //private bool IsGradeValid() => !IsGradeEmpty() && IsGradeValueValid();
        //private bool IsGradeEmpty() => string.IsNullOrEmpty(GradeTextBox.Text)
        //    && string.IsNullOrWhiteSpace(GradeTextBox.Text);
        //private bool IsGradeValueValid()     
        //{
        //    var score = GradeTextBox.Text;

        //    return int.TryParse(score, out _) && IntConvertor.ToInt(score) >= 0
        //        && IntConvertor.ToInt(score) <= Grade.ScoreLengthLimit;
        //}


        private void InsertGradeAsync(TeacherCourseEntity teacherCourse, StudentEntity student, int score)
        {
            //if (!IsGradeValid())
            //    throw new Exception();

            var addingTeacherCourse = new GradeEntity
            {
                TeacherCourse = teacherCourse,
                Students = student,
                Score = score,
            };

            _gradeRepository.Add(addingTeacherCourse);

        }

        private async Task InsertGradeAsync()
        {
            var teacherCourse = await GetSelectedTeacherCourseEntityAsync();
            var student = await GetSelectedStudentEntityAsync();
            var scoreValue = IntConvertor.ToInt(GradeTextBox.Text);

            InsertGradeAsync(teacherCourse, student, scoreValue);

            return;
        }

        private async Task<TeacherCourseEntity> GetSelectedTeacherCourseEntityAsync()
        {
            var selectedTeacherCourseId = teacherCoursesComboBox.GetSelectedItem().Value;

            return await _teacherCourseRepository.FetchAsync((int)selectedTeacherCourseId);
        }

        private async Task<StudentEntity> GetSelectedStudentEntityAsync()
        {
            var selectedStudentId = studentComboBox.GetSelectedItem().Value;

            return await _studentRepository.FetchAsync((int)selectedStudentId);
        }



        private async Task DeleteAsync()
        {
            if (GradesDataGridView.SelectedRows.Count < 0)
                throw new Exception();

            var deletedId = GradesDataGridView.GetId();
            await _gradeRepository.DeleteAsync(deletedId);
        }

        private async Task UpdateAsync()
        {
            var selectedGradeId = GradesDataGridView.GetId();
            var selectedGrade = await _gradeRepository.FetchAsync(selectedGradeId);


            var selectedTeachCourseId = teacherCoursesComboBox.GetSelectedItem().Value;
            var selectedTeacherCourse = await _teacherCourseRepository.FetchAsync((int)selectedTeachCourseId);

            var selectedStudentId = studentComboBox.GetSelectedItem().Value;
            var SelectedStudent = await _studentRepository.FetchAsync((int)selectedStudentId);


            selectedGrade.TeacherCourse = selectedTeacherCourse;
            selectedGrade.Students = SelectedStudent;
            selectedGrade.Score = IntConvertor.ToInt(GradeTextBox.Text);
        }

        private async Task RefreshDataGridViewAsync()
        {
            GradesDataGridView.Rows.Clear();

            var grade = await _gradeRepository.FetchAsync();

            foreach (var item in grade)
                GradesDataGridView.Rows
                    .Add(item.Id, item.TeacherCourse.Course.CourseName
                     , item.TeacherCourse.Teacher.TeacherName, item.TeacherCourse.Teacher.TeacherLastName
                     , item.Students.StudentName, item.Students.StudentLastName
                     , item.Score);
        }

        private void AddColumnToGridView()
        {
            var idColumn = nameof(GradeEntity.Id);
            var courseNameColumn = nameof(GradeEntity.TeacherCourse.Course.CourseName);
            var teacherNameColumn = nameof(GradeEntity.TeacherCourse.Teacher.TeacherName);
            var teacherLastNameColumn = nameof(GradeEntity.TeacherCourse.Teacher.TeacherLastName);
            var studentNameColumn = nameof(GradeEntity.Students.StudentName);
            var studentLastNameColumn = nameof(GradeEntity.Students.StudentLastName);
            var scoreColumn = nameof(GradeEntity.Score);

            var isReadOnly = true;

            GradesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = idColumn, ReadOnly = isReadOnly, Visible = false });
            GradesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = courseNameColumn, ReadOnly = isReadOnly });
            GradesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = teacherNameColumn, ReadOnly = isReadOnly });
            GradesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = teacherLastNameColumn, ReadOnly = isReadOnly });
            GradesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = studentNameColumn, ReadOnly = isReadOnly });
            GradesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = studentLastNameColumn, ReadOnly = isReadOnly });
            GradesDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = scoreColumn, ReadOnly = isReadOnly });
        }


        private async Task LoadDataInTeacherCoursesComboBoxAsync()
        {
            var teacherCourses = await _teacherCourseRepository.FetchAsync();

            foreach (var tc in teacherCourses)
                teacherCoursesComboBox.Items.Add(
                    new ComboBoxItem
                    {
                        Text = ($"{tc.Teacher.TeacherName} {tc.Teacher.TeacherLastName} {tc.Course.CourseName}"),
                        Value = tc.Id
                    });

            if (teacherCoursesComboBox.Items.Count > 0)
                teacherCoursesComboBox.SelectedIndex = 0;
        }

        private async Task LoadDataInStudentComboBoxAsync()
        {
            var students = await _studentRepository.FetchAsync();

            foreach (var student in students)
                studentComboBox.Items.Add(
                    new ComboBoxItem
                    {
                        Text = $"{student.StudentName} {student.StudentLastName}",
                        Value = student.Id
                    });

            if (studentComboBox.Items.Count > 0)
                studentComboBox.SelectedIndex = 0;
        }

        private async void Grades_Load(object sender, EventArgs e)
        {
            await LoadDataInTeacherCoursesComboBoxAsync();
            await LoadDataInStudentComboBoxAsync();
            AddColumnToGridView();
            await RefreshDataGridViewAsync();
        }

        private void GradesDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var courseName = GradesDataGridView.CurrentRow.Cells[1].Value;
            var teacherName = GradesDataGridView.CurrentRow.Cells[2].Value;
            var teacherLastName = GradesDataGridView.CurrentRow.Cells[3].Value;
            var studentName = GradesDataGridView.CurrentRow.Cells[4].Value;
            var studentLastName = GradesDataGridView.CurrentRow.Cells[5].Value;
            var score = GradesDataGridView.CurrentRow.Cells[6].Value;


            teacherCoursesComboBox.Text = $"{teacherName} {teacherLastName} {courseName}";
            studentComboBox.Text = $"{studentName} {studentLastName}";
            GradeTextBox.Text = score.ToString();
        }
    }
}
