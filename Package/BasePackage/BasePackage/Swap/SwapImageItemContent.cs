using Xamarin.Forms;

namespace Laavor
{
    namespace Swap
    {
        /// <summary>
        /// SwapImageItemContent
        /// </summary>
        public class SwapImageItemContent : StackLayout
        {
            private SwapImage swapImage;

            /// <summary>
            /// SwapImageItemContent
            /// </summary>
            public SwapImageItemContent()
            {
                Spacing = 0;
            }

            /// <summary>
            /// SetUser
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="father"></param>
            public void SetUser(string hash, SwapImage father)
            {
                if (hash == "__Laavor*+-")
                {
                    swapImage = father;
                }
            }

            /// <summary>
            /// Enter the image height.
            /// </summary>
            public static readonly BindableProperty PositionProperty = BindableProperty.Create(
                propertyName: nameof(Position),
                returnType: typeof(PositionContent),
                declaringType: typeof(SwapImageItemContent),
                defaultValue: PositionContent.RightBottom,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: PositionPropertyChanged);

            /// <summary>
            /// Enter the Position.
            /// </summary>
            public PositionContent Position
            {
                get
                {
                    return (PositionContent)GetValue(PositionProperty);
                }
                set
                {
                    SetValue(PositionProperty, value);
                }
            }

            private static void PositionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwapImageItemContent swap = (SwapImageItemContent)bindable;
                PositionContent posi = (PositionContent)newValue;
                swap.Position = posi;
            }
        }
    }
}
