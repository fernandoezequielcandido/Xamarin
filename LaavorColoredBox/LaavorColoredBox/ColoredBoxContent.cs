using Xamarin.Forms;

namespace LaavorColoredBox
{
    /// <summary>
    /// Class ColoredBoxContent
    /// </summary>
    public class ColoredBoxContent : StackLayout
    {
        /// <summary>
        /// Return Index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Constructor of ColoredBoxContent
        /// </summary>
        public ColoredBoxContent()
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
            if (key == "fernandoLaavor77+*_87WW")
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
            declaringType: typeof(ColoredBoxContent),
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
            ColoredBoxContent boxContent = (ColoredBoxContent)bindable;
            StackLayout copyContent = (StackLayout)newValue;
            boxContent.Children.Add(copyContent);
        }

        /// <summary>
        /// Content.
        /// </summary>
        public new static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsVisible),
            returnType: typeof(bool),
            declaringType: typeof(ColoredBoxContent),
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
