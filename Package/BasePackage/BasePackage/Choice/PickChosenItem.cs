namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class PickChosenItem
        /// </summary>
        public class PickChosenItem
        {
            /// <summary>
            /// Constructor of PickChosenItem
            /// </summary>
            /// <param name="index"></param>
            /// <param name="text"></param>
            /// <param name="value"></param>
            public PickChosenItem(int index, string text, string value)
            {
                this.Index = index;
                this.Text = text;
                this.Value = value;
            }

            /// <summary>
            /// Constructor of ChoiceChosenItem
            /// </summary>
            /// <param name="index"></param>
            /// <param name="text"></param>
            /// <param name="value"></param>
            /// <param name="source"></param>
            public PickChosenItem(int index, string text, string value, string source)
            {
                this.Index = index;
                this.Text = text;
                this.Source = source;
                this.Value = value;
            }

            /// <summary>
            /// Get Index
            /// </summary>
            public int Index { get; private set; }
            /// <summary>
            /// Get Text
            /// </summary>
            public string Text { get; private set; }
            /// <summary>
            /// Get Value
            /// </summary>
            public string Value { get; private set; }
            /// <summary>
            /// Get Source
            /// </summary>
            public string Source { get; private set; }
        }
    }
}
