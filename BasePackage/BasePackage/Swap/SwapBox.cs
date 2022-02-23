using Xamarin.Forms;

namespace Laavor
{
    namespace Swap
    {
        /// <summary>
        /// Class SwapBox
        /// </summary>
        public class SwapBox: Frame
        {
            /// <summary>
            /// Index of item is a list
            /// </summary>
            public int Index { get; private set; }

            /// <summary>
            /// IsChosen value
            /// </summary>
            public bool IsChosen;

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="key"></param>
            /// <param name="index"></param>
            public void setIndex(string key, int index)
            {
                if (key == "__Laavor*+-")
                {
                    Index = index;
                }
            }
        }
    }
}
