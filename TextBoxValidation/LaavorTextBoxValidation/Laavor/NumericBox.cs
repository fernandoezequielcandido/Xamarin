using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class NumericBox
    /// </summary>
    public class NumericBox : LaavorBaseValidate
    {
        /// <summary>
        ///  Returns current value of field.
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// Returns if field value is valid.
        /// </summary>
        public new bool IsValid { get; private set; }

        private Label labelError;

        /// <summary>
        /// Call When user enter in NumericBox
        /// </summary>
        public event EventHandler EnterField;

        /// <summary>
        /// Call When NumericBox is Validate
        /// </summary>
        public event EventHandler Validate;

        private FontAttributes currentFontType = FontAttributes.None;
        private ValidationType currentValidationType = ValidationType.WhenLoseFocus;
        private NumericType currentNumericType = NumericType.Integer;
        private TextAlignment currentHorizontalTextAlignment = TextAlignment.Start;
        private Keyboard currentKeyboard = Keyboard.Numeric;

        private Entry entryReference;
        private Frame frameReference;

        /// <summary>
        /// Constructor of NumericBox
        /// </summary>
        public NumericBox() : base()
        {
            IsValid = true;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Horizontal;
            InitAll();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            SaveNumber(e.NewTextValue);

            if (currentValidationType == ValidationType.CharacterToCharacter)
            {
                validate(e.NewTextValue);
            }
        }

        private void SaveNumber(string strNumber)
        {
            Number = strNumber;
        }

        private void InitAll()
        {
            Children.Clear();

            LabelMessageError = null;

            entryReference = new Entry();
            entryReference.Focused += Entry_Focused;
            entryReference.Unfocused += Entry_Unfocused;
            entryReference.TextChanged += Entry_TextChanged;

            entryReference.VerticalOptions = LayoutOptions.Center;
            entryReference.Keyboard = currentKeyboard;
            entryReference.FontAttributes = currentFontType;
            entryReference.FontSize = FontSize;
            entryReference.HorizontalTextAlignment = HorizontalTextAlignment;
            entryReference.Margin = new Thickness(-10, -20, -10, -20);
            entryReference.InputTransparent = InputTransparent;
            entryReference.WidthRequest = Width;
            entryReference.TextColor = Colors.Get(NumberColor);
            entryReference.BackgroundColor = Color.Transparent;

            if (!string.IsNullOrEmpty(FontFamily))
            {
                entryReference.FontFamily = FontFamily;
            }

            if (DefaultNumber != null)
            {
                entryReference.Text = DefaultNumber.Value.ToString();
            }
            else
            {
                entryReference.Placeholder = Placeholder;
                entryReference.PlaceholderColor = Colors.Get(PlaceholderColor);
            }

            frameReference = new Frame();
            frameReference.BorderColor = Colors.Get(BorderColor);
            frameReference.VerticalOptions = LayoutOptions.Start;
            frameReference.BackgroundColor = Color.Transparent;

            frameReference.Content = entryReference;

            Children.Add(frameReference);
        }

        private void SetColorsInitialState()
        {
            frameReference.BackgroundColor = BackgroundColor;
            entryReference.TextColor = Colors.Get(NumberColor);
            frameReference.BorderColor = Colors.Get(BorderColor);

            if (LabelMessageError != null && ChangeMessageLabel)
            {
                LabelMessageError.Text = "";
            }
        }

        /// <summary>
        /// Validate
        /// </summary>
        public override void ForceValidate()
        {
            validate(Number, false);
        }

        private void validate(string valueStr, bool callEventValidate = true)
        {
            string currentValue = valueStr;
            bool containsError = false;

            Number = valueStr;

            SetColorsInitialState();

            if (CanEmpty && string.IsNullOrEmpty(valueStr))
            {
                containsError = false;
            }
            else if (!CanEmpty && string.IsNullOrEmpty(valueStr))
            {
                if (ChangeMessageLabel && LabelMessageError != null)
                {
                    LabelMessageError.Text = "The value is invalid.";
                }

                containsError = true;
            }
            else
            {
                if (valueStr == "-" || valueStr.Contains("-"))
                {
                    if (Minimum != null)
                    {
                        if (Minimum >= 0)
                        {
                            containsError = true;

                            if (ChangeMessageLabel && LabelMessageError != null)
                            {
                                LabelMessageError.Text = "The minimum value is " + Minimum.ToString() + ".";
                            }
                        }
                    }
                }

                if (!containsError && currentNumericType == NumericType.Integer)
                {
                    containsError = !(ValidateInteger(currentValue));
                }

                if (!containsError && currentNumericType == NumericType.Double)
                {
                    containsError = !(ValidateDouble(currentValue));
                }
            }

            if (containsError)
            {
                if (callEventValidate)
                {
                    if (LabelMessageError != null)
                    {
                        LabelMessageError.IsVisible = true;
                    }

                    frameReference.BackgroundColor = Colors.Get(ColorUIError);
                    entryReference.TextColor = Colors.Get(NumberColorError);
                    frameReference.BorderColor = Colors.Get(BorderColorError);
                }

                IsValid = false;
            }
            else
            {
                if (LabelMessageError != null)
                {
                    LabelMessageError.IsVisible = false;

                    if (ChangeMessageLabel)
                    {
                        LabelMessageError.Text = "";
                    }
                }

                IsValid = true;
            }

            base.IsValid = IsValid;

            if (callEventValidate)
            {
                Validate?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool ValidateInteger(string valueStr)
        {
            bool returnValue = true;
            int intValue;

            if (valueStr.Contains(",") && valueStr.Contains("."))
            {
                returnValue = false;

                if (ChangeMessageLabel && LabelMessageError != null)
                {
                    LabelMessageError.Text = "The value is invalid.";
                }
            }
            else if (int.TryParse(valueStr, out intValue))
            {
                if (Minimum != null && intValue < Minimum)
                {
                    returnValue = false;

                    if (ChangeMessageLabel && LabelMessageError != null)
                    {
                        LabelMessageError.Text = "The minimum value is " + Minimum.ToString() + ".";
                    }
                }

                if (returnValue && Maximum != null && intValue > Maximum)
                {
                    returnValue = false;
                    if (ChangeMessageLabel && LabelMessageError != null)
                    {
                        labelError.Text = "The maximum value is " + Maximum.ToString() + ".";
                    }

                }
            }
            else
            {
                returnValue = false;

                if (ChangeMessageLabel && LabelMessageError != null)
                {
                    LabelMessageError.Text = "The value is invalid.";
                }
            }

            return returnValue;
        }

        private bool ValidateDouble(string valueStr)
        {
            bool returnValue = true;
            double doubleValue;

            string valueLocal = valueStr.Replace(",", ".");
            if (double.TryParse(valueLocal, NumberStyles.Float, new CultureInfo("en-US"), out doubleValue))
            {
                string[] spltNumber;
                spltNumber = valueLocal.Split('.');

                if (spltNumber.Length > 1 && NumberOfDecimals != null)
                {
                    if (spltNumber[1].Length > NumberOfDecimals)
                    {
                        returnValue = false;

                        if (ChangeMessageLabel && LabelMessageError != null)
                        {
                            LabelMessageError.Text = "Limit of " + NumberOfDecimals + " decimals exceeded.";
                        }
                    }
                }

                if (returnValue && Minimum != null && doubleValue < Minimum)
                {
                    returnValue = false;

                    if (ChangeMessageLabel && LabelMessageError != null)
                    {
                        LabelMessageError.Text = "The minimum value is " + Minimum.ToString() + ".";
                    }
                    LabelMessageError.Text = "The minimum value is " + Minimum.ToString() + ".";
                }

                if (returnValue && Maximum != null && doubleValue > Maximum)
                {
                    returnValue = false;
                    labelError.Text = "The maximum value is " + Maximum.ToString() + ".";
                }
            }
            else
            {
                returnValue = false;

                if (ChangeMessageLabel && LabelMessageError != null)
                {
                    LabelMessageError.Text = "The value is invalid.";
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Set if is Integ
        /// </summary>
        [Bindable(true)]
        public new ValidationType ValidationType
        {
            get
            {
                return currentValidationType;
            }
            set
            {
                currentValidationType = value;
                ValidationTypePropertyChanged(value);
            }
        }

        private void ValidationTypePropertyChanged(ValidationType newValue)
        {
            ValidationType copyValidationType = (ValidationType)newValue;

            currentValidationType = copyValidationType;

            if (currentValidationType == ValidationType.CharacterToCharacter)
            {
                entryReference.TextChanged -= Entry_TextChanged;
                entryReference.TextChanged += Entry_TextChanged;
            }
            else
            {
                entryReference.TextChanged -= Entry_TextChanged;
            }
        }

        private static void TypeValidationPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            numericBox.entryReference.IsEnabled = (bool)newValue;
        }

        /// <summary>
        /// Property to report if NumericBox is IsReadOnly
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(NumericBox),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if numeric box is for display only.
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
            NumericBox numericBox = (NumericBox)bindable;

            if (numericBox.entryReference != null)
            {
                numericBox.entryReference.IsEnabled = (bool)newValue;
            }
        }

        /// <summary>
        /// Property to report if NumericBox is nullable
        /// </summary>
        public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                 propertyName: nameof(CanEmpty),
                 returnType: typeof(bool),
                 declaringType: typeof(NumericBox),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Property to report if NumericBox is nullable
        /// </summary>
        public bool CanEmpty
        {
            get
            {
                return (bool)GetValue(CanEmptyProperty);
            }
            set
            {
                SetValue(CanEmptyProperty, value);
            }
        }

        /// <summary>
        /// Default Number (Initial Value) if  necessary
        /// </summary>
        public static readonly BindableProperty DefaultNumberProperty = BindableProperty.Create(
                 propertyName: nameof(DefaultNumber),
                 returnType: typeof(double?),
                 declaringType: typeof(NumericBox),
                 defaultValue: null,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: DefaultNumberPropertyChanged);

        /// <summary>
        /// Default Number (Initial Value) if  necessary
        /// </summary>
        public double? DefaultNumber
        {
            get
            {
                return (double?)GetValue(DefaultNumberProperty);
            }
            set
            {
                SetValue(DefaultNumberProperty, value);
            }
        }

        private static void DefaultNumberPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            double copyDefaultNumber = (double)newValue;
            numericBox.validate(copyDefaultNumber.ToString());

            if (numericBox.entryReference != null)
            {
                numericBox.entryReference.Text = copyDefaultNumber.ToString();
            }
        }

        /// <summary>
        /// Number Of Decimals for double numbers
        /// </summary>
        public static readonly BindableProperty NumberOfDecimalsProperty = BindableProperty.Create(
                 propertyName: nameof(NumberOfDecimals),
                 returnType: typeof(int?),
                 declaringType: typeof(NumericBox),
                 defaultValue: null,
                 defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Number Of Decimals for double numbers
        /// </summary>
        public int? NumberOfDecimals
        {
            get
            {
                return (int?)GetValue(NumberOfDecimalsProperty);
            }
            set
            {
                SetValue(NumberOfDecimalsProperty, value);
            }
        }

        /// <summary>
        /// Minimum value - Information for validation
        /// </summary>
        public static readonly BindableProperty MinimumProperty = BindableProperty.Create(
                 propertyName: nameof(Minimum),
                 returnType: typeof(double?),
                 declaringType: typeof(NumericBox),
                 defaultValue: null,
                 defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Minimum value - Information for validation
        /// </summary>
        public double? Minimum
        {
            get
            {
                return (double?)GetValue(MinimumProperty);
            }
            set
            {
                SetValue(MinimumProperty, value);
            }
        }

        /// <summary>
        /// Maximum value - Information for validation
        /// </summary>
        public static readonly BindableProperty MaximumProperty = BindableProperty.Create(
                 propertyName: nameof(Maximum),
                 returnType: typeof(double?),
                 declaringType: typeof(NumericBox),
                 defaultValue: null,
                 defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Maximum value - Information for validation 
        /// </summary>
        public double? Maximum
        {
            get
            {
                return (double?)GetValue(MaximumProperty);
            }
            set
            {
                SetValue(MaximumProperty, value);
            }
        }

        /// <summary>
        /// Enter the font size.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(NumericBox),
            defaultValue: 20.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size.
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
            NumericBox numericBox = (NumericBox)bindable;
            double copyFontSize = (double)newValue;

            if (numericBox.entryReference != null)
            {
                numericBox.entryReference.FontSize = copyFontSize;
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
                FontTypePropertyChanged(value);
            }
        }

        private void FontTypePropertyChanged(FontAttributes newValue)
        {
            if (entryReference != null)
            {
                entryReference.FontAttributes = newValue;
            }
        }

        /// <summary>
        /// Enter the label to set message error, you can create your message without change.
        /// </summary>
        [Bindable(true)]
        public Label LabelMessageError
        {
            get
            {
                return labelError;
            }
            set
            {
                labelError = value;
                if (value != null)
                {
                    labelError.IsVisible = false;
                }
            }
        }

        /// <summary>
        /// Enter the numerictype of box (double or integer).
        /// </summary>
        [Bindable(true)]
        public NumericType NumericType
        {
            get
            {
                return currentNumericType;
            }
            set
            {
                currentNumericType = value;
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
                HorizontalTextAlignmentPropertyChanged(value);

            }
        }

        private void HorizontalTextAlignmentPropertyChanged(TextAlignment newValue)
        {
            if (entryReference != null)
            {
                entryReference.HorizontalTextAlignment = newValue;
            }
        }

        /// <summary>
        /// Enter the Width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(NumericBox),
            defaultValue: 300.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the Width.
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
            NumericBox numericBox = (NumericBox)bindable;
            double copyWidthRequest = (double)newValue;

            if (numericBox.entryReference != null)
            {
                numericBox.entryReference.WidthRequest = copyWidthRequest;
            }
        }

        /// <summary>
        /// Enter the number color(text).
        /// </summary>
        public static readonly BindableProperty NumberColorProperty = BindableProperty.Create(
         propertyName: nameof(NumberColor),
         returnType: typeof(ColorUI),
         declaringType: typeof(NumericBox),
         defaultValue: ColorUI.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: NumberColorPropertyChanged);

        /// <summary>
        /// Enter the number color(text).
        /// </summary>
        public ColorUI NumberColor
        {
            get
            {
                return (ColorUI)GetValue(NumberColorProperty);
            }
            set
            {
                SetValue(NumberColorProperty, value);
            }
        }

        private static void NumberColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            ColorUI copyNumberColor = (ColorUI)newValue;

            if (numericBox.IsValid && numericBox.entryReference != null)
            {
                numericBox.entryReference.TextColor = Colors.Get(copyNumberColor);
            }
        }

        /// <summary>
        /// Enter the number color error(text).
        /// </summary>
        public static readonly BindableProperty NumberColorErrorProperty = BindableProperty.Create(
         propertyName: nameof(NumberColorError),
         returnType: typeof(ColorUI),
         declaringType: typeof(NumericBox),
         defaultValue: ColorUI.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: NumberColorErrorPropertyChanged);

        /// <summary>
        /// Enter the number color error(text).
        /// </summary>
        public ColorUI NumberColorError
        {
            get
            {
                return (ColorUI)GetValue(NumberColorErrorProperty);
            }
            set
            {
                SetValue(NumberColorErrorProperty, value);
            }
        }

        private static void NumberColorErrorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            ColorUI copyNumberColorError = (ColorUI)newValue;

            if (!numericBox.IsValid && numericBox.entryReference != null)
            {
                numericBox.entryReference.TextColor = Colors.Get(copyNumberColorError);
            }
        }

        /// <summary>
        /// Enter the ColorUI (background).
        /// </summary>
        public static readonly BindableProperty ColorUIProperty = BindableProperty.Create(
         propertyName: nameof(ColorUI),
         returnType: typeof(ColorUI),
         declaringType: typeof(NumericBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIPropertyChanged);

        /// <summary>
        /// Enter the ColorUI (background).
        /// </summary>
        public ColorUI ColorUI
        {
            get
            {
                return (ColorUI)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        private static void ColorUIPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            ColorUI copyColorUI = (ColorUI)newValue;

            if (numericBox.IsValid && numericBox.frameReference != null)
            {
                numericBox.frameReference.BackgroundColor = Colors.Get(copyColorUI);
            }
        }

        /// <summary>
        /// Enter the number ColorUI (Background) error(text).
        /// </summary>
        public static readonly BindableProperty ColorUIErrorProperty = BindableProperty.Create(
         propertyName: nameof(ColorUIError),
         returnType: typeof(ColorUI),
         declaringType: typeof(NumericBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIErrorPropertyChanged);

        /// <summary>
        /// Enter the number ColorUIError(BackgroundColor).
        /// </summary>
        public ColorUI ColorUIError
        {
            get
            {
                return (ColorUI)GetValue(ColorUIErrorProperty);
            }
            set
            {
                SetValue(ColorUIErrorProperty, value);
            }
        }

        private static void ColorUIErrorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            ColorUI copyBackgroundColorError = (ColorUI)newValue;

            if (!numericBox.IsValid && numericBox.frameReference != null)
            {
                numericBox.frameReference.BackgroundColor = Colors.Get(copyBackgroundColorError);
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(NumericBox),
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
            NumericBox numericBox = (NumericBox)bindable;
            string copyFontFamily = (string)newValue;

            if (numericBox.entryReference != null)
            {
                numericBox.entryReference.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Informs if use the default messages of plugin laavor.
        /// </summary>
        public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
            propertyName: nameof(ChangeMessageLabel),
            returnType: typeof(bool),
            declaringType: typeof(NumericBox),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Informs if use the default messages of plugin laavor.
        /// </summary>
        public bool ChangeMessageLabel
        {
            get
            {
                return (bool)GetValue(ChangeMessageLabelProperty);
            }
            set
            {
                SetValue(ChangeMessageLabelProperty, value);
            }
        }

        /// <summary>
        /// Placeholder if not using DefaultNumber.
        /// </summary>
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder),
            returnType: typeof(string),
            declaringType: typeof(NumericBox),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: PlaceholderPropertyChanged);

        /// <summary>
        /// Placeholder if not using DefaultNumber.
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
            NumericBox numericBox = (NumericBox)bindable;
            string copyPlaceholder = (string)newValue;

            if (numericBox.DefaultNumber == null && numericBox.entryReference != null)
            {
                numericBox.entryReference.Placeholder = copyPlaceholder;
            }
        }

        /// <summary>
        /// Enter the  BorderColor
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColor),
           returnType: typeof(ColorUI),
           declaringType: typeof(NumericBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorPropertyChanged);

        /// <summary>
        /// Enter the  BorderColor
        /// </summary>
        public ColorUI BorderColor
        {
            get
            {
                return (ColorUI)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        private static void BorderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            ColorUI copyBorderColor = (ColorUI)newValue;

            if (numericBox.frameReference != null)
            {
                numericBox.frameReference.BorderColor = Colors.Get(copyBorderColor);
            }
        }

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid number
        /// </summary>
        public static readonly BindableProperty BorderColorErrorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColorError),
           returnType: typeof(ColorUI),
           declaringType: typeof(NumericBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorErrorPropertyChanged);

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid number
        /// </summary>
        public ColorUI BorderColorError
        {
            get
            {
                return (ColorUI)GetValue(BorderColorErrorProperty);
            }
            set
            {
                SetValue(BorderColorErrorProperty, value);
            }
        }

        private static void BorderColorErrorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            ColorUI copyBorderColorError = (ColorUI)newValue;

            if (!numericBox.IsValid && numericBox.frameReference != null)
            {
                numericBox.frameReference.BorderColor = Colors.Get(copyBorderColorError);
            }
        }

        /// <summary>
        /// Enter the placeholder color.
        /// </summary>
        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
            propertyName: nameof(PlaceholderColor),
            returnType: typeof(ColorUI),
            declaringType: typeof(NumericBox),
            defaultValue: ColorUI.Gray,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: PlaceholderColorPropertyChanged);

        /// <summary>
        /// Enter the placeholder color.
        /// </summary>
        public ColorUI PlaceholderColor
        {
            get
            {
                return (ColorUI)GetValue(PlaceholderColorProperty);
            }
            set
            {
                SetValue(PlaceholderColorProperty, value);
            }
        }

        private static void PlaceholderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            NumericBox numericBox = (NumericBox)bindable;
            ColorUI copyPlaceholderColor = (ColorUI)newValue;

            if (numericBox.DefaultNumber == null && numericBox.entryReference != null)
            {
                numericBox.entryReference.PlaceholderColor = Colors.Get(copyPlaceholderColor);
            }
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if (currentValidationType == ValidationType.WhenLoseFocus)
            {
                validate((sender as Entry).Text);
            }
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            EnterField?.Invoke(this, EventArgs.Empty);
        }
    }
}
