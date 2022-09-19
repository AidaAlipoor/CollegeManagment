using BusinessLogic.Repositories;
using BusinessLogic.Repositories.Repositorey;
using BusinessLogic.Repositories.Teacher;
using DataAccess.Entities;
using DataAccess.EntitiesConfiguration;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;
using TeacherEntity = DataAccess.Entities.Teacher;

namespace CollegeManagment.UI.Forms
{
    public partial class TeacherForm : BaseForm
    {
        private readonly IRepository<TeacherEntity> _repository;
        public TeacherForm()
        {
            InitializeComponent();

            //_repository = new TeacherRepository();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddAsync(
                    teacherNameTextBox.Text, teacherLastNameTextBox.Text,
                    birthdayDateTimePicker.Value);

                await _repository.SaveAsync();

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
                var teacherId = teachersDataGridView.GetId();

                await _repository.DeleteAsync(teacherId);

                //await DeleteAsync();
                await _repository.SaveAsync();
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
                await _repository.SaveAsync();
                await RefreshDataGridViewAsync();

                MessageBox.Show(MessageProvider.ItemIsEdited);

            }
            catch (Exception)
            {
                ShowErrorMessageBox(MessageProvider.InvalidFields);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }


        //private bool IsTeacherValid()
        //{
        //    return !IsTeacherNameEmpty() && IsLetter() && IsBirthdayValid();
        //}
        //private bool IsTeacherNameEmpty() => string.IsNullOrEmpty(teacherNameTextBox.Text)
        //    && string.IsNullOrEmpty(teacherLastNameTextBox.Text);
        //private bool IsLetter()
        //{
        //    var teacherName = teacherNameTextBox.Text;
        //    var teacherLastName = teacherLastNameTextBox.Text;

        //    return teacherName.Count(c => char.IsLetter(c)) == teacherName.Length
        //        && teacherLastName.Count(c => char.IsLetter(c)) == teacherLastName.Length;
        //}
        //private bool IsBirthdayValid()
        //{
        //    var teacherBirthday = birthdayDateTimePicker.Value;
        //    return teacherBirthday.Year < 1999 && teacherBirthday.Year > 1950;
        //}


        private void AddAsync(
            string teacherName, string teacherLastName, DateTime teacherBirthdate)
        {
            //if (!IsTeacherValid())
            //    throw new Exception();

            _repository.Add(
                 new TeacherEntity
                 {
                     TeacherName = teacherName,
                     TeacherLastName = teacherLastName,
                     Birthday = teacherBirthdate
                 });
        }

        //private async Task CheckIsTeacherDeletableAsync()
        //{


        //var isTeacherUsedAtTeacherCourses = await _dbContext.TeacherCourses
        //    .Include(tc => tc.Teacher)
        //    .AnyAsync(tc => tc.Teacher.Id == selectedTeacherId);

        //if (isTeacherUsedAtTeacherCourses)
        //    throw new Exception(MessageProvider.ItemIsNotDeletable);
        //}

        //private async Task DeleteAsync()
        //{
        //    await CheckIsTeacherDeletableAsync();

        //    var deletedId = teachersDataGridView.GetId();
        //    var removeTeacher = await _dbContext.Teachers.FindAsync(deletedId);

        //    _dbContext.Teachers.Remove(removeTeacher);
        //}

        private async Task UpdateAsync()
        {
            //if (!IsTeacherValid())
            //    throw new Exception();

            var selectedRowId = teachersDataGridView.GetId();
            var selectedTeacher = await _repository.FetchAsync(selectedRowId);

            _repository.Update(selectedTeacher);
            selectedTeacher.TeacherName = teacherNameTextBox.Text;
            selectedTeacher.TeacherLastName = teacherLastNameTextBox.Text;
            selectedTeacher.Birthday = birthdayDateTimePicker.Value;
        }

        private async Task RefreshDataGridViewAsync()
        {
            teachersDataGridView.Rows.Clear();

            var teachers = await _repository.FetchAsync();

            foreach (var teacher in teachers)
                teachersDataGridView.Rows
                    .Add(teacher.Id, teacher.TeacherName, teacher.TeacherLastName, teacher.Birthday);
        }

        private void AddColumnsToDataGridView()
        {
            var idColumn = nameof(TeacherEntity.Id);
            var nameColumn = nameof(TeacherEntity.TeacherName);
            var lastNameColumn = nameof(TeacherEntity.TeacherLastName);
            var birthdayColumn = nameof(TeacherEntity.Birthday);

            var isReadOnly = true;

            teachersDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = idColumn, ReadOnly = isReadOnly, Visible = false });
            teachersDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = nameColumn, ReadOnly = isReadOnly });
            teachersDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = lastNameColumn, ReadOnly = isReadOnly });
            teachersDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = birthdayColumn, ReadOnly = isReadOnly });
        }



        private async void TeacherForm_Load(object sender, EventArgs e)
        {
            AddColumnsToDataGridView();

            await RefreshDataGridViewAsync();
        }
        private void TeachersDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedRow = teachersDataGridView.SelectedRows[0];

            string editedName = selectedRow.Cells[1].Value.ToString();
            string editedLastname = selectedRow.Cells[2].Value.ToString();
            var editedBirthday = birthdayDateTimePicker.Value = Convert.ToDateTime(selectedRow.Cells[3].Value);

            teacherNameTextBox.Text = editedName;
            teacherLastNameTextBox.Text = editedLastname;
            birthdayDateTimePicker.Value = editedBirthday;
        }
    }
}
