using DataAccess.EntitiesConfiguration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagment.UI.Forms
{
    public class BaseForm : Form
    {
        protected readonly CollegeManagmentContext _dbContext;

        public BaseForm() => _dbContext = new CollegeManagmentContext();


        protected void ShowErrorMessageBox(string message)
            => MessageBox.Show(
                    message, MessageProvider.InvalidFields,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        protected async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
