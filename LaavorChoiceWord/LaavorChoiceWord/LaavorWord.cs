using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorChoiceWord
{
    /// <summary>
    /// Class LaavorWord
    /// </summary>
    public class LaavorWord:Button
    {
        /// <summary>
        /// Index of LaavorWord In ChoiceWord  
        /// </summary>
        public int Index { get; private set; }

        private FontAttributes currentFontType;

        /// <summary>
        /// Constructor of LaavorWord
        /// </summary>
        public LaavorWord() : base()
        {

        }

        /// <summary>
        /// Cronstructor of LaavorWord
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public LaavorWord(string hash, int index, string value) : base()
        {
            if (hash != "__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl")
            {
                throw new Exception("Invalid Hash");
            }

            this.Index = index;
        }

        /// <summary>
        /// Enter the IsChosen.
        /// </summary>
        public static readonly BindableProperty IsChosenProperty = BindableProperty.Create(
            propertyName: nameof(IsChosen),
            returnType: typeof(bool),
            declaringType: typeof(LaavorWord),
            defaultValue: false,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the IsChosen.
        /// </summary>
        public bool IsChosen
        {
            get
            {
                return (bool)GetValue(IsChosenProperty);
            }
            set
            {
                SetValue(IsChosenProperty, value);
            }
        }

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double?),
            declaringType: typeof(LaavorWord),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightPropertyChanged);

        /// <summary>
        /// Enter the height.
        /// </summary>
        public new double? Height
        {
            get
            {
                return (double?)GetValue(HeightProperty);
            }
            set
            {
                SetValue(HeightProperty, value);
            }
        }

        private static void HeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            double wordHeight = (double)newValue;
            laavorWord.HeightRequest = wordHeight;
        }

        /// <summary>
        /// Enter the width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double?),
            declaringType: typeof(LaavorWord),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width.
        /// </summary>
        public new double? Width
        {
            get
            {
                return (double?)GetValue(WidthProperty);
            }
            set
            {
                SetValue(WidthProperty, value);
            }
        }

        private static void WidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            double wordWidth = (double)newValue;
            laavorWord.WidthRequest = wordWidth;
        }

        /// <summary>
        /// Enter the Value
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            propertyName: nameof(Value),
            returnType: typeof(string),
            declaringType: typeof(LaavorWord),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the value
        /// </summary>
        public string Value
        {
            get
            {
                return (string)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        /// <summary>
        /// Enter the font size.
        /// </summary>
        public new static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(LaavorWord),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size.
        /// </summary>
        public new double FontSize
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
            LaavorWord laavorWord = (LaavorWord)bindable;
            double copyFontSize = (double)newValue;
            laavorWord.FontSize = copyFontSize;
        }

        /// <summary>
        /// Enter the chosen textcolor.
        /// </summary>
        public static readonly BindableProperty TextColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(TextColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(LaavorWord),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextColorChosenPropertyChanged);

        /// <summary>
        /// Enter the chosen textcolor.
        /// </summary>
        public Color TextColorChosen
        {
            get
            {
                return (Color)GetValue(TextColorChosenProperty);
            }
            set
            {
                SetValue(TextColorChosenProperty, value);
            }
        }

        private static void TextColorChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            Color copyTextColor = (Color)newValue;
            if (!laavorWord.IsChosen)
            {
                laavorWord.TextColor = copyTextColor;
            }
        }

        /// <summary>
        /// Enter the UnChosen text color.
        /// </summary>
        public static readonly BindableProperty TextColorUnChosenProperty = BindableProperty.Create(
          propertyName: nameof(TextColorUnChosen),
          returnType: typeof(Color),
          declaringType: typeof(LaavorWord),
          defaultValue: Color.Gray,
          defaultBindingMode: BindingMode.OneWay,
          propertyChanged: TextColorUnChosenPropertyChanged);

        /// <summary>
        /// Enter the UnChosen text color.
        /// </summary>
        public Color TextColorUnChosen
        {
            get
            {
                return (Color)GetValue(TextColorUnChosenProperty);
            }
            set
            {
                SetValue(TextColorUnChosenProperty, value);
            }
        }

        private static void TextColorUnChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            Color copyTextColor = (Color)newValue;
            if (!laavorWord.IsChosen)
            {
                laavorWord.TextColor = copyTextColor;
            }
        }

        /// <summary>
        /// Enter the BorderColorChosen.
        /// </summary>
        public static readonly BindableProperty BorderColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BorderColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(LaavorWord),
            defaultValue: Color.Transparent,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the BorderColorChosen.
        /// </summary>
        public Color BorderColorChosen
        {
            get
            {
                return (Color)GetValue(BorderColorChosenProperty);
            }
            set
            {
                SetValue(BorderColorChosenProperty, value);
            }
        }

        /// <summary>
        /// Enter the BorderColorUnChosen.
        /// </summary>
        public static readonly BindableProperty BorderColorUnChosenProperty = BindableProperty.Create(
            propertyName: nameof(BorderColorUnChosen),
            returnType: typeof(Color),
            declaringType: typeof(LaavorWord),
            defaultValue: Color.Transparent,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderColorUnChosenPropertyChanged);

        /// <summary>
        /// Enter the BorderColorUnChosen.
        /// </summary>
        public Color BorderColorUnChosen
        {
            get
            {
                return (Color)GetValue(BorderColorUnChosenProperty);
            }
            set
            {
                SetValue(BorderColorUnChosenProperty, value);
            }
        }

        private static void BorderColorUnChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            Color copyBorderColor = (Color)newValue;
            if (!laavorWord.IsChosen)
            {
                laavorWord.BorderColor = copyBorderColor;
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
                FontTypePropertyChanged(this, currentFontType, value);
                currentFontType = value;
            }
        }

        private static void FontTypePropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            FontAttributes copyFontType = newValue;
            laavorWord.FontAttributes = copyFontType;
        }

        /// <summary>
        /// Enter the backgroundcolor chosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorChosenProperty = BindableProperty.Create(
         propertyName: nameof(BackgroundColorChosen),
         returnType: typeof(Color),
         declaringType: typeof(LaavorWord),
         defaultValue: Color.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: BackgroundColorChosenPropertyChanged);

        /// <summary>
        /// Enter the backgroundcolor chosen.
        /// </summary>
        public Color BackgroundColorChosen
        {
            get
            {
                return (Color)GetValue(BackgroundColorChosenProperty);
            }
            set
            {
                SetValue(BackgroundColorChosenProperty, value);
            }
        }

        private static void BackgroundColorChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            Color copyColor = (Color)newValue;

            if (laavorWord.IsChosen)
            {
                laavorWord.BackgroundColor = copyColor;
            }
        }

        /// <summary>
        /// Enter the backgroundcolor UnChosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorUnChosenProperty = BindableProperty.Create(
         propertyName: nameof(BackgroundColorUnChosen),
         returnType: typeof(Color),
         declaringType: typeof(LaavorWord),
         defaultValue: Color.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: BackgroundColorUnChosenPropertyChanged);

        /// <summary>
        /// Enter the backgroundcolor UnChosen.
        /// </summary>
        public Color BackgroundColorUnChosen
        {
            get
            {
                return (Color)GetValue(BackgroundColorUnChosenProperty);
            }
            set
            {
                SetValue(BackgroundColorUnChosenProperty, value);
            }
        }

        private static void BackgroundColorUnChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorWord laavorWord = (LaavorWord)bindable;
            Color copyColor = (Color)newValue;

            if (!laavorWord.IsChosen)
            {
                laavorWord.BackgroundColor = copyColor;
            }
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextUnChosenProperty = BindableProperty.Create(
            propertyName: nameof(TextUnChosen),
            returnType: typeof(string),
            declaringType: typeof(LaavorWord),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the text UnChosen
        /// </summary>
        public string TextUnChosen
        {
            get
            {
                return (string)GetValue(TextUnChosenProperty);
            }
            set
            {
                SetValue(TextUnChosenProperty, value);
            }
        }

        /// <summary>
        /// Enter the text
        /// </summary>
        public static readonly BindableProperty TextChosenProperty = BindableProperty.Create(
            propertyName: nameof(TextChosen),
            returnType: typeof(string),
            declaringType: typeof(LaavorWord),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the text Chosen
        /// </summary>
        public string TextChosen
        {
            get
            {
                return (string)GetValue(TextChosenProperty);
            }
            set
            {
                SetValue(TextChosenProperty, value);
            }
        }
    }
}
