using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// InquirySwitchLabel
        /// </summary>
        public class InquirySwitchLabel : Label
        {
            /// <summary>
            /// Internal
            /// </summary>
            public InquirySwitchControl SwitchImage { get; private set; }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="image"></param>
            public void setImage(string hash, InquirySwitchControl image)
            {
                if (hash == "__Laavor*+-")
                {
                    SwitchImage = image;
                }
            }
        }
    }
}
