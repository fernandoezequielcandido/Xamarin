using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Buttons
    {
        /// <summary>
        /// Class ButtonImage
        /// </summary>
        public class ButtonImage : StackLayout
        {
            /// <summary>
            /// Call when button is Touched
            /// </summary>
            public event EventHandler Touched;

            private AbsoluteLayout absoluteReference;
            private Image imageButton;
            private Label labelText;

            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor ButtonImage
            /// </summary>
            public ButtonImage()
            {
                InitAll();
            }

            private void InitAll()
            {
                absoluteReference = new AbsoluteLayout();
                absoluteReference.HorizontalOptions = LayoutOptions.Center;

                CreateButton();

                absoluteReference.Children.Add(imageButton);
                absoluteReference.Children.Add(labelText);

                this.Children.Add(absoluteReference);
            }

            private void CreateButton()
            {
                imageButton = new Image();
                imageButton.HorizontalOptions = LayoutOptions.Center;
                imageButton.WidthRequest = Width;
                imageButton.HeightRequest = Height;
                imageButton.Aspect = Aspect.Fill;
                imageButton.Source = Image;

                labelText = new Label();
                labelText.Text = Text;
                labelText.TextColor = Colors.Get(TextColor);
                labelText.FontAttributes = FontType;
                labelText.BackgroundColor = Color.Transparent;
                labelText.FontFamily = FontFamily;
                labelText.HorizontalOptions = LayoutOptions.Center;
                AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

                imageButton.GestureRecognizers.Clear();
                labelText.GestureRecognizers.Clear();

                if (!IsReadOnly)
                {
                    if (vivacity != Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetVivacity());
                        }

                        if (labelText.GestureRecognizers.Count == 0)
                        {
                            labelText.GestureRecognizers.Add(GetVivacity());
                        }
                    }

                    if (vivacity == Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }

                        if (labelText.GestureRecognizers.Count == 0)
                        {
                            labelText.GestureRecognizers.Add(GetTouch());
                        }
                    }
                    else
                    {
                        if (imageButton.GestureRecognizers.Count == 1)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }

                        if (labelText.GestureRecognizers.Count == 1)
                        {
                            labelText.GestureRecognizers.Add(GetTouch());
                        }
                    }
                    
                }
                else
                {
                    imageButton.Opacity = 0.3;
                    labelText.Opacity = 0.3;
                }
            }

            private void Touch_Tapped(object sender, EventArgs e)
            {
                Touched?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetTouch()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Touch_Tapped;
                return touch;
            }

            /// <summary>
            /// Property to report if button is readonly.
            /// </summary>
            public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(ButtonImage),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Property to report if button is readonly.
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
                ButtonImage button = (ButtonImage)bindable;
                bool isReadOnly = (bool)newValue;

                if (button.imageButton == null || button.labelText == null)
                {
                    return;
                }

                button.imageButton.GestureRecognizers.Clear();
                button.labelText.GestureRecognizers.Clear();

                if (isReadOnly)
                {
                    button.imageButton.Opacity = 0.3;
                    button.labelText.Opacity = 0.3;
                }
                else
                {
                    if (button.vivacity != Vivacity.None)
                    {
                        if (button.imageButton.GestureRecognizers.Count == 0)
                        {
                            button.imageButton.GestureRecognizers.Add(button.GetVivacity());
                        }

                        if (button.labelText.GestureRecognizers.Count == 0)
                        {
                            button.labelText.GestureRecognizers.Add(button.GetVivacity());
                        }
                    }

                    if (button.vivacity == Vivacity.None)
                    {
                        if (button.imageButton.GestureRecognizers.Count == 0)
                        {
                            button.imageButton.GestureRecognizers.Add(button.GetTouch());
                        }

                        if (button.labelText.GestureRecognizers.Count == 0)
                        {
                            button.labelText.GestureRecognizers.Add(button.GetTouch());
                        }
                    }
                    else
                    {
                        if (button.imageButton.GestureRecognizers.Count == 1)
                        {
                            button.imageButton.GestureRecognizers.Add(button.GetTouch());
                        }

                        if (button.labelText.GestureRecognizers.Count == 1)
                        {
                            button.labelText.GestureRecognizers.Add(button.GetTouch());
                        }
                    }

                    button.imageButton.Opacity = 1.0;
                    button.labelText.Opacity = 1.0;
                }
            }

            /// <summary>
            /// Enter the Image Source of button.
            /// </summary>
            public static readonly BindableProperty ImageProperty = BindableProperty.Create(
                propertyName: nameof(Image),
                returnType: typeof(string),
                declaringType: typeof(ButtonImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImagePropertyChanged);

            /// <summary>
            /// Enter the Image Source od button.
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
                ButtonImage buttonImage = (ButtonImage)bindable;
                string copyImage = (string)newValue;

                if (buttonImage.imageButton != null)
                {
                    buttonImage.imageButton.Source = copyImage;
                }
            }

            /// <summary>
            /// Enter the height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(ButtonImage),
                defaultValue: 40.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightPropertyChanged);

            /// <summary>
            /// Enter the height.
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
                ButtonImage buttonImage = (ButtonImage)bindable;
                double buttonHeight = (double)newValue;

                if (buttonImage.imageButton != null)
                {
                    buttonImage.imageButton.HeightRequest = buttonHeight;
                }
            }

            /// <summary>
            /// Enter the width.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(ButtonImage),
                defaultValue: 250.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter the width.
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
                ButtonImage buttonImage = (ButtonImage)bindable;
                double buttonWidth = (double)newValue;

                if (buttonImage.imageButton != null)
                {
                    buttonImage.imageButton.WidthRequest = buttonWidth;
                }
            }

            /// <summary>
            /// Enter the text
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(ButtonImage),
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
                ButtonImage buttonImage = (ButtonImage)bindable;
                string buttonText = (string)newValue;
                if (!string.IsNullOrEmpty(buttonText))
                {
                    if (buttonImage.labelText != null)
                    {
                        buttonImage.labelText.Text = buttonText;
                    }
                }
            }

            /// <summary>
            /// Enter the font size of text button.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(ButtonImage),
                defaultValue: 25.0,
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
                ButtonImage buttonImage = (ButtonImage)bindable;
                double copyFontSize = (double)newValue;

                if (buttonImage.labelText != null)
                {
                    buttonImage.labelText.FontSize = copyFontSize;
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(ButtonImage),
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
                ButtonImage buttonImage = (ButtonImage)bindable;
                string fontFamily = (string)newValue;

                if (buttonImage.labelText != null)
                {
                    buttonImage.labelText.FontFamily = fontFamily;
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
                if (labelText != null)
                {
                    labelText.FontAttributes = fontType;
                }
            }

            /// <summary>
            /// Set if is TextColor
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
                if (labelText != null)
                {
                    labelText.TextColor = Colors.Get(textColor);
                }
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
                    imageButton.GestureRecognizers.Clear();
                    labelText.GestureRecognizers.Clear();

                    if (vivacity != Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetVivacity());
                        }

                        if (labelText.GestureRecognizers.Count == 0)
                        {
                            labelText.GestureRecognizers.Add(GetVivacity());
                        }
                    }

                    if (vivacity == Vivacity.None)
                    {
                        if (imageButton.GestureRecognizers.Count == 0)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }

                        if (labelText.GestureRecognizers.Count == 0)
                        {
                            labelText.GestureRecognizers.Add(GetTouch());
                        }
                    }
                    else
                    {
                        if (imageButton.GestureRecognizers.Count == 1)
                        {
                            imageButton.GestureRecognizers.Add(GetTouch());
                        }

                        if (labelText.GestureRecognizers.Count == 1)
                        {
                            labelText.GestureRecognizers.Add(GetTouch());
                        }
                    }

                    imageButton.Opacity = 1.0;
                    labelText.Opacity = 1.0;
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
                    VivacityPropertyChanged();
                }
            }

            /// <summary>
            /// Get Vivacity
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacity()
            {
                if (Vivacity != Vivacity.None)
                {
                    MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + Vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
                    TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
                    return touchVivavicity;
                }
                else
                {
                    return new TapGestureRecognizer();
                }
            }

            /// <summary>
            /// Use to create VivacityDecrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityDecrease()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };

                return animationTap;
            }

            /// <summary>
            /// Use to create DepthDecrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthDecrease(Depth depth)
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

            /// <summary>
            /// Use to create VivacityIncrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityIncrease()
            {
                TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
                vivacityTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };

                return vivacityTap;
            }

            /// <summary>
            /// Use to create DepthIncrease is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthIncrease(Depth depth)
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

            /// <summary>
            /// Use to create VivacityRotation is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityRotation()
            {
                TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
                vivacityTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return vivacityTap;
            }

            /// <summary>
            /// Use to create DepthRotation is Auto Call
            /// </summary>
            /// <returns></returns>
            protected int GetDepthRotation(Depth depth)
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

            /// <summary>
            /// Use to create VivacityJump is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityJump()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthJump is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthJump(Depth depth)
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

            /// <summary>
            /// Use to create VivacityDown is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityDown()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthDown is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthDown(Depth depth)
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

            /// <summary>
            /// Use to create VivacityLeft is Auto Call
            /// </summary>
            /// <returns></returns>
            protected TapGestureRecognizer GetVivacityLeft()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthLeft is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthLeft(Depth depth)
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

            /// <summary>
            /// Use to create VivacityRight is Auto Call
            /// </summary>
            /// <returns></returns>
            private TapGestureRecognizer GetVivacityRight()
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    try
                    {
                        await imageButton.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                        await imageButton.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                        await labelText.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
                    }
                    catch { }
                };
                return animationTap;
            }

            /// <summary>
            /// Use to create DepthRight is Auto Call
            /// </summary>
            /// <returns></returns>
            protected double GetDepthRight(Depth depth)
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
}
