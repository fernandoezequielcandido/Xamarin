using System;
using Xamarin.Forms;

namespace LaavorRatingSwap
{
    /// <summary>
    /// Class SwapImageSimple
    /// </summary>
    public class SwapImageSimple: StackLayout
    {
        /// <summary>
        /// Returns if first image is selected.
        /// </summary>
        public bool FirstIsSelected { get; private set; }

        private bool copyBlockSwap;

        /// <summary>
        /// Event called when selected any swap
        /// </summary>
        public event EventHandler OnSelect;

        /// <summary>
        /// Constructor of SwapImageSimple
        /// </summary>
        public SwapImageSimple() : base()
        {
            FirstIsSelected = true;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Horizontal;
            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();

            LaavorImage image = new LaavorImage();

            image.WidthRequest = ImageWidth;
            image.HeightRequest = ImageHeight;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Image_Clicked; 
            image.GestureRecognizers.Add(tapGestureRecognizer);
            
            image.Source = FirstImage;
            image.IsSelected = true;

            Children.Add(image);

            copyBlockSwap = false;
        }

        /// <summary>
        /// Clears the swap value and shows everything in its initial state.
        /// </summary>
        public void ResetAll()
        {
            InitAll();
        }

        /// <summary>
        /// Property to inform if block swap, also leave the swap unedited.
        /// </summary>
        public static readonly BindableProperty BlockSwapProperty = BindableProperty.Create(
                propertyName: nameof(BlockSwap),
                returnType: typeof(bool),
                declaringType: typeof(SwapImageSimple),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Property to inform if block swap, also leave the swap unedited.
        /// </summary>
        public bool BlockSwap
        {
            get
            {
                return (bool)GetValue(BlockSwapProperty);
            }
            set
            {
                SetValue(BlockSwapProperty, value);
            }
        }

        /// <summary>
        /// Enter the first Image.
        /// </summary>
        public static readonly BindableProperty FirstImageProperty = BindableProperty.Create(
            propertyName: nameof(FirstImage),
            returnType: typeof(string),
            declaringType: typeof(SwapImageSimple),
            defaultValue: "none_Laavor",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FirstImagePropertyChanged);

        /// <summary>
        /// Enter the first Image.
        /// </summary>
        public string FirstImage
        {
            get
            {
                return (string)GetValue(FirstImageProperty);
            }
            set
            {
                SetValue(FirstImageProperty, value);
            }
        }

        private static void FirstImagePropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapImageSimple swap = (SwapImageSimple)bindable;
            string copyFirstImage = (string)newValue;

            for (int iCh = 0; iCh < swap.Children.Count; iCh++)
            {
                LaavorImage image = (LaavorImage)swap.Children[iCh];
                image.Source = copyFirstImage;
            }
        }

        /// <summary>
        /// Enter the second Image.
        /// </summary>
        public static readonly BindableProperty SecondImageProperty = BindableProperty.Create(
            propertyName: nameof(SecondImage),
            returnType: typeof(string),
            declaringType: typeof(SwapImageSimple),
            defaultValue: "none_Laavor",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the second Image.
        /// </summary>
        public string SecondImage
        {
            get
            {
                return (string)GetValue(SecondImageProperty);
            }
            set
            {
                SetValue(SecondImageProperty, value);
            }
        }

        /// <summary>
        /// Enter the image height.
        /// </summary>
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageHeight),
            returnType: typeof(double),
            declaringType: typeof(SwapImageSimple),
            defaultValue: 20.0,
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
            SwapImageSimple swap = (SwapImageSimple)bindable;
            double imageHeight = (double)newValue;
            for (int iCh = 0; iCh < swap.Children.Count; iCh++)
            {
                LaavorImage image = (LaavorImage)swap.Children[iCh];
                image.HeightRequest = imageHeight;
            }
        }

        /// <summary>
        /// Enter the image width.
        /// </summary>
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
            propertyName: nameof(ImageWidth),
            returnType: typeof(double),
            declaringType: typeof(SwapImageSimple),
            defaultValue: 20.0,
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
            SwapImageSimple swap = (SwapImageSimple)bindable;
            double imageWidth = (double)newValue;
            for (int iCh = 0; iCh < swap.Children.Count; iCh++)
            {
                LaavorImage image = (LaavorImage)swap.Children[iCh];
                image.WidthRequest = imageWidth;
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() != typeof(LaavorImage))
            {
                Children.RemoveAt(Children.Count - 1);
            }
        }

        private void Image_Clicked(object sender, EventArgs e)
        {
            var imageSender = (LaavorImage)sender;

            if(!copyBlockSwap)
            {
                if (imageSender.IsSelected)
                {
                    (Children[0] as LaavorImage).Source = SecondImage;
                    (Children[0] as LaavorImage).IsSelected = false;
                    FirstIsSelected = false;
                }
                else
                {
                    (Children[0] as LaavorImage).Source = FirstImage;
                    (Children[0] as LaavorImage).IsSelected = true;
                    FirstIsSelected = true;
                }

                if (BlockSwap)
                {
                    copyBlockSwap = BlockSwap;
                }
            }

            OnSelect?.Invoke(sender, e);
        }
    }
}
