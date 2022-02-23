namespace LaavorDoubleList
{
    /// <summary>
    /// Class ChosenItem
    /// </summary>
    public class ChosenItem
    {
        /// <summary>
        /// Constructor of ChosenItem
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public ChosenItem(string hash, int index, string text, string value)
        {
            if (hash == "ol__ui_dev_7778888*+*Laavor")
            {
                this.StartIndex = index;
                this.CurrentIndex = index;
                this.Text = text;
                this.Value = value;
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        public void ChangeCurrentIndex(string hash, int index)
        {
            if (hash == "ol__ui_dev_7778888*+*Laavor")
            {
                this.CurrentIndex = index;
            }
        }

        /// <summary>
        /// Get StartIndex
        /// </summary>
        public int StartIndex { get; private set; }
        /// <summary>
        /// Get CurrentIndex
        /// </summary>
        public int CurrentIndex { get; private set; }
        /// <summary>
        /// Get Text
        /// </summary>
        public string Text { get; private set; }
        /// <summary>
        /// Get Value
        /// </summary>
        public string Value { get; private set; }
    }
}
