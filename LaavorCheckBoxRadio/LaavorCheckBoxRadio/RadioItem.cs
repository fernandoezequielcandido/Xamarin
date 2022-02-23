using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace LaavorCheckBoxRadio
{
    /// <summary>
    /// Class RadioItem
    /// </summary>
    public class RadioItem : View
    {
        /// <summary>
        /// Constructor of RadioItem
        /// </summary>
        public RadioItem() : base()
        {
            IsVisible = false;
        }

        /// <summary>
        /// Enter the height, represents only item.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(RadioItem),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the height, represents only item.
        /// </summary>
        public new double Height
        {
            get
            {
                return (double)GetValue(HeightProperty);
            }
            set
            {
                SetValue(HeightProperty, value);
            }
        }

        /// <summary>
        /// Enter the width, represents only one item.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(RadioItem),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the width, represents only one item.
        /// </summary>
        public new double Width
        {
            get
            {
                return (double)GetValue(WidthProperty);
            }
            set
            {
                SetValue(WidthProperty, value);
            }
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(RadioItem),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the text
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

        /// <summary>
        /// Enter the Value
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(RadioItem),
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

        
        /// <summary>
        /// Enter the IsChecked.
        /// </summary>
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
            propertyName: nameof(IsChecked),
            returnType: typeof(bool),
            declaringType: typeof(RadioItem),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the IsChecked.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return (bool)GetValue(IsCheckedProperty);
            }
            set
            {
                SetValue(IsCheckedProperty, value);
            }
        }

        /// <summary>
        /// Enter the Row.
        /// </summary>
        public static readonly BindableProperty RowProperty = BindableProperty.Create(
            propertyName: nameof(Row),
            returnType: typeof(int?),
            declaringType: typeof(RadioItem),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Row.
        /// </summary>
        public int? Row
        {
            get
            {
                return (int?)GetValue(RowProperty);
            }
            set
            {
                SetValue(RowProperty, value);
            }
        }

        /// <summary>
        /// Enter the Col.
        /// </summary>
        public static readonly BindableProperty ColProperty = BindableProperty.Create(
            propertyName: nameof(Col),
            returnType: typeof(int?),
            declaringType: typeof(RadioItem),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Col.
        /// </summary>
        public int? Col
        {
            get
            {
                return (int?)GetValue(ColProperty);
            }
            set
            {
                SetValue(ColProperty, value);
            }
        }
    }
}
