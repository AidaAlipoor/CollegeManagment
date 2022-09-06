namespace UI.ComboBoxItems
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString() => Text;
    }
}
