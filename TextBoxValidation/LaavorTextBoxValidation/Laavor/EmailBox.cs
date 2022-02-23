using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class EmailBox
    /// </summary>
    public class EmailBox: LaavorBaseValidate
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
        /// Call When user enter in EmailBox
        /// </summary>
        public event EventHandler EnterField;

        /// <summary>
        /// Call When EmailBox is Validate
        /// </summary>
        public event EventHandler Validate;

        private FontAttributes currentFontType = FontAttributes.None;
        private ValidationType currentValidationType = ValidationType.WhenLoseFocus;
        private TextAlignment currentHorizontalTextAlignment = TextAlignment.Start;
        private Keyboard currentKeyboard = Keyboard.Email;

        private Entry entryReference;
        private Frame frameReference;

        /// <summary>
        /// Constructor of EmailBox
        /// </summary>
        public EmailBox() : base()
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

            if (currentValidationType == ValidationType.CharacterToCharacter)
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
            entryReference.WidthRequest = Width;
            entryReference.TextColor = Colors.Get(EmailColor);
            entryReference.BackgroundColor = Color.Transparent;

            if (!string.IsNullOrEmpty(FontFamily))
            {
                entryReference.FontFamily = FontFamily;
            }

            entryReference.Placeholder = Placeholder;

            entryReference.PlaceholderColor = Colors.Get(PlaceholderColor);

            frameReference = new Frame();
            frameReference.BorderColor = Colors.Get(BorderColor);
            frameReference.VerticalOptions = LayoutOptions.Start;
            frameReference.BackgroundColor = Colors.Get(ColorUI);

            frameReference.Content = entryReference;

            Children.Add(frameReference);
        }

        private void SetColorsInitialState()
        {
            frameReference.BackgroundColor = Colors.Get(ColorUI);
            entryReference.TextColor = Colors.Get(EmailColor);
            frameReference.BorderColor = Colors.Get(BorderColor);

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

                    frameReference.BackgroundColor = Colors.Get(ColorUIError);
                    entryReference.TextColor = Colors.Get(EmailColorError);
                    frameReference.BorderColor = Colors.Get(BorderColorError);

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
        /// Enter the ValidationType.
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
            if (newValue == ValidationType.CharacterToCharacter)
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
            EmailBox emailBox = (EmailBox)bindable;

            if (emailBox.entryReference != null)
            {
                emailBox.entryReference.IsEnabled = (bool)newValue;
            }
        }

        /// <summary>
        /// Property to report if emailBox is IsReadOnly
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(EmailBox),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if email box is for display only.
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
            EmailBox emailBox = (EmailBox)bindable;

            if (emailBox.entryReference != null)
            {
                emailBox.entryReference.IsEnabled = (bool)newValue;
            }
        }

        /// <summary>
        /// Property to report if NumericBox is nullable
        /// </summary>
        public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                 propertyName: nameof(CanEmpty),
                 returnType: typeof(bool),
                 declaringType: typeof(EmailBox),
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
        /// Enter the font size.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(EmailBox),
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
            EmailBox emailBox = (EmailBox)bindable;
            double copyFontSize = (double)newValue;

            if (emailBox.entryReference != null)
            {
                emailBox.entryReference.FontSize = copyFontSize;
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
            declaringType: typeof(EmailBox),
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
            EmailBox emailBox = (EmailBox)bindable;
            double copyWidth = (double)newValue;

            if (emailBox.entryReference != null)
            {
                emailBox.entryReference.WidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Enter the email color(text).
        /// </summary>
        public static readonly BindableProperty EmailColorProperty = BindableProperty.Create(
         propertyName: nameof(EmailColor),
         returnType: typeof(ColorUI),
         declaringType: typeof(EmailBox),
         defaultValue: ColorUI.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: EmailColorPropertyChanged);

        /// <summary>
        /// Enter the email color(text).
        /// </summary>
        public ColorUI EmailColor
        {
            get
            {
                return (ColorUI)GetValue(EmailColorProperty);
            }
            set
            {
                SetValue(EmailColorProperty, value);
            }
        }

        private static void EmailColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            EmailBox emailBox = (EmailBox)bindable;
            ColorUI copyEmailColor = (ColorUI)newValue;

            if (emailBox.IsValid && emailBox.entryReference != null)
            {
                emailBox.entryReference.TextColor = Colors.Get(copyEmailColor);
            }
        }

        /// <summary>
        /// Enter the email color error(text).
        /// </summary>
        public static readonly BindableProperty EmailColorErrorProperty = BindableProperty.Create(
         propertyName: nameof(EmailColorError),
         returnType: typeof(ColorUI),
         declaringType: typeof(EmailBox),
         defaultValue: ColorUI.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: EmailColorErrorPropertyChanged);

        /// <summary>
        /// Enter the email color error(text).
        /// </summary>
        public ColorUI EmailColorError
        {
            get
            {
                return (ColorUI)GetValue(EmailColorErrorProperty);
            }
            set
            {
                SetValue(EmailColorErrorProperty, value);
            }
        }

        private static void EmailColorErrorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            EmailBox emailBox = (EmailBox)bindable;
            ColorUI copyNumberColorError = (ColorUI)newValue;

            if (!emailBox.IsValid && emailBox.entryReference != null)
            {
                emailBox.entryReference.TextColor = Colors.Get(copyNumberColorError);
            }
        }

        /// <summary>
        /// Enter the ColorUI (background) color.
        /// </summary>
        public static readonly BindableProperty ColorUIProperty = BindableProperty.Create(
         propertyName: nameof(ColorUI),
         returnType: typeof(ColorUI),
         declaringType: typeof(EmailBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIPropertyChanged);

        /// <summary>
        /// Enter the ColorUI (background) color.
        /// </summary>
        public ColorUI ColorUI
        {
            get
            {
                return (ColorUI)GetValue(ColorUIProperty);
            }
            set
            {
                SetValue(ColorUIProperty, value);
            }
        }

        private static void ColorUIPropertyChanged(object bindable, object oldValue, object newValue)
        {
            EmailBox emailBox = (EmailBox)bindable;
            ColorUI copyColorUI = (ColorUI)newValue;

            if (emailBox.IsValid && emailBox.frameReference != null)
            {
                emailBox.frameReference.BackgroundColor = Colors.Get(copyColorUI);
            }
        }

        /// <summary>
        /// Enter the number ColorUI error(text).
        /// </summary>
        public static readonly BindableProperty ColorUIErrorProperty = BindableProperty.Create(
         propertyName: nameof(ColorUIError),
         returnType: typeof(ColorUI),
         declaringType: typeof(EmailBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIErrorPropertyChanged);

        /// <summary>
        /// Enter the number ColorUI error(text).
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
            EmailBox emailBox = (EmailBox)bindable;
            ColorUI copyColorUIError = (ColorUI)newValue;

            if (!emailBox.IsValid && emailBox.frameReference != null)
            {
                emailBox.frameReference.BackgroundColor = Colors.Get(copyColorUIError);
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(EmailBox),
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
            EmailBox emailBox = (EmailBox)bindable;
            string copyFontFamily = (string)newValue;

            if (emailBox.entryReference != null)
            {
                emailBox.entryReference.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Informs if use the default messages of plugin laavor.
        /// </summary>
        public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
            propertyName: nameof(ChangeMessageLabel),
            returnType: typeof(bool),
            declaringType: typeof(EmailBox),
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
            declaringType: typeof(EmailBox),
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
            EmailBox emailBox = (EmailBox)bindable;
            string copyPlaceholder = (string)newValue;

            if (emailBox.entryReference != null)
            {
                emailBox.entryReference.Placeholder = copyPlaceholder;
            }
        }
            
        /// <summary>
        /// Enter the  BorderColor
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColor),
           returnType: typeof(ColorUI),
           declaringType: typeof(EmailBox),
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
            EmailBox emailBox = (EmailBox)bindable;
            ColorUI copyBorderColor = (ColorUI)newValue;

            if (emailBox.IsValid && emailBox.frameReference != null)
            {
                emailBox.frameReference.BorderColor = Colors.Get(copyBorderColor);
            }
        }

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid email
        /// </summary>
        public static readonly BindableProperty BorderColorErrorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColorError),
           returnType: typeof(ColorUI),
           declaringType: typeof(EmailBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorErrorPropertyChanged);

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid email
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
            EmailBox emailBox = (EmailBox)bindable;
            ColorUI copyBorderColorError = (ColorUI)newValue;

            if (!emailBox.IsValid && emailBox.frameReference != null)
            {
                emailBox.frameReference.BorderColor = Colors.Get(copyBorderColorError);
            }
        }

        /// <summary>
        /// Enter the placeholder color.
        /// </summary>
        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
            propertyName: nameof(PlaceholderColor),
            returnType: typeof(ColorUI),
            declaringType: typeof(EmailBox),
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
            EmailBox emailBox = (EmailBox)bindable;
            ColorUI copyPlaceholderColor = (ColorUI)newValue;

            if (emailBox.entryReference != null)
            {
                emailBox.entryReference.PlaceholderColor = Colors.Get(copyPlaceholderColor);
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
