using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// PickImageSwapItem
        /// </summary>
        public class PickImageSwapItem : View
        {
            /// <summary>
            /// Constructor PickImageSwapItem
            /// </summary>
            public PickImageSwapItem()
            {
                IsVisible = false;
            }

            /// <summary>
            /// Enter the Source of Image UnChosen.
            /// </summary>
            public static readonly BindableProperty ImageUnChosenProperty = BindableProperty.Create(
                propertyName: nameof(ImageUnChosen),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwapItem),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the Source of Image UnChosen.
            /// </summary>
            public string ImageUnChosen
            {
                get
                {
                    return (string)GetValue(ImageUnChosenProperty);
                }
                set
                {
                    SetValue(ImageUnChosenProperty, value);
                }
            }

            /// <summary>
            /// Enter the Source of Image Chosen.
            /// </summary>
            public static readonly BindableProperty ImageChosenProperty = BindableProperty.Create(
                propertyName: nameof(ImageChosen),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwapItem),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Enter the Source of Image Chosen.
            /// </summary>
            public string ImageChosen
            {
                get
                {
                    return (string)GetValue(ImageChosenProperty);
                }
                set
                {
                    SetValue(ImageChosenProperty, value);
                }
            }
                     
            /// <summary>
            /// Enter the Value
            /// </summary>
            public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                propertyName: nameof(Value),
                returnType: typeof(string),
                declaringType: typeof(PickImageSwapItem),
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
}
