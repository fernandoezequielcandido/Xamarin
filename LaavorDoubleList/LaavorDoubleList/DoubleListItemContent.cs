using System;
using Xamarin.Forms;

namespace LaavorDoubleList
{
    /// <summary>
    /// Class DoubleListItemContent
    /// </summary>
    public class DoubleListItemContent: Button
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
        public DoubleListItemContent(string hash, string text, string value, int index, bool chosen)
        {
            if (hash != "hajajajkaKlulpll787878*--StairWay__Laavor*+-")
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
        /// <param name="chosen"></param>
        public void ChangeChosen(string hash, bool chosen)
        {
            if (hash != "hajajajkaKlulpll787878*--StairWay__Laavor*+-")
            {
                throw new Exception("Invalid Hash");
            }

            this.IsChosen = chosen;
        }
    }
}
