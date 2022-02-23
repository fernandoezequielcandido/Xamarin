using Xamarin.Forms;

namespace Laavor
{
    namespace Validate
    {
        /// <summary>
        /// Class PickerItem
        /// </summary>
        public class ValidatePickerItem : View
        {
            /// <summary>
            /// Constructor of PickerItem
            /// </summary>
            public ValidatePickerItem()
            {
                IsVisible = false;
            }

            /// <summary>
            /// Constructor of PickerItem
            /// </summary>
            /// <param name="text"></param>
            /// <param name="value"></param>
            public ValidatePickerItem(string text, string value)
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
                declaringType: typeof(ValidatePickerItem),
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
                declaringType: typeof(ValidatePickerItem),
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
}
