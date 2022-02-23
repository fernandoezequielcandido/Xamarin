namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class InquiryListChosen
        /// </summary>
        public class InquiryListChosen
        {
            /// <summary>
            /// Constructor of InquiryListChosen
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="index"></param>
            /// <param name="text"></param>
            /// <param name="value"></param>
            public InquiryListChosen(string hash, int index, string text, string value)
            {
                if (hash == "__Laavor*+-")
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
                if (hash == "__Laavor*+-")
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
}
