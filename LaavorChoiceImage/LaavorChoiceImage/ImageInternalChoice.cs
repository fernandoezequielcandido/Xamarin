using System;
using Xamarin.Forms;

namespace LaavorChoiceImage
{
    /// <summary>
    /// Class ImageInternalChoice
    /// </summary>
    public class ImageInternalChoice : Image
    {
        /// <summary>
        /// Set and Get if is chosen
        /// </summary>
        public bool IsChosen { get; set; }

        /// <summary>
        /// Call when is clicked
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// Constructor of ImageInteranlChoice
        /// </summary>
        public ImageInternalChoice() : base()
        {
            var click = new TapGestureRecognizer();
            click.Tapped += Click_Tapped;
        }

        private void Click_Tapped(object sender, System.EventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
