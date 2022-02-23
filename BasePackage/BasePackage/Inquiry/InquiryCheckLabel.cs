using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class InquiryCheckLabel
        /// </summary>
        public class InquiryCheckLabel : Label
        {
            /// <summary>
            /// Internal
            /// </summary>
            public InquiryCheckControl CheckControl { get; private set; }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="image"></param>
            public void setImage(string hash, InquiryCheckControl image)
            {
                if (hash == "__Laavor*+-")
                {
                    CheckControl = image;
                }
            }
        }
    }
}
