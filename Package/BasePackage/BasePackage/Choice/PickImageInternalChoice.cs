using System;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class PickImageInternalChoice
        /// </summary>
        public class PickImageInternalChoice : Image
        {
            /// <summary>
            /// Set and Get if is chosen
            /// </summary>
            public bool IsChosen { get; set; }

            /// <summary>
            /// Call when is touched
            /// </summary>
            public event EventHandler Touched;

            /// <summary>
            /// Constructor of ImageInteranlChoice
            /// </summary>
            public PickImageInternalChoice() : base()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Touch_Tapped;
                this.Aspect = Aspect.Fill;
            }

            private void Touch_Tapped(object sender, System.EventArgs e)
            {
                Touched?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
