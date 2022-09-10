using System.Windows.Forms;

namespace CollegeManagment.UI.Forms
{
    public class BaseForm : Form
    {
        protected void ShowErrorMessageBox(string message)
            => MessageBox.Show(
                    message, MessageProvider.InvalidFields,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
