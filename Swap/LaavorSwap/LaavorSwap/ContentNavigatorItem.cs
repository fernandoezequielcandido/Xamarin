using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LaavorSwap
{
    /// <summary>
    /// Class ContentNavigtorItem
    /// </summary>
    public class ContentNavigatorItem: StackLayout
    {
        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Constructor of ContentNavigatorItem
        /// </summary>
        public ContentNavigatorItem()
        {
            base.IsVisible = false;
            this.IsVisible = false;
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
        /// Content.
        /// </summary>
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(
            propertyName: nameof(Content),
            returnType: typeof(View),
            declaringType: typeof(ContentNavigatorItem),
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
            ContentNavigatorItem contentNavigatorItem = (ContentNavigatorItem)bindable;
            View copyContent = (View)newValue;
            contentNavigatorItem.Children.Add(copyContent);
        }

        /// <summary>
        /// Content.
        /// </summary>
        public new static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsVisible),
            returnType: typeof(bool),
            declaringType: typeof(ContentNavigatorItem),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ContentChanged);

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
