using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Class GroupBoxContent works inside GroupBox
        /// </summary>
        public class GroupBoxContent : StackLayout
        {
            /// <summary>
            /// Constructor of GroupBoxContent
            /// </summary>
            public GroupBoxContent()
            {
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="isVisible"></param>
            public void SetContent(string hash, bool isVisible)
            {
                if (hash == "__Laavor*+-")
                {
                    base.IsVisible = isVisible;
                    this.IsVisible = isVisible;
                }
            }


            /// <summary>
            /// Content.
            /// </summary>
            public static readonly BindableProperty ContentProperty = BindableProperty.Create(
                propertyName: nameof(Content),
                returnType: typeof(View),
                declaringType: typeof(GroupBoxContent),
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
                GroupBoxContent contentBox = (GroupBoxContent)bindable;
                View copyContent = (View)newValue;
                contentBox.Children.Add(copyContent);
            }

            /// <summary>
            /// Content.
            /// </summary>
            public new static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
                propertyName: nameof(IsVisible),
                returnType: typeof(bool),
                declaringType: typeof(GroupBoxContent),
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
}
