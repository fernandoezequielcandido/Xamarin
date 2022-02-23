using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorSwapImage
{
    /// <summary>
    /// Class SwapImage
    /// </summary>
    public class SwapImage : StackLayout
    {
        /// <summary>
        /// Returns current source.
        /// </summary>
        public bool CurrentSource { get; private set; }

        /// <summary>
        /// Returns current index of image, start in 0.
        /// </summary>
        public int CurrentIndex { get; private set; }

        private int currentIndex;

        private LaavorImageSwap imageReference;

        private FontAttributes currentFontType = FontAttributes.None;

        private List<SwapImageItem> listItems;

        private LaavorLabelSwap labelTextReference;
        private AbsoluteLayout absoluteToImage;
        private StackLayout stackContent;

        private PositionContent currentPosition = PositionContent.LeftBottom;

        /// <summary>
        /// Event called when selected any swap
        /// </summary>
        public event EventHandler OnSwap;

        /// <summary>
        /// Constructor of SwapImage        
        /// </summary>
        public SwapImage() : base()
        {
            InitializeComponents();
            this.Spacing = 0;
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Vertical;
            HorizontalOptions = LayoutOptions.Center;
            InitAll();
        }

        private void InitAll()
        {
            this.Spacing = 0;
            Children.Clear();

            listItems = new List<SwapImageItem>();
            imageReference = new LaavorImageSwap();

            absoluteToImage = new AbsoluteLayout();
            
            stackContent = new StackLayout();
            stackContent.Spacing = 0;

            imageReference.WidthRequest = ImageWidth;
            imageReference.HeightRequest = ImageHeight;
            imageReference.MinimumWidthRequest = ImageWidth;
            imageReference.MinimumHeightRequest = ImageHeight;
            imageReference.VerticalOptions = LayoutOptions.Center;
            imageReference.HorizontalOptions = LayoutOptions.Center;
            imageReference.Aspect = Aspect.AspectFill;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Touched;
            imageReference.GestureRecognizers.Add(tapGestureRecognizer);

            imageReference.Source = "";

            AbsoluteLayout.SetLayoutFlags(stackContent, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(stackContent, new Rectangle(GetX(currentPosition), GetY(currentPosition), -1, -1));
           
            absoluteToImage.VerticalOptions = LayoutOptions.CenterAndExpand;

            Children.Add(absoluteToImage);

            labelTextReference = new LaavorLabelSwap();
            labelTextReference.IsVisible = false;
            labelTextReference.FontSize = FontSize;
            labelTextReference.TextColor = TextColor;
            labelTextReference.FontFamily = FontFamily;
            labelTextReference.FontAttributes = FontType;
            labelTextReference.GestureRecognizers.Add(tapGestureRecognizer);
            labelTextReference.HorizontalOptions = LayoutOptions.Center;

            Children.Add(labelTextReference);

            this.Margin = new Thickness(5, 5, 5, 5);
        }

        // left TOP 0.03 0.03
        // left midle 0.03 0.5
        // left bottom 0.03 0.93

        // right top 0.93 0.03
        // right midle 0.93 0.5
        // right bottom 0.93 0.93

        // center top 0.5 0.03
        // center midle 0.5 0.5
        // center bottom 0.5 0.93

        private double GetX(PositionContent p)
        {
            if (p == PositionContent.CenterBottom || p == PositionContent.CenterMidle || p == PositionContent.CenterTop)
            {
                return 0.5;
            }
            else if (p == PositionContent.LeftBottom || p == PositionContent.LeftMidle || p == PositionContent.LeftTop)
            {
                return 0.03;
            }
            else
            {
                return 0.93;
            }
        }

        private double GetY(PositionContent p)
        {
            if (p == PositionContent.CenterTop || p == PositionContent.LeftTop || p == PositionContent.RightTop)
            {
                return 0.03;
            }
            else if (p == PositionContent.CenterMidle || p == PositionContent.LeftMidle || p == PositionContent.RightMidle)
            {
                return 0.5;
            }
            else
            {
                return 0.93;
            }
        }

        /// <summary>
        /// Enter the Position.
        /// </summary>
        [Bindable(true)]
        public PositionContent Position
        {
            get
            {
                return currentPosition;
            }
            set
            {
                currentPosition = value;
                PositionPropertyChanged();
            }
        }

        private void PositionPropertyChanged()
        {
            AbsoluteLayout.SetLayoutBounds(stackContent, new Rectangle(GetX(currentPosition), GetY(currentPosition), -1, -1));
        }

        /// <summary>
        /// Enter the image height.
        /// </summary>
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageHeight),
            returnType: typeof(double),
            declaringType: typeof(SwapImage),
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
            SwapImage swap = (SwapImage)bindable;
            double imageHeight = (double)newValue;
            if(swap.imageReference != null)
            {
                swap.imageReference.HeightRequest = imageHeight;
            }
        }

        /// <summary>
        /// Enter the image width.
        /// </summary>
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
            propertyName: nameof(ImageWidth),
            returnType: typeof(double),
            declaringType: typeof(SwapImage),
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
            SwapImage swap = (SwapImage)bindable;
            double imageWidth = (double)newValue;
            if (swap.imageReference != null)
            {
                swap.imageReference.WidthRequest = imageWidth;
                swap.WidthRequest = imageWidth;
                swap.MinimumWidthRequest = imageWidth;
            }      
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(SwapImage),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        private static void FontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapImage swapImage = (SwapImage)bindable;
            double copyFontSize = (double)newValue;

            if (swapImage.labelTextReference != null)
            {
                swapImage.labelTextReference.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(Color),
         declaringType: typeof(SwapImage),
         defaultValue: Color.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: TextColorPropertyChanged);

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        private static void TextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapImage swapImage = (SwapImage)bindable;
            Color copyTextColor = (Color)newValue;

            if (swapImage.labelTextReference != null)
            {
                swapImage.labelTextReference.TextColor = copyTextColor;
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(SwapImage),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyPropertyChanged);

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        private static void FontFamilyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapImage swapImage = (SwapImage)bindable;
            string copyFontFamily = (string)newValue;

            if (swapImage.labelTextReference != null)
            {
                swapImage.labelTextReference.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the fonttype (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontType
        {
            get
            {
                return currentFontType;
            }
            set
            {
                FontTypePropertyChanged(this, currentFontType, value);
                currentFontType = value;
            }
        }

        private static void FontTypePropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            SwapImage swapImage = (SwapImage)bindable;

            if (swapImage.labelTextReference != null)
            {
                swapImage.labelTextReference.FontAttributes = newValue;
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            
            if (child.GetType() == typeof(SwapImageItem))
            {
                SwapImageItem item = (SwapImageItem)child;
                item.setIndex("wertyafff7777_____784", currentIndex);

                if (currentIndex == 0)
                {
                    imageReference.Index = currentIndex;
                    imageReference.Source = item.Image;

                    if(!string.IsNullOrEmpty(item.Text))
                    {
                        labelTextReference.Text = item.Text;
                        labelTextReference.IsVisible = true;
                    }
                    else
                    {
                        labelTextReference.IsVisible = false;
                    }

                    labelTextReference.setIndex("wertyafff7777_____784", currentIndex);
                }

                if (item.UseSpecificWidth)
                {
                    imageReference.WidthRequest = item.ImageWidth;
                }
                else
                {
                    imageReference.WidthRequest = ImageWidth;
                }

                if (item.UseSpecificHeight)
                {
                    imageReference.HeightRequest = item.ImageHeight;
                }
                else
                {
                    imageReference.HeightRequest = ImageHeight;
                }
                
                absoluteToImage.Children.Add(imageReference);
                absoluteToImage.Children.Add(stackContent);
                
                if (item.Content != null)
                {
                    (item.Content as SwapImageItemContent).SetUser("javYUty_7124_*-+++ahhhhhhhhaaall", this);

                    if (currentIndex == 0)
                    {
                        item.Content.IsVisible = true;
                    }
                    else
                    {
                        item.Content.IsVisible = false;
                    }
                    stackContent.Children.Add(item.Content);
                    absoluteToImage.Children.Add(stackContent);
                }

                listItems.Add(item);
                currentIndex++;
            }
        }

        private void Touched(object sender, EventArgs e)
        {
            int index;

            if (sender.GetType() == typeof(LaavorImageSwap))
            {
                var itemUser = (LaavorImageSwap)sender;
                index = itemUser.Index;
            }
            else if (sender.GetType() == typeof(LaavorLabelSwap))
            {
                var itemUser = (LaavorLabelSwap)sender;
                index = itemUser.Index;
            }
            else
            {
                return;
            }

            if (listItems[index].Content != null)
            {
                listItems[index].Content.IsVisible = false;
            }

            SwapImageItem item;
            if ((index + 1) >= listItems.Count)
            {
                item = listItems[0];
                imageReference.Source = item.Image;
                imageReference.Index = 0;
            }
            else
            {
                item = listItems[index + 1];
                imageReference.Source = item.Image;
                imageReference.Index = index + 1;
            }

            if (item.UseSpecificWidth)
            {
                imageReference.WidthRequest = item.ImageWidth;
            }
            else
            {
                imageReference.WidthRequest = ImageWidth;
            }

            if (item.UseSpecificHeight)
            {
                imageReference.HeightRequest = item.ImageHeight;
            }
            else
            {
                imageReference.HeightRequest = ImageHeight;
            }

            stackContent.Children.Clear();
            if (item.Content != null)
            {
                stackContent.Children.Add(item.Content);
                item.Content.IsVisible = true;
                AbsoluteLayout.SetLayoutBounds(stackContent, new Rectangle(GetX((item.Content as SwapImageItemContent).Position), GetY((item.Content as SwapImageItemContent).Position), -1, -1));
            }

            if (!string.IsNullOrEmpty(item.Text))
            {
                labelTextReference.Text = item.Text;
                labelTextReference.IsVisible = true;
            }
            else
            {
                labelTextReference.IsVisible = false;
            }

            CurrentIndex = item.Index;

            labelTextReference.setIndex("wertyafff7777_____784", CurrentIndex);

            if (OnSwap != null)
            {
                OnSwap?.Invoke(sender, e);
            }
        }
    }
}
