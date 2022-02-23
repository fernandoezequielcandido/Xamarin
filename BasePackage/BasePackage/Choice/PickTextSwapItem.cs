using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class ChoiceTextShiftItem
        /// </summary>
        public class PickTextSwapItem: View
        {
            /// <summary>
            /// Constructor of ChoiceTextShiftItem
            /// </summary>
            public PickTextSwapItem()
            {
                IsVisible = false;
            }

            /// <summary>
            /// Enter the Text Chosen
            /// </summary>
            public static readonly BindableProperty TextChosenProperty = BindableProperty.Create(
                propertyName: nameof(TextChosen),
                returnType: typeof(string),
                declaringType: typeof(PickTextSwapItem),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the Text Chosen
            /// </summary>
            public string TextChosen
            {
                get
                {
                    return (string)GetValue(TextChosenProperty);
                }
                set
                {
                    SetValue(TextChosenProperty, value);
                }
            }

            /// <summary>
            /// Enter the Text UnChosen
            /// </summary>
            public static readonly BindableProperty TextUnChosenProperty = BindableProperty.Create(
                propertyName: nameof(TextUnChosen),
                returnType: typeof(string),
                declaringType: typeof(PickTextSwapItem),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the Text UnChosen
            /// </summary>
            public string TextUnChosen
            {
                get
                {
                    return (string)GetValue(TextUnChosenProperty);
                }
                set
                {
                    SetValue(TextUnChosenProperty, value);
                }
            }

            /// <summary>
            /// Enter the Value
            /// </summary>
            public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                propertyName: nameof(Value),
                returnType: typeof(string),
                declaringType: typeof(PickTextSwapItem),
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
            /// Enter the width
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(PickTextSwapItem),
                defaultValue: -1.0,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the width
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
            /// Enter the Height
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(PickTextSwapItem),
                defaultValue: -1.0,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the Height
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
        }
    }
}
