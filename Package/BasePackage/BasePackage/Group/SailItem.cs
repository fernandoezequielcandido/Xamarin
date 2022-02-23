using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Class SailItem
        /// </summary>
        public class SailItem : StackLayout
        {
            /// <summary>
            /// Index
            /// </summary>
            public int Index { get; private set; }

            /// <summary>
            /// Constructor of GroupSailItem
            /// </summary>
            public SailItem()
            {
                base.IsVisible = false;
                this.IsVisible = false;
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="visible"></param>
            public void SetContent(string hash, bool visible)
            {
                if (hash == "__Laavor*+-")
                {
                    if (visible)
                    {
                        base.IsVisible = true;
                        this.IsVisible = true;
                    }
                    else
                    {
                        base.IsVisible = false;
                        this.IsVisible = false;
                    }
                }
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="key"></param>
            /// <param name="index"></param>
            public void setIndex(string key, int index)
            {
                if (key == "__Laavor*+-")
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
                declaringType: typeof(SailItem),
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
                SailItem contentNavigatorItem = (SailItem)bindable;
                View copyContent = (View)newValue;
                contentNavigatorItem.Children.Add(copyContent);
            }

            /// <summary>
            /// Content.
            /// </summary>
            public new static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
                propertyName: nameof(IsVisible),
                returnType: typeof(bool),
                declaringType: typeof(SailItem),
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
}
