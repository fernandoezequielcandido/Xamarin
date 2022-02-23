using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorGroupBox
{
    /// <summary>
    /// Class GroupBox
    /// </summary>
    public class GroupBox : StackLayout
    {
        private StackLayout dataItems;

        private ContentBox contentBoxRefererence;
        private MergeBoxText mergeBoxTextReference;
        private Frame frameReference;

        private FontAttributes currentFontTypeTitle = FontAttributes.None;
        private ColorUI currentColorUI = ColorUI.Black;
        private ColorUI currentContentColor = ColorUI.White;
        private ColorUI currentBorderContentColor = ColorUI.Black;
        private ColorUI currentTextColorTitle = ColorUI.Black;
        private DesignType currentDesignType = DesignType.Shining;
        
        /// <summary>
        /// Constructor of GroupBox
        /// </summary>
        public GroupBox() : base()
        {
            dataItems = new StackLayout();
            Children.Add(dataItems);
        }

        /// <summary>
        /// Enter the font size title.
        /// </summary>
        public static readonly BindableProperty FontSizeTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeTitle),
            returnType: typeof(double),
            declaringType: typeof(GroupBox),
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
            GroupBox groupBox = (GroupBox)bindable;
            double copyFontSize = (double)newValue;

            if (groupBox.mergeBoxTextReference != null && groupBox.mergeBoxTextReference.barText != null)
            {
                groupBox.mergeBoxTextReference.barText.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Set TextColor
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
            }
        }

        private void ColorUIPropertyChanged()
        {
            if (mergeBoxTextReference != null && mergeBoxTextReference.barBox != null)
            {
                mergeBoxTextReference.barText.TextColor = GetColorFromColorUI(currentTextColorTitle);
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyTitle),
            returnType: typeof(string),
            declaringType: typeof(GroupBox),
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
            GroupBox groupBox = (GroupBox)bindable;
            string copyFontFamily = (string)newValue;
            if (groupBox.mergeBoxTextReference != null && groupBox.mergeBoxTextReference.barText != null)
            {
                groupBox.mergeBoxTextReference.barText.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the fonttype title (None, Bold, Italic).
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
                FontTypeTitlePropertyChanged(currentFontTypeTitle, value);
                currentFontTypeTitle = value;
            }
        }

        private void FontTypeTitlePropertyChanged(FontAttributes oldValue, FontAttributes newValue)
        {
            FontAttributes copyFontType = newValue;
            if (mergeBoxTextReference != null && mergeBoxTextReference.barText != null)
            {
                mergeBoxTextReference.barText.FontAttributes = copyFontType;
            }
        }

        /// <summary>
        /// Set ColorUI (Bar Title)
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUI
        {
            get
            {
                return currentColorUI;
            }
            set
            {
                currentColorUI = value;
                ColorUIPropertyChanged(currentColorUI, value);
            }
        }

        private void ColorUIPropertyChanged(ColorUI oldValue, ColorUI newValue)
        {
            if (mergeBoxTextReference != null && mergeBoxTextReference.barBox != null)
            {
                mergeBoxTextReference.barBox.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", newValue);
            }
        }

        /// <summary>
        /// Enter the heightBarTitle
        /// </summary>
        public static readonly BindableProperty HeightBarTitleProperty = BindableProperty.Create(
            propertyName: nameof(HeightBarTitle),
            returnType: typeof(double),
            declaringType: typeof(GroupBox),
            defaultValue: 30.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightBarTitlePropertyChanged);

        /// <summary>
        /// Enter the heightBarTitle.
        /// </summary>
        public double HeightBarTitle
        {
            get
            {
                return (double)GetValue(HeightBarTitleProperty);
            }
            set
            {
                SetValue(HeightBarTitleProperty, value);
            }
        }

        private static void HeightBarTitlePropertyChanged(object bindable, object oldValue, object newValue)
        {
            GroupBox groupBox = (GroupBox)bindable;
            double groupHeight = (double)newValue;

            if (groupBox.mergeBoxTextReference != null && groupBox.mergeBoxTextReference.barBox != null)
            {
                groupBox.mergeBoxTextReference.barBox.HeightRequest = groupHeight;
            }
        }

        /// <summary>
        /// Enter the width GroupBox.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double?),
            declaringType: typeof(GroupBox),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width GroupBox.
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
            GroupBox groupBox = (GroupBox)bindable;
            double groupBoxWidth = (double)newValue;
            if (groupBox.mergeBoxTextReference != null && groupBox.mergeBoxTextReference.barBox != null)
            {
                groupBox.mergeBoxTextReference.barBox.WidthRequest = groupBoxWidth;
            }

            if (groupBox.frameReference != null)
            {
                groupBox.frameReference.WidthRequest = groupBoxWidth - 42;
            }
        }

        /// <summary>
        /// Title.
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(ContentBox),
            defaultValue: "",
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TitlePropertyChanged);

        /// <summary>
        /// Title.
        /// </summary>
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        private static void TitlePropertyChanged(object bindable, object oldValue, object newValue)
        {
            GroupBox groupBox = (GroupBox)bindable;
            string title = (string)newValue;
            if (groupBox.mergeBoxTextReference != null && groupBox.mergeBoxTextReference.barText != null)
            {
                groupBox.mergeBoxTextReference.barText.Text = title;
            }
        }

        /// <summary>
        /// Set DesignType
        /// </summary>
        [Bindable(true)]
        public DesignType DesignType
        {
            get
            {
                return currentDesignType;
            }
            set
            {
                currentDesignType = value;
                DesignTypePropertyChanged(currentDesignType, value);                
            }
        }

        private void DesignTypePropertyChanged(DesignType oldValue, DesignType newValue)
        {
            if (mergeBoxTextReference != null && mergeBoxTextReference.barBox != null)
            {
                mergeBoxTextReference.barBox.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", newValue);
            }
        }

        /// <summary>
        /// Set ContentColor
        /// </summary>
        [Bindable(true)]
        public ColorUI ContentColor
        {
            get
            {
                return currentContentColor;
            }
            set
            {
                currentContentColor = value;
                ContentColorPropertyChanged();
            }
        }

        private void ContentColorPropertyChanged()
        {
            if (frameReference != null)
            {
                frameReference.BackgroundColor = GetColorFromColorUI(currentContentColor);
            }
        }

        /// <summary>
        /// Set Boder Content Color
        /// </summary>
        [Bindable(true)]
        public ColorUI BorderContentColor
        {
            get
            {
                return currentBorderContentColor;
            }
            set
            {
                currentBorderContentColor = value;
                BorderContentColorPropertyChanged();
            }
        }

        private void BorderContentColorPropertyChanged()
        {
            if (frameReference != null)
            {
                frameReference.BorderColor = GetColorFromColorUI(currentBorderContentColor);
            }
        }

        private Color GetColorFromColorUI(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Color.FromRgb(0, 0, 0);
                case ColorUI.Blue:
                    return Color.FromRgb(0, 0, 255);
                case ColorUI.Gray:
                    return Color.FromRgb(128, 128, 128);
                case ColorUI.Green:
                    return Color.FromRgb(0, 128, 0);
                case ColorUI.Red:
                    return Color.FromRgb(255, 0, 0);
                case ColorUI.Yellow:
                    return Color.FromRgb(255, 255, 0);
                case ColorUI.BlueLight:
                    return Color.FromRgb(170, 204, 255);
                case ColorUI.GreenLight:
                    return Color.FromRgb(0, 255, 0);
                case ColorUI.YellowLight:
                    return Color.FromRgb(255, 238, 170);
                case ColorUI.White:
                    return Color.FromRgb(255, 255, 255);
                case ColorUI.Pink:
                    return Color.FromRgb(255, 0, 255);
                case ColorUI.Orange:
                    return Color.FromRgb(255, 102, 0);
                case ColorUI.Brown:
                    return Color.FromRgb(128, 51, 0);
                case ColorUI.Purple:
                    return Color.FromRgb(128, 0, 128);
                case ColorUI.Turquoise:
                    return Color.FromRgb(0, 128, 128);
                case ColorUI.PinkLight:
                    return Color.FromRgb(255, 170, 204);
                case ColorUI.BlueSky:
                    return Color.FromRgb(85, 153, 255);
                case ColorUI.GrayLight:
                    return Color.FromRgb(204, 204, 204);
                case ColorUI.RedLight:
                    return Color.FromRgb(255, 128, 128);
                case ColorUI.OrangeLight:
                    return Color.FromRgb(255, 179, 128);
                case ColorUI.YellowDark:
                    return Color.FromRgb(255, 204, 0);
                case ColorUI.GreenDark:
                    return Color.FromRgb(34, 85, 0);
                case ColorUI.BlueDark:
                    return Color.FromRgb(0, 34, 85);
                case ColorUI.Aqua:
                    return Color.FromRgb(0, 255, 255);
                case ColorUI.Tan:
                    return Color.FromRgb(172, 157, 147);
                case ColorUI.GreenDarkness:
                    return Color.FromRgb(0, 34, 0);
                case ColorUI.BlueViolet:
                    return Color.FromRgb(138, 43, 226);
                default:
                    return Color.FromRgb(204, 204, 204);
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            if (child.GetType() == typeof(ContentBox))
            {
                ContentBox userItem = (ContentBox)child;
                base.OnChildAdded(child);

                contentBoxRefererence = new ContentBox();

                if (Width.HasValue)
                {
                    contentBoxRefererence.WidthRequest = Width.Value;
                }

                if (userItem.Content != null)
                {
                    contentBoxRefererence.Content = userItem.Content;
                }
                else
                {
                    for (int iS = 0; iS < userItem.Children.Count; iS++)
                    {
                        contentBoxRefererence.Children.Add(userItem.Children[iS]);
                    }
                }

                frameReference = new Frame()
                {
                    BorderColor = GetColorFromColorUI(currentBorderContentColor),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    BackgroundColor = GetColorFromColorUI(currentContentColor),
                    HasShadow = true,
                    Margin = new Thickness(0, -1, 0, 0)
                };

                if (Width.HasValue)
                {
                    frameReference.WidthRequest = Width.Value - 42;
                }
                else
                {
                    frameReference.Margin = new Thickness(5, -1, 5, 5);
                    frameReference.HorizontalOptions = LayoutOptions.FillAndExpand;
                }

                Grid grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Star }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto},
                        new RowDefinition { Height =  GridLength.Auto}
                    }
                };

                frameReference.Content = contentBoxRefererence;

                grid.Children.Add(CreateBar(), 0, 0);
                grid.RowSpacing = 0;

                dataItems.Spacing = 0;

                if (dataItems.Children.Count > 1)
                {
                    this.Children.RemoveAt(this.Children.Count - 1);
                }
                grid.Children.Add(frameReference, 0, 1);

                dataItems.Children.Add(grid);
            }
        }

        private View CreateBar()
        {
            BarBox imageButton = new BarBox("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentDesignType, currentColorUI);

            if (Width.HasValue)
            {
                imageButton.WidthRequest = Width.Value;
                imageButton.HorizontalOptions = LayoutOptions.Center;
            }
            else
            {
                imageButton.Margin = new Thickness(4, 4, 4, 0);
            }

            imageButton.HeightRequest = HeightBarTitle;

            BarText labelText = new BarText();
            labelText.Text = Title;
            labelText.TextColor = GetColorFromColorUI(currentTextColorTitle);
            labelText.FontAttributes = currentFontTypeTitle;
            labelText.BackgroundColor = Color.Transparent;
            labelText.FontFamily = FontFamilyTitle;
            labelText.HorizontalOptions = LayoutOptions.Center;
            labelText.FontSize = FontSizeTitle;

            AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

            mergeBoxTextReference = new MergeBoxText() { barBox = imageButton, barText = labelText };

            StackLayout stack = new StackLayout();
            stack.HorizontalOptions = LayoutOptions.FillAndExpand;

            AbsoluteLayout absolute = new AbsoluteLayout();
            absolute.VerticalOptions = LayoutOptions.CenterAndExpand;

            Grid grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height =  GridLength.Star}
                }
            };

            grid.Children.Add(imageButton);
            stack.Children.Add(grid);

            grid.ColumnSpacing = 0;
            grid.RowSpacing = 0;

            absolute.Children.Add(stack);
            absolute.Children.Add(labelText);

            StackLayout returnValue = new StackLayout();
            returnValue.Spacing = 0;
            returnValue.Children.Add(absolute);
            return returnValue;
        }
    }
}
