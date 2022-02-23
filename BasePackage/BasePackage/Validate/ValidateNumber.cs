using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace Laavor
{
    namespace Validate
    {
        /// <summary>
        /// Class ValidateNumber
        /// </summary>
        public class ValidateNumber : ValidateBase
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

            private Keyboard keyboard = Keyboard.Numeric;

            private Entry entry;
            private Frame frame;

            private ValidationType validationType = ValidationType.WhenLoseFocus;
            private FontAttributes fontType = FontAttributes.None;
            private NumericType numericType = NumericType.Integer;
            private TextAlignment horizontalTextAlignment = TextAlignment.End;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI textColorError = ColorUI.Red;
            private ColorUI colorUI = ColorUI.White;
            private ColorUI colorUIError = ColorUI.White;
            private ColorUI borderColor = ColorUI.Black;
            private ColorUI borderColorError = ColorUI.Black;
            private ColorUI placeHolderColor = ColorUI.GrayLight;

            /// <summary>
            /// Constructor of ValidateNumber
            /// </summary>
            public ValidateNumber() : base()
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

                if (ValidationType == ValidationType.CharacterToCharacter)
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

                entry = new Entry();
                entry.Focused += Entry_Focused;
                entry.Unfocused += Entry_Unfocused;
                entry.TextChanged += Entry_TextChanged;

                entry.VerticalOptions = LayoutOptions.Center;
                entry.Keyboard = keyboard;
                entry.FontAttributes = fontType;
                entry.FontSize = FontSize;
                entry.HorizontalTextAlignment = HorizontalTextAlignment;
                entry.Margin = new Thickness(-10, -20, -10, -20);
                entry.InputTransparent = InputTransparent;
                entry.WidthRequest = Width;
                entry.TextColor = Colors.Get(textColor);
                entry.BackgroundColor = Color.Transparent;

                if (!string.IsNullOrEmpty(FontFamily))
                {
                    entry.FontFamily = FontFamily;
                }

                if (DefaultNumber != null)
                {
                    entry.Text = DefaultNumber.Value.ToString();
                }
                else
                {
                    entry.Placeholder = Placeholder;
                    entry.PlaceholderColor = Colors.Get(PlaceholderColor);
                }

                frame = new Frame();
                frame.BorderColor = Colors.Get(BorderColor);
                frame.VerticalOptions = LayoutOptions.Start;
                frame.BackgroundColor = Colors.Get(colorUI);

                frame.Content = entry;

                Children.Add(frame);
            }

            private void SetColorsInitialState()
            {
                frame.BackgroundColor = Colors.Get(colorUI);
                entry.TextColor = Colors.Get(textColor);
                frame.BorderColor = Colors.Get(borderColor);

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

                    if (!containsError && numericType == NumericType.Integer)
                    {
                        containsError = !(ValidateInteger(currentValue));
                    }

                    if (!containsError && numericType == NumericType.Double)
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

                        frame.BackgroundColor = Colors.Get(colorUIError);
                        entry.TextColor = Colors.Get(textColorError);
                        frame.BorderColor = Colors.Get(borderColorError);
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
            /// Set ValidationType
            /// </summary>
            [Bindable(true)]
            public ValidationType ValidationType
            {
                get
                {
                    return validationType;
                }
                set
                {
                    validationType = value;
                    ValidationTypePropertyChanged();
                }
            }

            private void ValidationTypePropertyChanged()
            {
                if (validationType == ValidationType.CharacterToCharacter)
                {
                    entry.TextChanged -= Entry_TextChanged;
                    entry.TextChanged += Entry_TextChanged;
                }
                else
                {
                    entry.TextChanged -= Entry_TextChanged;
                }
            }

            /// <summary>
            /// Set if IsReadOnly
            /// </summary>
            public new static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidateNumber),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Set if IsReadOnly
            /// </summary>
            public new bool IsReadOnly
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
                ValidateNumber validateNumber = (ValidateNumber)bindable;
                bool readOnly = (bool)newValue;

                if (validateNumber.entry != null)
                {
                    validateNumber.entry.IsEnabled = readOnly;
                }
            }

            /// <summary>
            /// Property to report if ValidateNumber is nullable
            /// </summary>
            public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                     propertyName: nameof(CanEmpty),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidateNumber),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Property to report if ValidateNumber is nullable
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
                     declaringType: typeof(ValidateNumber),
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
                ValidateNumber validateNumber = (ValidateNumber)bindable;
                double defaultNumber = (double)newValue;
                validateNumber.validate(defaultNumber.ToString());

                if (validateNumber.entry != null)
                {
                    validateNumber.entry.Text = defaultNumber.ToString();
                }
            }

            /// <summary>
            /// Number Of Decimals for double numbers
            /// </summary>
            public static readonly BindableProperty NumberOfDecimalsProperty = BindableProperty.Create(
                     propertyName: nameof(NumberOfDecimals),
                     returnType: typeof(int?),
                     declaringType: typeof(ValidateNumber),
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
                     declaringType: typeof(ValidateNumber),
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
                     declaringType: typeof(ValidateNumber),
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
                declaringType: typeof(ValidateNumber),
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
                ValidateNumber validateNumber = (ValidateNumber)bindable;
                double fontSize = (double)newValue;

                if (validateNumber.entry != null)
                {
                    validateNumber.entry.FontSize = fontSize;
                }
            }

            /// <summary>
            /// Set FontAttributes
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
                if (entry != null)
                {
                    entry.FontAttributes = fontType;
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
            /// Set NumericType
            /// </summary>
            [Bindable(true)]
            public NumericType NumericType
            {
                get
                {
                    return numericType;
                }
                set
                {
                    numericType = value;
                }
            }

            /// <summary>
            /// Set HorizontalTextAlignment
            /// </summary>
            [Bindable(true)]
            public TextAlignment HorizontalTextAlignment
            {
                get
                {
                    return horizontalTextAlignment;
                }
                set
                {
                    horizontalTextAlignment = value;
                }
            }

            private void HorizontalTextAlignmentPropertyChanged()
            {
                if (entry != null)
                {
                    entry.HorizontalTextAlignment = horizontalTextAlignment;
                }
            }

            /// <summary>
            /// Enter the Width.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(ValidateNumber),
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
                ValidateNumber validateNumber = (ValidateNumber)bindable;
                double width = (double)newValue;

                if (validateNumber.entry != null)
                {
                    validateNumber.entry.WidthRequest = width;
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
                if (IsValid && entry != null)
                {
                    entry.TextColor = Colors.Get(textColor);
                }
            }

            /// <summary>
            /// Set TextColor
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorError
            {
                get
                {
                    return textColorError;
                }
                set
                {
                    textColorError = value;
                    TextColorErrorPropertyChanged();
                }
            }

            private void TextColorErrorPropertyChanged()
            {
                if (!IsValid && entry != null)
                {
                    entry.TextColor = Colors.Get(TextColorError);
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
                    return colorUI;
                }
                set
                {
                    colorUI = value;
                    ColorUIPropertyChanged();
                }
            }

            private void ColorUIPropertyChanged()
            {
                if (IsValid && frame != null)
                {
                    frame.BackgroundColor = Colors.Get(colorUI);
                }
            }

            /// <summary>
            /// Set ColorUIError
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIError
            {
                get
                {
                    return colorUIError;
                }
                set
                {
                    colorUIError = value;
                    ColorUIErrorPropertyChanged();
                }
            }

            private void ColorUIErrorPropertyChanged()
            {
                if (!IsValid && frame != null)
                {
                    frame.BackgroundColor = Colors.Get(colorUIError);
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(ValidateNumber),
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
                ValidateNumber validateNumber = (ValidateNumber)bindable;
                string fontFamily = (string)newValue;

                if (validateNumber.entry != null)
                {
                    validateNumber.entry.FontFamily = fontFamily;
                }
            }

            /// <summary>
            /// Informs if use the default messages error.
            /// </summary>
            public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
                propertyName: nameof(ChangeMessageLabel),
                returnType: typeof(bool),
                declaringType: typeof(ValidateNumber),
                defaultValue: false,
                defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Informs if use the default messages error.
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
                declaringType: typeof(ValidateNumber),
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
                ValidateNumber validateNumber = (ValidateNumber)bindable;
                string placeholder = (string)newValue;

                if (validateNumber.DefaultNumber == null && validateNumber.entry != null)
                {
                    validateNumber.entry.Placeholder = placeholder;
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
                    return borderColor;
                }
                set
                {
                    borderColor = value;
                    BorderColorPropertyChanged();
                }
            }

            private void BorderColorPropertyChanged()
            {
                if (frame != null)
                {
                    frame.BorderColor = Colors.Get(borderColor);
                }
            }

            /// <summary>
            /// Set BorderColorError
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorError
            {
                get
                {
                    return borderColorError;
                }
                set
                {
                    borderColorError = value;
                    BorderColorErrorPropertyChanged();
                }
            }

            private void BorderColorErrorPropertyChanged()
            {
                if (!IsValid && frame != null)
                {
                    frame.BorderColor = Colors.Get(borderColorError);
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
                    return placeHolderColor;
                }
                set
                {
                    placeHolderColor = value;
                    PlaceholderColorPropertyChanged();
                }
            }

            private void PlaceholderColorPropertyChanged()
            {
                if (DefaultNumber == null && entry != null)
                {
                    entry.PlaceholderColor = Colors.Get(placeHolderColor);
                }
            }

            private void Entry_Unfocused(object sender, FocusEventArgs e)
            {
                if (ValidationType == ValidationType.WhenLoseFocus)
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
}
