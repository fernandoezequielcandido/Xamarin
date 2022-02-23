using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorInputImage
{
    /// <summary>
    /// Class InputImage
    /// </summary>
    public class InputImage: StackLayout
    {
        private Entry entry;

        private StackLayout dataItems;
        private StackLayout stackGroupItems;
        private StackLayout stackEntry;
        private StackLayout stackImage;

        private Frame frame = new Frame();

        private Image image = null;

        private Side currentSide = Side.Left;
        private FontAttributes currentFontType = FontAttributes.None;
        private TextAlignment currentHorizontalTextAlignment;
        private ColorUI currentTextColor = ColorUI.Black;
        private ColorUI currentColorUI = ColorUI.White;
        private ColorUI currentBorderColor = ColorUI.Black;
        private ColorUI currentPlaceholderColor = ColorUI.Gray;

        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        /// <summary>
        /// Event call when Image is Touched
        /// </summary>
        public event EventHandler ImageTouched;

        /// <summary>
        /// Constructor of InputImage
        /// </summary>
        public InputImage() : base()
        {
            InitAll();
        }

        private void InitAll()
        {
            this.Spacing = 0;

            dataItems = new StackLayout();
            this.Orientation = StackOrientation.Vertical;
            dataItems.Orientation = StackOrientation.Horizontal;
            dataItems.Spacing = 0;

            stackGroupItems = new StackLayout();
            stackGroupItems.Spacing = 0;

            frame = new Frame();
            frame.BorderColor = Colors.Get(ColorUI.Black);
            frame.VerticalOptions = LayoutOptions.Start;
            frame.BackgroundColor = Color.Transparent;
            frame.GestureRecognizers.Add(GetTouchFrame());
                        
            stackImage = new StackLayout();
            stackImage.Spacing = 0;
            stackImage.VerticalOptions = LayoutOptions.Center;

            image = new Image();

            image.HeightRequest = ImageHeight;
            image.MinimumHeightRequest = ImageHeight;
            image.WidthRequest = ImageWidth;
            image.MinimumWidthRequest = ImageWidth;
            image.IsVisible = true;
            image.Aspect = Aspect.Fill;
            image.Source = Image;
            image.VerticalOptions = LayoutOptions.Center;
           
            image.GestureRecognizers.Add(GetTouch());
            image.GestureRecognizers.Add(GetVivacity());

            stackImage.Children.Add(image);
           
            stackEntry = new StackLayout();
            stackEntry.Spacing = 0;
            entry = new Entry();
            entry.VerticalOptions = LayoutOptions.Center;
            entry.WidthRequest = WidthInput;
            entry.FontSize = FontSize;

            stackEntry.Children.Add(entry);

            stackGroupItems.Orientation = StackOrientation.Horizontal;

            if (currentSide == Side.Left)
            {
                stackGroupItems.Children.Add(stackImage);
                stackGroupItems.Children.Add(stackEntry);
                image.HorizontalOptions = LayoutOptions.Start;
                entry.Margin = new Thickness(-10, -20, -10, -20);
                image.Margin = new Thickness(-10, -10, 10, -20);
            }
            else
            {
                stackGroupItems.Children.Add(stackEntry);
                stackGroupItems.Children.Add(stackImage);
                image.HorizontalOptions = LayoutOptions.End;
                entry.Margin = new Thickness(-10, 0, 10, -20);
                image.Margin = new Thickness(20, -10, -10, -20);
            }
            
            frame.Content = stackGroupItems;

            dataItems.Children.Add(frame);

            this.Children.Add(dataItems);
        }

        private TapGestureRecognizer GetTouch()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Tapped;
            return touch;
        }

        private void Touch_Tapped(object sender, EventArgs e)
        {
            ImageTouched?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetTouchFrame()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Frame;
            return touch;
        }

        private void Touch_Frame(object sender, EventArgs e)
        {
            entry.Focus();
        }

        /// <summary>
        /// Set Vivacity
        /// </summary>
        [Bindable(true)]
        public Vivacity Vivacity
        {
            get
            {
                return currentVivacity;
            }
            set
            {
                currentVivacity = value;
                VivacityPropertyChanged();
            }
        }

        private void VivacityPropertyChanged()
        {
            if (image != null)
            {
                image.GestureRecognizers.Clear();
                image.GestureRecognizers.Add(GetVivacity());
                image.GestureRecognizers.Add(GetTouch());
                image.Opacity = 1.0;
            }
        }

        /// <summary>
        /// VivacitySpeed changes animation speed when selecting an item. 
        /// </summary>
        [Bindable(true)]
        public VivacitySpeed VivacitySpeed
        {
            get
            {
                return currentVivacitySpeed;
            }
            set
            {
                currentVivacitySpeed = value;
                VivacityPropertyChanged();
            }
        }

        /// <summary>
        /// Set Vivacity
        /// </summary>
        [Bindable(true)]
        public Depth Depth
        {
            get
            {
                return currentDepth;
            }
            set
            {
                currentDepth = value;
                VivacityPropertyChanged();
            }
        }

        /// <summary>
        /// Set Default Text If Needs
        /// </summary>
        public static BindableProperty TextProperty = BindableProperty.Create(
           propertyName: nameof(Text),
           returnType: typeof(string),
           declaringType: typeof(InputImage),
           defaultValue: "",
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: TextPropertyChanged);

        /// <summary>
        /// Set Default Text If Needs
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
            InputImage inputImage = (InputImage)bindable;
            string text = (string)newValue;
            inputImage.Text = text;
        }

        /// <summary>
        /// Gets or sets the placeholder text shown when the entry InputImage.Text is null or empty.
        /// </summary>
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(
           propertyName: nameof(Placeholder),
           returnType: typeof(string),
           declaringType: typeof(InputImage),
           defaultValue: "",
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: PlaceholderPropertyChanged);

        /// <summary>
        /// Gets or sets the placeholder text shown when the entry InputImage.Text is null or empty.
        /// </summary>
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }

        private static void PlaceholderPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputImage inputImage = (InputImage)bindable;
            string placeHolder = (string)newValue;
            if (inputImage.entry != null)
            {
                inputImage.entry.Placeholder = placeHolder;
            }
        }

        /// <summary>
        /// Enter the font size of text button.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(InputImage),
            defaultValue: 20.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size of text button.
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
            InputImage inputImage = (InputImage)bindable;
            double copyFontSize = (double)newValue;

            if (inputImage.entry != null)
            {
                inputImage.entry.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Set TextColor
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColor
        {
            get
            {
                return currentTextColor;
            }
            set
            {
                currentTextColor = value;
                TextColorPropertyChanged();
            }
        }

        private void TextColorPropertyChanged()
        {
            if (entry != null)
            {
                entry.TextColor = Colors.Get(currentTextColor);
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(InputImage),
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
            InputImage inputImage = (InputImage)bindable;
            string copyFontFamily = (string)newValue;

            if (inputImage.entry != null)
            {
                inputImage.entry.FontFamily = copyFontFamily;
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
                currentFontType = value;
                FontTypePropertyChanged();
            }
        }

        private void FontTypePropertyChanged()
        {
            if (entry != null)
            {
                entry.FontAttributes = currentFontType;
            }
        }

        /// <summary>
        /// Enter the Horizontal Text Alignment.
        /// </summary>
        [Bindable(true)]
        public TextAlignment HorizontalTextAlignment
        {
            get
            {
                return currentHorizontalTextAlignment;
            }
            set
            {
                currentHorizontalTextAlignment = value;
                HorizontalTextAlignmentPropertyChanged();
            }
        }

        private void HorizontalTextAlignmentPropertyChanged()
        {
            if (entry != null)
            {
                entry.HorizontalTextAlignment = currentHorizontalTextAlignment;
            }
        }

        /// <summary>
        /// Enter the Side Image left or right.
        /// </summary>
        [Bindable(true)]
        public Side Side
        {
            get
            {
                return currentSide;
            }
            set
            {
                currentSide = value;
                SidePropertyChanged();
            }
        }

        private void SidePropertyChanged()
        {
            stackGroupItems.Children.Clear();
            if (currentSide == Side.Left)
            {
                stackGroupItems.Children.Add(stackImage);
                stackGroupItems.Children.Add(stackEntry);
                image.HorizontalOptions = LayoutOptions.Start;
                entry.Margin = new Thickness(-10, -20, -10, -20);
                image.Margin = new Thickness(-10, -10, 10, -20);
            }
            else
            {
                stackGroupItems.Children.Add(stackEntry);
                stackGroupItems.Children.Add(stackImage);
                image.HorizontalOptions = LayoutOptions.End;
                entry.Margin = new Thickness(-10, -20, 10, -20);
                image.Margin = new Thickness(-10, -10, -10, -20);
            }
        }

        /// <summary>
        /// Set ColorUI
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
            if (frame != null)
            {
                frame.BackgroundColor = Colors.Get(currentColorUI);
            }
        }

        /// <summary>
        /// Set PlaceholderColor
        /// </summary>
        [Bindable(true)]
        public ColorUI PlaceholderColor
        {
            get
            {
                return currentPlaceholderColor;
            }
            set
            {
                currentPlaceholderColor = value;
                PlaceholderColorPropertyChanged();
            }
        }

        private void PlaceholderColorPropertyChanged()
        {
            if (entry != null)
            {
                entry.PlaceholderColor = Colors.Get(currentPlaceholderColor);
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates if the entry should visually obscure typed text.
        /// </summary>
        public static BindableProperty IsPasswordProperty = BindableProperty.Create(
           propertyName: nameof(IsPassword),
           returnType: typeof(bool),
           declaringType: typeof(InputImage),
           defaultValue: false,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: PlaceholderPropertyChanged);

        /// <summary>
        /// Gets or sets a value that indicates if the entry should visually obscure typed text.
        /// </summary>
        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        private static void IsPasswordPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputImage inputImage = (InputImage)bindable;

            if (inputImage.entry != null)
            {
                inputImage.entry.IsPassword = (bool)newValue;
            }
        }

        /// <summary>
        /// Set Keyboard
        /// </summary>
        public static BindableProperty KeyboardProperty = BindableProperty.Create(
          propertyName: nameof(Keyboard),
          returnType: typeof(Keyboard),
          declaringType: typeof(InputImage),
          defaultValue: Keyboard.Default,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: KeyboardPropertyChanged);

        /// <summary>
        /// Set Keyboard
        /// </summary>
        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        private static void KeyboardPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputImage inputImage = (InputImage)bindable;

            if (inputImage.entry != null)
            {
                inputImage.Keyboard = (Keyboard)newValue;
            }
        }
        
        /// <summary>
        /// Enter the Width Input.
        /// </summary>
        public static readonly BindableProperty WidthInputProperty = BindableProperty.Create(
            propertyName: nameof(WidthInput),
            returnType: typeof(double),
            declaringType: typeof(InputImage),
            defaultValue: 250.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthInputPropertyChanged);

        /// <summary>
        /// Enter the Width Input.
        /// </summary>
        public double WidthInput
        {
            get
            {
                return (double)GetValue(WidthInputProperty);
            }
            set
            {
                SetValue(WidthInputProperty, value);
            }
        }

        private static void WidthInputPropertyChanged(object bindable, object oldValue, object newValue)
        {
            InputImage inputImage = (InputImage)bindable;
            double copyWidth = (double)newValue;

            if (inputImage.entry != null)
            {
                inputImage.entry.WidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Source of Image inside Input
        /// </summary>
        public static BindableProperty ImageProperty = BindableProperty.Create(
         propertyName: nameof(Image),
         returnType: typeof(string),
         declaringType: typeof(InputImage),
         defaultBindingMode: BindingMode.OneWay,
         defaultValue: "",
         propertyChanged: ImagePropertyChanged);

        /// <summary>
        /// Source of Image inside Input
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
            InputImage inputImage = (InputImage)bindable;
            if (inputImage.image != null)
            {
                inputImage.image.Source = newValue.ToString();


                if (inputImage.currentSide == Side.Left)
                {
                    inputImage.stackGroupItems.Children.Add(inputImage.stackImage);
                    inputImage.stackGroupItems.Children.Add(inputImage.stackEntry);
                    inputImage.image.HorizontalOptions = LayoutOptions.Start;
                    inputImage.entry.Margin = new Thickness(-10, -20, -10, -20);
                    inputImage.image.Margin = new Thickness(-10, -10, 10, -20);
                }
                else
                {
                    inputImage.stackGroupItems.Children.Add(inputImage.stackEntry);
                    inputImage.stackGroupItems.Children.Add(inputImage.stackImage);
                    inputImage.image.HorizontalOptions = LayoutOptions.End;
                    inputImage.entry.Margin = new Thickness(-10, 0, 10, -20);
                    inputImage.image.Margin = new Thickness(20, -10, -10, -20);
                }
            }
        }

        /// <summary>
        /// Set BorderColor
        /// </summary>
        [Bindable(true)]
        public ColorUI BorderColor
        {
            get
            {
                return currentBorderColor;
            }
            set
            {
                currentBorderColor = value;
                BorderColorPropertyChanged();
            }
        }

        private void BorderColorPropertyChanged()
        {
            if (frame != null)
            {
                frame.BorderColor = Colors.Get(currentBorderColor);
            }
        }

        /// <summary>
        /// Enter the Width Image.
        /// </summary>
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
            propertyName: nameof(ImageWidth),
            returnType: typeof(double),
            declaringType: typeof(InputImage),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageWidthPropertyChanged);

        /// <summary>
        /// Enter the Image Width.
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
            InputImage inputImage = (InputImage)bindable;
            double copyWidth = (double)newValue;

            if (inputImage.image != null)
            {
                inputImage.image.WidthRequest = copyWidth;
                inputImage.image.MinimumWidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Enter the Width Image.
        /// </summary>
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
            propertyName: nameof(ImageHeight),
            returnType: typeof(double),
            declaringType: typeof(InputImage),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ImageHeightPropertyChanged);

        /// <summary>
        /// Enter the Height Image.
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
            InputImage inputImage = (InputImage)bindable;
            double copyHeight = (double)newValue;

            if (inputImage.image != null)
            {
                inputImage.image.HeightRequest = copyHeight;
                inputImage.image.MinimumHeightRequest = copyHeight;
            }
        }

        private TapGestureRecognizer GetVivacity()
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchVivavicity;
        }

        private TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await image.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };

            return animationTap;
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 0.88;
            }
            else if (depth == Depth.LessMedium)
            {
                return 0.95;
            }
            else if (depth == Depth.Medium)
            {
                return 0.90;
            }
            else
            {
                return 0.75;
            }
        }

        private TapGestureRecognizer GetVivacityIncrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await image.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await image.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };

            return vivacityTap;
        }

        private double GetDepthIncrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 1.01;
            }
            else if (depth == Depth.LessMedium)
            {
                return 1.07;
            }
            else if (depth == Depth.Medium)
            {
                return 1.11;
            }
            else
            {
                return 1.15;
            }
        }

        private TapGestureRecognizer GetVivacityRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await image.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await image.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };
            return vivacityTap;
        }

        private int GetDepthRotation(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 200;
            }
            else if (depth == Depth.LessMedium)
            {
                return 250;
            }
            else if (depth == Depth.Medium)
            {
                return 300;
            }
            else
            {
                return 360;
            }
        }

        private TapGestureRecognizer GetVivacityJump()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await image.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthJump(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return -1.5;
            }
            else if (depth == Depth.LessMedium)
            {
                return -2.0;
            }
            else if (depth == Depth.Medium)
            {
                return -2.7;
            }
            else
            {
                return -3.4;
            }
        }

        private TapGestureRecognizer GetVivacityDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await image.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthDown(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 1.5;
            }
            else if (depth == Depth.LessMedium)
            {
                return 2.0;
            }
            else if (depth == Depth.Medium)
            {
                return 2.7;
            }
            else
            {
                return 3.4;
            }
        }

        private TapGestureRecognizer GetVivacityLeft()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await image.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthLeft(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return -2.00;
            }
            else if (depth == Depth.LessMedium)
            {
                return -3.0;
            }
            else if (depth == Depth.Medium)
            {
                return -5.0;
            }
            else
            {
                return -10.0;
            }
        }

        private TapGestureRecognizer GetVivacityRight()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await image.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await image.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
                }
                catch { }
            };
            return animationTap;
        }

        private double GetDepthRight(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 2.00;
            }
            else if (depth == Depth.LessMedium)
            {
                return 3.0;
            }
            else if (depth == Depth.Medium)
            {
                return 5.0;
            }
            else
            {
                return 10.0;
            }
        }
    }
}
