using DataAccess.Entities;
using DataAccess.EntitiesConfiguration;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Extensions;
using StudentEntity = DataAccess.Entities.Student;

namespace CollegeManagment.UI.Forms
{
    public partial class StudentsForm : BaseForm
    {
        public StudentsForm()
        {
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Add(StudentNameTextBox.Text, StudentLastNameTextBox.Text, int.Parse(StudentIdNumberTextBox.Text));
                
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
                ShowErrorMessageBox(ex.Message);
            }

        }
        private async void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                await EditAsync();
                await SaveChangesAsync();
                EditGridViewItems();
                MessageBox.Show(MessageProvider.ItemIsEdited);

            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(ex.Message);
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }


       
        private bool IsStudentValid()
        {
            return !IsStudentNameEmpty() && IsLetter() && IsIdNumberValid();
        }
        private bool IsStudentNameEmpty() => string.IsNullOrEmpty(StudentNameTextBox.Text)
            && string.IsNullOrEmpty(StudentLastNameTextBox.Text);
        private bool IsLetter()
        {
            var studentName = StudentNameTextBox.Text;
            var studentLastName = StudentLastNameTextBox.Text;

            return studentName.Count(c => char.IsLetter(c)) == studentName.Length
                && studentLastName.Count(c => char.IsLetter(c)) == studentLastName.Length;
        }
        private bool IsIdNumberValid()
        {
            var studentIdNumber = StudentIdNumberTextBox.Text;

            return int.TryParse(studentIdNumber, out _) 
                && studentIdNumber.Length > 0 
                && studentIdNumber.Length < StudentEntity.IdNumberLengthLimit;
        }



        public void Add(string studentName, string studentLastName, int studentIdNumber)
        {
            if (!IsStudentValid())
                throw new Exception();

            _dbContext.Students.Add(
                new StudentEntity
                {
                    StudentName = studentName,
                    StudentLastName = studentLastName,
                    IdNumber = studentIdNumber
                });
        }

        private async Task RefreshDataGridViewAsync()
        {
            StudentsDataGridView.Rows.Clear();

            var students = await _dbContext.Students.ToArrayAsync();

            foreach (var student in students)
                StudentsDataGridView.Rows
                    .Add(student.Id, student.StudentName, student.StudentLastName, student.IdNumber);
        }

        private void AddColumnsToDataGridView()
        {
            var idColumn = nameof(StudentEntity.Id);
            var nameColumn = nameof(StudentEntity.StudentName);
            var lastNameColumn = nameof(StudentEntity.StudentLastName);
            var idNumberColumn = nameof(StudentEntity.IdNumber);

            var isReadOnly = true;

            StudentsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = idColumn, ReadOnly = isReadOnly, Visible = false });
            StudentsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = nameColumn, ReadOnly = isReadOnly });
            StudentsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = lastNameColumn, ReadOnly = isReadOnly });
            StudentsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = idNumberColumn, ReadOnly = isReadOnly });
        }

        public async Task DeleteAsync()
        {
            var deletedId = StudentsDataGridView.GetId();
            var removeStudent = await _dbContext.Students.FindAsync(deletedId);

            _dbContext.Students.Remove(removeStudent);
        }

        public async Task EditAsync()
        {
            if (!IsStudentValid())
                throw new Exception();

            var selectedRowId = StudentsDataGridView.GetId();
            var newData = await _dbContext.Students.FindAsync(selectedRowId);

            newData.StudentName = StudentNameTextBox.Text;
            newData.StudentLastName = StudentLastNameTextBox.Text;
            newData.IdNumber = IntConvertor.ToInt(StudentIdNumberTextBox.Text);
        }

        private void EditGridViewItems()
        {
            if (StudentsDataGridView.SelectedRows.Count < 0)
                 throw new Exception();

            var editedIndex = StudentsDataGridView.CurrentRow.Index;
            StudentsDataGridView.Rows[editedIndex].Cells[1].Value = StudentNameTextBox.Text;
            StudentsDataGridView.Rows[editedIndex].Cells[2].Value = StudentLastNameTextBox.Text;
            StudentsDataGridView.Rows[editedIndex].Cells[3].Value = StudentIdNumberTextBox.Text;
        }


        private async void Students_Load(object sender, EventArgs e)
        {
            AddColumnsToDataGridView();
            await RefreshDataGridViewAsync();
        }
        private void StudentsDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string editedName = StudentsDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            string editedLastname = StudentsDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            var editedIdNumber = StudentsDataGridView.SelectedRows[0].Cells[3].Value.ToString();


            StudentNameTextBox.Text = editedName;
            StudentLastNameTextBox.Text = editedLastname;
            StudentIdNumberTextBox.Text = editedIdNumber;
        }
    }
}
