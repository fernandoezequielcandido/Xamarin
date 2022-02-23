using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Class ExpanderTitle
        /// </summary>
        public class ExpanderTitle: Label
        {
            /// <summary>
            /// Get Value of State
            /// </summary>
            public StateExpander State { get; private set; }

            /// <summary>
            /// Constructor of GroupAccordionTitle
            /// </summary>
            public ExpanderTitle() : base()
            {

            }

            /// <summary>
            /// Set value of State (Internal)
            /// </summary>
            /// <param name="key"></param>
            /// <param name="state"></param>
            public void SetState(string key, StateExpander state)
            {
                if (key == "__Laavor*+-")
                {
                    State = state;
                }
            }
        }
    }
}
