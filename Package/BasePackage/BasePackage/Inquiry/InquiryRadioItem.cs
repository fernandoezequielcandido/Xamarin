using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class InquiryRadioItem
        /// </summary>
        public class InquiryRadioItem : View
        {
            /// <summary>
            /// Constructor of InquiryRadioItem
            /// </summary>
            public InquiryRadioItem() : base()
            {
                IsVisible = false;
            }

            /// <summary>
            /// Enter the height, represents only item.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(InquiryRadioItem),
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
                declaringType: typeof(InquiryRadioItem),
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
                declaringType: typeof(InquiryRadioItem),
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
                declaringType: typeof(InquiryRadioItem),
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
            /// Enter the font size of text.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(InquiryRadioItem),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the font size of text.
            /// </summary>
            public double FontSize
            {
                get
                {
                    return (double)GetValue(FontSizeProperty);
                }
                set
                {
                    SetValue(FontSizeProperty, value);
                }
            }

            /// <summary>
            /// Enter the text color.
            /// </summary>
            public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
             propertyName: nameof(TextColor),
             returnType: typeof(Color),
             declaringType: typeof(InquiryRadioItem),
             defaultValue: Color.Black,
             defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the text color.
            /// </summary>
            public Color TextColor
            {
                get
                {
                    return (Color)GetValue(TextColorProperty);
                }
                set
                {
                    SetValue(TextColorProperty, value);
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(InquiryRadioItem),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public string FontFamily
            {
                get
                {
                    return (string)GetValue(FontFamilyProperty);
                }
                set
                {
                    SetValue(FontFamilyProperty, value);
                }
            }

            /// <summary>
            /// Enter the IsChecked.
            /// </summary>
            public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
                propertyName: nameof(IsChecked),
                returnType: typeof(bool),
                declaringType: typeof(InquiryRadioItem),
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
                declaringType: typeof(InquiryRadioItem),
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
                declaringType: typeof(InquiryRadioItem),
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
}
