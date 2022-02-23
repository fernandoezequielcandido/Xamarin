using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorSwap
{
    /// <summary>
    /// Class ImageNavigatorItem
    /// </summary>
    public class ImageNavigatorItem: View
    {
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; private set; }

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
        /// Enter the Image.
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(ImageNavigatorItem),
            defaultValue: "none_Laavor",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the Image.
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
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(ImageNavigator),
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
        /// Constructor of ImageNavigatorItem
        /// </summary>
        public ImageNavigatorItem() : base()
        {

        }

    }
}
