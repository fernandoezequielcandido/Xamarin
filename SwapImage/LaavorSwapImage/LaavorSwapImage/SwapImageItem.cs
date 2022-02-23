using Xamarin.Forms;

namespace LaavorSwapImage
{
    /// <summary>
    /// Class SwapImageItem
    /// </summary>
    public class SwapImageItem: StackLayout
    {
        /// <summary>
        /// Internal
        /// </summary>
        public bool UseSpecificHeight { get; private set; } = false;

        /// <summary>
        /// Internal
        /// </summary>
        public bool UseSpecificWidth { get; private set; } = false;

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Content if use. Too set needs Children.Add();
        /// </summary>
        public View Content { get; private set; }
        
        /// <summary>
        /// Constructor of SwapImageItem
        /// </summary>
        public SwapImageItem() : base()
        {
            Content = null;
            Spacing = 0;
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
        /// Enter the image height.
        /// </summary>
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageHeight),
            returnType: typeof(double),
            declaringType: typeof(SwapImageItem),
            defaultValue: 200.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageHeightPropertyChanged);

        /// <summary>
        /// Enter the image height.
        /// </summary>
        public double ImageHeight
        {
            get
            {
                return (double)GetValue(ImageHeightProperty);
            }
            set
            {
                SetValue(ImageHeightProperty, value);
            }
        }

        private static void ImageHeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapImageItem swapImageItem = (SwapImageItem)bindable;
            swapImageItem.UseSpecificHeight = true;
        }

        /// <summary>
        /// Enter the image width.
        /// </summary>
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
            propertyName: nameof(ImageWidth),
            returnType: typeof(double),
            declaringType: typeof(SwapImageItem),
            defaultValue: 200.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageWidthPropertyChanged);

        /// <summary>
        /// Enter the image width.
        /// </summary>
        public double ImageWidth
        {
            get
            {
                return (double)GetValue(ImageWidthProperty);
            }
            set
            {
                SetValue(ImageWidthProperty, value);
            }
        }

        private static void ImageWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapImageItem swapImageItem = (SwapImageItem)bindable;
            swapImageItem.UseSpecificWidth = true;
        }

        /// <summary>
        /// Enter the Image.
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(SwapImageItem),
            defaultValue: "",
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
            declaringType: typeof(SwapImageItem),
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
        /// Internal
        /// </summary>
        /// <param name="child"></param>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(SwapImageItemContent))
            {
                if (Content == null)
                {
                    Content = (SwapImageItemContent)child;
                }
                else
                {
                    throw new System.Exception("Can insert content one time");
                }
            }
        }

    }
}
