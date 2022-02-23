using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class Inquiry Radio Label
        /// </summary>
        public class InquiryRadioLabel : Label
        {
            /// <summary>
            /// Internal
            /// </summary>
            public InquiryRadioControl Image { get; private set; }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="inquiryRadioImage"></param>
            public void setImage(string hash, InquiryRadioControl inquiryRadioImage)
            {
                if (hash == "__Laavor*+-")
                {
                    Image = inquiryRadioImage;
                }
            }
        }
    }
}
