using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorColoredBox
{
    /// <summary>
    /// Class LineImage
    /// </summary>
    public class LineImage: Image
    {
        private ImageSource internalSource;

        private string line = "iVBORw0KGgoAAAANSUhEUgAABAcAAAABCAYAAACi0sdMAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAETgAABE4BQouT/AAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAAcSURBVFiF7cEBAQAACIAg+z+6hgRMtQEAAABvHSoRAQEybSQ/AAAAAElFTkSuQmCC";

        /// <summary>
        /// Constructor of BoxImage
        /// </summary>
        /// <param name="hash"></param>
        public LineImage(string hash)
        {
            if (hash != "hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ")
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
