using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorDivider
{
    /// <summary>
    /// Class Divider
    /// </summary>
    public class Divider: StackLayout
    {
        private ColorUI currentColorUI = ColorUI.Black;

        private LineImage lineImageRightReference;
        private LineImage lineImageLeftReference;

        private Image imageUser = null;
        private Label labelUser = null;

        private StackLayout stackRight;
        private StackLayout stackCenterRight;
        private StackLayout stackCenterLeft;
        private StackLayout stackLeft;

        private FontAttributes currentFontType = FontAttributes.None;
        private ImagePosition currentImagePosition = ImagePosition.Left;

        private LineSize currentLineSize = LineSize.One;
        private ColorUI currentColor = ColorUI.Black;

        private double? currentImageWidth = null;
        private double? currentImageHeight = null;

        /// <summary>
        /// Constructor of Divider
        /// </summary>
        public Divider()
        {
            Orientation = StackOrientation.Horizontal;
            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();
            lineImageRightReference = new LineImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColor, currentLineSize);
            lineImageLeftReference = new LineImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColor, currentLineSize);

            StartMarginImages(false);

            stackLeft = new StackLayout();
            stackLeft.HorizontalOptions = LayoutOptions.FillAndExpand;
            stackLeft.IsVisible = true;
            stackLeft.Orientation = StackOrientation.Vertical;
            stackLeft.VerticalOptions = LayoutOptions.Center;
            stackLeft.Children.Add(lineImageLeftReference);
       
            stackCenterLeft = new StackLayout();
            stackCenterLeft.HorizontalOptions = LayoutOptions.Center;
            stackCenterLeft.IsVisible = false;
            stackCenterLeft.VerticalOptions = LayoutOptions.Center;
            stackCenterLeft.Orientation = StackOrientation.Vertical;

            stackCenterRight = new StackLayout();
            stackCenterRight.HorizontalOptions = LayoutOptions.Center;
            stackCenterRight.IsVisible = false;
            stackCenterRight.VerticalOptions = LayoutOptions.Center;
            stackCenterRight.Orientation = StackOrientation.Vertical;

            stackRight = new StackLayout();
            stackRight.HorizontalOptions = LayoutOptions.FillAndExpand;
            stackRight.IsVisible = false;
            stackRight.Orientation = StackOrientation.Vertical;
            stackRight.Children.Add(lineImageRightReference);
            stackRight.VerticalOptions = LayoutOptions.Center;

            Children.Add(stackLeft);
            Children.Add(stackCenterLeft);
            Children.Add(stackCenterRight);
            Children.Add(stackRight);

            if(!string.IsNullOrEmpty(Image))
            {
                imageUser = new Image();
                imageUser.Source = Image;
                stackCenterLeft.Children.Add(imageUser);
                stackCenterLeft.IsVisible = true;
                stackRight.IsVisible = true;
            }

            if(!string.IsNullOrEmpty(Text))
            {
                labelUser = new Label();
                labelUser.Text = Text;
                labelUser.FontAttributes = FontType;
                labelUser.FontFamily = FontFamily;
                labelUser.FontSize = FontSize;
                labelUser.TextColor = TextColor;
                labelUser.LineBreakMode = LineBreakMode.NoWrap;
                labelUser.HorizontalTextAlignment = TextAlignment.Center;
                labelUser.HorizontalOptions = LayoutOptions.CenterAndExpand;
                stackCenterRight.IsVisible = true;
                stackRight.IsVisible = true;
            }
        }

        private void StartLabel()
        {
            labelUser = new Label();

            if (currentImagePosition == ImagePosition.Left)
            {
                stackCenterRight.Children.Add(labelUser);
            }
            else
            {
                stackCenterLeft.Children.Add(labelUser);
            }

            labelUser.VerticalOptions = LayoutOptions.Start;
        }

        private void StartMarginImages(bool defaultTwo)
        {
            if (defaultTwo)
            {
                lineImageLeftReference.Margin = new Thickness(2, 0, 0, 0);
                lineImageRightReference.Margin = new Thickness(0, 0, 2, 0);
            }
            else
            {
                lineImageLeftReference.Margin = new Thickness(2, 0, 2, 0);
                lineImageRightReference.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Enter the Text.
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(Divider),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextPropertyChanged);

        /// <summary>
        /// Enter the Text.
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

        private static void TextPropertyChanged(object bindable, object oldValue, object newValue)
        {
            Divider divider = (Divider)bindable;
            string copyText = (string)newValue;
            if (divider.labelUser == null)
            {
                divider.StartLabel();
            }

            if(!string.IsNullOrEmpty(copyText))
            {
                divider.stackCenterRight.IsVisible = true;
                divider.stackRight.IsVisible = true;
                divider.stackLeft.IsVisible = true;
                divider.StartMarginImages(true);
            }

            divider.labelUser.Text = copyText;
        }

        /// <summary>
        /// Enter the Image.
        /// </summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(string),
            declaringType: typeof(Divider),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImagePropertyChanged);

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

        private static void ImagePropertyChanged(object bindable, object oldValue, object newValue)
        {
            Divider divider = (Divider)bindable;
            string copyImage = (string)newValue;
            if (divider.imageUser == null)
            {
                divider.imageUser = new Image();

                if (divider.currentImagePosition == ImagePosition.Left)
                {
                    divider.stackCenterLeft.Children.Add(divider.imageUser);
                }
                else
                {
                    divider.stackCenterRight.Children.Add(divider.imageUser);
                }

                divider.imageUser.Aspect = Aspect.Fill;
                divider.imageUser.VerticalOptions = LayoutOptions.Center;
            }

            divider.imageUser.Source = copyImage;

            if(divider.currentImageWidth != null)
            {
                divider.imageUser.WidthRequest = divider.ImageWidth.Value;
            }

            if (divider.currentImageHeight != null)
            {
                divider.imageUser.HeightRequest = divider.ImageHeight.Value;
            }

            if (!string.IsNullOrEmpty(copyImage))
            {
                divider.stackCenterLeft.IsVisible = true;
                divider.stackRight.IsVisible = true;
                divider.stackLeft.IsVisible = true;

                divider.StartMarginImages(true);
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
                currentColorUI = value;
                ColorUIPropertyChanged();
            }
        }

        private void ColorUIPropertyChanged()
        {
            lineImageLeftReference.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI);
            lineImageRightReference.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI);
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
            Divider divider = (Divider)bindable;
            FontAttributes copyFontType = newValue;
            if(divider.labelUser == null)
            {
                divider.StartLabel();
            }

            divider.labelUser.FontAttributes = copyFontType;
        }

        /// <summary>
        /// Enter the ImagePosition (Left, Right).
        /// </summary>
        [Bindable(true)]
        public ImagePosition ImagePosition
        {
            get
            {
                return currentImagePosition;
            }
            set
            {
                ImagePositionPropertyChanged(this, currentImagePosition, value);
                currentImagePosition = value;
            }
        }

        private static void ImagePositionPropertyChanged(object bindable, ImagePosition oldValue, ImagePosition newValue)
        {
            Divider divider = (Divider)bindable;
            ImagePosition imagePosition = newValue;
            if (divider.labelUser != null || divider.imageUser != null)
            {
                divider.stackCenterLeft.Children.Clear();
                divider.stackCenterRight.Children.Clear();
            }

            if(divider.labelUser != null)
            {
                if(imagePosition == ImagePosition.Left)
                {
                    divider.stackCenterRight.Children.Add(divider.labelUser);
                }
                else
                {
                    divider.stackCenterLeft.Children.Add(divider.labelUser);
                }
            }

            if(divider.imageUser != null)
            {
                if (imagePosition == ImagePosition.Left)
                {
                    divider.stackCenterLeft.Children.Add(divider.imageUser);
                }
                else
                {
                    divider.stackCenterRight.Children.Add(divider.imageUser);
                }
            }
        }

        /// <summary>
        /// Enter the LineSize (One, Two).
        /// </summary>
        [Bindable(true)]
        public LineSize LineSize
        {
            get
            {
                return currentLineSize;
            }
            set
            {
                currentLineSize = value;
                LineSizePropertyChanged();
            }
        }

        private void LineSizePropertyChanged()
        {
            lineImageLeftReference.ChangeSize("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentLineSize);
            lineImageRightReference.ChangeSize("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentLineSize);
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(Color),
         declaringType: typeof(Divider),
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
            Divider divider = (Divider)bindable;
            Color copyColor = (Color)newValue;
            if (divider.labelUser == null)
            {
                divider.StartLabel();
            }

            divider.labelUser.TextColor = copyColor;
        }

        /// <summary>
        /// Enter the Image Height.
        /// </summary>
        [Bindable(true)]
        public double? ImageHeight
        {
            get
            {
                return currentImageHeight;
            }
            set
            {
                currentImageHeight = value;
                ImageHeightChanged();
            }
        }

        private void ImageHeightChanged()
        {
            if (imageUser != null && currentImageHeight != null)
            {
                imageUser.HeightRequest = currentImageHeight.Value;
            }
        }

        /// <summary>
        /// Enter the Image Width.
        /// </summary>
        [Bindable(true)]
        public double? ImageWidth
        {
            get
            {
                return currentImageWidth;
            }
            set
            {
                currentImageWidth = value;
                ImageWidthPropertyChanged(this, currentImageWidth, value);
            }
        }

        private static void ImageWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            Divider divider = (Divider)bindable;
            double copyImageWidth = (double)newValue;
            if (divider.imageUser != null)
            {
                divider.imageUser.WidthRequest = copyImageWidth;
            }
        }
             
        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(Divider),
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
            Divider divider = (Divider)bindable;
            string copyFontFamily = (string)newValue;
            if (divider.labelUser == null)
            {
                divider.StartLabel();
            }

            divider.labelUser.FontFamily = copyFontFamily;
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(Divider),
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
            Divider divider = (Divider)bindable;
            double copyFontSize = (double)newValue;
            if (divider.labelUser == null)
            {
                divider.StartLabel();
            }

            divider.labelUser.FontSize = copyFontSize;
        }

    }
}
