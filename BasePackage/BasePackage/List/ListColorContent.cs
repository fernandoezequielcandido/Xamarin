using Xamarin.Forms;

namespace Laavor
{
    namespace List
    {
        /// <summary>
        /// Class ListColorContent
        /// </summary>
        public class ListColorContent : StackLayout
        {
            /// <summary>
            /// Return Index
            /// </summary>
            public int Index { get; private set; }

            /// <summary>
            /// Constructor of ListColorContent
            /// </summary>
            public ListColorContent()
            {
                base.IsVisible = false;
                this.IsVisible = false;
            }

            /// <summary>
            /// Set value of Index (Internal)
            /// </summary>
            /// <param name="key"></param>
            /// <param name="indexValue"></param>
            public void SetIndex(string key, int indexValue)
            {
                if (key == "__Laavor*+-")
                {
                    base.IsVisible = true;
                    this.IsVisible = true;

                    Index = indexValue;
                }
            }

            /// <summary>
            /// Content.
            /// </summary>
            public static readonly BindableProperty ContentProperty = BindableProperty.Create(
                propertyName: nameof(Content),
                returnType: typeof(StackLayout),
                declaringType: typeof(ListColorContent),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ContentChanged);

            /// <summary>
            /// Content.
            /// </summary>
            public StackLayout Content
            {
                get
                {
                    return (StackLayout)GetValue(ContentProperty);
                }
                set
                {
                    SetValue(ContentProperty, value);
                }
            }

            private static void ContentChanged(object bindable, object oldValue, object newValue)
            {
                ListColorContent boxContent = (ListColorContent)bindable;
                StackLayout copyContent = (StackLayout)newValue;
                boxContent.Children.Add(copyContent);
            }

            /// <summary>
            /// Content.
            /// </summary>
            public new static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
                propertyName: nameof(IsVisible),
                returnType: typeof(bool),
                declaringType: typeof(ListColorContent),
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
