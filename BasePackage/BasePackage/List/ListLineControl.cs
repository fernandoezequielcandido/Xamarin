using System;
using Xamarin.Forms;

namespace Laavor
{
    namespace List
    {
        /// <summary>
        /// Class ListLineControl
        /// </summary>
        public class ListLineControl : Image
        {
            private ImageSource internalSource;

            private string line = "iVBORw0KGgoAAAANSUhEUgAABAcAAAABCAYAAACi0sdMAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAETgAABE4BQouT/AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAcSURBVFiF7cEBAQAACIAg+z+6hgRMtQEAAABvHSoRAQEybSQ/AAAAAElFTkSuQmCC";

            /// <summary>
            /// Constructor of ListLineControl
            /// </summary>
            /// <param name="hash"></param>
            public ListLineControl(string hash)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in Constructor");
                }

                Aspect = Aspect.Fill;
                Margin = new Thickness(2, 0, 2, 0);
                HorizontalOptions = LayoutOptions.FillAndExpand;
                VerticalOptions = LayoutOptions.FillAndExpand;

                byte[] imageBytes = Convert.FromBase64String(line);
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }
        }

    }
}
