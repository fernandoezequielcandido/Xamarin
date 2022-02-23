using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class DoubleList
        /// </summary>
        public class DoubleList : StackLayout
        {
            /// <summary>
            /// Returns the List the Chosen items.
            /// </summary>
            public List<InquiryListChosen> ItemsChosen { get; private set; }

            /// <summary>
            /// Returns the List the UnChosen items.
            /// </summary>
            public List<InquiryListChosen> ItemsUnChosen { get; private set; }

            /// <summary>
            /// Call when Item is chosen
            /// </summary>
            public event EventHandler Chosen;

            /// <summary>
            /// Call when Item is Unchosen
            /// </summary>
            public event EventHandler UnChosen;

            private bool isFirstChosen = true;

            private Frame frameUnchosen;
            private Frame frameChosen;

            private StackLayout stackLayoutUnchosen;
            private StackLayout stackLayoutExternalUnchosen;

            private StackLayout stackMidle;

            private StackLayout stackLayoutChosen;
            private StackLayout stackLayoutExternalChosen;

            private List<InquiryListItemContent> listBtnUnchosen;
            private List<InquiryListItemContent> listBtnChosen;

            private Label labelChosen;
            private Label labelUnchosen;

            //private IEnumerable items = null;
            private List<int> listInitialbyIndex = null;
            private List<string> listInitialbyValue = null;

            private ArrowControl arrowLeft;
            private ArrowControl arrowRight;

            private int currentIndex;

            private Grid gridUnchosen;
            private Grid gridChosen;

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

                ItemsChosen = new List<InquiryListChosen>();
                ItemsUnChosen = new List<InquiryListChosen>();
            }

            private void InitAll()
            {
                currentIndex = 0;



                listBtnUnchosen = new List<InquiryListItemContent>();

                frameUnchosen = new Frame();
                frameUnchosen.BorderColor = Colors.Get(BorderColorSides);

                gridUnchosen = new Grid
                {
                    ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star }
                },
                    RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Star }
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
                labelUnchosen.TextColor = Colors.Get(TextColorTitle);
                labelUnchosen.FontFamily = FontFamilyTitle;
                labelUnchosen.FontAttributes = FontTypeTitle;




                stackLayoutUnchosen = new StackLayout();
                stackLayoutUnchosen.Spacing = 0;
                stackLayoutUnchosen.Orientation = StackOrientation.Vertical;

                frameUnchosen.Content = stackLayoutUnchosen;

                gridUnchosen.Children.Add(frameUnchosen);
                stackLayoutExternalUnchosen.Children.Add(labelUnchosen);
                stackLayoutExternalUnchosen.Children.Add(gridUnchosen);

                this.Children.Add(stackLayoutExternalUnchosen);




                arrowLeft = new ArrowControl("__Laavor*+-", ColorArrow, Side.Left, 0, true, DesignType);
                arrowLeft.WidthRequest = 35;
                arrowLeft.HeightRequest = 35;
                arrowLeft.Margin = new Thickness(5, 0, 5, 0);
                arrowLeft.GestureRecognizers.Add(GetTouchUnchosen());
                arrowLeft.GestureRecognizers.Add(GetVivacity());

                arrowRight = new ArrowControl("__Laavor*+-", ColorArrow, Side.Right, 0, true, DesignType);
                arrowRight.WidthRequest = 35;
                arrowRight.HeightRequest = 35;
                arrowRight.Margin = new Thickness(0, 0, 5, 0);
                arrowRight.GestureRecognizers.Add(GetTouchChosen());
                arrowRight.GestureRecognizers.Add(GetVivacity());

                stackMidle = new StackLayout();
                stackMidle.Orientation = StackOrientation.Horizontal;
                stackMidle.VerticalOptions = LayoutOptions.Center;
                stackMidle.HorizontalOptions = LayoutOptions.Center;
                stackMidle.Spacing = 0;

                stackMidle.Children.Add(arrowLeft);
                stackMidle.Children.Add(arrowRight);

                this.Children.Add(stackMidle);





                listBtnChosen = new List<InquiryListItemContent>();

                frameChosen = new Frame();
                frameChosen.BorderColor = Colors.Get(BorderColorSides);

                gridChosen = new Grid
                {
                    ColumnDefinitions =
                {
                    new ColumnDefinition { Width =  GridLength.Star }
                },
                    RowDefinitions =
                {
                    new RowDefinition { Height =  GridLength.Star }
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
                labelChosen.TextColor = Colors.Get(TextColorTitle);
                labelChosen.FontFamily = FontFamilyTitle;
                labelChosen.FontAttributes = FontTypeTitle;

                stackLayoutChosen = new StackLayout();
                stackLayoutChosen.Spacing = 0;
                stackLayoutChosen.Orientation = StackOrientation.Vertical;

                frameChosen.Content = stackLayoutChosen;

                gridChosen.Children.Add(frameChosen);
                stackLayoutExternalChosen.Children.Add(labelChosen);
                stackLayoutExternalChosen.Children.Add(gridChosen);

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
                    InquiryListItemContent doubleListItemContent = (InquiryListItemContent)stackLayoutUnchosen.Children[iList];
                    if (doubleListItemContent.IsChosen)
                    {
                        doubleListItemContent.ChangeChosen("__Laavor*+-", false);
                        doubleListItemContent.BackgroundColor = Colors.Get(ColorUIItemsUnChosen);
                        doubleListItemContent.TextColor = Colors.Get(TextColorItemsUnChosen);

                        int iIFExist = -1;
                        for (int iUnChosen = 0; iUnChosen < ItemsUnChosen.Count - 1; iUnChosen++)
                        {
                            if (ItemsUnChosen[iUnChosen].StartIndex == doubleListItemContent.Index)
                            {
                                iIFExist = iUnChosen;
                                break;
                            }
                        }

                        InquiryListChosen chosenItem = null;
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
                                (stackLayoutChosen.Children[stackLayoutChosen.Children.Count - 2] as InquiryListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                            }

                            (stackLayoutChosen.Children[stackLayoutChosen.Children.Count - 1] as InquiryListItemContent).Margin = new Thickness(-16, 0, -16, -16);
                        }

                        if (chosenItem == null)
                        {
                            chosenItem = new InquiryListChosen("__Laavor*+-", doubleListItemContent.Index, doubleListItemContent.Text, doubleListItemContent.Value);
                        }

                        chosenItem.ChangeCurrentIndex("__Laavor*+-", (stackLayoutChosen.Children.Count - 1));
                        ItemsChosen.Add(chosenItem);

                        iList--;
                        countList--;
                    }
                }

                countList = stackLayoutUnchosen.Children.Count;
                for (int iList = 0; iList < countList; iList++)
                {
                    InquiryListItemContent doubleListItemContent = (InquiryListItemContent)stackLayoutUnchosen.Children[iList];

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
                    InquiryListItemContent doubleListItemContent = (InquiryListItemContent)stackLayoutChosen.Children[iList];
                    if (doubleListItemContent.IsChosen)
                    {
                        doubleListItemContent.ChangeChosen("__Laavor*+-", false);
                        doubleListItemContent.BackgroundColor = Colors.Get(ColorUIItemsUnChosen);
                        doubleListItemContent.TextColor = Colors.Get(TextColorItemsUnChosen);

                        int iIFExist = -1;
                        for (int iChosen = 0; iChosen < ItemsChosen.Count - 1; iChosen++)
                        {
                            if (ItemsChosen[iChosen].StartIndex == doubleListItemContent.Index)
                            {
                                iIFExist = iChosen;
                                break;
                            }
                        }

                        InquiryListChosen chosenItem = null;
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
                                (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 2] as InquiryListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                            }

                            (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 1] as InquiryListItemContent).Margin = new Thickness(-16, 0, -16, -16);
                        }

                        if (chosenItem == null)
                        {
                            chosenItem = new InquiryListChosen("__Laavor*+-", doubleListItemContent.Index, doubleListItemContent.Text, doubleListItemContent.Value);
                        }

                        chosenItem.ChangeCurrentIndex("__Laavor*+-", (stackLayoutUnchosen.Children.Count - 1));
                        ItemsUnChosen.Add(chosenItem);

                        iList--;
                        countList--;
                    }
                }

                countList = stackLayoutChosen.Children.Count;
                for (int iList = 0; iList < countList; iList++)
                {
                    InquiryListItemContent doubleListItemContent = (InquiryListItemContent)stackLayoutChosen.Children[iList];

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
                DoubleList inquiryList = (DoubleList)bindable;
                double copyWidth = (double)newValue;

                if (inquiryList.arrowLeft != null && inquiryList.arrowRight != null)
                {
                    inquiryList.arrowLeft.WidthRequest = copyWidth;
                    inquiryList.arrowRight.WidthRequest = copyWidth;
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
            public static readonly BindableProperty TextColorTitleProperty = BindableProperty.Create(
                propertyName: nameof(TextColorTitle),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.Black,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextColorTitlePropertyChanged);

            /// <summary>
            /// Enter the TextColorTitle.
            /// </summary>
            public ColorUI TextColorTitle
            {
                get
                {
                    return (ColorUI)GetValue(TextColorTitleProperty);
                }
                set
                {
                    SetValue(TextColorTitleProperty, value);
                }
            }

            private static void TextColorTitlePropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI colorUI = (ColorUI)newValue;

                if (inquiryList.labelUnchosen != null && inquiryList.labelChosen != null)
                {
                    inquiryList.labelUnchosen.TextColor = Colors.Get(colorUI);
                    inquiryList.labelChosen.TextColor = Colors.Get(colorUI);
                }
            }

            /// <summary>
            /// Enter the FontTypeTitle.
            /// </summary>
            public static readonly BindableProperty FontTypeTitleProperty = BindableProperty.Create(
                propertyName: nameof(FontTypeTitle),
                returnType: typeof(FontAttributes),
                declaringType: typeof(DoubleList),
                defaultValue: FontAttributes.Bold,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontTypeTitlePropertyChanged);

            /// <summary>
            /// Enter the FontTypeTitle.
            /// </summary>
            public FontAttributes FontTypeTitle
            {
                get
                {
                    return (FontAttributes)GetValue(FontTypeTitleProperty);
                }
                set
                {
                    SetValue(FontTypeTitleProperty, value);
                }
            }

            private static void FontTypeTitlePropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                FontAttributes fontType = (FontAttributes)newValue;

                if (inquiryList.labelUnchosen != null && inquiryList.labelChosen != null)
                {
                    inquiryList.labelUnchosen.FontAttributes = fontType;
                    inquiryList.labelChosen.FontAttributes = fontType;
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
                DoubleList inquiryList = (DoubleList)bindable;
                double copyFontSize = (double)newValue;

                if (inquiryList.labelUnchosen != null && inquiryList.labelChosen != null)
                {
                    inquiryList.labelUnchosen.FontSize = copyFontSize;
                    inquiryList.labelChosen.FontSize = copyFontSize;
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
                DoubleList inquiryList = (DoubleList)bindable;
                string copyFontFamily = (string)newValue;
                if (inquiryList.labelUnchosen != null && inquiryList.labelChosen != null)
                {
                    inquiryList.labelChosen.FontFamily = copyFontFamily;
                    inquiryList.labelUnchosen.FontFamily = copyFontFamily;
                }
            }

            /// <summary>
            /// Enter the ColorUIItemsUnChosen.
            /// </summary>
            public static readonly BindableProperty ColorUIItemsUnChosenProperty = BindableProperty.Create(
                propertyName: nameof(ColorUIItemsUnChosen),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.GrayLight,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ColorUIItemsUnChosenPropertyChanged);

            /// <summary>
            /// Enter the ColorUIItemsUnChosen.
            /// </summary>
            public ColorUI ColorUIItemsUnChosen
            {
                get
                {
                    return (ColorUI)GetValue(ColorUIItemsUnChosenProperty);
                }
                set
                {
                    SetValue(ColorUIItemsUnChosenProperty, value);
                }
            }

            private static void ColorUIItemsUnChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI color = (ColorUI)newValue;

                if (inquiryList.stackLayoutUnchosen != null)
                {
                    for (int iItem = 0; iItem < inquiryList.stackLayoutUnchosen.Children.Count; iItem++)
                    {
                        if (inquiryList.stackLayoutChosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)inquiryList.stackLayoutUnchosen.Children[iItem];
                            doubleListItemContent.BackgroundColor = Colors.Get(color);
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the ColorUIItemsChosen.
            /// </summary>
            public static readonly BindableProperty ColorUIItemsChosenProperty = BindableProperty.Create(
                propertyName: nameof(ColorUIItemsChosen),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.BlueDark,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ColorUIItemsChosenPropertyChanged);

            /// <summary>
            /// Enter the ColorUIItemsChosen.
            /// </summary>
            public ColorUI ColorUIItemsChosen
            {
                get
                {
                    return (ColorUI)GetValue(ColorUIItemsChosenProperty);
                }
                set
                {
                    SetValue(ColorUIItemsChosenProperty, value);
                }
            }

            private static void ColorUIItemsChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI color = (ColorUI)newValue;

                if (inquiryList.stackLayoutChosen != null)
                {
                    for (int iItem = 0; iItem < inquiryList.stackLayoutChosen.Children.Count; iItem++)
                    {
                        if (inquiryList.stackLayoutChosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)inquiryList.stackLayoutChosen.Children[iItem];
                            doubleListItemContent.BackgroundColor = Colors.Get(color);
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the TextColorItemsChosen.
            /// </summary>
            public static readonly BindableProperty TextColorItemsChosenProperty = BindableProperty.Create(
                propertyName: nameof(TextColorItemsChosen),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.White,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextColorItemsChosenPropertyChanged);

            /// <summary>
            /// Enter the TextColorItemsChosen.
            /// </summary>
            public ColorUI TextColorItemsChosen
            {
                get
                {
                    return (ColorUI)GetValue(TextColorItemsChosenProperty);
                }
                set
                {
                    SetValue(TextColorItemsChosenProperty, value);
                }
            }

            private static void TextColorItemsChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI color = (ColorUI)newValue;

                if (inquiryList.stackLayoutChosen != null)
                {
                    for (int iItem = 0; iItem < inquiryList.stackLayoutChosen.Children.Count; iItem++)
                    {
                        if (inquiryList.stackLayoutChosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)inquiryList.stackLayoutChosen.Children[iItem];
                            doubleListItemContent.TextColor = Colors.Get(color);
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the TextColorItemsUnChosen.
            /// </summary>
            public static readonly BindableProperty TextColorItemsUnChosenProperty = BindableProperty.Create(
                propertyName: nameof(TextColorItemsUnChosen),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.Black,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextColorItemsUnChosenPropertyChanged);

            /// <summary>
            /// Enter the TextColorItemsUnChosen.
            /// </summary>
            public ColorUI TextColorItemsUnChosen
            {
                get
                {
                    return (ColorUI)GetValue(TextColorItemsUnChosenProperty);
                }
                set
                {
                    SetValue(TextColorItemsUnChosenProperty, value);
                }
            }

            private static void TextColorItemsUnChosenPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI color = (ColorUI)newValue;

                if (inquiryList.stackLayoutUnchosen != null)
                {
                    for (int iItem = 0; iItem < inquiryList.stackLayoutUnchosen.Children.Count; iItem++)
                    {
                        if (inquiryList.stackLayoutUnchosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)inquiryList.stackLayoutChosen.Children[iItem];
                            doubleListItemContent.TextColor = Colors.Get(color);
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the ColorUISides.
            /// </summary>
            public static readonly BindableProperty ColorUISidesProperty = BindableProperty.Create(
                propertyName: nameof(ColorUISides),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.Transparent,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ColorUISidesPropertyChanged);

            /// <summary>
            /// Enter the ColorUISides.
            /// </summary>
            public ColorUI ColorUISides
            {
                get
                {
                    return (ColorUI)GetValue(ColorUISidesProperty);
                }
                set
                {
                    SetValue(ColorUISidesProperty, value);
                }
            }

            private static void ColorUISidesPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI color = (ColorUI)newValue;

                if (inquiryList.frameUnchosen != null)
                {
                    inquiryList.frameUnchosen.BackgroundColor = Colors.Get(color);
                }

                if (inquiryList.frameChosen != null)
                {
                    inquiryList.frameChosen.BackgroundColor = Colors.Get(color);
                }
            }

            /// <summary>
            /// Enter the BorderColorSides.
            /// </summary>
            public static readonly BindableProperty BorderColorSidesProperty = BindableProperty.Create(
                propertyName: nameof(BorderColorSides),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.BlueSky,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: BorderColorSidesPropertyChanged);

            /// <summary>
            /// Enter the BorderColorSides.
            /// </summary>
            public ColorUI BorderColorSides
            {
                get
                {
                    return (ColorUI)GetValue(BorderColorSidesProperty);
                }
                set
                {
                    SetValue(BorderColorSidesProperty, value);
                }
            }

            private static void BorderColorSidesPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI color = (ColorUI)newValue;

                if (inquiryList.frameUnchosen != null && inquiryList.frameUnchosen != null)
                {
                    inquiryList.frameUnchosen.BorderColor = Colors.Get(color);
                    inquiryList.frameChosen.BorderColor = Colors.Get(color);
                }
            }

            /// <summary>
            /// Enter the ColorArrow.
            /// </summary>
            public static readonly BindableProperty ColorArrowProperty = BindableProperty.Create(
                propertyName: nameof(ColorArrow),
                returnType: typeof(ColorUI),
                declaringType: typeof(DoubleList),
                defaultValue: ColorUI.BlueSky,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ColorArrowPropertyChanged);

            /// <summary>
            /// Enter the ColorArrow.
            /// </summary>
            public ColorUI ColorArrow
            {
                get
                {
                    return (ColorUI)GetValue(ColorArrowProperty);
                }
                set
                {
                    SetValue(ColorArrowProperty, value);
                }
            }

            private static void ColorArrowPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                ColorUI color = (ColorUI)newValue;

                if (inquiryList.arrowLeft != null)
                {
                    inquiryList.arrowLeft.ChangeColor("__Laavor*+-", color);
                }

                if (inquiryList.arrowRight != null)
                {
                    inquiryList.arrowRight.ChangeColor("__Laavor*+-", color);
                }
            }


            /// <summary>
            /// Enter the FontTypeItems.
            /// </summary>
            public static readonly BindableProperty FontTypeItemsProperty = BindableProperty.Create(
                propertyName: nameof(FontTypeItems),
                returnType: typeof(FontAttributes),
                declaringType: typeof(DoubleList),
                defaultValue: FontAttributes.None,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontTypeItemsPropertyChanged);

            /// <summary>
            /// Enter the FontTypeItems.
            /// </summary>
            public FontAttributes FontTypeItems
            {
                get
                {
                    return (FontAttributes)GetValue(FontTypeItemsProperty);
                }
                set
                {
                    SetValue(FontTypeItemsProperty, value);
                }
            }

            private static void FontTypeItemsPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                FontAttributes fontType = (FontAttributes)newValue;

                if (inquiryList.stackLayoutUnchosen != null)
                {
                    for (int iItem = 0; iItem < inquiryList.stackLayoutUnchosen.Children.Count; iItem++)
                    {
                        if (inquiryList.stackLayoutUnchosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)inquiryList.stackLayoutUnchosen.Children[iItem];
                            doubleListItemContent.FontAttributes = fontType;
                        }
                    }
                }

                if (inquiryList.stackLayoutChosen != null)
                {
                    for (int iItem = 0; iItem < inquiryList.stackLayoutChosen.Children.Count; iItem++)
                    {
                        if (inquiryList.stackLayoutChosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)inquiryList.stackLayoutChosen.Children[iItem];
                            doubleListItemContent.FontAttributes = fontType;
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
                        if (doubleList.stackLayoutUnchosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)doubleList.stackLayoutUnchosen.Children[iItem];
                            doubleListItemContent.FontSize = copyFontSize;
                        }
                    }
                }

                if (doubleList.stackLayoutChosen != null)
                {
                    for (int iItem = 0; iItem < doubleList.stackLayoutChosen.Children.Count; iItem++)
                    {
                        if (doubleList.stackLayoutChosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)doubleList.stackLayoutChosen.Children[iItem];
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
                        if (doubleList.stackLayoutUnchosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)doubleList.stackLayoutUnchosen.Children[iItem];
                            doubleListItemContent.FontFamily = copyFontFamily;
                        }
                    }
                }

                if (doubleList.stackLayoutChosen != null)
                {
                    for (int iItem = 0; iItem < doubleList.stackLayoutChosen.Children.Count; iItem++)
                    {
                        if (doubleList.stackLayoutChosen.Children[iItem].GetType() == typeof(InquiryListItemContent))
                        {
                            InquiryListItemContent doubleListItemContent = (InquiryListItemContent)doubleList.stackLayoutChosen.Children[iItem];
                            doubleListItemContent.FontFamily = copyFontFamily;
                        }
                    }
                }
            }

            /// <summary>
            /// Set DesignType
            /// </summary>
            public static readonly BindableProperty DesignTypeProperty = BindableProperty.Create(
                     propertyName: nameof(DesignType),
                     returnType: typeof(DesignType),
                     declaringType: typeof(DoubleList),
                     defaultValue: DesignType.Shinning,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: DesignTypePropertyChanged);

            /// <summary>
            /// Set DesignType
            /// </summary>
            public DesignType DesignType
            {
                get
                {
                    return (DesignType)GetValue(DesignTypeProperty);
                }
                set
                {
                    SetValue(DesignTypeProperty, value);
                }
            }

            private static void DesignTypePropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;
                DesignType designType = (DesignType)newValue;

                if (inquiryList.arrowLeft != null)
                {
                    inquiryList.arrowLeft.ChangeDesignType("__Laavor*+-", designType);
                }

                if (inquiryList.arrowRight != null)
                {
                    inquiryList.arrowRight.ChangeDesignType("__Laavor*+-", designType);
                }
            }

            /// <summary>
            /// Property to set Vivacity.
            /// </summary>
            public static readonly BindableProperty VivacityProperty = BindableProperty.Create(
                     propertyName: nameof(Vivacity),
                     returnType: typeof(Vivacity),
                     declaringType: typeof(DoubleList),
                     defaultValue: Vivacity.Decrease,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: VivacityPropertyChanged);

            /// <summary>
            /// Property to set Vivacity.
            /// </summary>
            public Vivacity Vivacity
            {
                get
                {
                    return (Vivacity)GetValue(VivacityProperty);
                }
                set
                {
                    SetValue(VivacityProperty, value);
                }
            }

            /// <summary>
            /// Call when Vivacity is Changed
            /// </summary>
            /// <param name="bindable"></param>
            /// <param name="oldValue"></param>
            /// <param name="newValue"></param>
            protected static void VivacityPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;

                if (inquiryList.Vivacity != Vivacity.None)
                {
                    inquiryList.arrowLeft.GestureRecognizers.Clear();

                    if (inquiryList.arrowLeft.GestureRecognizers.Count == 0)
                    {
                        inquiryList.arrowLeft.GestureRecognizers.Add(inquiryList.GetTouchUnchosen());
                    }

                    if (inquiryList.arrowLeft.GestureRecognizers.Count == 1)
                    {
                        inquiryList.arrowLeft.GestureRecognizers.Add(inquiryList.GetVivacity());
                    }

                    inquiryList.arrowRight.GestureRecognizers.Clear();
                    if (inquiryList.arrowRight.GestureRecognizers.Count == 0)
                    {
                        inquiryList.arrowRight.GestureRecognizers.Add(inquiryList.GetTouchChosen());
                    }

                    if (inquiryList.arrowRight.GestureRecognizers.Count == 1)
                    {
                        inquiryList.arrowRight.GestureRecognizers.Add(inquiryList.GetVivacity());
                    }

                    inquiryList.ChangeVivacityItens();
                }
            }

            private void ChangeVivacityItens()
            {
                for (int iBtn = 0; iBtn < listBtnChosen.Count; iBtn++)
                {
                    InquiryListItemContent doubleListItemContent = listBtnChosen[iBtn];
                    SetVivacity(doubleListItemContent);
                }

                for (int iBtn = 0; iBtn < listBtnUnchosen.Count; iBtn++)
                {
                    InquiryListItemContent doubleListItemContent = listBtnUnchosen[iBtn];
                    SetVivacity(doubleListItemContent);
                }
            }

            private void SetVivacity(Button button)
            {
                if (Vivacity == Vivacity.Decrease)
                {
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;

                    button.Clicked += VivacityDecrease;
                }
                else if (Vivacity == Vivacity.Increase)
                {
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;

                    button.Clicked += VivacityIncrease;
                }
                else if (Vivacity == Vivacity.Jump)
                {
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;

                    button.Clicked += VivacityJump;
                }
                else if (Vivacity == Vivacity.Rotation)
                {
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;

                    button.Clicked += VivacityRotation;
                }
                else if (Vivacity == Vivacity.Down)
                {
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;

                    button.Clicked += VivacityDown;
                }
                else if (Vivacity == Vivacity.Left)
                {
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;

                    button.Clicked += VivacityLeft;
                }
                else if (Vivacity == Vivacity.Right)
                {
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;

                    button.Clicked += VivacityRight;
                }
                else
                {
                    button.Clicked -= VivacityIncrease;
                    button.Clicked -= VivacityDecrease;
                    button.Clicked -= VivacityJump;
                    button.Clicked -= VivacityRotation;
                    button.Clicked -= VivacityDown;
                    button.Clicked -= VivacityLeft;
                    button.Clicked -= VivacityRight;
                }
            }

            private async void VivacityDecrease(object sender, EventArgs e)
            {
                try
                {
                    InquiryListItemContent button = (InquiryListItemContent)sender;
                    await button.ScaleTo(GetDepthDecrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await button.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            private async void VivacityIncrease(object sender, EventArgs e)
            {
                try
                {
                    InquiryListItemContent button = (InquiryListItemContent)sender;
                    await button.ScaleTo(GetDepthIncrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await button.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            private async void VivacityJump(object sender, EventArgs e)
            {
                try
                {
                    InquiryListItemContent button = (InquiryListItemContent)sender;
                    await button.TranslateTo(0, GetDepthJump(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await button.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            private async void VivacityRotation(object sender, EventArgs e)
            {
                try
                {
                    InquiryListItemContent button = (InquiryListItemContent)sender;
                    await button.RotateTo(GetDepthRotation(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await button.RotateTo(0, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            private async void VivacityDown(object sender, EventArgs e)
            {
                try
                {
                    InquiryListItemContent button = (InquiryListItemContent)sender;
                    await button.TranslateTo(0, GetDepthDown(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await button.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            private async void VivacityLeft(object sender, EventArgs e)
            {
                try
                {
                    InquiryListItemContent button = (InquiryListItemContent)sender;
                    await button.TranslateTo(GetDepthLeft(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                    await button.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            /// <summary>
            /// Use to create VivacityRight is Auto Call
            /// </summary>
            public async void VivacityRight(object sender, EventArgs e)
            {
                try
                {
                    InquiryListItemContent button = (InquiryListItemContent)sender;
                    await button.TranslateTo(GetDepthRight(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                    await button.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            /// <summary>
            /// Use to create DepthRight is Auto Call
            /// </summary>
            /// <returns></returns>
            public double GetDepthRight(Depth depth)
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


            /// <summary>
            /// Property to set Depth of Vivacity.
            /// </summary>
            public static readonly BindableProperty DepthProperty = BindableProperty.Create(
                     propertyName: nameof(Depth),
                     returnType: typeof(Depth),
                     declaringType: typeof(DoubleList),
                     defaultValue: Depth.LessMedium,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: DepthPropertyChanged);

            /// <summary>
            /// Property to set Depth of Vivacity.
            /// </summary>
            public Depth Depth
            {
                get
                {
                    return (Depth)GetValue(DepthProperty);
                }
                set
                {
                    SetValue(DepthProperty, value);
                }
            }

            /// <summary>
            /// Call when Depth is Changed
            /// </summary>
            /// <param name="bindable"></param>
            /// <param name="oldValue"></param>
            /// <param name="newValue"></param>
            protected static void DepthPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;

                if (inquiryList.Vivacity != Vivacity.None)
                {
                    inquiryList.arrowLeft.GestureRecognizers.Clear();

                    if (inquiryList.arrowLeft.GestureRecognizers.Count == 0)
                    {
                        inquiryList.arrowLeft.GestureRecognizers.Add(inquiryList.GetTouchUnchosen());
                    }

                    if (inquiryList.arrowLeft.GestureRecognizers.Count == 1)
                    {
                        inquiryList.arrowLeft.GestureRecognizers.Add(inquiryList.GetVivacity());
                    }

                    inquiryList.arrowRight.GestureRecognizers.Clear();

                    if (inquiryList.arrowRight.GestureRecognizers.Count == 0)
                    {
                        inquiryList.arrowRight.GestureRecognizers.Add(inquiryList.GetTouchChosen());
                    }

                    if (inquiryList.arrowRight.GestureRecognizers.Count == 1)
                    {
                        inquiryList.arrowRight.GestureRecognizers.Add(inquiryList.GetVivacity());
                    }

                    inquiryList.ChangeVivacityItens();
                }
            }

            /// <summary>
            /// Property to set VivacitySpeed.
            /// </summary>
            public static readonly BindableProperty VivacitySpeedProperty = BindableProperty.Create(
                     propertyName: nameof(VivacitySpeed),
                     returnType: typeof(VivacitySpeed),
                     declaringType: typeof(DoubleList),
                     defaultValue: VivacitySpeed.Fast,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: VivacitySpeedPropertyChanged);

            /// <summary>
            /// Property to set VivacitySpeed.
            /// </summary>
            public VivacitySpeed VivacitySpeed
            {
                get
                {
                    return (VivacitySpeed)GetValue(VivacitySpeedProperty);
                }
                set
                {
                    SetValue(VivacitySpeedProperty, value);
                }
            }

            /// <summary>
            /// Call when VivacitySpeed is Changed
            /// </summary>
            /// <param name="bindable"></param>
            /// <param name="oldValue"></param>
            /// <param name="newValue"></param>
            protected static void VivacitySpeedPropertyChanged(object bindable, object oldValue, object newValue)
            {
                DoubleList inquiryList = (DoubleList)bindable;

                if (inquiryList.Vivacity != Vivacity.None)
                {
                    inquiryList.arrowLeft.GestureRecognizers.Clear();

                    if (inquiryList.arrowLeft.GestureRecognizers.Count == 0)
                    {
                        inquiryList.arrowLeft.GestureRecognizers.Add(inquiryList.GetTouchUnchosen());
                    }

                    if (inquiryList.arrowLeft.GestureRecognizers.Count == 1)
                    {
                        inquiryList.arrowLeft.GestureRecognizers.Add(inquiryList.GetVivacity());
                    }

                    inquiryList.arrowRight.GestureRecognizers.Clear();
                    if (inquiryList.arrowRight.GestureRecognizers.Count == 0)
                    {
                        inquiryList.arrowRight.GestureRecognizers.Add(inquiryList.GetTouchChosen());
                    }

                    if (inquiryList.arrowRight.GestureRecognizers.Count == 1)
                    {
                        inquiryList.arrowRight.GestureRecognizers.Add(inquiryList.GetVivacity());
                    }

                    inquiryList.ChangeVivacityItens();
                }
            }

            private TapGestureRecognizer GetVivacity()
            {
                MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + Vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

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
                        ArrowControl arrow = (ArrowControl)sender;
                       
                        await arrow.ScaleTo(GetDepthDecrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await arrow.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
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
                        ArrowControl arrow = (ArrowControl)sender;

                        await arrow.ScaleTo(GetDepthIncrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await arrow.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
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
                        ArrowControl arrow = (ArrowControl)sender;

                        await arrow.RotateTo(GetDepthRotation(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await arrow.RotateTo(0, (uint)VivacitySpeed, Easing.Linear);
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
                        ArrowControl arrow = (ArrowControl)sender;

                        await arrow.TranslateTo(0, GetDepthJump(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await arrow.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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
                        ArrowControl arrow = (ArrowControl)sender;

                        await arrow.TranslateTo(0, GetDepthDown(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await arrow.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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
                        ArrowControl arrow = (ArrowControl)sender;

                        await arrow.TranslateTo(GetDepthLeft(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                        await arrow.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="child"></param>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (child.GetType() == typeof(InquiryListItem))
                {
                    InquiryListItem doubleListItem = (InquiryListItem)child;
                    InquiryListItemContent doubleListItemContent = new InquiryListItemContent("__Laavor*+-", doubleListItem.Text, doubleListItem.Value, currentIndex, false);
                    doubleListItemContent.Pressed += DoubleListItemContent_Pressed;
                    doubleListItemContent.BackgroundColor = Colors.Get(ColorUIItemsUnChosen);
                    doubleListItemContent.TextColor = Colors.Get(TextColorItemsUnChosen);
                    doubleListItemContent.FontAttributes = FontTypeItems;
                    doubleListItemContent.FontSize = FontSizeItems;

                    SetVivacity(doubleListItemContent);

                    InquiryListChosen chosenItem = new InquiryListChosen("__Laavor*+-", currentIndex, doubleListItem.Text, doubleListItem.Value);

                    bool isInserted = false;

                    
                    if (listInitialbyValue != null && listInitialbyValue.Count > 0)
                    {
                        if (listInitialbyValue.Contains(doubleListItem.Value))
                        {
                            doubleListItemContent.ChangeChosen("__Laavor*+-", true);

                            if (currentIndex == 0)
                            {
                                doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                            }
                            else
                            {
                                if (currentIndex >= 2)
                                {
                                    (stackLayoutChosen.Children[stackLayoutChosen.Children.Count - 1] as InquiryListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                                }

                                doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                            }

                            listBtnChosen.Add(doubleListItemContent);
                            stackLayoutChosen.Children.Add(doubleListItemContent);
                            chosenItem.ChangeCurrentIndex("__Laavor*+-", (stackLayoutChosen.Children.Count - 1));
                            ItemsChosen.Add(chosenItem);

                            isInserted = true;
                        }
                    }
                    else if (listInitialbyIndex != null && listInitialbyIndex.Count > 0)
                    {
                        if (listInitialbyIndex.Contains(doubleListItemContent.Index))
                        {
                            doubleListItemContent.ChangeChosen("__Laavor*+-", true);

                            if (currentIndex == 0)
                            {
                                doubleListItemContent.Margin = new Thickness(-16, -16, -16, 4);
                            }
                            else
                            {
                                if (currentIndex >= 2)
                                {
                                    (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 1] as InquiryListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                                }

                                doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                            }

                            listBtnUnchosen.Add(doubleListItemContent);
                            stackLayoutUnchosen.Children.Add(doubleListItemContent);
                            chosenItem.ChangeCurrentIndex("__Laavor*+-", (stackLayoutUnchosen.Children.Count - 1));
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
                                (stackLayoutUnchosen.Children[stackLayoutUnchosen.Children.Count - 1] as InquiryListItemContent).Margin = new Thickness(-16, 0, -16, 4);
                            }

                            doubleListItemContent.Margin = new Thickness(-16, 0, -16, -16);
                        }

                        listBtnUnchosen.Add(doubleListItemContent);
                        stackLayoutUnchosen.Children.Add(doubleListItemContent);
                        chosenItem.ChangeCurrentIndex("__Laavor*+-", (stackLayoutUnchosen.Children.Count - 1));
                        ItemsUnChosen.Add(chosenItem);
                    }

                    
                    if (currentIndex == 0)
                    {
                        InquiryListItem doubleListItemRight = (InquiryListItem)child;
                        InquiryListItemContent doubleListItemContentRight = new InquiryListItemContent("__Laavor*+-", doubleListItem.Text, doubleListItem.Value, currentIndex, false);
                        doubleListItemContentRight.Margin = new Thickness(-16, -16, -16, 4);
                        doubleListItemContentRight.BackgroundColor = Colors.Get(ColorUIItemsUnChosen);
                        doubleListItemContentRight.TextColor = Colors.Get(TextColorItemsUnChosen);

                        InquiryListChosen auxItem = new InquiryListChosen("__Laavor*+-", currentIndex, "Wtesetu8chosen", "asv");

                        listBtnChosen.Add(doubleListItemContentRight);
                        stackLayoutChosen.Children.Add(doubleListItemContentRight);
                        //ItemsChosen.Add(auxItem);

                        isFirstChosen = true;
                    }
                    else
                    {
                        if (listBtnChosen.Count > 0)
                        {
                            if (listBtnChosen[0].Text.Length < doubleListItem.Text.Length)
                            {
                                listBtnChosen[0].Text = doubleListItem.Text;
                            }
                        }
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
                InquiryListItemContent doubleListItemContent = (InquiryListItemContent)sender;

                if (isFirstChosen)
                {
                    //listBtnChosen.Clear();
                    //stackLayoutChosen.Children.Clear();
                    //ItemsChosen.Clear();
                    //isFirstChosen = false;
                }
                
                if (doubleListItemContent.IsChosen)
                {
                    doubleListItemContent.ChangeChosen("__Laavor*+-", false);

                    doubleListItemContent.BackgroundColor = Colors.Get(ColorUIItemsUnChosen);
                    doubleListItemContent.TextColor = Colors.Get(TextColorItemsUnChosen);
                }
                else
                {
                    doubleListItemContent.ChangeChosen("__Laavor*+-", true);

                    doubleListItemContent.BackgroundColor = Colors.Get(ColorUIItemsChosen);
                    doubleListItemContent.TextColor = Colors.Get(TextColorItemsChosen);
                }
            }

        }
    }
}
