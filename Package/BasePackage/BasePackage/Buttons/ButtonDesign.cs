using BasePackage.Details;
using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Buttons
    {
        /// <summary>
        /// Class ButtonDesign
        /// </summary>
        public class ButtonDesign: Content
        {
            /// <summary>
            /// Event call when button is Touched
            /// </summary>
            public event EventHandler Touched;

            private Label labelText;
            private BaseDesignControl imageButton;
            
            private ColorUI colorUI = ColorUI.Gray;
            private DesignType designType = DesignType.Shinning;
            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of Button Design
            /// </summary>
            public ButtonDesign()
            {
                InitAll();
            }

            private void InitAll()
            {
                AbsoluteLayout abs = new AbsoluteLayout();
                abs.HorizontalOptions = LayoutOptions.Center;

                CreateButton();

                abs.Children.Add(imageButton);
                abs.Children.Add(labelText);

                this.Children.Add(abs);
            }



            private void CreateButton()
            {
                imageButton = new BaseDesignControl("__Laavor*+-", DesignType, ColorUI);
                imageButton.WidthRequest = Width;
                imageButton.MinimumHeightRequest = Width;
                imageButton.HeightRequest = Height;
                imageButton.MinimumHeightRequest = Height;

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
            }

            /// <summary>
            /// Enter the AnchorY.
            /// </summary>
            [Browsable(false)]
            [Bindable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static readonly BindableProperty AnchorYProperty = BindableProperty.Create(
                propertyName: nameof(AnchorY),
                returnType: typeof(double),
                declaringType: typeof(Content),
                defaultValue: 250.0,
                defaultBindingMode: BindingMode.OneWay);

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
                     declaringType: typeof(ButtonDesign),
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
                ButtonDesign button = (ButtonDesign)bindable;
                bool copyIsReadOnly = (bool)newValue;
                if (button.imageButton != null && button.labelText != null)
                {
                    button.imageButton.GestureRecognizers.Clear();
                    button.labelText.GestureRecognizers.Clear();

                    if (copyIsReadOnly)
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
            }

            /// <summary>
            /// Set if is ColorUI
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUI
            {
                get
                {
                    return colorUI;
                }
                set
                {
                    ColorUIPropertyChanged(this, colorUI, value);
                    colorUI = value;
                }
            }

            private void ColorUIPropertyChanged(object bindable, ColorUI oldValue, ColorUI newValue)
            {
                if (imageButton != null)
                {
                    imageButton.ChangeColor("__Laavor*+-", newValue);
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
            /// Enter the height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(ButtonDesign),
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
                ButtonDesign buttonDesign = (ButtonDesign)bindable;
                double buttonHeight = (double)newValue;

                if (buttonDesign.imageButton != null)
                {
                    buttonDesign.imageButton.HeightRequest = buttonHeight;
                    buttonDesign.imageButton.MinimumHeightRequest = buttonHeight;
                }
            }

            /// <summary>
            /// Enter the width.
            /// </summary>
            [Browsable(false)]
            [Bindable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(ButtonDesign),
                defaultValue: 250.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter the width.
            /// </summary>
            [Browsable(false)]
            [Bindable(false)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            [EditorBrowsable(EditorBrowsableState.Never)]
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
                ButtonDesign buttonDesign = (ButtonDesign)bindable;
                double buttonWidth = (double)newValue;

                if (buttonDesign.imageButton != null)
                {
                    buttonDesign.imageButton.WidthRequest = buttonWidth;
                    buttonDesign.imageButton.MinimumWidthRequest = buttonWidth;
                }
            }

            /// <summary>
            /// Enter the text
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(ButtonDesign),
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
                ButtonDesign buttonDesign = (ButtonDesign)bindable;
                string buttonText = (string)newValue;

                if (buttonDesign.labelText != null)
                {
                    buttonDesign.labelText.Text = buttonText;
                }
            }

            /// <summary>
            /// Enter the font size of text button.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(ButtonDesign),
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
                ButtonDesign buttonDesign = (ButtonDesign)bindable;
                double copyFontSize = (double)newValue;

                if (buttonDesign.labelText != null)
                {
                    buttonDesign.labelText.FontSize = copyFontSize;
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(ButtonDesign),
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
                ButtonDesign buttonDesign = (ButtonDesign)bindable;
                string copyFontFamily = (string)newValue;

                if (buttonDesign.labelText != null)
                {
                    buttonDesign.labelText.FontFamily = copyFontFamily;
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
                    return fontType;
                }
                set
                {
                    FontTypePropertyChanged(this, fontType, value);
                    fontType = value;
                }
            }

            private void FontTypePropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
            {
                labelText.FontAttributes = newValue;
            }

            /// <summary>
            /// Set DesignType
            /// </summary>
            [Bindable(true)]
            public DesignType DesignType
            {
                get
                {
                    return designType;
                }
                set
                {
                    DesignTypePropertyChanged(this, designType, value);
                    designType = value;
                }
            }

            private void DesignTypePropertyChanged(object bindable, DesignType oldValue, DesignType newValue)
            {
                if (imageButton != null)
                {
                    imageButton.ChangeDesignType("__Laavor*+-", newValue);
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
                    if (imageButton != null && labelText != null)
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
