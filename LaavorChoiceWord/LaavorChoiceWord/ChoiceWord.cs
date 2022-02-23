
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaavorChoiceWord
{
    /// <summary>
    /// Class ChoiceWord
    /// </summary>
    public class ChoiceWord : StackLayout
    {
        /// <summary>
        /// Returns the index of the chosen.
        /// </summary>
        public int IndexChosen { get; private set; }

        /// <summary>
        /// Returns the text of the chosen.
        /// </summary>
        public string TextChosen { get; private set; }

        /// <summary>
        /// Returns the value of the chosen.
        /// </summary>
        public string ValueChosen { get; private set; }

        /// <summary>
        /// Call when word is chosen
        /// </summary>
        public event EventHandler Chosen;

        private ScrollView scroll;

        private const double spaceDecrease = 6.1;

        /// <summary>
        /// Internal use.
        /// </summary>
        private StackLayout dataItems;

        private FontAttributes currentFontType = FontAttributes.None;

        private int currentIndex = 0;

        private ChoiceOrientation currentOrientation = ChoiceOrientation.Horizontal;

        private IEnumerable items = null;

        private Vivacity currentVivacity = Vivacity.None;
        private Depth depth = Depth.Medium;
        private VivacitySpeed vivacitySpeed = VivacitySpeed.Fast;

        private List<LaavorWord> listWords;

        /// <summary>
        /// Constructor of ChoiceWord
        /// </summary>
        public ChoiceWord() : base()
        {
            ValueChosen = "";
            dataItems = new StackLayout();
            scroll = new ScrollView();
            scroll.Content = dataItems;

            if (currentOrientation == ChoiceOrientation.Horizontal)
            {
                scroll.Orientation = ScrollOrientation.Horizontal;
                dataItems.Orientation = StackOrientation.Horizontal;
                base.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                scroll.Orientation = ScrollOrientation.Vertical;
                dataItems.Orientation = StackOrientation.Vertical;
                base.Orientation = StackOrientation.Vertical;
            }

            scroll.HorizontalOptions = LayoutOptions.Center;
            scroll.VerticalOptions = LayoutOptions.Center;

            this.Children.Add(scroll);

            listWords = new List<LaavorWord>();
        }

        /// <summary>
        /// Property to inform SpaceBetween Word
        /// </summary>
        public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                 propertyName: nameof(SpaceBetween),
                 returnType: typeof(int),
                 declaringType: typeof(ChoiceWord),
                 defaultValue: 0,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: SpaceBetweenPropertyChanged);

        /// <summary>
        /// Property to inform SpaceBetween Word
        /// </summary>
        public int SpaceBetween
        {
            get
            {
                return (int)GetValue(SpaceBetweenProperty);
            }
            set
            {
                SetValue(SpaceBetweenProperty, value);
            }
        }

        private static void SpaceBetweenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            int copySpace = (int)newValue;

            for (int iItem = 1; iItem < choiceWord.Children.Count; iItem++)
            {
                if (choiceWord.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.Children[iItem];
                    if (choiceWord.OrientationChoice == ChoiceOrientation.Horizontal)
                    {
                        laavorWord.Margin = new Thickness((copySpace - spaceDecrease), 0, 0, 0);
                    }
                    else
                    {
                        laavorWord.Margin = new Thickness(0, (copySpace - spaceDecrease), 0, 0);
                    }
                }
            }
        }

        private void ChangeOrientation(ChoiceOrientation o)
        {
            if (o == ChoiceOrientation.Horizontal)
            {
                base.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                base.Orientation = StackOrientation.Vertical;
            }
        }

        private void SetSpace(LaavorWord laavorWord, int space)
        {
            if (OrientationChoice == ChoiceOrientation.Horizontal)
            {
                laavorWord.Margin = new Thickness((space - spaceDecrease), 0, 0, 0);

            }
            else
            {
                laavorWord.Margin = new Thickness(0, (space - spaceDecrease), 0, 0);
            }
        }

        /// <summary>
        /// Choice should be vertically or horizontally oriented.
        /// </summary>
        [Bindable(true)]
        public ChoiceOrientation OrientationChoice
        {
            get
            {
                return currentOrientation;
            }
            set
            {
                OrientationChoicePropertyChanged(this, currentOrientation, value);
                currentOrientation = value;
            }
        }

        private static void OrientationChoicePropertyChanged(object bindable, ChoiceOrientation oldValue, ChoiceOrientation newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            ChoiceOrientation copyOrientation = newValue;

            if (copyOrientation == ChoiceOrientation.Horizontal)
            {
                choiceWord.scroll.Orientation = ScrollOrientation.Horizontal;
                choiceWord.dataItems.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                choiceWord.scroll.Orientation = ScrollOrientation.Vertical;
                choiceWord.dataItems.Orientation = StackOrientation.Vertical;
            }

            choiceWord.ChangeOrientation(copyOrientation);
        }


        /// <summary>
        /// Orientation is deprecate
        /// </summary>
        [Obsolete]
        [Bindable(true)]
        public new StackOrientation Orientation
        {
            get
            {
                return StackOrientation.Horizontal;
            }
            set { }
        }

        /// <summary>
        /// Preselected index
        /// </summary>
        public static readonly BindableProperty InitialIndexChosenProperty = BindableProperty.Create(
            propertyName: nameof(InitialIndexChosen),
            returnType: typeof(int),
            declaringType: typeof(ChoiceWord),
            defaultValue: -1,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: InitialIndexChosenPropertyChanged);

        /// <summary>
        /// Preselected index
        /// </summary>
        public int InitialIndexChosen
        {
            get
            {
                return (int)GetValue(InitialIndexChosenProperty);
            }
            set
            {
                SetValue(InitialIndexChosenProperty, value);
            }
        }

        private static void InitialIndexChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            int copyIndex = (int)newValue;
            for (int iLV = 0; iLV < choiceWord.dataItems.Children.Count; iLV++)
            {
                if (choiceWord.dataItems.Children[iLV].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iLV];
                    if (laavorWord.Index == copyIndex)
                    {
                        laavorWord.IsChosen = true;
                        laavorWord.TextColor = laavorWord.TextColorChosen;
                        laavorWord.BorderColor = laavorWord.BorderColorChosen;
                        laavorWord.BackgroundColor = laavorWord.BackgroundColorChosen;
                        choiceWord.IndexChosen = laavorWord.Index;
                        choiceWord.TextChosen = laavorWord.Text;
                        choiceWord.ValueChosen = laavorWord.Value;
                        laavorWord.Clicked += choiceWord.LaavorWord_Clicked;
                    }
                    else
                    {
                        laavorWord.IsChosen = false;
                        laavorWord.TextColor = laavorWord.TextColorUnChosen;
                        laavorWord.BorderColor = laavorWord.BorderColorUnChosen;
                        laavorWord.BackgroundColor = laavorWord.BackgroundColorUnChosen;
                        laavorWord.Clicked -= choiceWord.LaavorWord_Clicked;
                        laavorWord.Clicked += choiceWord.LaavorWord_Clicked;
                    }
                }
            }
        }

        /// <summary>
        /// Preselected Value
        /// </summary>
        public static readonly BindableProperty InitialValueChosenProperty = BindableProperty.Create(
            propertyName: nameof(InitialValueChosen),
            returnType: typeof(string),
            declaringType: typeof(ChoiceWord),
            defaultValue: "_laavor_nothing_2018_77",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: InitialValueChosenPropertyChanged);

        /// <summary>
        /// Preselected Value
        /// </summary>
        public string InitialValueChosen
        {
            get
            {
                return (string)GetValue(InitialValueChosenProperty);
            }
            set
            {
                SetValue(InitialValueChosenProperty, value);
            }
        }

        private static void InitialValueChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            string copyValue = newValue.ToString();
            for (int iLV = 0; iLV < choiceWord.dataItems.Children.Count; iLV++)
            {
                if (choiceWord.dataItems.Children[iLV].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iLV];
                    if (laavorWord.Value == copyValue)
                    {
                        laavorWord.IsChosen = true;
                        laavorWord.TextColor = laavorWord.TextColorChosen;
                        laavorWord.BorderColor = laavorWord.BorderColorChosen;
                        laavorWord.BackgroundColor = laavorWord.BackgroundColorChosen;
                        choiceWord.IndexChosen = laavorWord.Index;
                        choiceWord.TextChosen = laavorWord.Text;
                        choiceWord.ValueChosen = laavorWord.Value;
                        laavorWord.Clicked += choiceWord.LaavorWord_Clicked;
                    }
                    else
                    {
                        laavorWord.IsChosen = false;
                        laavorWord.TextColor = laavorWord.TextColorUnChosen;
                        laavorWord.BorderColor = laavorWord.BorderColorUnChosen;
                        laavorWord.BackgroundColor = laavorWord.BackgroundColorUnChosen;
                        laavorWord.Clicked -= choiceWord.LaavorWord_Clicked;
                        laavorWord.Clicked += choiceWord.LaavorWord_Clicked;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the font size.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 25.0,
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            double copyFontSize = (double)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.FontSize = copyFontSize;
                }
            }
        }

        /// <summary>
        /// Enter the chosen textcolor.
        /// </summary>
        public static readonly BindableProperty TextColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(TextColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceWord),
            defaultValue: Color.Orange,
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            Color copyColorChosen = (Color)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.TextColorChosen = copyColorChosen;
                }
            }
        }

        /// <summary>
        /// Enter the UnChosen text color.
        /// </summary>
        public static readonly BindableProperty TextColorUnChosenProperty = BindableProperty.Create(
          propertyName: nameof(TextColorUnChosen),
          returnType: typeof(Color),
          declaringType: typeof(ChoiceWord),
          defaultValue: Color.Black,
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            Color copyColorUnChosen = (Color)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.TextColorUnChosen = copyColorUnChosen;
                }
            }
        }

        /// <summary>
        /// Enter the backgroundcolor chosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BackgroundColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceWord),
            defaultValue: Color.Yellow,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BackgroundColorChosenPropertyChanged);

        /// <summary>
        /// Enter the backgroundcolor UnChosen.
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            Color copyColor = (Color)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];

                    if (laavorWord.IsChosen)
                    {
                        laavorWord.BackgroundColor = copyColor;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the backgroundcolor UnChosen.
        /// </summary>
        public static readonly BindableProperty BackgroundColorUnChosenProperty = BindableProperty.Create(
         propertyName: nameof(BackgroundColorUnChosen),
         returnType: typeof(Color),
         declaringType: typeof(ChoiceWord),
         defaultValue: Color.Gray,
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            Color copyColor = (Color)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];

                    if (!laavorWord.IsChosen)
                    {
                        laavorWord.BackgroundColor = copyColor;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the BorderWidth.
        /// </summary>
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            propertyName: nameof(BorderWidth),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 1.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderWidthPropertyChanged);

        /// <summary>
        /// Enter the BorderWidth.
        /// </summary>
        public double BorderWidth
        {
            get
            {
                return (double)GetValue(BorderWidthProperty);
            }
            set
            {
                SetValue(BorderWidthProperty, value);
            }
        }

        private static void BorderWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            double copyBorderWidth = (double)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.BorderWidth = copyBorderWidth;
                }
            }
        }

        /// <summary>
        /// Enter the BorderRadius.
        /// </summary>
        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(
            propertyName: nameof(BorderRadius),
            returnType: typeof(int),
            declaringType: typeof(ChoiceWord),
            defaultValue: 0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderRadiusPropertyChanged);

        /// <summary>
        /// Enter the BorderRadius.
        /// </summary>
        public int BorderRadius
        {
            get
            {
                return (int)GetValue(BorderRadiusProperty);
            }
            set
            {
                SetValue(BorderRadiusProperty, value);
            }
        }

        private static void BorderRadiusPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            int copyBorderRadius = (int)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.CornerRadius = copyBorderRadius;
                }
            }
        }

        /// <summary>
        /// Enter the BorderColorChosen.
        /// </summary>
        public static readonly BindableProperty BorderColorChosenProperty = BindableProperty.Create(
            propertyName: nameof(BorderColorChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceWord),
            defaultValue: Color.Yellow,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderColorChosenPropertyChanged);

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

        private static void BorderColorChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            Color copyBorderColorChosen = (Color)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    if (laavorWord.IsChosen)
                    {
                        laavorWord.BorderColorChosen = copyBorderColorChosen;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the BorderColorUnChosen.
        /// </summary>
        public static readonly BindableProperty BorderColorUnChosenProperty = BindableProperty.Create(
            propertyName: nameof(BorderColorUnChosen),
            returnType: typeof(Color),
            declaringType: typeof(ChoiceWord),
            defaultValue: Color.Gray,
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            Color copyBorderColorUnChosen = (Color)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    if (!laavorWord.IsChosen)
                    {
                        laavorWord.BorderColorUnChosen = copyBorderColorUnChosen;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(ChoiceWord),
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            string copyFontFamily = (string)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.FontFamily = copyFontFamily;
                }
            }
        }

        /// <summary>
        /// Enter ListItems(Data items).
        /// </summary>
        public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
            propertyName: nameof(ListItems),
            returnType: typeof(IEnumerable),
            declaringType: typeof(ChoiceWord),
            defaultBindingMode: BindingMode.OneWay,
            defaultValue: null,
            propertyChanged: ListItemsPropertyChanged);

        /// <summary>
        /// Enter ListItems(Data items).
        /// </summary>
        public IEnumerable ListItems
        {
            get
            {
                return (IEnumerable)GetValue(ListItemsProperty);
            }
            set
            {
                SetValue(ListItemsProperty, value);
            }
        }

        private static void ListItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            choiceWord.items = (IEnumerable)newValue;
            choiceWord.InitAllBindable();
        }

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
            propertyName: nameof(ValueField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceWord),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ValueFieldPropertyChanged);

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public string ValueField
        {
            get
            {
                return (string)GetValue(ValueFieldProperty);
            }
            set
            {
                SetValue(ValueFieldProperty, value);
            }
        }

        private static void ValueFieldPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            choiceWord.InitAllBindable();
        }

        /// <summary>
        /// Enter the TextField, only when using list mvvm.
        /// </summary>
        public static readonly BindableProperty TextFieldProperty = BindableProperty.Create(
            propertyName: nameof(TextField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceWord),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextFieldPropertyChanged);

        /// <summary>
        /// Enter the TextField, only when using list mvvm.
        /// </summary>
        public string TextField
        {
            get
            {
                return (string)GetValue(TextFieldProperty);
            }
            set
            {
                SetValue(TextFieldProperty, value);
            }
        }

        private static void TextFieldPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            choiceWord.InitAllBindable();
        }

        /// <summary>
        /// Enter the MarginLeftItems.
        /// </summary>
        public static readonly BindableProperty MarginLeftItemsProperty = BindableProperty.Create(
            propertyName: nameof(MarginLeftItems),
            returnType: typeof(int),
            declaringType: typeof(ChoiceWord),
            defaultValue: 15,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: MarginLeftItemsPropertyChanged);

        /// <summary>
        /// Enter the MarginLeftItems.
        /// </summary>
        public int MarginLeftItems
        {
            get
            {
                return (int)GetValue(MarginLeftItemsProperty);
            }
            set
            {
                SetValue(MarginLeftItemsProperty, value);
            }
        }

        private static void MarginLeftItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            int marginLeft = (int)newValue;
            choiceWord.dataItems.Margin = new Thickness(marginLeft, 0, 0, 0);
        }

        /// <summary>
        /// Enter the MarginRightItems.
        /// </summary>
        public static readonly BindableProperty MarginRightItemsProperty = BindableProperty.Create(
            propertyName: nameof(MarginRightItems),
            returnType: typeof(int),
            declaringType: typeof(ChoiceWord),
            defaultValue: 15,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: MarginRightItemsPropertyChanged);

        /// <summary>
        /// Enter the MarginRightItems.
        /// </summary>
        public int MarginRightItems
        {
            get
            {
                return (int)GetValue(MarginRightItemsProperty);
            }
            set
            {
                SetValue(MarginRightItemsProperty, value);
            }
        }

        private static void MarginRightItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            int marginRight = (int)newValue;
            choiceWord.dataItems.Padding = new Thickness(0, 0, marginRight, 0);
        }

        /// <summary>
        /// Enter Widht.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 150.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter Widht.
        /// </summary>
        public new double Width
        {
            get
            {
                return (double)GetValue(MarginRightItemsProperty);
            }
            set
            {
                SetValue(MarginRightItemsProperty, value);
            }
        }

        private static void WidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            double width = (double)newValue;
            choiceWord.ChangeWidthRequest(width);
        }

        private void ChangeWidthRequest(double w)
        {
            base.WidthRequest = w;
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(
            propertyName: nameof(WidthRequest),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double WidthRequest
        {
            get
            {
                return (double)GetValue(WidthRequestProperty);
            }
            set { }
        }

        /// <summary>
        /// Depracate.
        /// </summary>
        [Obsolete]
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            propertyName: nameof(HeightRequest),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Deprecate.
        /// </summary>
        [Obsolete]
        public new double HeightRequest
        {
            get
            {
                return (double)GetValue(HeightRequestProperty);
            }
            set { }
        }

        /// <summary>
        /// Enter the HeightItems.
        /// </summary>
        public static readonly BindableProperty HeightItemsProperty = BindableProperty.Create(
            propertyName: nameof(HeightItems),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 35.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightItemsPropertyChanged);

        /// <summary>
        /// Enter the HeightItems.
        /// </summary>
        public double HeightItems
        {
            get
            {
                return (double)GetValue(HeightItemsProperty);
            }
            set
            {
                SetValue(HeightItemsProperty, value);
            }
        }

        private static void HeightItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            double heightItem = (double)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.Height = heightItem;
                }
            }
        }

        /// <summary>
        /// Enter the WidthtItems.
        /// </summary>
        public static readonly BindableProperty WidthItemsProperty = BindableProperty.Create(
            propertyName: nameof(WidthItems),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 70.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthItemsPropertyChanged);

        /// <summary>
        /// Enter the WidthItems.
        /// </summary>
        public double WidthItems
        {
            get
            {
                return (double)GetValue(WidthItemsProperty);
            }
            set
            {
                SetValue(WidthItemsProperty, value);
            }
        }

        private static void WidthItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            double widthItem = (double)newValue;
            for (int iItem = 0; iItem < choiceWord.dataItems.Children.Count; iItem++)
            {
                if (choiceWord.dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)choiceWord.dataItems.Children[iItem];
                    laavorWord.Width = widthItem;
                }
            }
        }
        /// <summary>
        /// Enter the Height.
        /// </summary>
        public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
            propertyName: nameof(Height),
            returnType: typeof(double),
            declaringType: typeof(ChoiceWord),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightPropertyChanged);

        /// <summary>
        /// Enter the Height.
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
            ChoiceWord choiceWord = (ChoiceWord)bindable;
            double height = (double)newValue;
            choiceWord.ChangeHeightBase(height);
        }

        private void ChangeHeightBase(double r)
        {
            base.HeightRequest = r;
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
                FontTypePropertyChanged();
            }
        }

        private void FontTypePropertyChanged()
        {
            for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
            {
                if (dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                {
                    LaavorWord laavorWord = (LaavorWord)dataItems.Children[iItem];
                    laavorWord.FontType = currentFontType;
                }
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
                return currentVivacity;
            }
            set
            {
                currentVivacity = value;
            }
        }

        private void VivacityPropertyChanged()
        {
            if (currentVivacity != Vivacity.None)
            {
                for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                {
                    if (dataItems.Children[iItem].GetType() == typeof(LaavorWord))
                    {
                        LaavorWord laavorWord = (LaavorWord)dataItems.Children[iItem];
                        SetVivacity(laavorWord);
                    }
                }
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
                DepthPropertyChanged();
            }
        }

        private void DepthPropertyChanged()
        {
            VivacityPropertyChanged();
        }

        /// <summary>
        /// VivacitySpeed changes speedof Vivacity. 
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

        private void SetVivacity(Button button)
        {
            if (currentVivacity == Vivacity.None)
            {
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;
                button.Pressed -= VivacityDecrease;
            }
            else if (currentVivacity == Vivacity.Decrease)
            {
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;

                button.Pressed += VivacityDecrease;
            }
            else if (currentVivacity == Vivacity.Increase)
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;

                button.Pressed += VivacityIncrease;
            }
            else if (currentVivacity == Vivacity.Jump)
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;

                button.Pressed += VivacityJump;
            }
            else if (currentVivacity == Vivacity.Rotation)
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;

                button.Pressed += VivacityRotation;
            }
            else if (currentVivacity == Vivacity.Down)
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;

                button.Pressed += VivacityDown;
            }
            else if (currentVivacity == Vivacity.Left)
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;

                button.Pressed += VivacityLeft;
            }
            else
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityJump;
                button.Pressed -= VivacityRotation;
                button.Pressed -= VivacityDown;
                button.Pressed -= VivacityLeft;
            }
        }

        private async void VivacityDecrease(object sender, EventArgs e)
        {
            try
            {
                LaavorWord laavorWord = (LaavorWord)sender;
                await laavorWord.ScaleTo(GetDepthDecrease(depth), (uint)vivacitySpeed, Easing.Linear);
                await laavorWord.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
            }
            catch { }
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 0.80;
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

        private async void VivacityIncrease(object sender, EventArgs e)
        {
            try
            {
                LaavorWord laavorWord = (LaavorWord)sender;
                await laavorWord.ScaleTo(GetDepthIncrease(depth), (uint)vivacitySpeed, Easing.Linear);
                await laavorWord.ScaleTo(1, (uint)vivacitySpeed, Easing.Linear);
            }
            catch { }
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

        private async void VivacityJump(object sender, EventArgs e)
        {
            try
            {
                LaavorWord laavorWord = (LaavorWord)sender;
                await laavorWord.TranslateTo(0, GetDepthJump(depth), (uint)vivacitySpeed, Easing.Linear);
                await laavorWord.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
            }
            catch { }
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

        private async void VivacityRotation(object sender, EventArgs e)
        {
            try
            {
                LaavorWord laavorWord = (LaavorWord)sender;
                await laavorWord.RotateTo(GetDepthRotation(depth), (uint)vivacitySpeed, Easing.Linear);
                await laavorWord.RotateTo(0, (uint)vivacitySpeed, Easing.Linear);
            }
            catch { }
        }

        private int GetDepthRotation(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 200;
            }
            else if (depth == Depth.LessMedium)
            {
                return 90;
            }
            else if (depth == Depth.Medium)
            {
                return 140;
            }
            else
            {
                return 210;
            }
        }

        private async void VivacityDown(object sender, EventArgs e)
        {
            try
            {
                LaavorWord laavorWord = (LaavorWord)sender;
                await laavorWord.TranslateTo(0, GetDepthDown(depth), (uint)vivacitySpeed, Easing.Linear);
                await laavorWord.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
            }
            catch { }
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

        private async void VivacityLeft(object sender, EventArgs e)
        {
            try
            {
                LaavorWord laavorWord = (LaavorWord)sender;
                await laavorWord.TranslateTo(GetDepthLeft(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                await laavorWord.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
            }
            catch { }
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

        private async void VivacityRight(object sender, EventArgs e)
        {
            try
            {
                LaavorWord laavorWord = (LaavorWord)sender;
                await laavorWord.TranslateTo(GetDepthRight(depth), 0, (uint)vivacitySpeed, Easing.Linear);
                await laavorWord.TranslateTo(0, 0, (uint)vivacitySpeed, Easing.Linear);
            }
            catch { }
        }

        private double GetDepthRight(Depth depth)
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

        private void InitAllBindable()
        {
            ChoiceWord choiceWord = this;

            if (choiceWord.items != null && !string.IsNullOrEmpty(choiceWord.TextField) && !string.IsNullOrEmpty(choiceWord.ValueField))
            {
                currentIndex = 0;
                dataItems.Children.Clear();
                listWords = new List<LaavorWord>();

                var enumerator = choiceWord.items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object obj = enumerator.Current;
                    string textObj = obj.GetType().GetProperty(choiceWord.TextField).GetValue(obj).ToString();
                    string valueObj = obj.GetType().GetProperty(choiceWord.ValueField).GetValue(obj).ToString();

                    LaavorWord item = new LaavorWord("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", currentIndex, valueObj);
                    item.Text = textObj;
                    item.TextColorChosen = choiceWord.TextColorChosen;
                    item.TextColorUnChosen = choiceWord.TextColorUnChosen;
                    item.BackgroundColorChosen = choiceWord.BackgroundColorChosen;
                    item.BackgroundColorUnChosen = choiceWord.BackgroundColorUnChosen;
                    item.BorderWidth = choiceWord.BorderWidth;
                    item.CornerRadius = choiceWord.BorderRadius;
                    item.BorderColorChosen = choiceWord.BorderColorChosen;
                    item.BorderColorUnChosen = choiceWord.BorderColorUnChosen;
                    item.FontSize = choiceWord.FontSize;
                    item.FontType = choiceWord.currentFontType;
                    item.FontFamily = choiceWord.FontFamily;
                    item.Height = choiceWord.HeightItems;
                    item.Width = choiceWord.WidthItems;

                    SetVivacity(item);

                    item.Value = valueObj;

                    if ((InitialIndexChosen == -1 && InitialValueChosen == "_laavor_nothing_2018_77") || (InitialIndexChosen != currentIndex && InitialValueChosen != valueObj))
                    {
                        item.Clicked += LaavorWord_Clicked;
                    }
                    else if (InitialIndexChosen == currentIndex || InitialValueChosen == valueObj)
                    {
                        item.IsChosen = true;
                        item.TextColor = TextColorChosen;
                        item.BorderColor = BorderColorChosen;
                        item.BackgroundColor = BackgroundColorChosen;
                        IndexChosen = currentIndex;
                        TextChosen = textObj;
                        ValueChosen = valueObj;
                    }

                    if (currentIndex > 0)
                    {
                        SetSpace(item, SpaceBetween);
                    }

                    currentIndex++;
                    dataItems.Children.Add(item);
                }
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(ChoiceWordItem))
            {
                ChoiceWordItem choiceWordItem = (ChoiceWordItem)child;
                LaavorWord laavorWord = new LaavorWord("__Laavor*+-///indexfaearara$$##%))=@33%%*&VVVMMad13,a,a8d939kl", currentIndex, choiceWordItem.Value);

                laavorWord.Text = choiceWordItem.Text;

                laavorWord.TextColorChosen = this.TextColorChosen;
                laavorWord.TextColorUnChosen = this.TextColorUnChosen;
                laavorWord.BackgroundColorChosen = this.BackgroundColorChosen;
                laavorWord.BackgroundColorUnChosen = this.BackgroundColorUnChosen;
                laavorWord.BorderWidth = this.BorderWidth;
                laavorWord.CornerRadius = this.BorderRadius;
                laavorWord.BorderColorChosen = this.BorderColorChosen;
                laavorWord.BorderColorUnChosen = this.BorderColorUnChosen;
                laavorWord.Height = this.HeightItems;
                laavorWord.Width = this.WidthItems;

                SetVivacity(laavorWord);

                laavorWord.FontSize = this.FontSize;
                laavorWord.FontType = this.currentFontType;
                laavorWord.FontFamily = this.FontFamily;

                laavorWord.Value = choiceWordItem.Value;

                if (InitialIndexChosen == -1 || InitialIndexChosen != currentIndex)
                {
                    laavorWord.Clicked += LaavorWord_Clicked;
                }
                else if (InitialIndexChosen == currentIndex)
                {
                    laavorWord.IsChosen = true;
                    laavorWord.TextColor = TextColorChosen;
                    laavorWord.BorderColor = BorderColorChosen;
                    laavorWord.BackgroundColor = BackgroundColorChosen;
                    IndexChosen = currentIndex;
                    TextChosen = choiceWordItem.Text;
                    ValueChosen = choiceWordItem.Value;
                }

                if (currentIndex > 0)
                {
                    SetSpace(laavorWord, SpaceBetween);
                }

                currentIndex++;
                dataItems.Children.Add(laavorWord);
            }
        }

        private void LaavorWord_Clicked(object sender, EventArgs e)
        {
            LaavorWord laavorWord = (LaavorWord)sender;

            if (!laavorWord.IsChosen)
            {
                laavorWord.IsChosen = true;
                laavorWord.TextColor = laavorWord.TextColorChosen;
                laavorWord.BorderColor = laavorWord.BorderColorChosen;
                laavorWord.BackgroundColor = laavorWord.BackgroundColorChosen;
                IndexChosen = laavorWord.Index;
                TextChosen = laavorWord.Text;
                ValueChosen = laavorWord.Value;

                laavorWord.Clicked -= LaavorWord_Clicked;

                for (int iL = 0; iL < dataItems.Children.Count; iL++)
                {
                    LaavorWord laavorWordItem = (LaavorWord)dataItems.Children[iL];
                    if (laavorWordItem.Index != laavorWord.Index)
                    {
                        laavorWordItem.IsChosen = false;
                        laavorWordItem.TextColor = laavorWord.TextColorUnChosen;
                        laavorWordItem.BorderColor = laavorWord.BorderColorUnChosen;
                        laavorWordItem.BackgroundColor = laavorWord.BackgroundColorUnChosen;
                        laavorWordItem.Clicked -= LaavorWord_Clicked;
                        laavorWordItem.Clicked += LaavorWord_Clicked;
                    }
                }
            }

            Chosen?.Invoke(this, EventArgs.Empty);
        }


    }
}
