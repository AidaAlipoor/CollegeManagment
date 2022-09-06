using UI.ComboBoxItems;

namespace CollegeManagment.UI.Extensions
{
    internal static class ComboBox
    {
        internal static ComboBoxItem GetSelectedItem(this System.Windows.Forms.ComboBox comboBox)
            => comboBox.SelectedItem as ComboBoxItem;

    }
}
