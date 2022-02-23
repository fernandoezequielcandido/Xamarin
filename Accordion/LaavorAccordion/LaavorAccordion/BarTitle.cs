using Xamarin.Forms;

namespace LaavorAccordion
{
    /// <summary>
    /// Class BarTitle
    /// </summary>
    public class BarTitle: Label
    {
        /// <summary>
        /// Get Value of Index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Constructor of BarTitle
        /// </summary>
        public BarTitle():base()
        {

        }

        /// <summary>
        /// Set value of Index (Internal)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="indexValue"></param>
        public void SetIndex(string key, int indexValue)
        {
            if (key == "fernandoLaavor77+*_87WW")
            {
                Index = indexValue;
            }
        }
    }
}
