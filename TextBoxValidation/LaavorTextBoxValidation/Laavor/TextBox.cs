using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// Class TextBox
    /// </summary>
    public class TextBox : LaavorBaseValidate
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

        private Entry entryReference;
        private Frame frameReference;

        private FontAttributes currentFontType = FontAttributes.None;
        private ValidationType currentValidationType = ValidationType.WhenLoseFocus;
        private TextAlignment currentHorizontalTextAlignment = TextAlignment.Start;
        private Keyboard currentKeyboard = Keyboard.Text;

        /// <summary>
        /// Constructor of TextBox
        /// </summary>
        public TextBox() : base()
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

            if (currentValidationType == ValidationType.CharacterToCharacter)
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

            entryReference = new Entry();
            entryReference.Focused += Entry_Focused;
            entryReference.Unfocused += Entry_Unfocused;
            entryReference.TextChanged += Entry_TextChanged;

            entryReference.VerticalOptions = LayoutOptions.Center;
            entryReference.Keyboard = currentKeyboard;
            entryReference.FontAttributes = currentFontType;
            entryReference.TextColor = Colors.Get(TextColor);
            entryReference.FontSize = FontSize;
            entryReference.HorizontalTextAlignment = HorizontalTextAlignment;
            entryReference.Margin = new Thickness(-10, -20, -10, -20);
            entryReference.WidthRequest = Width;
            entryReference.TextColor = Colors.Get(TextColor);
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
            frameReference.BackgroundColor = Color.Transparent;

            frameReference.Content = entryReference;

            StackLayout stackCenter = new StackLayout();
            stackCenter.Spacing = 0;
            stackCenter.Margin = new Thickness(0.05, 0, 0.05, 0);
            stackCenter.HorizontalOptions = LayoutOptions.Center;
            stackCenter.Orientation = StackOrientation.Vertical;
            stackCenter.Children.Add(frameReference);
            stackCenter.BackgroundColor = Color.Transparent;

            Children.Add(stackCenter);
        }

        private void SetColorsInitialState()
        {
            frameReference.BackgroundColor = BackgroundColor;
            entryReference.TextColor = Colors.Get(TextColor);
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
            else if(MinimumOfCharacters != null || MaximumOfCharacters != null)
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

                    frameReference.BackgroundColor = Colors.Get(ColorUIError);
                    entryReference.TextColor = Colors.Get(TextColorError);
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

            Text = valueStr;

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
            if (entryReference != null)
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
        }

        private static void TypeValidationPropertyChanged(object bindable, object oldValue, object newValue)
        {
            TextBox textBox = (TextBox)bindable;

            if (textBox.entryReference != null)
            {
                textBox.entryReference.IsEnabled = (bool)newValue;
            }
        }

        /// <summary>
        /// Property to report if textBox is IsReadOnly
        /// </summary>
        public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(
                 propertyName: nameof(IsReadOnly),
                 returnType: typeof(bool),
                 declaringType: typeof(TextBox),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: IsReadOnlyPropertyChanged);

        /// <summary>
        /// Property to report if text box is for display only.
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
            TextBox textBox = (TextBox)bindable;

            if (textBox.entryReference != null)
            {
                textBox.entryReference.IsEnabled = (bool)newValue;
            }
        }

        /// <summary>
        /// Property to report if TextBox is nullable
        /// </summary>
        public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                 propertyName: nameof(CanEmpty),
                 returnType: typeof(bool),
                 declaringType: typeof(TextBox),
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
            declaringType: typeof(TextBox),
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
            TextBox textBox = (TextBox)bindable;
            double copyFontSize = (double)newValue;

            if (textBox.entryReference != null)
            {
                textBox.entryReference.FontSize = copyFontSize;
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
            declaringType: typeof(TextBox),
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
            TextBox textBox = (TextBox)bindable;
            double copyWidthRequest = (double)newValue;

            if (textBox.entryReference != null)
            {
                textBox.entryReference.WidthRequest = copyWidthRequest;
            }
        }

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
         propertyName: nameof(TextColor),
         returnType: typeof(ColorUI),
         declaringType: typeof(TextBox),
         defaultValue: ColorUI.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: TextColorPropertyChanged);

        /// <summary>
        /// Enter the text color.
        /// </summary>
        public ColorUI TextColor
        {
            get
            {
                return (ColorUI)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        private static void TextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            TextBox textBox = (TextBox)bindable;
            ColorUI copyTextColor = (ColorUI)newValue;

            if (textBox.IsValid && textBox.entryReference != null)
            {
                textBox.entryReference.TextColor = Colors.Get(copyTextColor);
            }
        }

        /// <summary>
        /// Enter the text color error.
        /// </summary>
        public static readonly BindableProperty TextColorErrorProperty = BindableProperty.Create(
         propertyName: nameof(TextColorError),
         returnType: typeof(ColorUI),
         declaringType: typeof(TextBox),
         defaultValue: ColorUI.Black,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: TextColorErrorPropertyChanged);

        /// <summary>
        /// Enter the text color error.
        /// </summary>
        public ColorUI TextColorError
        {
            get
            {
                return (ColorUI)GetValue(TextColorErrorProperty);
            }
            set
            {
                SetValue(TextColorErrorProperty, value);
            }
        }

        private static void TextColorErrorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            TextBox textBox = (TextBox)bindable;
            ColorUI copyTextColorError = (ColorUI)newValue;

            if (!textBox.IsValid && textBox.entryReference != null)
            {
                textBox.entryReference.TextColor = Colors.Get(copyTextColorError);
            }
        }

        /// <summary>
        /// Enter the ColorUI (background).
        /// </summary>
        public static readonly BindableProperty ColorUIProperty = BindableProperty.Create(
         propertyName: nameof(ColorUI),
         returnType: typeof(ColorUI),
         declaringType: typeof(TextBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIPropertyChanged);

        /// <summary>
        /// Enter the ColorUI(background).
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
            TextBox textBox = (TextBox)bindable;
            ColorUI copyColorUI = (ColorUI)newValue;

            if (textBox.IsValid && textBox.frameReference != null)
            {
                textBox.frameReference.BackgroundColor = Colors.Get(copyColorUI);
            }
        }

        /// <summary>
        /// Enter the ColorUIError (Background) error.
        /// </summary>
        public static readonly BindableProperty ColorUIErrorProperty = BindableProperty.Create(
         propertyName: nameof(ColorUIError),
         returnType: typeof(ColorUI),
         declaringType: typeof(TextBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIErrorPropertyChanged);

        /// <summary>
        /// Enter the ColorUI error.
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
            TextBox textBox = (TextBox)bindable;
            ColorUI copyColorUIError = (ColorUI)newValue;

            if (!textBox.IsValid && textBox.frameReference != null)
            {
                textBox.frameReference.BackgroundColor = Colors.Get(copyColorUIError);
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(TextBox),
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
            TextBox textBox = (TextBox)bindable;
            string copyFontFamily = (string)newValue;

            if (textBox.entryReference != null)
            {
                textBox.entryReference.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Informs if use the default messages of plugin laavor.
        /// </summary>
        public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
            propertyName: nameof(ChangeMessageLabel),
            returnType: typeof(bool),
            declaringType: typeof(TextBox),
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
            declaringType: typeof(TextBox),
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
            TextBox textBox = (TextBox)bindable;
            string copyPlaceholder = (string)newValue;

            if (textBox.entryReference != null)
            {
                textBox.entryReference.Placeholder = copyPlaceholder;
            }
        }

        /// <summary>
        /// Enter the  BorderColor
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColor),
           returnType: typeof(ColorUI),
           declaringType: typeof(TextBox),
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
            TextBox textBox = (TextBox)bindable;
            ColorUI copyBorderColor = (ColorUI)newValue;

            if (textBox.frameReference != null)
            {
                textBox.frameReference.BorderColor = Colors.Get(copyBorderColor);
            }
        }

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid text
        /// </summary>
        public static readonly BindableProperty BorderColorErrorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColorError),
           returnType: typeof(ColorUI),
           declaringType: typeof(TextBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorErrorPropertyChanged);

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid text
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
            TextBox textBox = (TextBox)bindable;
            ColorUI copyBorderColorError = (ColorUI)newValue;
            if (!textBox.IsValid && textBox.frameReference != null)
            {
                textBox.frameReference.BorderColor = Colors.Get(copyBorderColorError);
            }
        }

        /// <summary>
        /// Enter the placeholder color.
        /// </summary>
        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
            propertyName: nameof(PlaceholderColor),
            returnType: typeof(ColorUI),
            declaringType: typeof(TextBox),
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
            TextBox textBox = (TextBox)bindable;
            ColorUI copyPlaceholderColor = (ColorUI)newValue;

            if (textBox.entryReference != null)
            {
                textBox.entryReference.PlaceholderColor = Colors.Get(copyPlaceholderColor);
            }
        }

        /// <summary>
        /// Minimum Of Characters - Information for validation
        /// </summary>
        public static readonly BindableProperty MinimumOfCharactersProperty = BindableProperty.Create(
                 propertyName: nameof(MinimumOfCharacters),
                 returnType: typeof(int?),
                 declaringType: typeof(TextBox),
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
                 declaringType: typeof(TextBox),
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
