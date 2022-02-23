using Laavor.Divider;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Laavor
{
    namespace Graphics
    {
        /// <summary>
        /// BarsVertical       
        /// </summary>
        public class BarsVertical : StackLayout
        {
            /// <summary>
            /// Event call when Icon is Touched
            /// </summary>
            public event EventHandler Touched;

            private DividerControl imageButton;

            private ColorUI colorUI = ColorUI.Gray;
            private IconType iconType = IconType.Like;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of BarsVertical
            /// </summary>
            public BarsVertical()
            {
                InitAll();
            }

            private void InitAll()
            {
                CreateButton();

                this.Children.Add(imageButton);
            }

            private void CreateButton()
            {
                

                imageButton = new DividerControl("__Laavor*+-", colorUI, LineSize.Four);
                imageButton.WidthRequest = Width;
                imageButton.MinimumWidthRequest = Width;
                imageButton.HeightRequest = Height;
                imageButton.MinimumHeightRequest = Height;

                imageButton.GestureRecognizers.Clear();

                //    if (!IsReadOnly)
                //    {
                //        if (Vivacity != Vivacity.None)
                //        {
                //            if (imageButton.GestureRecognizers.Count == 0)
                //            {
                //                imageButton.GestureRecognizers.Add(GetVivacity());
                //            }
                //        }

                //        if (Vivacity == Vivacity.None)
                //        {
                //            if (imageButton.GestureRecognizers.Count == 0)
                //            {
                //                imageButton.GestureRecognizers.Add(GetTouch());
                //            }
                //        }
                //        else
                //        {
                //            if (imageButton.GestureRecognizers.Count == 1)
                //            {
                //                imageButton.GestureRecognizers.Add(GetTouch());
                //            }
                //        }
                //    }
                //}

            }
        }
    }
}
