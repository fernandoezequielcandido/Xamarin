using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Validate
    {
        /// <summary>
        /// Class ValidateText
        /// </summary>
        public class ValidateText: ValidateBase
        {
            /// <summary>
            ///  Returns current text of field.
            /// </summary>
            public string Text { get; private set; }

            /// <summary>
            /// Returns if field value is valid.
            /// </summary>
            public new bool IsValid { get; private set; }

            private Label labelError;

            /// <summary>
            /// Call When user Enter in TextBox
            /// </summary>
            public event EventHandler EnterField;

            /// <summary>
            /// Cal When TextBox Is Validate
            /// </summary>
            public event EventHandler Validate;

            private Entry entry;
            private Frame frame;

            private ValidationType validationType = ValidationType.WhenLoseFocus;
            private FontAttributes fontType = FontAttributes.None;
            private TextAlignment horizontalTextAlignment = TextAlignment.End;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI textColorError = ColorUI.Red;
            private ColorUI colorUI = ColorUI.White;
            private ColorUI colorUIError = ColorUI.White;
            private ColorUI borderColor = ColorUI.Black;
            private ColorUI borderColorError = ColorUI.Black;
            private ColorUI placeHolderColor = ColorUI.GrayLight;

            /// <summary>
            /// Constructor of ValidateText
            /// </summary>
            public ValidateText() : base()
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
                SaveText(e.NewTextValue);

                if (ValidationType == ValidationType.CharacterToCharacter)
                {
                    validate(e.NewTextValue);
                }
            }

            private void SaveText(string strText)
            {
                Text = strText;
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
                entry.Keyboard = Keyboard;
                entry.FontAttributes = FontType;
                entry.TextColor = Colors.Get(TextColor);
                entry.FontSize = FontSize;
                entry.HorizontalTextAlignment = HorizontalTextAlignment;
                entry.Margin = new Thickness(-10, -20, -10, -20);
                entry.WidthRequest = Width;
                entry.TextColor = Colors.Get(TextColor);
                entry.BackgroundColor = Color.Transparent;

                if (!string.IsNullOrEmpty(FontFamily))
                {
                    entry.FontFamily = FontFamily;
                }

                entry.Placeholder = Placeholder;
                entry.PlaceholderColor = Colors.Get(PlaceholderColor);

                frame = new Frame();
                frame.BorderColor = Colors.Get(BorderColor);
                frame.VerticalOptions = LayoutOptions.Start;
                frame.BackgroundColor = Color.Transparent;

                frame.Content = entry;

                StackLayout stackCenter = new StackLayout();
                stackCenter.Spacing = 0;
                stackCenter.Margin = new Thickness(0.05, 0, 0.05, 0);
                stackCenter.HorizontalOptions = LayoutOptions.Center;
                stackCenter.Orientation = StackOrientation.Vertical;
                stackCenter.Children.Add(frame);
                stackCenter.BackgroundColor = Color.Transparent;

                Children.Add(stackCenter);
            }

            private void SetColorsInitialState()
            {
                frame.BackgroundColor = BackgroundColor;
                entry.TextColor = Colors.Get(TextColor);
                frame.BorderColor = Colors.Get(BorderColor);

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
                validate(Text, false);
            }

            private void validate(string valueStr, bool callEventValidate = true)
            {
                SetColorsInitialState();
                bool isValid = true;

                if (string.IsNullOrEmpty(valueStr))
                {
                    if (!CanEmpty)
                    {
                        isValid = false;

                        if (ChangeMessageLabel && LabelMessageError != null)
                        {
                            LabelMessageError.Text = "Text must be at least " + MinimumOfCharacters + " characters long.";
                        }
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else if (MinimumOfCharacters != null || MaximumOfCharacters != null)
                {
                    if (MinimumOfCharacters != null && valueStr.Length < MinimumOfCharacters)
                    {
                        if (ChangeMessageLabel && LabelMessageError != null)
                        {
                            LabelMessageError.Text = "Text must be at least " + MinimumOfCharacters + " characters long.";
                        }

                        isValid = false;
                    }

                    if (MaximumOfCharacters != null && valueStr.Length > MaximumOfCharacters)
                    {
                        if (ChangeMessageLabel && LabelMessageError != null)
                        {
                            LabelMessageError.Text = "Text must be " + MaximumOfCharacters + " characters or less.";
                        }

                        isValid = false;
                    }
                }

                if (!isValid)
                {
                    if (callEventValidate)
                    {
                        if (LabelMessageError != null)
                        {
                            LabelMessageError.IsVisible = true;
                        }

                        frame.BackgroundColor = Colors.Get(ColorUIError);
                        entry.TextColor = Colors.Get(TextColorError);
                        frame.BorderColor = Colors.Get(BorderColorError);
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

                Text = valueStr;

                if (callEventValidate)
                {
                    Validate?.Invoke(this, EventArgs.Empty);
                }
            }

            /// <summary>
            /// Set Keyboard
            /// </summary>
            public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
                     propertyName: nameof(Keyboard),
                     returnType: typeof(Keyboard),
                     declaringType: typeof(ValidateText),
                     defaultValue: Keyboard.Text,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: KeyboardPropertyChanged);

            /// <summary>
            /// Set Keyboard
            /// </summary>
            public Keyboard Keyboard
            {
                get
                {
                    return (Keyboard)GetValue(KeyboardProperty);
                }
                set
                {
                    SetValue(KeyboardProperty, value);
                }
            }

            private static void KeyboardPropertyChanged(object bindable, object oldValue, object newValue)
            {
                ValidateText text = (ValidateText)bindable;

                if (text.entry != null)
                {
                    text.entry.IsEnabled = (bool)newValue;
                }
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
                if (entry != null)
                {
                    if (ValidationType.CharacterToCharacter == validationType)
                    {
                        entry.TextChanged -= Entry_TextChanged;
                        entry.TextChanged += Entry_TextChanged;
                    }
                    else
                    {
                        entry.TextChanged -= Entry_TextChanged;
                    }
                }

                if (entry != null)
                {
                    entry.IsEnabled = true;
                }
            }

            /// <summary>
            /// Set IsReadOnly
            /// </summary>
            public static new readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidateText),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Set IsReadOnly
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
                ValidateText validateText = (ValidateText)bindable;
                bool readOnly = (bool)newValue;

                if (validateText.entry != null)
                {
                    validateText.entry.IsEnabled = readOnly;
                }
            }

            /// <summary>
            /// Property to report if TextBox is nullable
            /// </summary>
            public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                     propertyName: nameof(CanEmpty),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidateText),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Property to report if TextBox is nullable
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
            /// Enter the font size.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(ValidateText),
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
                ValidateText validateText = (ValidateText)bindable;
                double fontSize = (double)newValue;

                if (validateText.entry != null)
                {
                    validateText.entry.FontSize = fontSize;
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
                if (entry != null)
                {
                    entry.FontAttributes = fontType;
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
                    HorizontalTextLignmentChanged();
                }
            }

            private void HorizontalTextLignmentChanged()
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
                declaringType: typeof(ValidateText),
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
                ValidateText validateText = (ValidateText)bindable;
                double width = (double)newValue;

                if (validateText.entry != null)
                {
                    validateText.entry.WidthRequest = width;
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
                    TextColorChanged();
                }
            }

            private void TextColorChanged()
            {
                if (IsValid && entry != null)
                {
                    entry.TextColor = Colors.Get(textColor);
                }
            }

            /// <summary>
            /// Set TextColorError
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
                    TextColorErrorChanged();
                }
            }

            private void TextColorErrorChanged()
            {
                if (!IsValid && entry != null)
                {
                    entry.TextColor = Colors.Get(textColorError);
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
                    ColorUIChanged();
                }
            }

            private void ColorUIChanged()
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
                    ColorUIErrorChanged();
                }
            }

            private void ColorUIErrorChanged()
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
                declaringType: typeof(ValidateText),
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
                ValidateText validateText = (ValidateText)bindable;
                string fontFamily = (string)newValue;

                if (validateText.entry != null)
                {
                    validateText.entry.FontFamily = fontFamily;
                }
            }

            /// <summary>
            /// Informs if use the default messages of plugin laavor.
            /// </summary>
            public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
                propertyName: nameof(ChangeMessageLabel),
                returnType: typeof(bool),
                declaringType: typeof(ValidateText),
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
            /// Placeholder
            /// </summary>
            public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
                propertyName: nameof(Placeholder),
                returnType: typeof(string),
                declaringType: typeof(ValidateText),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: PlaceholderPropertyChanged);

            /// <summary>
            /// Placeholder
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
                ValidateText validateText = (ValidateText)bindable;
                string placeholder = (string)newValue;

                if (validateText.entry != null)
                {
                    validateText.entry.Placeholder = placeholder;
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
                    BorderColorChanged();
                }
            }

            private void BorderColorChanged()
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
                    BorderColorErrorChanged();
                }
            }

            private void BorderColorErrorChanged()
            {
                if (!IsValid && frame != null)
                {
                    frame.BorderColor = Colors.Get(borderColorError);
                }
            }

            /// <summary>
            /// Enter the placeholder color.
            /// </summary>
            public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
                propertyName: nameof(PlaceholderColor),
                returnType: typeof(ColorUI),
                declaringType: typeof(ValidateText),
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
                ValidateText textBox = (ValidateText)bindable;
                ColorUI placeholderColor = (ColorUI)newValue;

                if (textBox.entry != null)
                {
                    textBox.entry.PlaceholderColor = Colors.Get(placeholderColor);
                }
            }

            /// <summary>
            /// Minimum Of Characters - Information for validation
            /// </summary>
            public static readonly BindableProperty MinimumOfCharactersProperty = BindableProperty.Create(
                     propertyName: nameof(MinimumOfCharacters),
                     returnType: typeof(int?),
                     declaringType: typeof(ValidateText),
                     defaultValue: null,
                     defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Minimum Of Characters - Information for validation
            /// </summary>
            public int? MinimumOfCharacters
            {
                get
                {
                    return (int?)GetValue(MinimumOfCharactersProperty);
                }
                set
                {
                    SetValue(MinimumOfCharactersProperty, value);
                }
            }

            /// <summary>
            /// Maximum of Characters - Information for validation
            /// </summary>
            public static readonly BindableProperty MaximumOfCharactersProperty = BindableProperty.Create(
                     propertyName: nameof(MaximumOfCharacters),
                     returnType: typeof(int?),
                     declaringType: typeof(ValidateText),
                     defaultValue: null,
                     defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Maximum of Characters
            /// </summary>
            public int? MaximumOfCharacters
            {
                get
                {
                    return (int?)GetValue(MaximumOfCharactersProperty);
                }
                set
                {
                    SetValue(MaximumOfCharactersProperty, value);
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
