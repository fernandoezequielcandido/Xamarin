using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorChoiceImage
{
    /// <summary>
    /// Class ChoiceImageItem
    /// </summary>
    public class ChoiceImageItem: View
    {
        /// <summary>
        /// Constructor ChoiceImageItem
        /// </summary>
        public ChoiceImageItem()
        {
            IsVisible = false;
        }

        /// <summary>
        /// Enter the Image Source of button.
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(ChoiceImageItem),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Image Source of button.
        /// </summary>
        public string Image
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }

        /// <summary>
        /// Enter the Value
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(ChoiceImageItem),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the value
        /// </summary>
        public string Value
        {
            get
            {
                return (string)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

       
    }
}
