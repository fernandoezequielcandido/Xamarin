using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorCheckBoxRadio
{
    /// <summary>
    /// Class CheckBox
    /// </summary>
    public class CheckBox : StackLayout
    {
        /// <summary>
        /// Inform checkbox state 
        /// </summary>
        public bool IsChecked { get; private set; }

        /// <summary>
        /// Event call when checkbox is checked or uncked
        /// </summary>
        public event EventHandler Checked;

        private CheckBoxImage checkBoxImageReference;
        private LabelCheck labelTextReference;

        private ColorUI currentColorUI = ColorUI.Black;
        private DesignType currentDesignType = DesignType.Fit;
        private ColorUI currentTextColor = ColorUI.Black;
        private TouchType touchType = TouchType.WithText;

        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.Medium;
        private VivacitySpeed currentVivacitySpeed = VivacitySpeed.Normal;

        /// <summary>
        /// Constructor of ChekBox
        /// </summary>
        public CheckBox() : base()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            labelTextReference = null;

            Orientation = StackOrientation.Horizontal;

            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();
            CheckBoxImage checkBoxImage = new CheckBoxImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentDesignType, currentColorUI, InitialState);
            
            checkBoxImage.WidthRequest = Width;
            checkBoxImage.HeightRequest = Height;
                        
            checkBoxImageReference = checkBoxImage;

            Children.Add(checkBoxImage);

            labelTextReference = new LabelCheck();

            labelTextReference.setImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", checkBoxImage);
            checkBoxImage.setlabel("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", labelTextReference);   

            if (!string.IsNullOrEmpty(Text))
            {
                labelTextReference.Text = Text;
                labelTextReference.FontSize = FontSize;
                labelTextReference.FontFamily = FontFamily;
                labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                labelTextReference.TextColor = Colors.Get(currentTextColor);

                Children.Add(labelTextReference);
            }

            VivacityPropertyChanged();

         }

        private TapGestureRecognizer GetCheckClick()
        {
            var checkedItem = new TapGestureRecognizer();
            checkedItem.Tapped += OnCheck_Item;
            return checkedItem;
        }

        private void OnCheck_Item(object sender, EventArgs e)
        {
            CheckBoxImage checkImage;
            LabelCheck labelImage;

            if (sender.GetType() == typeof(CheckBoxImage))
            {
                checkImage = (CheckBoxImage)sender;
                labelImage = checkImage.Label;
            }
            else
            {
                labelImage = (LabelCheck)sender;
                checkImage = labelImage.CheckBoxImage;
            }

            if (checkBoxImageReference != null)
            {
                IsChecked = !(checkBoxImageReference.IsChecked);
                checkBoxImageReference.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", !(checkBoxImageReference.IsChecked));
            }

            if (IsChecked)
            {
                if (labelTextReference != null)
                {
                    if (labelTextReference != null)
                    {
                        if (string.IsNullOrEmpty(TextChecked))
                        {
                            labelTextReference.Text = Text;
                        }
                        else
                        {
                            labelTextReference.Text = TextChecked;
                        }
                    }
                }
            }
            else
            {
                if (labelTextReference != null)
                {
                    if (labelTextReference != null)
                    {
                        labelTextReference.Text = Text;
                    }
                }
            }

            Checked?.Invoke(this, EventArgs.Empty);
        }


        /// <summary>
        /// Property to report if CheckBox is readonly.
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(CheckBox),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if CheckBox is readonly.
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
            CheckBox checkBox = (CheckBox)bindable;
            bool copyIsReadOnly = (bool)newValue;
            checkBox.VivacityPropertyChanged();
        }

        /// <summary>
        /// Property inform initial state of checkbox.
        /// </summary>
        public static readonly BindableProperty InitialStateProperty = BindableProperty.Create(
                 propertyName: nameof(InitialState),
                 returnType: typeof(bool),
                 declaringType: typeof(CheckBox),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: InitialStatePropertyChanged);

        /// <summary>
        /// Property inform initial state of checkbox.
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
            CheckBox checkBox = (CheckBox)bindable;
            bool copyInitialState = (bool)newValue;

            if (checkBox.checkBoxImageReference != null)
            {
                checkBox.checkBoxImageReference.ChangeState("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", copyInitialState);
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
            if (checkBoxImageReference != null)
            {
                checkBoxImageReference.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI);
            }
        }

        /// <summary>
        /// Set if is TouchType
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
            VivacityPropertyChanged();
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

        private static void DesignTypePropertyChanged(object bindable, object oldValue, object newValue)
        {
            CheckBox checkBox = (CheckBox)bindable;
            DesignType copyDesignType = (DesignType)newValue;

            if (checkBox.checkBoxImageReference != null)
            {
                checkBox.checkBoxImageReference.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", copyDesignType);
            }
        }

        /// <summary>
        /// Enter the height checkbox.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(CheckBox),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightPropertyChanged);

        /// <summary>
        /// Enter the height checkbox.
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
            CheckBox checkBox = (CheckBox)bindable;
            double checkHeight = (double)newValue;
            for (int iCh = 0; iCh < checkBox.Children.Count; iCh++)
            {
                if (checkBox.Children[iCh].GetType() == typeof(CheckBoxImage))
                {
                    CheckBoxImage checkBoxImage = (CheckBoxImage)checkBox.Children[iCh];
                    checkBoxImage.HeightRequest = checkHeight;
                    checkBoxImage.MinimumHeightRequest = checkHeight;
                }
            }
        }

        /// <summary>
        /// Enter the width checkbox.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(CheckBox),
            defaultValue: 40.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width checkbox.
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
            CheckBox checkBox = (CheckBox)bindable;
            double checkWidth = (double)newValue;
            for (int iCh = 0; iCh < checkBox.Children.Count; iCh++)
            {
                if (checkBox.Children[iCh].GetType() == typeof(CheckBoxImage))
                {
                    CheckBoxImage checkBoxImage = (CheckBoxImage)checkBox.Children[iCh];
                    checkBoxImage.WidthRequest = checkWidth;
                    checkBoxImage.MinimumWidthRequest = checkWidth;
                }
            }
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(CheckBox),
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
            CheckBox checkBox = (CheckBox)bindable;
            string checkText = (string)newValue;

            if (!checkBox.IsChecked)
            {
                if (checkBox.labelTextReference == null)
                {
                    checkBox.labelTextReference = new LabelCheck();
                }

                if (!string.IsNullOrEmpty(checkText))
                {
                    checkBox.labelTextReference.Text = checkText;
                    checkBox.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                    checkBox.labelTextReference.FontSize = checkBox.FontSize;
                    checkBox.labelTextReference.FontFamily = checkBox.FontFamily;
                    checkBox.labelTextReference.TextColor = Colors.Get(checkBox.currentTextColor);

                    if (checkBox.Children.Count <= 2)
                    {
                        checkBox.Children.Add(checkBox.labelTextReference);
                    }

                    checkBox.VivacityPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Enter the text default -- (Is Optional  you can add your Label)
        /// </summary>
        public static readonly BindableProperty TextCheckedProperty = BindableProperty.Create(
            propertyName: nameof(TextChecked),
            returnType: typeof(string),
            declaringType: typeof(CheckBox),
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
            CheckBox checkBox = (CheckBox)bindable;
            string checkCheckedText = (string)newValue;

            if (checkBox.IsChecked)
            {
                if (checkBox.labelTextReference == null)
                {
                    checkBox.labelTextReference = new LabelCheck();
                }

                if (!string.IsNullOrEmpty(checkCheckedText))
                {
                    checkBox.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                    checkBox.labelTextReference.FontSize = checkBox.FontSize;
                    checkBox.labelTextReference.FontFamily = checkBox.FontFamily;
                    checkBox.labelTextReference.TextColor = Colors.Get(checkBox.currentTextColor);

                    if (checkBox.Children.Count <= 2)
                    {
                        checkBox.Children.Add(checkBox.labelTextReference);
                    }

                    checkBox.labelTextReference.Text = checkCheckedText;
                }
            }
        }

        /// <summary>
        /// Enter the font size of text.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(CheckBox),
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
            CheckBox checkBox = (CheckBox)bindable;
            double copyFontSize = (double)newValue;

            if (checkBox.labelTextReference == null)
            {
                checkBox.labelTextReference = new LabelCheck();
                checkBox.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                checkBox.labelTextReference.FontFamily = checkBox.FontFamily;
                checkBox.labelTextReference.TextColor = Colors.Get(checkBox.currentTextColor);

                if (checkBox.Children.Count <= 2)
                {
                    checkBox.Children.Add(checkBox.labelTextReference);
                }
            }

            checkBox.labelTextReference.FontSize = copyFontSize;
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
            if (labelTextReference == null)
            {
                labelTextReference = new LabelCheck();
                labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                labelTextReference.FontSize = FontSize;
                labelTextReference.FontFamily = FontFamily;
                labelTextReference.TextColor = Colors.Get(currentTextColor);

                if (Children.Count <= 2)
                {
                    Children.Add(labelTextReference);
                }
            }
            else
            {
                labelTextReference.TextColor = Colors.Get(currentTextColor);
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(CheckBox),
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
            CheckBox checkBox = (CheckBox)bindable;
            string copyFontFamily = (string)newValue;

            if (checkBox.labelTextReference == null)
            {
                checkBox.labelTextReference = new LabelCheck();
                checkBox.labelTextReference.VerticalTextAlignment = TextAlignment.Center;
                checkBox.labelTextReference.FontSize = checkBox.FontSize;
                checkBox.labelTextReference.TextColor = Colors.Get(checkBox.currentTextColor);

                if (checkBox.Children.Count <= 2)
                {
                    checkBox.Children.Add(checkBox.labelTextReference);
                }
            }
            checkBox.labelTextReference.FontFamily = copyFontFamily;
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
            if (!IsReadOnly)
            {
                if (checkBoxImageReference != null)
                {
                    checkBoxImageReference.Opacity = 1;

                    checkBoxImageReference.GestureRecognizers.Clear();

                    if (checkBoxImageReference.GestureRecognizers.Count == 0)
                    {
                        checkBoxImageReference.GestureRecognizers.Add(GetCheckClick());
                    }

                    if (labelTextReference != null)
                    {
                        labelTextReference.Opacity = 1;

                        labelTextReference.GestureRecognizers.Clear();

                        if (touchType == TouchType.WithText)
                        {
                            if (labelTextReference.GestureRecognizers.Count == 0)
                            {
                                labelTextReference.GestureRecognizers.Add(GetCheckClick());
                            }

                            if (currentVivacity != Vivacity.None && labelTextReference.GestureRecognizers.Count == 1)
                            {
                                labelTextReference.GestureRecognizers.Add(GetVivacity());
                            }
                        }
                    }

                    if (currentVivacity != Vivacity.None && checkBoxImageReference.GestureRecognizers.Count == 1)
                    {
                        checkBoxImageReference.GestureRecognizers.Add(GetVivacity());
                    }
                }
            }
            else
            {
                checkBoxImageReference.GestureRecognizers.Clear();
                labelTextReference.GestureRecognizers.Clear();
                checkBoxImageReference.Opacity = 0.25;
                labelTextReference.Opacity = 0.25;
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
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

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
                    CheckBoxImage checkBoxImage;
                    LabelCheck labelImage;

                    if (sender.GetType() == typeof(CheckBoxImage))
                    {
                        checkBoxImage = (CheckBoxImage)sender;
                        labelImage = checkBoxImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelCheck)sender;
                        checkBoxImage = labelImage.CheckBoxImage;
                    }

                    await checkBoxImage.ScaleTo(GetDepthDecrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await checkBoxImage.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    CheckBoxImage checkBoxImage;
                    LabelCheck labelImage;

                    if (sender.GetType() == typeof(CheckBoxImage))
                    {
                        checkBoxImage = (CheckBoxImage)sender;
                        labelImage = checkBoxImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelCheck)sender;
                        checkBoxImage = labelImage.CheckBoxImage;
                    }

                    await checkBoxImage.ScaleTo(GetDepthIncrease(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await checkBoxImage.ScaleTo(1, (uint)currentVivacitySpeed, Easing.Linear);
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
                    CheckBoxImage checkBoxImage;
                    LabelCheck labelImage;

                    if (sender.GetType() == typeof(CheckBoxImage))
                    {
                        checkBoxImage = (CheckBoxImage)sender;
                        labelImage = checkBoxImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelCheck)sender;
                        checkBoxImage = labelImage.CheckBoxImage;
                    }

                    await checkBoxImage.RotateTo(GetDepthRotation(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await checkBoxImage.RotateTo(0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    CheckBoxImage checkBoxImage;
                    LabelCheck labelImage;

                    if (sender.GetType() == typeof(CheckBoxImage))
                    {
                        checkBoxImage = (CheckBoxImage)sender;
                        labelImage = checkBoxImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelCheck)sender;
                        checkBoxImage = labelImage.CheckBoxImage;
                    }
                    
                    await checkBoxImage.TranslateTo(0, GetDepthJump(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await checkBoxImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    CheckBoxImage checkBoxImage;
                    LabelCheck labelImage;

                    if (sender.GetType() == typeof(CheckBoxImage))
                    {
                        checkBoxImage = (CheckBoxImage)sender;
                        labelImage = checkBoxImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelCheck)sender;
                        checkBoxImage = labelImage.CheckBoxImage;
                    }

                    await checkBoxImage.TranslateTo(0, GetDepthDown(currentDepth), (uint)currentVivacitySpeed, Easing.Linear);
                    await checkBoxImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    CheckBoxImage checkBoxImage;
                    LabelCheck labelImage;

                    if (sender.GetType() == typeof(CheckBoxImage))
                    {
                        checkBoxImage = (CheckBoxImage)sender;
                        labelImage = checkBoxImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelCheck)sender;
                        checkBoxImage = labelImage.CheckBoxImage;
                    }

                    await checkBoxImage.TranslateTo(GetDepthLeft(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await checkBoxImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
                    CheckBoxImage checkBoxImage;
                    LabelCheck labelImage;

                    if (sender.GetType() == typeof(CheckBoxImage))
                    {
                        checkBoxImage = (CheckBoxImage)sender;
                        labelImage = checkBoxImage.Label;
                    }
                    else
                    {
                        labelImage = (LabelCheck)sender;
                        checkBoxImage = labelImage.CheckBoxImage;
                    }

                    await checkBoxImage.TranslateTo(GetDepthRight(currentDepth), 0, (uint)currentVivacitySpeed, Easing.Linear);
                    await checkBoxImage.TranslateTo(0, 0, (uint)currentVivacitySpeed, Easing.Linear);
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
