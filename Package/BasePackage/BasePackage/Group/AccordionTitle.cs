using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Class AccordionTitle
        /// </summary>
        public class AccordionTitle : Label
        {
            /// <summary>
            /// Get Value of Index
            /// </summary>
            public int Index { get; private set; }

            /// <summary>
            /// Constructor of AccordionTitle
            /// </summary>
            public AccordionTitle() : base()
            {

            }

            /// <summary>
            /// Set value of Index (Internal)
            /// </summary>
            /// <param name="key"></param>
            /// <param name="indexValue"></param>
            public void SetIndex(string key, int indexValue)
            {
                if (key == "__Laavor*+-")
                {
                    Index = indexValue;
                }
            }
        }
    }
}
