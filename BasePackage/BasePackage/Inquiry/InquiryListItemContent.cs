using System;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class InquiryListItemContent
        /// </summary>
        public class InquiryListItemContent : Button
        {
            /// <summary>
            /// Value 
            /// </summary>
            public string Value { get; private set; }
            /// <summary>
            /// Index
            /// </summary>
            public int Index { get; private set; }
            /// <summary>
            /// IsChosen
            /// </summary>
            public bool IsChosen { get; private set; }

            /// <summary>
            /// Constructor of DoucleListItemContent
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="text"></param>
            /// <param name="value"></param>
            /// <param name="index"></param>
            /// <param name="chosen"></param>
            public InquiryListItemContent(string hash, string text, string value, int index, bool chosen)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Invalid Hash");
                }

                this.Text = text;
                this.Value = value;
                this.Index = index;
                this.IsChosen = chosen;
            }


            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="text"></param>
            public void ChangeChosen(string hash, string text)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Invalid Hash");
                }

                this.Text = text;
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="chosen"></param>
            public void ChangeChosen(string hash, bool chosen)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Invalid Hash");
                }

                this.IsChosen = chosen;
            }
        }
    }
}
