﻿using Xamarin.Forms;

namespace Laavor
{
    namespace Swap
    {
        /// <summary>
        /// Class SlotContentImage
        /// </summary>
        public class SwapSlotContentImage : View
        {
            /// <summary>
            /// Index
            /// </summary>
            public int Index { get; private set; }

            /// <summary>
            /// Constructor of SwapSlotContentImage
            /// </summary>
            public SwapSlotContentImage()
            {
                IsVisible = false;
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="index"></param>
            public void InformIndex(string hash, int index)
            {
                if (hash == "__Laavor*+-")
                {
                    Index = index;
                }
            }

            /// <summary>
            /// Enter the Value.
            /// </summary>
            public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                propertyName: nameof(Value),
                returnType: typeof(string),
                declaringType: typeof(SwapSlotContentImage),
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

            /// <summary>
            /// Enter the image.
            /// </summary>
            public static readonly BindableProperty ImageProperty = BindableProperty.Create(
                propertyName: nameof(Image),
                returnType: typeof(string),
                declaringType: typeof(SwapSlotContentImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the image.
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
        }
    }
}