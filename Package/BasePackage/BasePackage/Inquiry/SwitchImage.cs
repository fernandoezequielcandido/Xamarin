using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// SwitchImage
        /// </summary>
        public class SwitchImage: StackLayout
        {
            /// <summary>
            /// Inform switch state 
            /// </summary>
            public State State { get; private set; }

            /// <summary>
            /// Event call when Switch is changed to on or off
            /// </summary>
            public event EventHandler ChangeState;

            private InquirySwitchControl inquirySwitchControl;
            private InquirySwitchLabel label;

            private TouchType touchType = Laavor.TouchType.WithText;
            private ColorUI textColor = ColorUI.Black;

            private State initialState = State.Off;
            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of SwitchImage
            /// </summary>
            public SwitchImage() : base()
            {
                InitializeComponents();
            }

            private void InitializeComponents()
            {
                label = null;

                Orientation = StackOrientation.Horizontal;

                InitAll();
            }

            private void InitAll()
            {
                Children.Clear();
                this.State = InitialState;

                inquirySwitchControl = new InquirySwitchControl("__Laavor*+-", ColorUI.Transparent, this.State, DesignType.Fit);
                inquirySwitchControl.Source = ImageOff;
                inquirySwitchControl.WidthRequest = Width;
                inquirySwitchControl.HeightRequest = Height;

                if (Vivacity != Vivacity.None)
                {
                    inquirySwitchControl.GestureRecognizers.Add(GetVivacity());
                }

                inquirySwitchControl.GestureRecognizers.Add(GetTouch());

                Children.Add(inquirySwitchControl);

                label = new InquirySwitchLabel();

                label.setImage("__Laavor*+-", inquirySwitchControl);
                inquirySwitchControl.setlabel("__Laavor*+-", label);

                if (!string.IsNullOrEmpty(Text))
                {

                    label.Text = Text;
                    label.FontSize = FontSize;
                    label.FontFamily = FontFamily;
                    label.VerticalTextAlignment = TextAlignment.Center;
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
                var switchItem = new TapGestureRecognizer();
                switchItem.Tapped += ChangeState_Item;
                return switchItem;
            }

            private void ChangeState_Item(object sender, EventArgs e)
            {
                InquirySwitchControl switchImage;
                InquirySwitchLabel labelImage;

                if (sender.GetType() == typeof(InquirySwitchControl))
                {
                    switchImage = (InquirySwitchControl)sender;
                    labelImage = switchImage.Label;
                }
                else
                {
                    labelImage = (InquirySwitchLabel)sender;
                    switchImage = labelImage.SwitchImage;
                }

                if (switchImage.State == State.Off)
                {
                    if (label != null && !string.IsNullOrEmpty(Text))
                    {
                        label.Text = Text;
                    }

                    switchImage.ChangeState("__Laavor*+-", State.On);
                    switchImage.Source = ImageOn;
                    State = State.On;
                }
                else
                {
                    if (label != null && !string.IsNullOrEmpty(TextOn))
                    {
                        label.Text = TextOn;
                    }

                    switchImage.ChangeState("__Laavor*+-", State.Off);
                    switchImage.Source = ImageOff;
                    State = State.Off;
                }

                ChangeState?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            /// Property to report if Switch is readonly.
            /// </summary>
            public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(SwitchImage),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Property to report if Switch is readonly.
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
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                bool isReadOnly = (bool)newValue;
                if (isReadOnly)
                {
                    inquirySwitch.inquirySwitchControl.GestureRecognizers.Clear();
                    inquirySwitch.inquirySwitchControl.Opacity = 0.25;
                }
                else
                {
                    inquirySwitch.inquirySwitchControl.GestureRecognizers.Add(inquirySwitch.GetTouch());
                    inquirySwitch.inquirySwitchControl.Opacity = 1.0;
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
                        label.GestureRecognizers.Add(GetTouch());

                        if (vivacity != Vivacity.None)
                        {
                            label.GestureRecognizers.Add(GetVivacity());
                        }
                    }
                }
            }

            /// <summary>
            /// Set InitialState
            /// </summary>
            [Bindable(true)]
            public State InitialState
            {
                get
                {
                    return initialState;
                }
                set
                {
                    initialState = value;
                    InitialStatePropertyChanged();
                }
            }

            private void InitialStatePropertyChanged()
            {
                if (inquirySwitchControl != null)
                {
                    inquirySwitchControl.ChangeState("__Laavor*+-", initialState);

                    if (initialState == State.Off)
                    {
                        inquirySwitchControl.Source = ImageOff;
                    }
                    else
                    {
                        inquirySwitchControl.Source = ImageOn;
                    }
                }
            }

            /// <summary>
            /// Enter the Image Off
            /// </summary>
            public static readonly BindableProperty ImageOffProperty = BindableProperty.Create(
                propertyName: nameof(ImageOff),
                returnType: typeof(string),
                declaringType: typeof(SwitchImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageOffPropertyChanged);

            /// <summary>
            /// Enter the ImageOff
            /// </summary>
            public string ImageOff
            {
                get
                {
                    return (string)GetValue(ImageOffProperty);
                }
                set
                {
                    SetValue(ImageOffProperty, value);
                }
            }

            private static void ImageOffPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                string image = (string)newValue;

                if (inquirySwitch.inquirySwitchControl != null)
                {
                    if (inquirySwitch.State == State.Off)
                    {
                        inquirySwitch.inquirySwitchControl.Source = image;
                    }
                }
            }

            /// <summary>
            /// Enter the Image On
            /// </summary>
            public static readonly BindableProperty ImageOnProperty = BindableProperty.Create(
                propertyName: nameof(ImageOn),
                returnType: typeof(string),
                declaringType: typeof(SwitchImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageOnPropertyChanged);

            /// <summary>
            /// Enter the ImageOn
            /// </summary>
            public string ImageOn
            {
                get
                {
                    return (string)GetValue(ImageOnProperty);
                }
                set
                {
                    SetValue(ImageOnProperty, value);
                }
            }

            private static void ImageOnPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                string image = (string)newValue;
                
                if (inquirySwitch.inquirySwitchControl != null)
                {
                    if (inquirySwitch.State == State.On)
                    {
                        inquirySwitch.inquirySwitchControl.Source = image;
                    }
                }
            }
                       
            /// <summary>
            /// Enter the height InquirySwitch.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(SwitchImage),
                defaultValue: 35.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightPropertyChanged);

            /// <summary>
            /// Enter the height InquirySwitch.
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
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                double switchHeight = (double)newValue;

                if (inquirySwitch.inquirySwitchControl != null)
                {
                    inquirySwitch.inquirySwitchControl.HeightRequest = switchHeight;
                }
            }

            /// <summary>
            /// Enter the width InquirySwitch.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(SwitchImage),
                defaultValue: 80.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter the width InquirySwitch.
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
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                double switchWidth = (double)newValue;

                if (inquirySwitch.inquirySwitchControl != null)
                {
                    inquirySwitch.inquirySwitchControl.WidthRequest = switchWidth;
                }
            }

            /// <summary>
            /// Enter the text
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(SwitchImage),
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
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                string text = (string)newValue;

                if (inquirySwitch.State != State.On)
                {
                    if (inquirySwitch.label == null)
                    {
                        inquirySwitch.label = new InquirySwitchLabel();
                    }

                    if (!string.IsNullOrEmpty(text))
                    {
                        inquirySwitch.label.Text = text;
                        inquirySwitch.label.VerticalTextAlignment = TextAlignment.Center;
                        inquirySwitch.label.FontSize = inquirySwitch.FontSize;
                        inquirySwitch.label.FontFamily = inquirySwitch.FontFamily;
                        inquirySwitch.label.TextColor = Colors.Get(inquirySwitch.TextColor);

                        if (inquirySwitch.Children.Count <= 2)
                        {
                            inquirySwitch.Children.Add(inquirySwitch.label);
                        }

                        if (inquirySwitch.TouchType == TouchType.WithText)
                        {
                            inquirySwitch.label.GestureRecognizers.Clear();
                            inquirySwitch.label.GestureRecognizers.Add(inquirySwitch.GetTouch());

                            if (inquirySwitch.Vivacity != Vivacity.None)
                            {
                                inquirySwitch.label.GestureRecognizers.Add(inquirySwitch.GetVivacity());
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the TextOn -- (Is Optional  you can add your Label)
            /// </summary>
            public static readonly BindableProperty TextOnProperty = BindableProperty.Create(
                propertyName: nameof(TextOn),
                returnType: typeof(string),
                declaringType: typeof(SwitchImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextOnPropertyChanged);

            /// <summary>
            /// Enter the TextOn -- (Is Optional you can add your Label)
            /// </summary>
            public string TextOn
            {
                get
                {
                    return (string)GetValue(TextOnProperty);
                }
                set
                {
                    SetValue(TextOnProperty, value);
                }
            }

            private static void TextOnPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                string onText = (string)newValue;

                if (inquirySwitch.State != State.Off)
                {
                    if (inquirySwitch.label == null)
                    {
                        inquirySwitch.label = new InquirySwitchLabel();
                    }

                    if (!string.IsNullOrEmpty(onText))
                    {
                        inquirySwitch.label.VerticalTextAlignment = TextAlignment.Center;
                        inquirySwitch.label.FontSize = inquirySwitch.FontSize;
                        inquirySwitch.label.FontFamily = inquirySwitch.FontFamily;
                        inquirySwitch.label.TextColor = Colors.Get(inquirySwitch.TextColor);

                        if (inquirySwitch.Children.Count <= 2)
                        {
                            inquirySwitch.Children.Add(inquirySwitch.label);
                        }

                        inquirySwitch.label.Text = onText;
                    }
                }
            }

            /// <summary>
            /// Enter the font size of text.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(SwitchImage),
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
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                double fontSize = (double)newValue;

                if (inquirySwitch.label == null)
                {
                    inquirySwitch.label = new InquirySwitchLabel();
                    inquirySwitch.label.VerticalTextAlignment = TextAlignment.Center;
                    inquirySwitch.label.FontFamily = inquirySwitch.FontFamily;
                    inquirySwitch.label.TextColor = Colors.Get(inquirySwitch.textColor);

                    if (inquirySwitch.Children.Count <= 2)
                    {
                        inquirySwitch.Children.Add(inquirySwitch.label);
                    }
                }

                inquirySwitch.label.FontSize = fontSize;
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
                if (label == null)
                {
                    label = new InquirySwitchLabel();
                    label.VerticalTextAlignment = TextAlignment.Center;
                    label.FontSize = FontSize;
                    label.FontFamily = FontFamily;
                    label.TextColor = Colors.Get(textColor);

                    if (Children.Count <= 2)
                    {
                        Children.Add(label);
                    }
                }
                else
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
                declaringType: typeof(SwitchImage),
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
                SwitchImage inquirySwitch = (SwitchImage)bindable;
                string fontFamily = (string)newValue;

                if (inquirySwitch.label == null)
                {
                    inquirySwitch.label = new InquirySwitchLabel();
                    inquirySwitch.label.VerticalTextAlignment = TextAlignment.Center;
                    inquirySwitch.label.FontSize = inquirySwitch.FontSize;
                    inquirySwitch.label.TextColor = Colors.Get(inquirySwitch.TextColor);

                    if (inquirySwitch.Children.Count <= 2)
                    {
                        inquirySwitch.Children.Add(inquirySwitch.label);
                    }
                }
                inquirySwitch.label.FontFamily = fontFamily;
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
                    if (inquirySwitchControl != null)
                    {
                        inquirySwitchControl.GestureRecognizers.Clear();
                        inquirySwitchControl.GestureRecognizers.Add(GetTouch());

                        if (touchType == TouchType.WithText)
                        {
                            label.GestureRecognizers.Clear();
                            label.GestureRecognizers.Add(GetTouch());
                        }

                        if (vivacity != Vivacity.None)
                        {
                            inquirySwitchControl.GestureRecognizers.Add(GetVivacity());

                            if (touchType == TouchType.WithText)
                            {
                                label.GestureRecognizers.Add(GetVivacity());
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
                        InquirySwitchControl inquirySwitchControl;
                        InquirySwitchLabel inquirySwitchLabel;

                        if (sender.GetType() == typeof(InquirySwitchControl))
                        {
                            inquirySwitchControl = (InquirySwitchControl)sender;
                            inquirySwitchLabel = inquirySwitchControl.Label;
                        }
                        else
                        {
                            inquirySwitchLabel = (InquirySwitchLabel)sender;
                            inquirySwitchControl = inquirySwitchLabel.SwitchImage;
                        }

                        await inquirySwitchControl.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquirySwitchControl.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        InquirySwitchControl inquirySwitchControl;
                        InquirySwitchLabel inquirySwitchLabel;

                        if (sender.GetType() == typeof(InquirySwitchControl))
                        {
                            inquirySwitchControl = (InquirySwitchControl)sender;
                            inquirySwitchLabel = inquirySwitchControl.Label;
                        }
                        else
                        {
                            inquirySwitchLabel = (InquirySwitchLabel)sender;
                            inquirySwitchControl = inquirySwitchLabel.SwitchImage;
                        }

                        await inquirySwitchControl.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquirySwitchControl.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
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
                        InquirySwitchControl inquirySwitchControl;
                        InquirySwitchLabel inquirySwitchLabel;

                        if (sender.GetType() == typeof(InquirySwitchControl))
                        {
                            inquirySwitchControl = (InquirySwitchControl)sender;
                            inquirySwitchLabel = inquirySwitchControl.Label;
                        }
                        else
                        {
                            inquirySwitchLabel = (InquirySwitchLabel)sender;
                            inquirySwitchControl = inquirySwitchLabel.SwitchImage;
                        }

                        await inquirySwitchControl.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquirySwitchControl.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
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
                        InquirySwitchControl inquirySwitchControl;
                        InquirySwitchLabel inquirySwitchLabel;

                        if (sender.GetType() == typeof(InquirySwitchControl))
                        {
                            inquirySwitchControl = (InquirySwitchControl)sender;
                            inquirySwitchLabel = inquirySwitchControl.Label;
                        }
                        else
                        {
                            inquirySwitchLabel = (InquirySwitchLabel)sender;
                            inquirySwitchControl = inquirySwitchLabel.SwitchImage;
                        }

                        await inquirySwitchControl.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquirySwitchControl.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        InquirySwitchControl inquirySwitchControl;
                        InquirySwitchLabel inquirySwitchLabel;

                        if (sender.GetType() == typeof(InquirySwitchControl))
                        {
                            inquirySwitchControl = (InquirySwitchControl)sender;
                            inquirySwitchLabel = inquirySwitchControl.Label;
                        }
                        else
                        {
                            inquirySwitchLabel = (InquirySwitchLabel)sender;
                            inquirySwitchControl = inquirySwitchLabel.SwitchImage;
                        }

                        await inquirySwitchControl.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await inquirySwitchControl.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
                        InquirySwitchControl inquirySwitchControl;
                        InquirySwitchLabel inquirySwitchLabel;

                        if (sender.GetType() == typeof(InquirySwitchControl))
                        {
                            inquirySwitchControl = (InquirySwitchControl)sender;
                            inquirySwitchLabel = inquirySwitchControl.Label;
                        }
                        else
                        {
                            inquirySwitchLabel = (InquirySwitchLabel)sender;
                            inquirySwitchControl = inquirySwitchLabel.SwitchImage;
                        }

                        await inquirySwitchControl.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await inquirySwitchControl.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
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
