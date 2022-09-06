using DataAccess.Entities;
using UI.ComboBoxItems;
using CollegeManagment.UI.Extensions;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;

namespace CollegeManagment.UI.Forms
{
    public partial class GradeForm : BaseForm
    {
        public GradeForm()
        {
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                await InsertGradeAsync();
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
                MessageBox.Show(ex.Message.ToString(), MessageProvider.ItemIsDeleted, MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private bool IsGradeValid() => !IsGradeEmpty() && IsGradeValueValid();
        private bool IsGradeEmpty() => string.IsNullOrEmpty(GradeTextBox.Text)
            && string.IsNullOrWhiteSpace(GradeTextBox.Text);
        private bool IsGradeValueValid()
        {
            var score = GradeTextBox.Text;

            return int.TryParse(score, out _) && IntConvertor.ToInt(score) >= 0
                && IntConvertor.ToInt(score) <= Grade.ScoreLengthLimit;
        }


        private Task InsertGradeAsync(TeacherCourse teacherCourse, Student student, int score)
        {
            if (!IsGradeValid())
                throw new Exception();

            var addingTeacherCourse = new Grade
            {
                TeacherCourse = teacherCourse,
                Students = student,
                Score = score,
            };

            _dbContext.Grades.Add(addingTeacherCourse);
            return Task.CompletedTask;
        }

        private async Task InsertGradeAsync()
        {
            var teacherCourse = await GetSelectedTeacherCourseEntityAsync();
            var student = await GetSelectedStudentEntityAsync();
            var scoreValue = IntConvertor.ToInt(GradeTextBox.Text);

            await InsertGradeAsync(teacherCourse, student, scoreValue);

            return;
        }

        private async Task<TeacherCourse> GetSelectedTeacherCourseEntityAsync()
        {
            var selectedCourseId = teacherCoursesComboBox.GetSelectedItem().Value;

            return await _dbContext.TeacherCourses.FindAsync(selectedCourseId);
        }

        private async Task<Student> GetSelectedStudentEntityAsync()
        {
            var selectedCourseId = studentComboBox.GetSelectedItem().Value;

            return await _dbContext.Students.FindAsync(selectedCourseId);
        }



        private async Task DeleteAsync()
        {
            if (GradesDataGridView.SelectedRows.Count < 0)
                throw new Exception();

            var deletedId = GradesDataGridView.GetId();
            var removeGrade = await _dbContext.Grades.FindAsync(deletedId);

            _dbContext.Grades.Remove(removeGrade);
        }

        private async Task EditAsync()
        {
            var selectedGradeId = GradesDataGridView.GetId();
            var selectedGrade = await _dbContext.Grades.FindAsync(selectedGradeId);


            var selectedTeachCourseId = teacherCoursesComboBox.GetSelectedItem().Value;
            var selectedTeacherCourse = await _dbContext.TeacherCourses.FindAsync(selectedTeachCourseId);

            var selectedStudentId = studentComboBox.GetSelectedItem().Value;
            var SelectedStudent = await _dbContext.Students.FindAsync(selectedStudentId);


            selectedGrade.TeacherCourse = selectedTeacherCourse;
            selectedGrade.Students = SelectedStudent;
            selectedGrade.Score = IntConvertor.ToInt(GradeTextBox.Text);
        }

        private async Task RefreshDataGridViewAsync()
        {
            GradesDataGridView.Rows.Clear();

            var grade = await _dbContext.Grades.ToArrayAsync();

            foreach (var item in grade)
                GradesDataGridView.Rows
                    .Add(item.Id, item.TeacherCourse.Course.CourseName
                     , item.TeacherCourse.Teacher.TeacherName, item.TeacherCourse.Teacher.TeacherLastName
                     , item.Students.StudentName, item.Students.StudentLastName
                     , item.Score);
        }

        private void AddColumnToGridView()
        {
            var idColumn = nameof(Grade.Id);
            var courseNameColumn = nameof(Grade.TeacherCourse.Course.CourseName);
            var teacherNameColumn = nameof(Grade.TeacherCourse.Teacher.TeacherName);
            var teacherLastNameColumn = nameof(Grade.TeacherCourse.Teacher.TeacherLastName);
            var studentNameColumn = nameof(Grade.Students.StudentName);
            var studentLastNameColumn = nameof(Grade.Students.StudentLastName);
            var scoreColumn = nameof(Grade.Score);

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
            var teacherCourses = await _dbContext.TeacherCourses.ToArrayAsync();

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
            var students = await _dbContext.Students.ToArrayAsync();

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
