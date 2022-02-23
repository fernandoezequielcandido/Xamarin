using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorCollapseBox
{
    /// <summary>
    /// Class ContentBox 
    /// </summary>
    public class ContentBox : StackLayout
    {
        /// <summary>
        /// Constructor of ContentBox
        ///</summary>
        public ContentBox()
        {
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="hash"></param>
        public void SetContent(string hash)
        {
            if (hash == "VisibleLL4488*-+++kmasdflaavor___")
            {
                base.IsVisible = true;
                this.IsVisible = true;
            }
            else if (hash == "InvisiblekktyRE35__00.)*+-////]]]}}}}}")
            {
                base.IsVisible = false;
                this.IsVisible = false;
            }
        }


        /// <summary>
        /// Content.
        /// </summary>
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(
            propertyName: nameof(Content),
            returnType: typeof(View),
            declaringType: typeof(ContentBox),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ContentChanged);

        /// <summary>
        /// Content.
        /// </summary>
        public View Content
        {
            get
            {
                return (View)GetValue(ContentProperty);
            }
            set
            {
                SetValue(ContentProperty, value);
            }
        }

        private static void ContentChanged(object bindable, object oldValue, object newValue)
        {
            ContentBox contentBox = (ContentBox)bindable;
            View copyContent = (View)newValue;
            contentBox.Children.Add(copyContent);
        }

        /// <summary>
        /// Content.
        /// </summary>
        public new static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsVisible),
            returnType: typeof(bool),
            declaringType: typeof(ContentBox),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Content.
        /// </summary>
        public new bool IsVisible
        {
            get
            {
                return (bool)GetValue(IsVisibleProperty);
            }
            set
            {
                //SetValue(ContentProperty, value);
            }
        }
    }
}
