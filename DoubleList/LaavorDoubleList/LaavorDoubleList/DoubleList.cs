using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorDoubleList
{
    /// <summary>
    /// Class DoubleList
    /// </summary>
    public class DoubleList : StackLayout
    {
        /// <summary>
        /// Returns the List the Chosen items.
        /// </summary>
        public List<ChosenItem> ItemsChosen { get; private set; }

        /// <summary>
        /// Returns the List the UnChosen items.
        /// </summary>
        public List<ChosenItem> ItemsUnChosen { get; private set; }

        /// <summary>
        /// Call when Item is chosen
        /// </summary>
        public event EventHandler Chosen;

        /// <summary>
        /// Call when Item is Unchosen
        /// </summary>
        public event EventHandler UnChosen;

        private Frame frameUnchosen;
        private Frame frameChosen;

        private StackLayout stackLayoutUnchosen;
        private StackLayout stackLayoutExternalUnchosen;

        private StackLayout stackMidle;

        private StackLayout stackLayoutChosen;
        private StackLayout stackLayoutExternalChosen;

        private List<DoubleListItemContent> listBtnUnchosen;
        private List<DoubleListItemContent> listBtnChosen;

        private FontAttributes currentFontTypeItems = FontAttributes.None;
        private FontAttributes currentFontTypeTitle = FontAttributes.Bold;
        private Vivacity currentVivacity = Vivacity.Decrease;
        private Depth currentDepth = Depth.LessMedium;
        private ColorUI currentArrowColor = ColorUI.Black;
        private ColorUI currentBorderColorSides = ColorUI.Black;
        private ColorUI currentTextColorItemsChosen = ColorUI.Black;
        private ColorUI currentTextColorItemsUnChosen = ColorUI.White;
        private ColorUI currentColorUIItemsChosen = ColorUI.Yellow;
        private ColorUI currentColorUIItemsUnChosen = ColorUI.GrayLight;
        private ColorUI currentColorUISides = ColorUI.White;
        private ColorUI currentTextColorTitle = ColorUI.Black;

        private Label labelChosen;
        private Label labelUnchosen;

        //private IEnumerable items = null;
        private List<int> listInitialbyIndex = null;
        private List<string> listInitialbyValue = null;

        private ArrowImage arrowLeft;
        private ArrowImage arrowRight;

        private int currentIndex;

        private Grid gridUnchosen;
        private Grid gridChosen;

        private DesignType designType;

        private bool userChangeHeight = false;

        /// <summary>
        /// Constructor od DoubleList
        /// </summary>
        public DoubleList()
        {
            InitAll();

            this.Orientation = StackOrientation.Horizontal;
            this.HorizontalOptions = LayoutOptions.Center;
            this.Spacing = 0;
            this.Margin = new Thickness(0, 5, 0, 5);

            ItemsChosen = new List<ChosenItem>();
            ItemsUnChosen = new List<ChosenItem>();
        }

        private void InitAll()
        {
            currentIndex = 0;



            listBtnUnchosen = new List<DoubleListItemContent>();

            frameUnchosen = new Frame();
            frameUnchosen.BorderColor = GetColorFromColorUI(BorderColorSides);

            gridUnchosen = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = WidthSides }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = HeightSides }
                }
            };

            gridUnchosen.ColumnSpacing = 0;
            gridUnchosen.RowSpacing = 0;

            stackLayoutExternalUnchosen = new StackLayout();
            stackLayoutExternalUnchosen.Spacing = 0;

            labelUnchosen = new Label();
            labelUnchosen.HorizontalOptions = LayoutOptions.Center;
            labelUnchosen.HorizontalTextAlignment = TextAlignment.Center;
            labelUnchosen.Text = TitleUnChosen;
            labelUnchosen.TextColor = GetColorFromColorUI(TextColorTitle);
            labelUnchosen.FontFamily = FontFamilyTitle;
            labelUnchosen.FontAttributes = FontTypeTitle;

            gridUnchosen.Children.Add(frameUnchosen);
            stackLayoutExternalUnchosen.Children.Add(labelUnchosen);
            stackLayoutExternalUnchosen.Children.Add(gridUnchosen);

            stackLayoutUnchosen = new StackLayout();
            stackLayoutUnchosen.Spacing = 0;
            stackLayoutUnchosen.Orientation = StackOrientation.Vertical;

            frameUnchosen.Content = stackLayoutUnchosen;

            this.Children.Add(stackLayoutExternalUnchosen);





            arrowLeft = new ArrowImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentArrowColor, Side.Left);
            arrowLeft.WidthRequest = 35;
            arrowLeft.HeightRequest = 35;
            arrowLeft.Margin = new Thickness(5, 0, 5, 0);
            arrowLeft.GestureRecognizers.Add(GetTouchUnchosen());
            arrowLeft.GestureRecognizers.Add(GetVivacity(Side.Left));

            arrowRight = new ArrowImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentArrowColor, Side.Right);
            arrowRight.WidthRequest = 35;
            arrowRight.HeightRequest = 35;
            arrowRight.Margin = new Thickness(0, 0, 5, 0);
            arrowRight.GestureRecognizers.Add(GetTouchChosen());
            arrowRight.GestureRecognizers.Add(GetVivacity(Side.Right));

            stackMidle = new StackLayout();
            stackMidle.Orientation = StackOrientation.Horizontal;
            stackMidle.VerticalOptions = LayoutOptions.Center;
            stackMidle.HorizontalOptions = LayoutOptions.Center;
            stackMidle.Spacing = 0;

            stackMidle.Children.Add(arrowLeft);
            stackMidle.Children.Add(arrowRight);

            this.Children.Add(stackMidle);





            listBtnChosen = new List<DoubleListItemContent>();

            frameChosen = new Frame();
            frameChosen.BorderColor = GetColorFromColorUI(BorderColorSides);

            gridChosen = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = WidthSides }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = HeightSides }
                }
            };
            gridChosen.ColumnSpacing = 0;
            gridChosen.RowSpacing = 0;

            stackLayoutExternalChosen = new StackLayout();
            stackLayoutExternalChosen.Spacing = 0;

            labelChosen = new Label();
            labelChosen.HorizontalOptions = LayoutOptions.Center;
            labelChosen.HorizontalTextAlignment = TextAlignment.Center;
            labelChosen.Text = TitleChosen;
            labelChosen.TextColor = GetColorFromColorUI(TextColorTitle);
            labelChosen.FontFamily = FontFamilyTitle;
            labelChosen.FontAttributes = FontTypeTitle;

            gridChosen.Children.Add(frameChosen);
            stackLayoutExternalChosen.Children.Add(labelChosen);
            stackLayoutExternalChosen.Children.Add(gridChosen);

            stackLayoutChosen = new StackLayout();
            stackLayoutChosen.Spacing = 0;
            stackLayoutChosen.Orientation = StackOrientation.Vertical;

            frameChosen.Content = stackLayoutChosen;

            this.Children.Add(stackLayoutExternalChosen);

        }

        private TapGestureRecognizer GetTouchChosen()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += ChangeToChosen;
            return touch;
        }

        private void ChangeToChosen(object sender, EventArgs e)
        {
            int countList = stackLayoutUnchosen.Children.Count;
            for (int iList = 0; iList < countList; iList++)
            {
                DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutUnchosen.Children[iList];
                if (doubleListItemContent.IsChosen)
                {
                    doubleListItemContent.ChangeChosen("hajajajkaKlulpll787878*--StairWay__Laavor*+-", false);
                    doubleListItemContent.BackgroundColor = GetColorFromColorUI(ColorUIItemsUnChosen);
                    doubleListItemContent.TextColor = GetColorFromColorUI(TextColorItemsUnChosen);

                    int iIFExist = -1;
                    for (int iUnChosen = 0; iUnChosen < ItemsUnChosen.Count - 1; iUnChosen++)
                    {
                        if (ItemsUnChosen[iUnChosen].StartIndex == doubleListItemContent.Index)
                        {
                            iIFExist = iUnChosen;
                            break;
                        }
                    }

                    ChosenItem chosenItem = null;
                    if (iIFExist != -1)
                    {
                        chosenItem = ItemsUnChosen[iIFExist];
                        ItemsUnChosen.RemoveAt(iIFExist);
                    }

                    listBtnUnchosen.Remove(doubleListItemContent);
                    stackLayoutUnchosen.Children.Remove(doubleListItemContent);

                    listBtnChosen.Add(doubleListItemContent);
                    stackLayoutChosen.Children.Add(doubleListItemContent);

                    int currentIndex = stackLayoutChosen.Children.Count - 1;
                    if (currentIndex == 0)
                    {
                        doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                    }
                    else
                    {
                        if (currentIndex >= 2)
                        {
                            (stackLayoutChosen.Children[stackLayoutChosen.Children.Count - 2] as DoubleListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                        }

                        (stackLayoutChosen.Children[stackLayoutChosen.Children.Count - 1] as DoubleListItemContent).Margin = new Thickness(-16, 0, -16, -16);
                    }

                    if (chosenItem == null)
                    {
                        chosenItem = new ChosenItem("ol__ui_dev_7778888*+*Laavor", doubleListItemContent.Index, doubleListItemContent.Text, doubleListItemContent.Value);
                    }

                    chosenItem.ChangeCurrentIndex("ol__ui_dev_7778888*+*Laavor", (stackLayoutChosen.Children.Count - 1));
                    ItemsChosen.Add(chosenItem);

                    iList--;
                    countList--;
                }
            }

            countList = stackLayoutUnchosen.Children.Count;
            for (int iList = 0; iList < countList; iList++)
            {
                DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutUnchosen.Children[iList];

                if (iList == 0)
                {
                    doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                }
                else
                {
                    if (iList <= countList - 1)
                    {
                        doubleListItemContent.Margin = new Thickness(-16, 0, -16, 4);
                    }
                    else
                    {
                        doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                    }
                }
            }

            Chosen?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetTouchUnchosen()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += ChangeToUnchosen;
            return touch;
        }

        private void ChangeToUnchosen(object sender, EventArgs e)
        {
            int countList = stackLayoutChosen.Children.Count;
            for (int iList = 0; iList < countList; iList++)
            {
                DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutChosen.Children[iList];
                if (doubleListItemContent.IsChosen)
                {
                    doubleListItemContent.ChangeChosen("hajajajkaKlulpll787878*--StairWay__Laavor*+-", false);
                    doubleListItemContent.BackgroundColor = GetColorFromColorUI(ColorUIItemsUnChosen);
                    doubleListItemContent.TextColor = GetColorFromColorUI(TextColorItemsUnChosen);

                    int iIFExist = -1;
                    for (int iChosen = 0; iChosen < ItemsChosen.Count - 1; iChosen++)
                    {
                        if (ItemsChosen[iChosen].StartIndex == doubleListItemContent.Index)
                        {
                            iIFExist = iChosen;
                            break;
                        }
                    }

                    ChosenItem chosenItem = null;
                    if (iIFExist != -1)
                    {
                        chosenItem = ItemsChosen[iIFExist];
                        ItemsChosen.RemoveAt(iIFExist);
                    }

                    stackLayoutChosen.Children.RemoveAt(iList);
                    listBtnChosen.RemoveAt(iList);

                    stackLayoutUnchosen.Children.Add(doubleListItemContent);
                    listBtnUnchosen.Add(doubleListItemContent);

                    int currentIndex = stackLayoutUnchosen.Children.Count - 1;
                    if (currentIndex == 0)
                    {
                        doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                    }
                    else
                    {
                        if (currentIndex >= 2)
                        {
                            (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 2] as DoubleListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                        }

                        (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 1] as DoubleListItemContent).Margin = new Thickness(-16, 0, -16, -16);
                    }

                    if (chosenItem == null)
                    {
                        chosenItem = new ChosenItem("ol__ui_dev_7778888*+*Laavor", doubleListItemContent.Index, doubleListItemContent.Text, doubleListItemContent.Value);
                    }

                    chosenItem.ChangeCurrentIndex("ol__ui_dev_7778888*+*Laavor", (stackLayoutUnchosen.Children.Count - 1));
                    ItemsUnChosen.Add(chosenItem);

                    iList--;
                    countList--;
                }
            }

            countList = stackLayoutChosen.Children.Count;
            for (int iList = 0; iList < countList; iList++)
            {
                DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutChosen.Children[iList];

                if (iList == 0)
                {
                    doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                }
                else
                {
                    if (iList <= countList - 1)
                    {
                        doubleListItemContent.Margin = new Thickness(-16, 0, -16, 4);
                    }
                    else
                    {
                        doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                    }
                }
            }

            UnChosen?.Invoke(this, EventArgs.Empty);
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
                designType = value;
                DesignTypePropertyChanged();
            }
        }

        private void DesignTypePropertyChanged()
        {
            arrowRight.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", designType);
            arrowLeft.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", designType);
        }

        /// <summary>
        /// Enter the Width Arrow Image.
        /// </summary>
        public static readonly BindableProperty WidthArrowProperty = BindableProperty.Create(
            propertyName: nameof(WidthArrow),
            returnType: typeof(double),
            declaringType: typeof(DoubleList),
            defaultValue: 30.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthArrowPropertyChanged);

        /// <summary>
        /// Enter the Width Arrow Image.
        /// </summary>
        public double WidthArrow
        {
            get
            {
                return (double)GetValue(WidthArrowProperty);
            }
            set
            {
                SetValue(WidthArrowProperty, value);
            }
        }

        private static void WidthArrowPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            double copyWidth = (double)newValue;

            if (doubleList.arrowLeft != null && doubleList.arrowRight != null)
            {
                doubleList.arrowLeft.WidthRequest = copyWidth;
                doubleList.arrowRight.WidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Enter the Height Arrow Image.
        /// </summary>
        public static readonly BindableProperty HeightArrowProperty = BindableProperty.Create(
            propertyName: nameof(HeightArrow),
            returnType: typeof(double),
            declaringType: typeof(DoubleList),
            defaultValue: 35.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightArrowPropertyChanged);

        /// <summary>
        /// Enter the Height Arrow Image.
        /// </summary>
        public double HeightArrow
        {
            get
            {
                return (double)GetValue(HeightArrowProperty);
            }
            set
            {
                SetValue(HeightArrowProperty, value);
            }
        }

        private static void HeightArrowPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            double copyHeight = (double)newValue;

            if (doubleList.arrowLeft != null && doubleList.arrowRight != null)
            {
                doubleList.arrowLeft.HeightRequest = copyHeight;
                doubleList.arrowRight.HeightRequest = copyHeight;
            }
        }

        /// <summary>
        /// Enter the TitleChosen.
        /// </summary>
        public static readonly BindableProperty TitleChosenProperty = BindableProperty.Create(
            propertyName: nameof(TitleChosen),
            returnType: typeof(string),
            declaringType: typeof(DoubleList),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TitleChosenPropertyChanged);

        /// <summary>
        /// Enter the TitleChosen.
        /// </summary>
        public string TitleChosen
        {
            get
            {
                return (string)GetValue(TitleChosenProperty);
            }
            set
            {
                SetValue(TitleChosenProperty, value);
            }
        }

        private static void TitleChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            string titleChosen = (string)newValue;

            if (doubleList.labelChosen != null)
            {
                doubleList.labelChosen.Text = titleChosen;
            }
        }

        /// <summary>
        /// Enter the TitleUnChosen.
        /// </summary>
        public static readonly BindableProperty TitleUnChosenProperty = BindableProperty.Create(
            propertyName: nameof(TitleUnChosen),
            returnType: typeof(string),
            declaringType: typeof(DoubleList),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TitleUnChosenPropertyChanged);

        /// <summary>
        /// Enter the TitleUnChosen.
        /// </summary>
        public string TitleUnChosen
        {
            get
            {
                return (string)GetValue(TitleUnChosenProperty);
            }
            set
            {
                SetValue(TitleUnChosenProperty, value);
            }
        }

        private static void TitleUnChosenPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            string titleUnChosen = (string)newValue;

            if (doubleList.labelUnchosen != null)
            {
                doubleList.labelUnchosen.Text = titleUnChosen;
            }
        }

        /// <summary>
        /// Enter the TextColorTitle.
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColorTitle
        {
            get
            {
                return currentTextColorTitle;
            }
            set
            {
                currentTextColorTitle = value;
                TextColorTitlePropertyChanged();
            }
        }

        private void TextColorTitlePropertyChanged()
        {
            if (labelChosen != null && labelUnchosen != null)
            {
                labelChosen.TextColor = GetColorFromColorUI(currentTextColorTitle);
                labelUnchosen.TextColor = GetColorFromColorUI(currentTextColorTitle);
            }
        }


        /// <summary>
        /// Enter the fonttype of Title (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontTypeTitle
        {
            get
            {
                return currentFontTypeTitle;
            }
            set
            {
                currentFontTypeTitle = value;
                FontTypeTitlePropertyChanged();
            }
        }

        private void FontTypeTitlePropertyChanged()
        {
            if (labelChosen != null && labelUnchosen != null)
            {
                labelChosen.FontAttributes = currentFontTypeTitle;
                labelUnchosen.FontAttributes = currentFontTypeTitle;
            }
        }

        /// <summary>
        /// Enter the font size title.
        /// </summary>
        public static readonly BindableProperty FontSizeTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeTitle),
            returnType: typeof(double),
            declaringType: typeof(DoubleList),
            defaultValue: 15.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size title.
        /// </summary>
        public double FontSizeTitle
        {
            get
            {
                return (double)GetValue(FontSizeTitleProperty);
            }
            set
            {
                SetValue(FontSizeTitleProperty, value);
            }
        }

        private static void FontSizePropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            double copyFontSize = (double)newValue;

            if (doubleList.labelUnchosen != null && doubleList.labelChosen != null)
            {
                doubleList.labelUnchosen.FontSize = copyFontSize;
                doubleList.labelChosen.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the font family Title.
        /// </summary>
        public static readonly BindableProperty FontFamilyTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyTitle),
            returnType: typeof(string),
            declaringType: typeof(DoubleList),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyTitlePropertyChanged);

        /// <summary>
        /// Enter the font family Title.
        /// </summary>
        public string FontFamilyTitle
        {
            get
            {
                return (string)GetValue(FontFamilyTitleProperty);
            }
            set
            {
                SetValue(FontFamilyTitleProperty, value);
            }
        }

        private static void FontFamilyTitlePropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            string copyFontFamily = (string)newValue;
            if (doubleList.labelUnchosen != null && doubleList.labelChosen != null)
            {
                doubleList.labelChosen.FontFamily = copyFontFamily;
                doubleList.labelUnchosen.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the ColorUIItemsUnChosen.
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUIItemsUnChosen
        {
            get
            {
                return currentColorUIItemsUnChosen;
            }
            set
            {
                currentColorUIItemsUnChosen = value;
                ColorUIItemsUnChosenPropertyChanged();
            }
        }

        private void ColorUIItemsUnChosenPropertyChanged()
        {
            if (stackLayoutUnchosen != null)
            {
                for (int iItem = 0; iItem < stackLayoutUnchosen.Children.Count; iItem++)
                {
                    if (stackLayoutChosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutUnchosen.Children[iItem];
                        doubleListItemContent.BackgroundColor = GetColorFromColorUI(currentColorUIItemsUnChosen);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the ColorUIItemsChosen.
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUIItemsChosen
        {
            get
            {
                return currentColorUIItemsChosen;
            }
            set
            {
                currentColorUIItemsChosen = value;
                ColorUIItemsChosenPropertyChanged();
            }
        }

        private void ColorUIItemsChosenPropertyChanged()
        {
            if (stackLayoutChosen != null)
            {
                for (int iItem = 0; iItem < stackLayoutChosen.Children.Count; iItem++)
                {
                    if (stackLayoutChosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutChosen.Children[iItem];
                        doubleListItemContent.BackgroundColor = GetColorFromColorUI(currentColorUIItemsChosen);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the TextColorItemsUnChosen.
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColorItemsUnChosen
        {
            get
            {
                return currentTextColorItemsUnChosen;
            }
            set
            {
                currentTextColorItemsUnChosen = value;
                TextColorItemsUnChosenPropertyChanged();
            }
        }

        private void TextColorItemsUnChosenPropertyChanged()
        {
            if (stackLayoutUnchosen != null)
            {
                for (int iItem = 0; iItem < stackLayoutUnchosen.Children.Count; iItem++)
                {
                    if (stackLayoutUnchosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutUnchosen.Children[iItem];
                        doubleListItemContent.TextColor = GetColorFromColorUI(currentTextColorItemsUnChosen);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the TextColorItemsChosen.
        /// </summary>
        [Bindable(true)]
        public ColorUI TextColorItemsChosen
        {
            get
            {
                return currentTextColorItemsChosen;
            }
            set
            {
                currentTextColorItemsChosen = value;
                TextColorItemsChosenPropertyChanged();
            }
        }

        private void TextColorItemsChosenPropertyChanged()
        {
            if (stackLayoutChosen != null)
            {
                for (int iItem = 0; iItem < stackLayoutChosen.Children.Count; iItem++)
                {
                    if (stackLayoutChosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutChosen.Children[iItem];
                        doubleListItemContent.TextColor = GetColorFromColorUI(currentTextColorItemsChosen);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the HeightSides.
        /// </summary>
        public static readonly BindableProperty HeightSidesProperty = BindableProperty.Create(
            propertyName: nameof(HeightSides),
            returnType: typeof(double),
            declaringType: typeof(DoubleList),
            defaultValue: 105.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightSidesPropertyChanged);

        /// <summary>
        /// Enter the HeightSides.
        /// </summary>
        public double HeightSides
        {
            get
            {
                return (double)GetValue(HeightSidesProperty);
            }
            set
            {
                SetValue(HeightSidesProperty, value);
            }
        }

        private static void HeightSidesPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            double height = (double)newValue;

            if (doubleList.gridUnchosen != null)
            {
                doubleList.gridUnchosen.RowDefinitions[0].Height = height;
            }

            if (doubleList.gridChosen != null)
            {
                doubleList.gridChosen.RowDefinitions[0].Height = height;
            }

            doubleList.userChangeHeight = true;
        }

        /// <summary>
        /// Enter the WidthSides.
        /// </summary>
        public static readonly BindableProperty WidthSidesProperty = BindableProperty.Create(
            propertyName: nameof(WidthSides),
            returnType: typeof(double),
            declaringType: typeof(DoubleList),
            defaultValue: 110.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthSidesPropertyChanged);

        /// <summary>
        /// Enter the WidthSides.
        /// </summary>
        public double WidthSides
        {
            get
            {
                return (double)GetValue(WidthSidesProperty);
            }
            set
            {
                SetValue(WidthSidesProperty, value);
            }
        }

        private static void WidthSidesPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            double width = (double)newValue;

            if (doubleList.gridUnchosen != null)
            {
                doubleList.gridUnchosen.ColumnDefinitions[0].Width = width;
            }

            if (doubleList.gridChosen != null)
            {
                doubleList.gridChosen.ColumnDefinitions[0].Width = width;
            }
        }

        /// <summary>
        /// Enter the ColorUISides.
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUISides
        {
            get
            {
                return currentColorUISides;
            }
            set
            {
                currentColorUISides = value;
                ColorUISidesPropertyChanged();
            }
        }

        private void ColorUISidesPropertyChanged()
        {
            if (frameUnchosen != null)
            {
                frameUnchosen.BackgroundColor = GetColorFromColorUI(currentColorUISides);
            }

            if (frameChosen != null)
            {
                frameChosen.BackgroundColor = GetColorFromColorUI(currentColorUISides);
            }
        }

        /// <summary>
        /// Enter the BorderColorSides.
        /// </summary>
        [Bindable(true)]
        public ColorUI BorderColorSides
        {
            get
            {
                return currentBorderColorSides;
            }
            set
            {
                currentBorderColorSides = value;
                BorderColorSidesPropertyChanged();
            }
        }

        private void BorderColorSidesPropertyChanged()
        {
            if (frameUnchosen != null && frameUnchosen != null)
            {
                frameUnchosen.BorderColor = GetColorFromColorUI(currentBorderColorSides);
                frameChosen.BorderColor = GetColorFromColorUI(currentBorderColorSides);
            }
        }

        /// <summary>
        /// Enter the color of Arrow.
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorArrow
        {
            get
            {
                return currentArrowColor;
            }
            set
            {
                currentArrowColor = value;
                ColorArrowPropertyChanged();
            }
        }

        private void ColorArrowPropertyChanged()
        {
            if (arrowLeft != null)
            {
                arrowLeft.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentArrowColor);
            }

            if (arrowRight != null)
            {
                arrowRight.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentArrowColor);
            }
        }

        /// <summary>
        /// Enter the fonttype (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontTypeItems
        {
            get
            {
                return currentFontTypeItems;
            }
            set
            {
                currentFontTypeItems = value;
                FontTypeItemsPropertyChanged();
            }
        }

        private void FontTypeItemsPropertyChanged()
        {
            if (stackLayoutUnchosen != null)
            {
                for (int iItem = 0; iItem < stackLayoutUnchosen.Children.Count; iItem++)
                {
                    if (stackLayoutUnchosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutUnchosen.Children[iItem];
                        doubleListItemContent.FontAttributes = currentFontTypeItems;
                    }
                }
            }

            if (stackLayoutChosen != null)
            {
                for (int iItem = 0; iItem < stackLayoutChosen.Children.Count; iItem++)
                {
                    if (stackLayoutChosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutChosen.Children[iItem];
                        doubleListItemContent.FontAttributes = currentFontTypeItems;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the font size items.
        /// </summary>
        public static readonly BindableProperty FontSizeItemsProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeItems),
            returnType: typeof(double),
            declaringType: typeof(DoubleList),
            defaultValue: 15.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizeItemsPropertyChanged);

        /// <summary>
        /// Enter the font size items.
        /// </summary>
        public double FontSizeItems
        {
            get
            {
                return (double)GetValue(FontSizeItemsProperty);
            }
            set
            {
                SetValue(FontSizeItemsProperty, value);
            }
        }

        private static void FontSizeItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            double copyFontSize = (double)newValue;

            if (doubleList.stackLayoutUnchosen != null)
            {
                for (int iItem = 0; iItem < doubleList.stackLayoutUnchosen.Children.Count; iItem++)
                {
                    if (doubleList.stackLayoutUnchosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)doubleList.stackLayoutUnchosen.Children[iItem];
                        doubleListItemContent.FontSize = copyFontSize;
                    }
                }
            }

            if (doubleList.stackLayoutChosen != null)
            {
                for (int iItem = 0; iItem < doubleList.stackLayoutChosen.Children.Count; iItem++)
                {
                    if (doubleList.stackLayoutChosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)doubleList.stackLayoutChosen.Children[iItem];
                        doubleListItemContent.FontSize = copyFontSize;
                    }
                }
            }
        }

        /// <summary>
        /// Enter the font family items.
        /// </summary>
        public static readonly BindableProperty FontFamilyItemsProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyItems),
            returnType: typeof(string),
            declaringType: typeof(DoubleList),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontFamilyItemsPropertyChanged);

        /// <summary>
        /// Enter the font family Items.
        /// </summary>
        public string FontFamilyItems
        {
            get
            {
                return (string)GetValue(FontFamilyItemsProperty);
            }
            set
            {
                SetValue(FontFamilyItemsProperty, value);
            }
        }

        private static void FontFamilyItemsPropertyChanged(object bindable, object oldValue, object newValue)
        {
            DoubleList doubleList = (DoubleList)bindable;
            string copyFontFamily = (string)newValue;
            if (doubleList.stackLayoutUnchosen != null)
            {
                for (int iItem = 0; iItem < doubleList.stackLayoutUnchosen.Children.Count; iItem++)
                {
                    if (doubleList.stackLayoutUnchosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)doubleList.stackLayoutUnchosen.Children[iItem];
                        doubleListItemContent.FontFamily = copyFontFamily;
                    }
                }
            }

            if (doubleList.stackLayoutChosen != null)
            {
                for (int iItem = 0; iItem < doubleList.stackLayoutChosen.Children.Count; iItem++)
                {
                    if (doubleList.stackLayoutChosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)doubleList.stackLayoutChosen.Children[iItem];
                        doubleListItemContent.FontFamily = copyFontFamily;
                    }
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
                for (int iItem = 0; iItem < stackLayoutUnchosen.Children.Count; iItem++)
                {
                    if (stackLayoutUnchosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutUnchosen.Children[iItem];
                        SetVivacity(doubleListItemContent);
                    }
                }

                for (int iItem = 0; iItem < stackLayoutChosen.Children.Count; iItem++)
                {
                    if (stackLayoutChosen.Children[iItem].GetType() == typeof(DoubleListItemContent))
                    {
                        DoubleListItemContent doubleListItemContent = (DoubleListItemContent)stackLayoutChosen.Children[iItem];
                        SetVivacity(doubleListItemContent);
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
            VivacityPropertyChanged();
        }

        private void SetVivacity(Button button)
        {
            if (currentVivacity == Vivacity.Decrease)
            {
                button.Pressed -= VivacityDecrease;
                button.Pressed -= VivacityIncrease;
                //button.Pressed -= VivacityJump;
                //button.Pressed -= VivacityRotation;
                //button.Pressed -= VivacityDown;

                button.Pressed += VivacityDecrease;
            }
            else if (currentVivacity == Vivacity.Increase)
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                //button.Pressed -= VivacityJump;
                //button.Pressed -= VivacityRotation;
                //button.Pressed -= VivacityDown;

                button.Pressed += VivacityIncrease;
            }
            //else if (currentVivacity == Vivacity.Jump)
            //{
            //    button.Pressed -= VivacityIncrease;
            //    button.Pressed -= VivacityDecrease;
            //    button.Pressed -= VivacityJump;
            //    button.Pressed -= VivacityRotation;
            //    button.Pressed -= VivacityDown;

            //    button.Pressed += VivacityJump;
            //}
            //else if (currentVivacity == Vivacity.Rotation)
            //{
            //    button.Pressed -= VivacityIncrease;
            //    button.Pressed -= VivacityDecrease;
            //    button.Pressed -= VivacityJump;
            //    button.Pressed -= VivacityRotation;
            //    button.Pressed -= VivacityDown;

            //    button.Pressed += VivacityRotation;
            //}
            //else if (currentVivacity == Vivacity.Down)
            //{
            //    button.Pressed -= VivacityIncrease;
            //    button.Pressed -= VivacityDecrease;
            //    button.Pressed -= VivacityJump;
            //    button.Pressed -= VivacityRotation;
            //    button.Pressed -= VivacityDown;

            //    button.Pressed += VivacityDown;
            //}
            else
            {
                button.Pressed -= VivacityIncrease;
                button.Pressed -= VivacityDecrease;
                //button.Pressed -= VivacityJump;
                //button.Pressed -= VivacityRotation;
                //button.Pressed -= VivacityDown;
            }
        }

        private async void VivacityDecrease(object sender, EventArgs e)
        {
            try
            {
                DoubleListItemContent itemContent = (DoubleListItemContent)sender;
                await itemContent.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                await itemContent.ScaleTo(1, 100, Easing.Linear);
            }
            catch { }
        }

        private double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.LessMedium)
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
                DoubleListItemContent itemContent = (DoubleListItemContent)sender;
                await itemContent.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                await itemContent.ScaleTo(1, 100, Easing.Linear);
            }
            catch { }
        }

        private double GetDepthIncrease(Depth depth)
        {
            if (depth == Depth.LessMedium)
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
                DoubleListItemContent itemContent = (DoubleListItemContent)sender;
                await itemContent.TranslateTo(0, GetDepthJump(currentDepth), 100, Easing.Linear);
                await itemContent.TranslateTo(0, 0, 100, Easing.Linear);
            }
            catch { }
        }

        private double GetDepthJump(Depth depth)
        {
            if (depth == Depth.LessMedium)
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
                DoubleListItemContent itemContent = (DoubleListItemContent)sender;
                await itemContent.RotateTo(GetDepthRotation(currentDepth), 100, Easing.Linear);
                await itemContent.RotateTo(0, 100, Easing.Linear);
            }
            catch { }
        }

        private int GetDepthRotation(Depth depth)
        {
            if (depth == Depth.LessMedium)
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
                DoubleListItemContent itemContent = (DoubleListItemContent)sender;
                await itemContent.TranslateTo(0, GetDepthDown(currentDepth), 100, Easing.Linear);
                await itemContent.TranslateTo(0, 0, 100, Easing.Linear);
            }
            catch { }
        }

        private double GetDepthDown(Depth depth)
        {
            if (depth == Depth.LessMedium)
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

        private TapGestureRecognizer GetVivacity(Side side)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + currentVivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { side };

            TapGestureRecognizer touchAnimation = (TapGestureRecognizer)methodToInvoke.Invoke(this, parametersInvoke);

            return touchAnimation;
        }

        private TapGestureRecognizer GetVivacityDecrease(Side side)
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (side == Side.Left)
                    {
                        await arrowLeft.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                        await arrowLeft.ScaleTo(1, 100, Easing.Linear);
                    }
                    else
                    {
                        await arrowRight.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                        await arrowRight.ScaleTo(1, 100, Easing.Linear);
                    }
                }
                catch { }
            };

            return vivacityTap;
        }

        private TapGestureRecognizer GetVivacityIncrease(Side side)
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    if (side == Side.Left)
                    {
                        await arrowLeft.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                        await arrowLeft.ScaleTo(1, 100, Easing.Linear);
                    }
                    else
                    {
                        await arrowRight.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                        await arrowRight.ScaleTo(1, 100, Easing.Linear);
                    }
                }
                catch { }
            };

            return vivacityTap;
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="child"></param>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(DoubleListItem))
            {
                DoubleListItem doubleListItem = (DoubleListItem)child;
                DoubleListItemContent doubleListItemContent = new DoubleListItemContent("hajajajkaKlulpll787878*--StairWay__Laavor*+-", doubleListItem.Text, doubleListItem.Value, currentIndex, false);
                SetVivacity(doubleListItemContent);
                doubleListItemContent.Pressed += DoubleListItemContent_Pressed;
                doubleListItemContent.BackgroundColor = GetColorFromColorUI(ColorUIItemsUnChosen);
                doubleListItemContent.TextColor = GetColorFromColorUI(TextColorItemsUnChosen);
                doubleListItemContent.FontAttributes = FontTypeItems;
                doubleListItemContent.FontSize = FontSizeItems;

                ChosenItem chosenItem = new ChosenItem("ol__ui_dev_7778888*+*Laavor", currentIndex, doubleListItem.Text, doubleListItem.Value);

                bool isInserted = false;

                if (listInitialbyValue != null && listInitialbyValue.Count > 0)
                {
                    if (listInitialbyValue.Contains(doubleListItem.Value))
                    {
                        doubleListItemContent.ChangeChosen("hajajajkaKlulpll787878*--StairWay__Laavor*+-", true);

                        if (currentIndex == 0)
                        {
                            doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                        }
                        else
                        {
                            if (currentIndex >= 2)
                            {
                                (stackLayoutChosen.Children[stackLayoutChosen.Children.Count - 1] as DoubleListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                            }

                            doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                        }

                        listBtnChosen.Add(doubleListItemContent);
                        stackLayoutChosen.Children.Add(doubleListItemContent);
                        chosenItem.ChangeCurrentIndex("ol__ui_dev_7778888*+*Laavor", (stackLayoutChosen.Children.Count - 1));
                        ItemsChosen.Add(chosenItem);

                        isInserted = true;
                    }
                }
                else if (listInitialbyIndex != null && listInitialbyIndex.Count > 0)
                {
                    if (listInitialbyIndex.Contains(doubleListItemContent.Index))
                    {
                        doubleListItemContent.ChangeChosen("hajajajkaKlulpll787878*--StairWay__Laavor*+-", true);

                        if (currentIndex == 0)
                        {
                            doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                        }
                        else
                        {
                            if (currentIndex >= 2)
                            {
                                (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 1] as DoubleListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                            }

                            doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                        }

                        listBtnUnchosen.Add(doubleListItemContent);
                        stackLayoutUnchosen.Children.Add(doubleListItemContent);
                        chosenItem.ChangeCurrentIndex("ol__ui_dev_7778888*+*Laavor", (stackLayoutUnchosen.Children.Count - 1));
                        ItemsUnChosen.Add(chosenItem);

                        isInserted = true;
                    }
                }

                if (!isInserted)
                {
                    if (currentIndex == 0)
                    {
                        doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                    }
                    else
                    {
                        if (currentIndex >= 2)
                        {
                            (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 1] as DoubleListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                        }

                        doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                    }

                    listBtnUnchosen.Add(doubleListItemContent);
                    stackLayoutUnchosen.Children.Add(doubleListItemContent);
                    chosenItem.ChangeCurrentIndex("ol__ui_dev_7778888*+*Laavor", (stackLayoutUnchosen.Children.Count - 1));
                    ItemsUnChosen.Add(chosenItem);
                }

                currentIndex++;

                if (!userChangeHeight)
                {
                    gridUnchosen.RowDefinitions[0].Height = 53 * currentIndex;
                    gridChosen.RowDefinitions[0].Height = 53 * currentIndex;
                }
            }
        }

        private void DoubleListItemContent_Pressed(object sender, EventArgs e)
        {
            DoubleListItemContent doubleListItemContent = (DoubleListItemContent)sender;

            if (doubleListItemContent.IsChosen)
            {
                doubleListItemContent.ChangeChosen("hajajajkaKlulpll787878*--StairWay__Laavor*+-", false);

                doubleListItemContent.BackgroundColor = GetColorFromColorUI(ColorUIItemsUnChosen);
                doubleListItemContent.TextColor = GetColorFromColorUI(TextColorItemsUnChosen);
            }
            else
            {
                doubleListItemContent.ChangeChosen("hajajajkaKlulpll787878*--StairWay__Laavor*+-", true);

                doubleListItemContent.BackgroundColor = GetColorFromColorUI(ColorUIItemsChosen);
                doubleListItemContent.TextColor = GetColorFromColorUI(TextColorItemsChosen);
            }
        }

        private Color GetColorFromColorUI(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Color.FromHex("#000000");
                case ColorUI.Blue:
                    return Color.FromHex("#0000FF");
                case ColorUI.Gray:
                    return Color.FromHex("#808080");
                case ColorUI.Green:
                    return Color.FromHex("#008000");
                case ColorUI.Red:
                    return Color.FromHex("#FF0000");
                case ColorUI.Yellow:
                    return Color.FromHex("#FFFF00");
                case ColorUI.BlueLight:
                    return Color.FromHex("#5599FF");
                case ColorUI.GreenLight:
                    return Color.FromHex("#00FF00");
                case ColorUI.YellowLight:
                    return Color.FromHex("#FFEEAA");
                case ColorUI.White:
                    return Color.FromHex("#FFFFFF");
                case ColorUI.Pink:
                    return Color.FromHex("#FF00FF");
                case ColorUI.Orange:
                    return Color.FromHex("#FF6600");
                case ColorUI.Brown:
                    return Color.FromHex("#803300");
                case ColorUI.Purple:
                    return Color.FromHex("#800080");
                case ColorUI.Turquoise:
                    return Color.FromHex("#008080");
                case ColorUI.PinkLight:
                    return Color.FromHex("#FFAACC");
                case ColorUI.BlueSky:
                    return Color.FromHex("#5599FF");
                case ColorUI.GrayLight:
                    return Color.FromHex("#CCCCCC");
                case ColorUI.RedLight:
                    return Color.FromHex("#FF8080");
                case ColorUI.OrangeLight:
                    return Color.FromHex("#FFB380");
                case ColorUI.YellowDark:
                    return Color.FromHex("#FFCC00");
                case ColorUI.GreenDark:
                    return Color.FromHex("#225500");
                case ColorUI.BlueDark:
                    return Color.FromHex("#002255");
                case ColorUI.Aqua:
                    return Color.FromHex("#00FFFF");
                case ColorUI.Tan:
                    return Color.FromHex("#AC9D93");
                case ColorUI.GreenDarkness:
                    return Color.FromHex("#002200");
                case ColorUI.BlueViolet:
                    return Color.FromHex("#8A2BE2");
                default:
                    return Color.FromHex("#CCCCCC");
            }
        }

    }


}
