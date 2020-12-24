namespace NewsAgencyApp.Helper
{
    // https://stackoverflow.com/a/3063421/1738413
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
