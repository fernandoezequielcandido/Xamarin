using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorAccordion
{
    /// <summary>
    /// Class LaavorBox
    /// </summary>
    public class LaavorBox : StackLayout
    {
        /// <summary>
        /// Internal class, don't use can create errors.
        /// </summary>
        public LaavorBox()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        /// <summary>
        /// Enter border color.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
         propertyName: nameof(BorderColor),
         returnType: typeof(Color),
         declaringType: typeof(LaavorBox),
         defaultValue: Color.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: BorderColorPropertyChanged);

        /// <summary>
        /// Enter the border color.
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        private static void BorderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorBox box = (LaavorBox)bindable;
            Color copyBorderColor = (Color)newValue;
            box.BackgroundColor = copyBorderColor;
        }

        /// <summary>
        /// Enter border color.
        /// </summary>
        public static readonly BindableProperty BorderProperty = BindableProperty.Create(
         propertyName: nameof(Border),
         returnType: typeof(int),
         declaringType: typeof(LaavorBox),
         defaultValue: 1,
         defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the border.
        /// </summary>
        public int Border
        {
            get
            {
                return (int)GetValue(BorderProperty);
            }
            set
            {
                SetValue(BorderProperty, value);
                Padding = value;
            }
        }
    }
}
