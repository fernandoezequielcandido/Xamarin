using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace LaavorSwap
{
    /// <summary>
    /// Class ImageNavigator
    /// </summary>
    public class ImageNavigator : StackLayout
    {
        /// <summary>
        /// Returns current string.
        /// </summary>
        public string CurrentImage { get; private set; }

        /// <summary>
        /// Returns current index of image, start in 0.
        /// </summary>
        public int CurrentIndex { get; private set; }

        private int currentIndex;

        private LaavorImageSwap imageReference;

        private LaavorControl laavorControl;

        private Label labelTextReference;

        private LaavorImageSwap imageArrowLeftReference;
        private LaavorImageSwap imageArrowRightReference;

        private StackLayout dataItems;
        private StackLayout stackLeft;
        private StackLayout stackCenter;
        private StackLayout stackInsideCenter;
        private StackLayout stackRight;
        private Frame frameReference;

        private const int arrowHeight = 70;
        private const int arrowWidth = 40;

        private DesignType currentDesignType = DesignType.Filled;
        private ColorUI currentColorUI = ColorUI.Black;

        private FontAttributes currentFontType = FontAttributes.None;

        private List<ImageNavigatorItem> listItems;

        /// <summary>
        /// Event called when selected Change Image
        /// </summary>
        public event EventHandler ChangeImage;

        /// <summary>
        /// Event called when Image or Text are clicked
        /// </summary>
        public event EventHandler Clicked;

        /// <summary>
        /// Constructor of ImageNavigator        
        /// </summary>
        public ImageNavigator() : base()
        {
            InitializeComponents();
            this.Spacing = 0;
        }

        private void InitializeComponents()
        {
            laavorControl = new LaavorControl("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl");

            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.Center;
            InitAll();
        }

        private TapGestureRecognizer GetClickLeftAnimation()
        {
            TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
            animationTapImg.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageArrowLeftReference.ScaleTo(0.80, 140, Easing.Linear);
                    await imageArrowLeftReference.ScaleTo(1, 140, Easing.Linear);
                }
                catch { }
            };

            return animationTapImg;
        }

        private TapGestureRecognizer GetClickRightAnimation()
        {
            TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
            animationTapImg.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageArrowRightReference.ScaleTo(0.80, 140, Easing.Linear);
                    await imageArrowRightReference.ScaleTo(1, 140, Easing.Linear);
                }
                catch { }
            };

            return animationTapImg;
        }

        private void InitAll()
        {
            Children.Clear();

            dataItems = new StackLayout();
            this.Orientation = StackOrientation.Vertical;
            dataItems.Orientation = StackOrientation.Horizontal;
            dataItems.HorizontalOptions = LayoutOptions.Center;
            dataItems.Spacing = 0;

            listItems = new List<ImageNavigatorItem>();




            imageArrowLeftReference = new LaavorImageSwap();
            imageArrowLeftReference.VerticalOptions = LayoutOptions.Center;
            imageArrowLeftReference.Aspect = Aspect.Fill;
            imageArrowLeftReference.WidthRequest = arrowWidth;
            imageArrowLeftReference.HeightRequest = arrowHeight;
            imageArrowLeftReference.GestureRecognizers.Add(GetClickLeftAnimation());
            imageArrowLeftReference.GestureRecognizers.Add(GetClickLeft());
            imageArrowLeftReference.Opacity = 0.3;

            byte[] buttonBytesArrowLeft = Convert.FromBase64String(laavorControl.GetItemArrow(currentDesignType, currentColorUI, Side.Left, "__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl"));
            var streamButtonLeft = new System.IO.MemoryStream(buttonBytesArrowLeft);
            imageArrowLeftReference.Source = ImageSource.FromStream(() => streamButtonLeft);

            stackLeft = new StackLayout();
            stackLeft.Spacing = 0;
            stackLeft.HorizontalOptions = LayoutOptions.Center;
            stackLeft.Orientation = StackOrientation.Vertical;
            stackLeft.VerticalOptions = LayoutOptions.Center;
            stackLeft.Children.Add(imageArrowLeftReference);




            imageReference = new LaavorImageSwap();
            imageReference.WidthRequest = ImageWidth;
            imageReference.HeightRequest = ImageHeight;
            imageReference.MinimumWidthRequest = ImageWidth;
            imageReference.MinimumHeightRequest = ImageHeight;
            imageReference.Margin = new Thickness(-10, -17, -10, -17);        
            imageReference.VerticalOptions = LayoutOptions.Center;
            imageReference.HorizontalOptions = LayoutOptions.Center;
            imageReference.Aspect = Aspect.Fill;
            imageReference.Source = "";
            imageReference.GestureRecognizers.Add(GetClickImageLabel());



            frameReference = new Frame();
            frameReference.BorderColor = Color.Gray;
            frameReference.VerticalOptions = LayoutOptions.Start;
            frameReference.BackgroundColor = Color.Transparent;
           
            stackCenter = new StackLayout();
            stackCenter.Spacing = 0;
            stackCenter.Margin = new Thickness(0.05, 0, 0.05, 0);
            stackCenter.HorizontalOptions = LayoutOptions.Center;
            stackCenter.Orientation = StackOrientation.Vertical;

            labelTextReference = new Label();
            labelTextReference.HorizontalOptions = LayoutOptions.Center;
            labelTextReference.Margin = new Thickness(0, 17, 0, -15);
            labelTextReference.IsVisible = false;
            labelTextReference.GestureRecognizers.Add(GetClickImageLabel());

            stackInsideCenter = new StackLayout();
            stackInsideCenter.Orientation = StackOrientation.Vertical;
            stackInsideCenter.Children.Add(imageReference);
            stackInsideCenter.Children.Add(labelTextReference);
            stackInsideCenter.Spacing = 0;

            frameReference.Content = stackInsideCenter;

            stackCenter.Children.Add(frameReference);




            imageArrowRightReference = new LaavorImageSwap();
            imageArrowRightReference.VerticalOptions = LayoutOptions.Center;
            imageArrowRightReference.Aspect = Aspect.Fill;
            imageArrowRightReference.WidthRequest = arrowWidth;
            imageArrowRightReference.HeightRequest = arrowHeight;
            imageArrowRightReference.Opacity = 0.3;
            imageArrowRightReference.GestureRecognizers.Add(GetClickRightAnimation());
            imageArrowRightReference.GestureRecognizers.Add(GetClickRight());

            byte[] buttonBytesArrowRight = Convert.FromBase64String(laavorControl.GetItemArrow(currentDesignType, currentColorUI, Side.Right, "__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl"));
            var streamButtonRight = new System.IO.MemoryStream(buttonBytesArrowRight);
            imageArrowRightReference.Source = ImageSource.FromStream(() => streamButtonRight);

            stackRight = new StackLayout();
            stackRight.Spacing = 0;
            stackRight.HorizontalOptions = LayoutOptions.Center;
            stackRight.Orientation = StackOrientation.Vertical;
            stackRight.VerticalOptions = LayoutOptions.Center;
            stackRight.Children.Add(imageArrowRightReference);

            dataItems.Children.Add(stackLeft);
            dataItems.Children.Add(stackCenter);
            dataItems.Children.Add(stackRight);

            Children.Add(dataItems);
        }

        private void Click_Event(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        /// <summary>
        /// Change current item/index. The index must exist, otherwise it does nothing
        /// Does not call the ChangeImage event
        /// </summary>
        /// <param name="index"></param>
        public void NavigateToIndex(int index)
        {
            try
            {
                if (index >= listItems.Count || index < 0)
                {
                    return;
                }

                ImageNavigatorItem item = listItems[index];
                imageReference.Source = item.Image;
                imageReference.Index = item.Index;

                if (index == 0)
                {
                    imageArrowLeftReference.Opacity = 0.3;
                    imageArrowRightReference.Opacity = 1;
                }
                else if (index == (listItems.Count - 1))
                {
                    imageArrowLeftReference.Opacity = 1;
                    imageArrowRightReference.Opacity = 0.3;
                }
                else
                {
                    imageArrowLeftReference.Opacity = 1;
                    imageArrowRightReference.Opacity = 1;
                }

                labelTextReference.Text = item.Text;

                imageArrowRightReference.Index = item.Index;
                imageArrowLeftReference.Index = item.Index;

                CurrentIndex = item.Index;
                CurrentImage = item.Image;
            }
            catch { }
        }

        private void Left_Clicked(object sender, EventArgs e)
        {
            var itemUser = (LaavorImageSwap)sender;

            try
            {
                ImageNavigatorItem item;
                if (itemUser.Index == 1)
                {
                    item = listItems[0];
                    imageReference.Source = item.Image;
                    imageReference.Index = item.Index;
                    imageArrowLeftReference.Opacity = 0.3;
                }
                else if (itemUser.Index == 0)
                {
                    return;
                }
                else
                {
                    imageArrowLeftReference.Opacity = 1;
                    item = listItems[itemUser.Index - 1];
                    imageReference.Source = item.Image;
                    imageReference.Index = item.Index;
                }

                if (item.Index < (listItems.Count - 1))
                {
                    imageArrowRightReference.Opacity = 1;
                }

                labelTextReference.Text = item.Text;

                imageArrowRightReference.Index = item.Index;
                imageArrowLeftReference.Index = item.Index;

                CurrentIndex = item.Index;
                CurrentImage = item.Image;

                ChangeImage?.Invoke(this, e);
            }
            catch
            { }
        }

        private void Right_Clicked(object sender, EventArgs e)
        {
            var itemUser = (LaavorImageSwap)sender;

            try
            {
                ImageNavigatorItem item;
                if (itemUser.Index == (listItems.Count - 2))
                {
                    item = listItems[itemUser.Index + 1];
                    imageReference.Source = item.Image;
                    imageReference.Index = item.Index;
                    imageArrowRightReference.Opacity = 0.3;
                }
                else if (itemUser.Index == (listItems.Count - 1))
                {
                    return;
                }
                else
                {
                    imageArrowRightReference.Opacity = 1;
                    item = listItems[itemUser.Index + 1];
                    imageReference.Source = item.Image;
                    imageReference.Index = item.Index;
                }

                if (item.Index > 0)
                {
                    imageArrowLeftReference.Opacity = 1;
                }

                labelTextReference.Text = item.Text;

                imageArrowRightReference.Index = item.Index;
                imageArrowLeftReference.Index = item.Index;

                CurrentIndex = item.Index;
                CurrentImage = item.Image;

                ChangeImage?.Invoke(this, e);
            }
            catch
            {}
        }

        private TapGestureRecognizer GetClickImageLabel()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Click_Event;
            return tapGestureRecognizer;
        }

        private TapGestureRecognizer GetClickLeft()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Left_Clicked;
            return tapGestureRecognizer;
        }

        private TapGestureRecognizer GetClickRight()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Right_Clicked;
            return tapGestureRecognizer;
        }

        /// <summary>
        /// Enter the image height.
        /// </summary>
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageHeight),
            returnType: typeof(double),
            declaringType: typeof(ImageNavigator),
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
            ImageNavigator navigator = (ImageNavigator)bindable;
            double imageHeight = (double)newValue;
            if (navigator.imageReference != null)
            {
                navigator.imageReference.HeightRequest = imageHeight;
                navigator.imageReference.MinimumHeightRequest = imageHeight;
            }
        }

        /// <summary>
        /// Enter the image width.
        /// </summary>
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
            propertyName: nameof(ImageWidth),
            returnType: typeof(double),
            declaringType: typeof(ImageNavigator),
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
            ImageNavigator navigator = (ImageNavigator)bindable;
            double imageWidth = (double)newValue;
            if (navigator.imageReference != null)
            {
                navigator.imageReference.WidthRequest = imageWidth;
                navigator.imageReference.MinimumWidthRequest = imageWidth;
            }
        }

        /// <summary>
        /// Set if is ColorUI
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUI
        {
            get
            {
                return currentColorUI;
            }
            set
            {
                ColorUIPropertyChanged(this, currentColorUI, value);
                currentColorUI = value;
            }
        }

        private static void ColorUIPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ImageNavigator imageNavigator = (ImageNavigator)bindable;
            ColorUI copyColorUI = (ColorUI)newValue;

            byte[] buttonBytesArrowRight = Convert.FromBase64String(imageNavigator.laavorControl.GetItemArrow(imageNavigator.currentDesignType, copyColorUI, Side.Right, "__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl"));
            var streamButtonRight = new System.IO.MemoryStream(buttonBytesArrowRight);
            imageNavigator.imageArrowRightReference.Source = ImageSource.FromStream(() => streamButtonRight);

            byte[] buttonBytesArrowLeft = Convert.FromBase64String(imageNavigator.laavorControl.GetItemArrow(imageNavigator.currentDesignType, copyColorUI, Side.Left, "__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl"));
            var streamButtonLeft = new System.IO.MemoryStream(buttonBytesArrowLeft);
            imageNavigator.imageArrowLeftReference.Source = ImageSource.FromStream(() => streamButtonLeft);
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ImageNavigator),
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
            ImageNavigator imageNavigator = (ImageNavigator)bindable;
            double copyFontSize = (double)newValue;

            imageNavigator.labelTextReference.FontSize = copyFontSize;
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(Color),
         declaringType: typeof(ImageNavigator),
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
            ImageNavigator imageNavigator = (ImageNavigator)bindable;
            Color copyTextColor = (Color)newValue;

            imageNavigator.labelTextReference.TextColor = copyTextColor;
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(ImageNavigator),
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
            ImageNavigator imageNavigator = (ImageNavigator)bindable;
            string copyFontFamily = (string)newValue;

            imageNavigator.labelTextReference.FontFamily = copyFontFamily;
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
            ImageNavigator imageNavigator = (ImageNavigator)bindable;
            imageNavigator.labelTextReference.FontAttributes = newValue;
        }

        /// <summary>
        /// Enter the Border color input.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: nameof(BorderColor),
            returnType: typeof(Color),
            declaringType: typeof(ImageNavigator),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderColorPropertyChanged);

        /// <summary>
        /// Enter the Border color.
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        private static void BorderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ImageNavigator imageNavigator = (ImageNavigator)bindable;
            Color copyBorderColor = (Color)newValue;

            if (imageNavigator.frameReference != null)
            {
                imageNavigator.frameReference.BorderColor = copyBorderColor;
            }
        }

        /// <summary>
        /// Set DesignType
        /// </summary>
        [Bindable(true)]
        public DesignType DesignType
        {
            get
            {
                return currentDesignType;
            }
            set
            {
                DesignTypePropertyChanged(this, currentDesignType, value);
                currentDesignType = value;
            }
        }

        private static void DesignTypePropertyChanged(object bindable, DesignType oldValue, DesignType newValue)
        {
            ImageNavigator imageNavigator = (ImageNavigator)bindable;

            byte[] buttonBytesArrowRight = Convert.FromBase64String(imageNavigator.laavorControl.GetItemArrow(newValue, imageNavigator.currentColorUI, Side.Right, "__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl"));
            var streamButtonRight = new System.IO.MemoryStream(buttonBytesArrowRight);
            imageNavigator.imageArrowRightReference.Source = ImageSource.FromStream(() => streamButtonRight);

            byte[] buttonBytesArrowLeft = Convert.FromBase64String(imageNavigator.laavorControl.GetItemArrow(newValue, imageNavigator.currentColorUI, Side.Left, "__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl"));
            var streamButtonLeft = new System.IO.MemoryStream(buttonBytesArrowLeft);
            imageNavigator.imageArrowLeftReference.Source = ImageSource.FromStream(() => streamButtonLeft);
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(ImageNavigatorItem))
            {
                ImageNavigatorItem item = (ImageNavigatorItem)child;
                item.setIndex("wertyafff7777_____784", currentIndex);

                if (currentIndex == 0)
                {
                    imageReference.Index = currentIndex;
                    imageReference.Source = item.Image;

                    labelTextReference.Text = item.Text;

                    imageArrowRightReference.Index = currentIndex;
                    imageArrowLeftReference.Index = currentIndex;

                    imageArrowRightReference.Opacity = 1.0;
                }

                if (!string.IsNullOrEmpty(item.Text))
                {
                    labelTextReference.IsVisible = true;
                }

                imageReference.WidthRequest = ImageWidth;
                imageReference.HeightRequest = ImageHeight;

                listItems.Add(item);

                currentIndex++;
            }
        }

    }
}
