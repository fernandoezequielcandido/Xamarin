using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Laavor
{
    namespace Validate
    {
        /// <summary>
        /// Class ValidateEmail
        /// </summary>
        public class ValidateEmail : ValidateBase
        {
            /// <summary>
            /// Returns current value of field.
            /// </summary>
            public string Email { get; private set; }

            /// <summary>
            /// Returns if field value is valid.
            /// </summary>
            public new bool IsValid { get; private set; }

            private Label labelError;

            /// <summary>
            /// Call When user enter in ValidateEmail
            /// </summary>
            public event EventHandler EnterField;

            /// <summary>
            /// Call When ValidateEmail is Validate
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
            /// Constructor of ValidateEmail
            /// </summary>
            public ValidateEmail() : base()
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
                SaveEmail(e.NewTextValue);

                if (validationType == ValidationType.CharacterToCharacter)
                {
                    validate(e.NewTextValue);
                }
            }

            private void SaveEmail(string strEmail)
            {
                Email = strEmail;
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
                entry.FontSize = FontSize;
                entry.HorizontalTextAlignment = HorizontalTextAlignment;
                entry.Margin = new Thickness(-10, -20, -10, -20);
                entry.WidthRequest = Width;
                entry.TextColor = Colors.Get(textColor);
                entry.BackgroundColor = Color.Transparent;

                if (!string.IsNullOrEmpty(FontFamily))
                {
                    entry.FontFamily = FontFamily;
                }

                entry.Placeholder = Placeholder;

                entry.PlaceholderColor = Colors.Get(placeHolderColor);

                frame = new Frame();
                frame.BorderColor = Colors.Get(borderColor);
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
            /// Call al Validations of Boxes inside Form
            /// </summary>
            public override void ForceValidate()
            {
                validate(Email, false);
            }

            private void validate(string valueStr, bool callEventValidate = true)
            {
                SetColorsInitialState();
                bool isValid = false;

                string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

                if (!string.IsNullOrEmpty(valueStr))
                {
                    isValid = (Regex.IsMatch(valueStr, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                }
                else
                {
                    if (!CanEmpty)
                    {
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
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

                        frame.BackgroundColor = Colors.Get(colorUIError);
                        entry.TextColor = Colors.Get(textColorError);
                        frame.BorderColor = Colors.Get(borderColorError);

                        if (ChangeMessageLabel && LabelMessageError != null)
                        {
                            LabelMessageError.Text = "The email is invalid.";
                        }
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

                Email = valueStr;

                base.IsValid = IsValid;
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
                     declaringType: typeof(ValidateEmail),
                     defaultValue: Keyboard.Email,
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
                ValidateEmail validateEmail = (ValidateEmail)bindable;
                Keyboard keyboard = (Keyboard)newValue;

                if (validateEmail.entry != null)
                {
                    validateEmail.entry.Keyboard = keyboard;
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
            /// Property to report if ValidateEmail is IsReadOnly
            /// </summary>
            public new static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                     propertyName: nameof(IsReadOnly),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidateEmail),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: IsReadOnlyPropertyChanged);

            /// <summary>
            /// Property to report if ValidateEmail is IsReadOnly
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
                ValidateEmail validateEmail = (ValidateEmail)bindable;
                bool readOnly = (bool)newValue;

                if (validateEmail.entry != null)
                {
                    validateEmail.entry.IsEnabled = readOnly;
                }
            }

            /// <summary>
            /// Property to report if ValidateEmail is nullable
            /// </summary>
            public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                     propertyName: nameof(CanEmpty),
                     returnType: typeof(bool),
                     declaringType: typeof(ValidateEmail),
                     defaultValue: false,
                     defaultBindingMode: BindingMode.OneWay);

            /// <summary>
            /// Property to report if ValidateEmail is nullable
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
                declaringType: typeof(ValidateEmail),
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
                ValidateEmail emailBox = (ValidateEmail)bindable;
                double fontSize = (double)newValue;

                if (emailBox.entry != null)
                {
                    emailBox.entry.FontSize = fontSize;
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
                    HorizontalTextAlignmentPropertyChanged();
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
                declaringType: typeof(ValidateEmail),
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
                ValidateEmail validateEmail = (ValidateEmail)bindable;
                double width = (double)newValue;

                if (validateEmail.entry != null)
                {
                    validateEmail.entry.WidthRequest = width;
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
                    TextColorErrorPropertyChanged();
                }
            }

            private void TextColorErrorPropertyChanged()
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
                declaringType: typeof(ValidateEmail),
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
                ValidateEmail emailBox = (ValidateEmail)bindable;
                string fontFamily = (string)newValue;

                if (emailBox.entry != null)
                {
                    emailBox.entry.FontFamily = fontFamily;
                }
            }

            /// <summary>
            /// Informs if use the default messages of plugin laavor.
            /// </summary>
            public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
                propertyName: nameof(ChangeMessageLabel),
                returnType: typeof(bool),
                declaringType: typeof(ValidateEmail),
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
                declaringType: typeof(ValidateEmail),
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
                ValidateEmail validateEmail = (ValidateEmail)bindable;
                string placeholder = (string)newValue;

                if (validateEmail.entry != null)
                {
                    validateEmail.entry.Placeholder = placeholder;
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
                if (IsValid && frame != null)
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
            /// Set PlaceHolderColor
            /// </summary>
            [Bindable(true)]
            public ColorUI PlaceHolderColor
            {
                get
                {
                    return placeHolderColor;
                }
                set
                {
                    placeHolderColor = value;
                    PlaceHolderColorPropertyChanged();
                }
            }
                     
            private void PlaceHolderColorPropertyChanged()
            {
                if (entry != null)
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
