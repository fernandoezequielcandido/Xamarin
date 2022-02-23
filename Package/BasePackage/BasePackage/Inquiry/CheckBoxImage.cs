using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class CheckBoxImage
        /// </summary>
        public class CheckBoxImage : StackLayout
        {
            /// <summary>
            /// Inform InquiryCheck state 
            /// </summary>
            public bool IsChecked { get; private set; }

            /// <summary>
            /// Event call when InquiryCheckImage is checked or uncked
            /// </summary>
            public event EventHandler Checked;

            private InquiryCheckControl inquiryCheckControl;
            private TouchType touchType = TouchType.WithText;
            private InquiryCheckLabel label;

            private FontAttributes fontType = FontAttributes.None;
            private ColorUI textColor = ColorUI.Black;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Fast;

            /// <summary>
            /// Constructor of CheckBoxImage
            /// </summary>
            public CheckBoxImage() : base()
            {
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
                inquiryCheckControl = new InquiryCheckControl("__Laavor*+-", DesignType.Filled, ColorUI.Transparent, false);

                label = new InquiryCheckLabel();

                inquiryCheckControl.Source = ImageUnChecked;
                inquiryCheckControl.Aspect = Aspect.Fill;
                inquiryCheckControl.HorizontalOptions = LayoutOptions.Start;
                inquiryCheckControl.VerticalOptions = LayoutOptions.Center;
                inquiryCheckControl.WidthRequest = Width;
                inquiryCheckControl.HeightRequest = Height;

                if (vivacity != Vivacity.None)
                {
                    if (inquiryCheckControl.GestureRecognizers.Count == 0)
                    {
                        inquiryCheckControl.GestureRecognizers.Add(GetVivacity());
                    }
                }

                if (vivacity == Vivacity.None)
                {
                    if (inquiryCheckControl.GestureRecognizers.Count == 0)
                    {
                        inquiryCheckControl.GestureRecognizers.Add(GetVivacity());
                    }
                }
                else
                {
                    if (inquiryCheckControl.GestureRecognizers.Count == 1)
                    {
                        inquiryCheckControl.GestureRecognizers.Add(GetTouch());
                    }
                }

                Children.Add(inquiryCheckControl);

                label.setImage("__Laavor*+-", inquiryCheckControl);
                inquiryCheckControl.setlabel("__Laavor*+-", label);

                if (!string.IsNullOrEmpty(Text))
                {
                    label.Text = Text;
                    label.FontSize = FontSize;
                    label.FontFamily = FontFamily;
                    label.VerticalTextAlignment = TextAlignment.Center;
                    label.FontAttributes = fontType;
                    label.TextColor = Colors.Get(TextColor);

                    if (TouchType == TouchType.WithText)
                    {
                        label.GestureRecognizers.Add(GetTouch());
                    }

                    Children.Add(label);
                }
            }

            private TapGestureRecognizer GetTouch()
            {
                var checkedItem = new TapGestureRecognizer();
                checkedItem.Tapped += Touch_Check;
                return checkedItem;
            }

            private void Touch_Check(object sender, EventArgs e)
            {
                InquiryCheckControl checkImage;
                InquiryCheckLabel labelImage;

                if (sender.GetType() == typeof(InquiryCheckControl))
                {
                    checkImage = (InquiryCheckControl)sender;
                    labelImage = checkImage.Label;
                }
                else
                {
                    labelImage = (InquiryCheckLabel)sender;
                    checkImage = labelImage.CheckControl;
                }

                if (IsChecked)
                {
                    inquiryCheckControl.Source = ImageUnChecked;
                }
                else
                {
                    inquiryCheckControl.Source = ImageChecked;
                }

                if (IsChecked)
                {
                    IsChecked = false;

                    if (label != null && !string.IsNullOrEmpty(Text))
                    {
                        label.Text = Text;
                    }
                }
                else
                {
                    IsChecked = true;

                    if (label != null && !string.IsNullOrEmpty(TextChecked))
                    {
                        label.Text = TextChecked;
                    }
                }

                Checked?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            /// Set Image UnChecked.
            /// </summary>
            public static readonly BindableProperty ImageUnCheckedProperty = BindableProperty.Create(
                propertyName: nameof(ImageUnChecked),
                returnType: typeof(string),
                declaringType: typeof(CheckBoxImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageUnCheckedPropertyChanged);

            /// <summary>
            /// Set Image UnChecked.
            /// </summary>
            public string ImageUnChecked
            {
                get
                {
                    return (string)GetValue(ImageUnCheckedProperty);
                }
                set
                {
                    SetValue(ImageUnCheckedProperty, value);
                }
            }

            private static void ImageUnCheckedPropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheckImage = (CheckBoxImage)bindable;
                string imageSource = (string)newValue;

                if (inquiryCheckImage.inquiryCheckControl != null)
                {
                    if(!inquiryCheckImage.IsChecked)
                    {
                        inquiryCheckImage.inquiryCheckControl.Source = imageSource;
                    }
                }
            }

            /// <summary>
            /// Set Image Checked.
            /// </summary>
            public static readonly BindableProperty ImageCheckedProperty = BindableProperty.Create(
                propertyName: nameof(ImageChecked),
                returnType: typeof(string),
                declaringType: typeof(CheckBoxImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageCheckedPropertyChanged);

            /// <summary>
            /// Set Image Checked.
            /// </summary>
            public string ImageChecked
            {
                get
                {
                    return (string)GetValue(ImageCheckedProperty);
                }
                set
                {
                    SetValue(ImageCheckedProperty, value);
                }
            }

            private static void ImageCheckedPropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheckImage = (CheckBoxImage)bindable;
                string imageSource = (string)newValue;

                if (inquiryCheckImage.inquiryCheckControl != null)
                {
                    if (inquiryCheckImage.IsChecked)
                    {
                        inquiryCheckImage.inquiryCheckControl.Source = imageSource;
                    }
                }
            }

            /// <summary>
            /// Property to report if InquiryCheck is readonly.
            /// </summary>
            public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(CheckBoxImage),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Property to report if InquiryCheck is readonly.
            /// </summary>
            public bool IsReadOnly
            {
                get
                {
                    return (bool)GetValue(IsReadOnlyProperty);
                }
                set
                {
                    SetValue(IsReadOnlyProperty, value);
                }
            }

            private static void IsReadOnlyPropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                bool isReadOnly = (bool)newValue;

                inquiryCheck.inquiryCheckControl.GestureRecognizers.Clear();
                inquiryCheck.label.GestureRecognizers.Clear();

                if (isReadOnly)
                {
                    inquiryCheck.inquiryCheckControl.Opacity = 0.25;
                }
                else
                {
                    if (inquiryCheck.Vivacity != Vivacity.None)
                    {
                        if (inquiryCheck.inquiryCheckControl.GestureRecognizers.Count == 0)
                        {
                            inquiryCheck.inquiryCheckControl.GestureRecognizers.Add(inquiryCheck.GetVivacity());
                        }
                        
                        if (inquiryCheck.TouchType == TouchType.WithText)
                        {
                            if (inquiryCheck.label.GestureRecognizers.Count == 0)
                            {
                                inquiryCheck.label.GestureRecognizers.Add(inquiryCheck.GetVivacity());
                            }
                        }
                    }

                    if (inquiryCheck.Vivacity == Vivacity.None)
                    {
                        if (inquiryCheck.inquiryCheckControl.GestureRecognizers.Count == 0)
                        {
                            inquiryCheck.inquiryCheckControl.GestureRecognizers.Add(inquiryCheck.GetTouch());
                        }

                        if (inquiryCheck.TouchType == TouchType.WithText)
                        {
                            if (inquiryCheck.label.GestureRecognizers.Count == 0)
                            {
                                inquiryCheck.label.GestureRecognizers.Add(inquiryCheck.GetTouch());
                            }
                        }
                    }
                    else
                    {
                        if (inquiryCheck.inquiryCheckControl.GestureRecognizers.Count == 1)
                        {
                            inquiryCheck.inquiryCheckControl.GestureRecognizers.Add(inquiryCheck.GetTouch());
                        }

                        if (inquiryCheck.TouchType == TouchType.WithText)
                        {
                            if (inquiryCheck.label.GestureRecognizers.Count == 1)
                            {
                                inquiryCheck.label.GestureRecognizers.Add(inquiryCheck.GetTouch());
                            }
                        }
                    }

                    inquiryCheck.inquiryCheckControl.Opacity = 1.0;
                }
            }

            /// <summary>
            /// Property inform initial state of InquiryCheck.
            /// </summary>
            public static readonly BindableProperty InitialStateProperty = BindableProperty.Create(
                     propertyName: nameof(InitialState),
                     returnType: typeof(bool),
                     declaringType: typeof(CheckBoxImage),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: InitialStatePropertyChanged);

            /// <summary>
            /// Property inform initial state of InquiryCheck.
            /// </summary>
            public bool InitialState
            {
                get
                {
                    return (bool)GetValue(InitialStateProperty);
                }
                set
                {
                    SetValue(InitialStateProperty, value);
                }
            }

            private static void InitialStatePropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                bool initialState = (bool)newValue;

                if (inquiryCheck.inquiryCheckControl != null)
                {
                    inquiryCheck.inquiryCheckControl.ChangeState("__Laavor*+-", initialState);
                }
            }

            /// <summary>
            /// Set TouchType
            /// </summary>
            [Bindable(true)]
            public TouchType TouchType
            {
                get
                {
                    return touchType;
                }
                set
                {
                    touchType = value;
                    TouchTypePropertyChanged();
                }
            }

            private void TouchTypePropertyChanged()
            {
                if (label != null && !IsReadOnly)
                {
                    if (TouchType == TouchType.WithText)
                    {
                        label.GestureRecognizers.Clear();

                        if (vivacity != Vivacity.None)
                        {
                            if (label.GestureRecognizers.Count == 0)
                            {
                                label.GestureRecognizers.Add(GetVivacity());
                            }
                        }

                        if (vivacity == Vivacity.None)
                        {
                            if (label.GestureRecognizers.Count == 0)
                            {
                                label.GestureRecognizers.Add(GetTouch());
                            }
                        }
                        else
                        {
                            if (label.GestureRecognizers.Count == 1)
                            {
                                label.GestureRecognizers.Add(GetTouch());
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the height InquiryCheck.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(CheckBoxImage),
                defaultValue: 40.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightPropertyChanged);

            /// <summary>
            /// Enter the height InquiryCheck.
            /// </summary>
            public new double Height
            {
                get
                {
                    return (double)GetValue(HeightProperty);
                }
                set
                {
                    SetValue(HeightProperty, value);
                }
            }

            private static void HeightPropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                double checkHeight = (double)newValue;
                for (int index = 0; index < inquiryCheck.Children.Count; index++)
                {
                    if (inquiryCheck.Children[index].GetType() == typeof(InquiryCheckControl))
                    {
                        InquiryCheckControl inquiryCheckImage = (InquiryCheckControl)inquiryCheck.Children[index];
                        inquiryCheckImage.HeightRequest = checkHeight;
                        inquiryCheckImage.MinimumHeightRequest = checkHeight;
                    }
                }
            }

            /// <summary>
            /// Enter the width InquiryCheck.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(CheckBoxImage),
                defaultValue: 40.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter the width InquiryCheck.
            /// </summary>
            public new double Width
            {
                get
                {
                    return (double)GetValue(WidthProperty);
                }
                set
                {
                    SetValue(WidthProperty, value);
                }
            }

            private static void WidthPropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                double checkWidth = (double)newValue;
                for (int index = 0; index < inquiryCheck.Children.Count; index++)
                {
                    if (inquiryCheck.Children[index].GetType() == typeof(InquiryCheckControl))
                    {
                        InquiryCheckControl inquiryCheckImage = (InquiryCheckControl)inquiryCheck.Children[index];
                        inquiryCheckImage.WidthRequest = checkWidth;
                        inquiryCheckImage.MinimumWidthRequest = checkWidth;
                    }
                }
            }

            /// <summary>
            /// Enter the text
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(CheckBoxImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextPropertyChanged);

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

            private static void TextPropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                string checkText = (string)newValue;

                if (!inquiryCheck.IsChecked)
                {
                    if (inquiryCheck.label == null)
                    {
                        inquiryCheck.label = new InquiryCheckLabel();
                    }

                    if (!string.IsNullOrEmpty(checkText))
                    {
                        inquiryCheck.label.Text = checkText;
                        inquiryCheck.label.VerticalTextAlignment = TextAlignment.Center;
                        inquiryCheck.label.FontSize = inquiryCheck.FontSize;
                        inquiryCheck.label.FontFamily = inquiryCheck.FontFamily;
                        inquiryCheck.label.TextColor = Colors.Get(inquiryCheck.TextColor);

                        if (inquiryCheck.Children.Count <= 2)
                        {
                            inquiryCheck.Children.Add(inquiryCheck.label);
                        }

                        inquiryCheck.label.GestureRecognizers.Clear();

                        if (inquiryCheck.TouchType == TouchType.WithText && !inquiryCheck.IsReadOnly)
                        {
                            if (inquiryCheck.Vivacity != Vivacity.None)
                            {
                                if (inquiryCheck.label.GestureRecognizers.Count == 0)
                                {
                                    inquiryCheck.label.GestureRecognizers.Add(inquiryCheck.GetVivacity());
                                }
                            }

                            if (inquiryCheck.Vivacity == Vivacity.None)
                            {
                                if (inquiryCheck.label.GestureRecognizers.Count == 0)
                                {
                                    inquiryCheck.label.GestureRecognizers.Add(inquiryCheck.GetTouch());
                                }
                            }
                            else
                            {
                                if (inquiryCheck.label.GestureRecognizers.Count == 1)
                                {
                                    inquiryCheck.label.GestureRecognizers.Add(inquiryCheck.GetTouch());
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the TextChecked -- (Is Optional)
            /// </summary>
            public static readonly BindableProperty TextCheckedProperty = BindableProperty.Create(
                propertyName: nameof(TextChecked),
                returnType: typeof(string),
                declaringType: typeof(CheckBoxImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextCheckedPropertyChanged);

            /// <summary>
            /// Enter the TextChecked -- (Is Optional)
            /// </summary>
            public string TextChecked
            {
                get
                {
                    return (string)GetValue(TextCheckedProperty);
                }
                set
                {
                    SetValue(TextCheckedProperty, value);
                }
            }

            private static void TextCheckedPropertyChanged(object bindable, object oldValue, object newValue)
            {
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                string checkCheckedText = (string)newValue;

                if (inquiryCheck.IsChecked)
                {
                    if (inquiryCheck.label == null)
                    {
                        inquiryCheck.label = new InquiryCheckLabel();
                    }

                    if (!string.IsNullOrEmpty(checkCheckedText))
                    {
                        inquiryCheck.label.VerticalTextAlignment = TextAlignment.Center;
                        inquiryCheck.label.FontSize = inquiryCheck.FontSize;
                        inquiryCheck.label.FontFamily = inquiryCheck.FontFamily;
                        inquiryCheck.label.TextColor = Colors.Get(inquiryCheck.TextColor);

                        if (inquiryCheck.Children.Count <= 2)
                        {
                            inquiryCheck.Children.Add(inquiryCheck.label);
                        }

                        inquiryCheck.label.Text = checkCheckedText;
                    }
                }
            }

            /// <summary>
            /// Set FontType
            /// </summary>
            [Bindable(true)]
            public FontAttributes FontType
            {
                get
                {
                    return fontType;
                }
                set
                {
                    fontType = value;
                    FontTypePropertyChanged();
                }
            }

            private void FontTypePropertyChanged()
            {
                if (label != null)
                {
                    label.FontAttributes = fontType;
                }
            }

            /// <summary>
            /// Enter the font size of text.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(CheckBoxImage),
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
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                double fontSize = (double)newValue;

                if (inquiryCheck.label == null)
                {
                    inquiryCheck.label = new InquiryCheckLabel();
                    inquiryCheck.label.VerticalTextAlignment = TextAlignment.Center;
                    inquiryCheck.label.FontFamily = inquiryCheck.FontFamily;
                    inquiryCheck.label.TextColor = Colors.Get(inquiryCheck.TextColor);

                    if (inquiryCheck.Children.Count <= 2)
                    {
                        inquiryCheck.Children.Add(inquiryCheck.label);
                    }
                }

                inquiryCheck.label.FontSize = fontSize;
            }

            /// <summary>
            /// Set TextColor
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColor
            {
                get
                {
                    return textColor;
                }
                set
                {
                    textColor = value;
                    TextColorPropertyChanged();
                }
            }

            private void TextColorPropertyChanged()
            {
                if (label != null)
                {
                    label.TextColor = Colors.Get(textColor);
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(CheckBoxImage),
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
                CheckBoxImage inquiryCheck = (CheckBoxImage)bindable;
                string fontFamily = (string)newValue;

                if (inquiryCheck.label == null)
                {
                    inquiryCheck.label = new InquiryCheckLabel();
                    inquiryCheck.label.VerticalTextAlignment = TextAlignment.Center;
                    inquiryCheck.label.FontSize = inquiryCheck.FontSize;
                    inquiryCheck.label.TextColor = Colors.Get(inquiryCheck.TextColor);

                    if (inquiryCheck.Children.Count <= 2)
                    {
                        inquiryCheck.Children.Add(inquiryCheck.label);
                    }
                }
                inquiryCheck.label.FontFamily = fontFamily;
            }

            /// <summary>
            /// Set Vivacity
            /// </summary>
            [Bindable(true)]
            public Vivacity Vivacity
            {
                get
                {
                    return vivacity;
                }
                set
                {
                    vivacity = value;
                    VivacityPropertyChanged();
                }
            }

            private void VivacityPropertyChanged()
            {
                if (!IsReadOnly)
                {
                    if (inquiryCheckControl != null)
                    {
                        inquiryCheckControl.GestureRecognizers.Clear();
                        label.GestureRecognizers.Clear();

                        if (vivacity != Vivacity.None)
                        {
                            if (inquiryCheckControl.GestureRecognizers.Count == 0)
                            {
                                inquiryCheckControl.GestureRecognizers.Add(GetVivacity());
                            }

                            if (touchType == TouchType.WithText)
                            {
                                if (label.GestureRecognizers.Count == 0)
                                {
                                    label.GestureRecognizers.Add(GetVivacity());
                                }
                            }
                        }

                        if (vivacity == Vivacity.None)
                        {
                            if (touchType == TouchType.WithText)
                            {
                                if (label.GestureRecognizers.Count == 0)
                                {
                                    label.GestureRecognizers.Add(GetTouch());
                                }
                            }

                            if (inquiryCheckControl.GestureRecognizers.Count == 0)
                            {
                                inquiryCheckControl.GestureRecognizers.Add(GetTouch());
                            }
                        }
                        else
                        {
                            if (touchType == TouchType.WithText)
                            {
                                if (label.GestureRecognizers.Count == 1)
                                {
                                    label.GestureRecognizers.Add(GetTouch());
                                }
                            }

                            if (inquiryCheckControl.GestureRecognizers.Count == 1)
                            {
                                inquiryCheckControl.GestureRecognizers.Add(GetTouch());
                            }
                        }
                    }
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
                    return vivacitySpeed;
                }
                set
                {
                    vivacitySpeed = value;
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
                    return depth;
                }
                set
                {
                    depth = value;
                    DepthPropertyChanged();
                }
            }

            private void DepthPropertyChanged()
            {
                if (!IsReadOnly)
                {
                    VivacityPropertyChanged();
                }
            }

            private TapGestureRecognizer GetVivacity()
            {
                MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

                TapGestureRecognizer touchAnimation = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);

                return touchAnimation;
            }

            private TapGestureRecognizer GetVivacityDecrease()
            {
                TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
                vivacityTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        InquiryCheckControl inquiryCheckControl;
                        InquiryCheckLabel inquiryCheckLabel;

                        if (sender.GetType() == typeof(InquiryCheckControl))
                        {
                            inquiryCheckControl = (InquiryCheckControl)sender;
                            inquiryCheckLabel = inquiryCheckControl.Label;
                        }
                        else
                        {
                            inquiryCheckLabel = (InquiryCheckLabel)sender;
                            inquiryCheckControl = inquiryCheckLabel.CheckControl;
                        }

                        await inquiryCheckControl.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquiryCheckControl.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };

                return vivacityTap;
            }

            private double GetDepthDecrease(Depth depth)
            {
                if (depth == Depth.Small)
                {
                    return 0.80;
                }
                else if (depth == Depth.LessMedium)
                {
                    return 0.87;
                }
                else if (depth == Depth.Medium)
                {
                    return 0.77;
                }
                else
                {
                    return 0.67;
                }
            }

            private TapGestureRecognizer GetVivacityIncrease()
            {
                TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
                vivacityTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        InquiryCheckControl inquiryCheckControl;
                        InquiryCheckLabel inquiryCheckLabel;

                        if (sender.GetType() == typeof(InquiryCheckControl))
                        {
                            inquiryCheckControl = (InquiryCheckControl)sender;
                            inquiryCheckLabel = inquiryCheckControl.Label;
                        }
                        else
                        {
                            inquiryCheckLabel = (InquiryCheckLabel)sender;
                            inquiryCheckControl = inquiryCheckLabel.CheckControl;
                        }

                        await inquiryCheckControl.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquiryCheckControl.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        InquiryCheckControl inquiryCheckControl;
                        InquiryCheckLabel inquiryCheckLabel;

                        if (sender.GetType() == typeof(InquiryCheckControl))
                        {
                            inquiryCheckControl = (InquiryCheckControl)sender;
                            inquiryCheckLabel = inquiryCheckControl.Label;
                        }
                        else
                        {
                            inquiryCheckLabel = (InquiryCheckLabel)sender;
                            inquiryCheckControl = inquiryCheckLabel.CheckControl;
                        }

                        await inquiryCheckControl.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquiryCheckControl.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                        InquiryCheckControl inquiryCheckControl;
                        InquiryCheckLabel inquiryCheckLabel;

                        if (sender.GetType() == typeof(InquiryCheckControl))
                        {
                            inquiryCheckControl = (InquiryCheckControl)sender;
                            inquiryCheckLabel = inquiryCheckControl.Label;
                        }
                        else
                        {
                            inquiryCheckLabel = (InquiryCheckLabel)sender;
                            inquiryCheckControl = inquiryCheckLabel.CheckControl;
                        }

                        await inquiryCheckControl.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquiryCheckControl.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        InquiryCheckControl inquiryCheckControl;
                        InquiryCheckLabel inquiryCheckLabel;

                        if (sender.GetType() == typeof(InquiryCheckControl))
                        {
                            inquiryCheckControl = (InquiryCheckControl)sender;
                            inquiryCheckLabel = inquiryCheckControl.Label;
                        }
                        else
                        {
                            inquiryCheckLabel = (InquiryCheckLabel)sender;
                            inquiryCheckControl = inquiryCheckLabel.CheckControl;
                        }

                        await inquiryCheckControl.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquiryCheckControl.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        InquiryCheckControl inquiryCheckControl;
                        InquiryCheckLabel inquiryCheckLabel;

                        if (sender.GetType() == typeof(InquiryCheckControl))
                        {
                            inquiryCheckControl = (InquiryCheckControl)sender;
                            inquiryCheckLabel = inquiryCheckControl.Label;
                        }
                        else
                        {
                            inquiryCheckLabel = (InquiryCheckLabel)sender;
                            inquiryCheckControl = inquiryCheckLabel.CheckControl;
                        }

                        await inquiryCheckControl.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await inquiryCheckControl.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
        }
    }
}
