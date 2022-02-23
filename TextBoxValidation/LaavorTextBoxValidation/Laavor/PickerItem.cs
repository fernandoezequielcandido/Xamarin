using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class PickerItem
    /// </summary>
    public class PickerItem: View
    {
        /// <summary>
        /// Constructor of PickerItem
        /// </summary>
        public PickerItem()
        {
            IsVisible = false;   
        }

        /// <summary>
        /// Constructor of PickerItem
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public PickerItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        /// <summary>
        /// Enter the Value..
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(PickerItem),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Value.
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
        
        /// <summary>
        /// Enter the Text.
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(PickerItem),
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Text.
        /// </summary>
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
    }
}
