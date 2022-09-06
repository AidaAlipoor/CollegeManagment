namespace UI.Extensions
{
    internal static class DataGridView
    { 
        internal static int GetId(this System.Windows.Forms.DataGridView dataGridView)
            => (int)dataGridView.SelectedRows[0].Cells[0].Value;
    }
}
