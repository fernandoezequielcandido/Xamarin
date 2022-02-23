using Xamarin.Forms;

namespace Laavor
{
    namespace Swap
    {
        /// <summary>
        /// SwapTextItem
        /// </summary>
        public class SwapTextItem : View
        {
            /// <summary>
            /// Index of SwapTextItem
            /// </summary>
            public int Index { get; private set; }

            /// <summary>
            /// Internal
            /// </summary>
            public bool UseSpecificTextColor { get; private set; } = false;
            /// <summary>
            /// Internal
            /// </summary>
            public bool UseSpecificBackgroundColor { get; private set; } = false;
            /// <summary>
            /// Internal
            /// </summary>
            public bool UseSpecificBorderColor { get; private set; } = false;

            /// <summary>
            /// Constructor of SwapTextItem
            /// </summary>
            public SwapTextItem() : base()
            {

            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="key"></param>
            /// <param name="index"></param>
            public void setIndex(string key, int index)
            {
                if (key == "wertyafff7777_____784")
                {
                    Index = index;
                }
            }

            /// <summary>
            /// Enter the TextColor.
            /// </summary>
            public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
              propertyName: nameof(TextColor),
              returnType: typeof(ColorUI),
              declaringType: typeof(SwapTextItem),
              defaultValue: ColorUI.Black,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: TextColorPropertyChanged);

            /// <summary>
            /// Enter the TextColor.
            /// </summary>
            public ColorUI TextColor
            {
                get
                {
                    return (ColorUI)GetValue(TextColorProperty);
                }
                set
                {
                    SetValue(TextColorProperty, value);
                }
            }

            private static void TextColorPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwapTextItem swapTextItem = (SwapTextItem)bindable;
                swapTextItem.UseSpecificTextColor = true;
            }

            /// <summary>
            /// Enter the ColorUI.
            /// </summary>
            public static readonly BindableProperty ColorUIProperty = BindableProperty.Create(
                propertyName: nameof(ColorUI),
                returnType: typeof(ColorUI),
                declaringType: typeof(SwapTextItem),
                defaultValue: ColorUI.Transparent,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ColorUIPropertyChanged);

            /// <summary>
            /// Enter the ColorUI.
            /// </summary>
            public ColorUI ColorUI
            {
                get
                {
                    return (ColorUI)GetValue(ColorUIProperty);
                }
                set
                {
                    SetValue(ColorUIProperty, value);
                }
            }

            private static void ColorUIPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwapTextItem swapTextItem = (SwapTextItem)bindable;
                swapTextItem.UseSpecificBackgroundColor = true;
            }

            /// <summary>
            /// Enter the BorderColor.
            /// </summary>
            public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
              propertyName: nameof(BorderColor),
              returnType: typeof(ColorUI),
              declaringType: typeof(SwapTextItem),
              defaultValue: ColorUI.Black,
              defaultBindingMode: BindingMode.OneWay,
              propertyChanged: BorderColorPropertyChanged);

            /// <summary>
            /// Enter the BorderColor.
            /// </summary>
            public ColorUI BorderColor
            {
                get
                {
                    return (ColorUI)GetValue(BorderColorProperty);
                }
                set
                {
                    SetValue(BorderColorProperty, value);
                }
            }

            private static void BorderColorPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwapTextItem swapLabelItem = (SwapTextItem)bindable;
                swapLabelItem.UseSpecificBorderColor = true;
            }


            /// <summary>
            /// Enter the Text.
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
              propertyName: nameof(Text),
              returnType: typeof(string),
              declaringType: typeof(SwapTextItem),
              defaultValue: "",
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

            /// <summary>
            /// Enter the Value.
            /// </summary>
            public static readonly BindableProperty ValueProperty = BindableProperty.Create(
              propertyName: nameof(Value),
              returnType: typeof(string),
              declaringType: typeof(SwapTextItem),
              defaultValue: "",
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
        }
    }
}
