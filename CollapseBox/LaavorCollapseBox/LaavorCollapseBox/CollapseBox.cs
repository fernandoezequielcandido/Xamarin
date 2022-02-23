using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace LaavorCollapseBox
{
    /// <summary>
    /// Class CollapseBox
    /// </summary>
    public class CollapseBox: StackLayout
    {
        /// <summary>
        /// Get State (Open or Close)
        /// </summary>
        public StateCollapseBox State { get; private set; }

        private StackLayout dataItems;

        private ContentBox contentBoxRefererence;
        private MergeBoxTextTitle mergeBoxTextTitleReference;

        private StackLayout stackData;

        private Scene sceneReference;

        private DesignType currentDesignType = DesignType.Fit;

        private FontAttributes currentFontTypeTitle = FontAttributes.None;
        private ColorUI currentColorUI = ColorUI.Blue;

        private StateCollapseBox currentInitialState;

        private Depth currentDepth = Depth.LessMedium;
        private Vivacity currentVivacity = Vivacity.Decrease;

        /// <summary>
        /// Call When State is changed
        /// </summary>
        public event EventHandler ChangeState;

        /// <summary>
        /// Constructor of CollapseBox
        /// </summary>
        public CollapseBox() : base()
        {
            InitialState = StateCollapseBox.Open;
            dataItems = new StackLayout();
            Children.Add(dataItems);
            this.Margin = new Thickness(5, 5, 5, 5);
        }

        private void ChangeState_Tapped(object sender, EventArgs e)
        {
            if (State == StateCollapseBox.Open && stackData != null)
            {
                State = StateCollapseBox.Close;
                stackData.IsVisible = false;
            }
            else
            {
                if (stackData != null)
                {
                    State = StateCollapseBox.Open;
                    stackData.IsVisible = true;
                }
            }

            if (mergeBoxTextTitleReference.barBox != null)
            {
                mergeBoxTextTitleReference.barBox.ChangeState("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", State);
            }

            ChangeState?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetTouch()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += ChangeState_Tapped;
            return touch;
        }



        /// <summary>
        /// Set InitialState
        /// </summary>
        [Bindable(true)]
        public StateCollapseBox InitialState
        {
            get
            {
                return currentInitialState;
            }
            set
            {
                currentInitialState = value;
                InitialStatePropertyChanged();
            }
        }

        private void InitialStatePropertyChanged()
        {
            if (this.stackData != null)
            {
                if(currentInitialState == StateCollapseBox.Open)
                {
                    this.stackData.IsVisible = true;
                }
                else
                {
                    this.stackData.IsVisible = false;
                }

                if (this.mergeBoxTextTitleReference != null && this.mergeBoxTextTitleReference.barBox != null)
                {
                    this.mergeBoxTextTitleReference.barBox.ChangeState("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentInitialState);
                }

                this.State = currentInitialState;
            }
        }

        /// <summary>
        /// Enter the font size title.
        /// </summary>
        public static readonly BindableProperty FontSizeTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontSizeTitle),
            returnType: typeof(double),
            declaringType: typeof(CollapseBox),
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
            CollapseBox collapseBox = (CollapseBox)bindable;
            double copyFontSize = (double)newValue;

            if (collapseBox.mergeBoxTextTitleReference != null && collapseBox.mergeBoxTextTitleReference.barText != null)
            {
                collapseBox.mergeBoxTextTitleReference.barText.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the title textcolor.
        /// </summary>
        public static readonly BindableProperty TextColorTitleProperty = BindableProperty.Create(
            propertyName: nameof(TextColorTitle),
            returnType: typeof(Color),
            declaringType: typeof(CollapseBox),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextColorTitlePropertyChanged);

        /// <summary>
        /// Enter the title textcolor.
        /// </summary>
        public Color TextColorTitle
        {
            get
            {
                return (Color)GetValue(TextColorTitleProperty);
            }
            set
            {
                SetValue(TextColorTitleProperty, value);
            }
        }

        private static void TextColorTitlePropertyChanged(object bindable, object oldValue, object newValue)
        {
            CollapseBox collapseBox = (CollapseBox)bindable;
            Color copyColorText = (Color)newValue;

            if (collapseBox.mergeBoxTextTitleReference != null && collapseBox.mergeBoxTextTitleReference.barText != null)
            {
                collapseBox.mergeBoxTextTitleReference.barText.TextColor = copyColorText;
            }
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontFamilyTitle),
            returnType: typeof(string),
            declaringType: typeof(CollapseBox),
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
            CollapseBox collapseBox = (CollapseBox)bindable;
            string copyFontFamily = (string)newValue;
            if (collapseBox.mergeBoxTextTitleReference != null && collapseBox.mergeBoxTextTitleReference.barText != null)
            {
                collapseBox.mergeBoxTextTitleReference.barText.FontFamily = copyFontFamily;
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
                FontTypeTitlePropertyChanged(this, currentFontTypeTitle, value);
                currentFontTypeTitle = value;
            }
        }

        private static void FontTypeTitlePropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            CollapseBox collapseBox = (CollapseBox)bindable;
            FontAttributes copyFontType = newValue;
            if (collapseBox.mergeBoxTextTitleReference != null && collapseBox.mergeBoxTextTitleReference.barText != null)
            {
                collapseBox.mergeBoxTextTitleReference.barText.FontAttributes = copyFontType;
            }
        }

        /// <summary>
        /// Set if is ColorUI
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
                ColorUIPropertyChanged();
            }
        }

        private void ColorUIPropertyChanged()
        {
            if (mergeBoxTextTitleReference != null && mergeBoxTextTitleReference.barBox != null)
            {
                mergeBoxTextTitleReference.barBox.ChangeColorUI("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI);
            }

            if (sceneReference != null)
            {
                sceneReference.ChangeColorUI("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentColorUI);
            }

            this.State = currentInitialState;
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
                DesignTypePropertyChanged();
            }
        }

        private void DesignTypePropertyChanged()
        {
            if (mergeBoxTextTitleReference != null && mergeBoxTextTitleReference.barBox != null)
            {
                mergeBoxTextTitleReference.barBox.ChangeDesignType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType);
            }

            if (sceneReference != null)
            {
                sceneReference.ChangeDesignType("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType);
            }
        }

        /// <summary>
        /// Enter the width CollapseBox.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double?),
            declaringType: typeof(CollapseBox),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the width CollapseBox.
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
            CollapseBox collapseBox = (CollapseBox)bindable;
            double collapseBoxWidth = (double)newValue;
            if (collapseBox.mergeBoxTextTitleReference != null && collapseBox.mergeBoxTextTitleReference.barBox != null)
            {
                collapseBox.mergeBoxTextTitleReference.barBox.WidthRequest = collapseBoxWidth;
            }

            if(collapseBox.sceneReference != null)
            {
                collapseBox.sceneReference.WidthRequest = collapseBoxWidth;
            }
        }

        /// <summary>
        /// Enter the HeightContent ContentBox.
        /// </summary>
        public static readonly BindableProperty HeightContentProperty = BindableProperty.Create(
            propertyName: nameof(HeightContent),
            returnType: typeof(double?),
            declaringType: typeof(CollapseBox),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightContentPropertyChanged);

        /// <summary>
        /// Enter the HeightContent Content.
        /// </summary>
        public double? HeightContent
        {
            get
            {
                return (double?)GetValue(HeightContentProperty);
            }
            set
            {
                SetValue(HeightContentProperty, value);
            }
        }

        private static void HeightContentPropertyChanged(object bindable, object oldValue, object newValue)
        {
            CollapseBox collapseBox = (CollapseBox)bindable;
            double collapseBoxWidth = (double)newValue;
            if (collapseBox.sceneReference != null)
            {
                collapseBox.sceneReference.WidthRequest = collapseBoxWidth;
            }
        }

        /// <summary>
        /// Title.
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(CollapseBox),
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
            CollapseBox collapseBox = (CollapseBox)bindable;
            string title = (string)newValue;
            if (collapseBox.mergeBoxTextTitleReference != null && collapseBox.mergeBoxTextTitleReference.barText != null)
            {
                collapseBox.mergeBoxTextTitleReference.barText.Text = title;
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
                VivacityPropertyChanged();
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
                VivacityPropertyChanged();
            }
        }

        private void VivacityPropertyChanged()
        {
            if (mergeBoxTextTitleReference != null)
            {
                if (mergeBoxTextTitleReference.barBox != null && mergeBoxTextTitleReference.barText != null)
                {
                    mergeBoxTextTitleReference.barBox.GestureRecognizers.Clear();
                    mergeBoxTextTitleReference.barText.GestureRecognizers.Clear();

                    mergeBoxTextTitleReference.barBox.GestureRecognizers.Add(GetVivacity(currentVivacity));
                    mergeBoxTextTitleReference.barText.GestureRecognizers.Add(GetVivacity(currentVivacity));
                    mergeBoxTextTitleReference.barBox.GestureRecognizers.Add(GetTouch());
                    mergeBoxTextTitleReference.barText.GestureRecognizers.Add(GetTouch());
                }
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

                grid.Children.Add(CreateBar(), 0, 0);
                grid.RowSpacing = 0;

                dataItems.Spacing = 0;

                if (dataItems.Children.Count > 1)
                {
                    this.Children.RemoveAt(this.Children.Count - 1);
                }
                stackData = CreateContent(contentBoxRefererence);
                grid.Children.Add(stackData, 0, 1);

                dataItems.Children.Add(grid);

                if (currentInitialState == StateCollapseBox.Close)
                {
                    State = StateCollapseBox.Close;
                    stackData.IsVisible = false;
                }
                else
                {
                    State = StateCollapseBox.Open;
                    stackData.IsVisible = true;
                }
            }

        }

        private View CreateBar()
        {
            BarBox imageButton = new BarBox("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType, currentColorUI, currentInitialState);

            if (Width.HasValue)
            {
                imageButton.WidthRequest = Width.Value;
                imageButton.HorizontalOptions = LayoutOptions.Center;
            }
            else
            {
                imageButton.Margin = new Thickness(0, 0, 0, 0);
            }

            imageButton.Aspect = Aspect.Fill;
            imageButton.HeightRequest = 30;

            BarText labelText = new BarText();
            labelText.Text = Title;
            labelText.TextColor = TextColorTitle;
            labelText.FontAttributes = currentFontTypeTitle;
            labelText.BackgroundColor = Color.Transparent;
            labelText.FontFamily = FontFamilyTitle;
            labelText.HorizontalOptions = LayoutOptions.Center;
            labelText.FontSize = FontSizeTitle;

            AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

            mergeBoxTextTitleReference = new MergeBoxTextTitle() { barBox = imageButton, barText = labelText };

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

            imageButton.GestureRecognizers.Add(GetVivacity(currentVivacity));
            labelText.GestureRecognizers.Add(GetVivacity(currentVivacity));
            imageButton.GestureRecognizers.Add(GetTouch());
            labelText.GestureRecognizers.Add(GetTouch());

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

        private StackLayout CreateContent(ContentBox item)
        {
            sceneReference = new Scene("__Laavor*+-///qwertyuiiii23444UUUU+=@33%%*&¨VVVMMad13,a,a8d939kl", currentDesignType, currentColorUI);

            if (Width.HasValue)
            {
                sceneReference.WidthRequest = Width.Value;
                sceneReference.HorizontalOptions = LayoutOptions.Center;
            }
            else
            {
                sceneReference.Margin = new Thickness(0, 0, 0, 0);
            }

            sceneReference.Aspect = Aspect.Fill;

            AbsoluteLayout.SetLayoutFlags(item, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(item, new Rectangle(0.05, 0.05, -1, -1));

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

            if(HeightContent.HasValue)
            {
                sceneReference.HeightRequest = HeightContent.Value;
            }

            grid.Children.Add(sceneReference);
            stack.Children.Add(grid);

            grid.ColumnSpacing = 0;
            grid.RowSpacing = 0;

            absolute.Children.Add(stack);
            absolute.Children.Add(item);

            StackLayout returnValue = new StackLayout();
            returnValue.Spacing = 0;
            returnValue.Children.Add(absolute);

            return returnValue;
        }

        private TapGestureRecognizer GetVivacity(Vivacity vivacity)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
            TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
            return touchVivavicity;
        }

        private TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await mergeBoxTextTitleReference.barBox.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                    await mergeBoxTextTitleReference.barText.ScaleTo(GetDepthDecrease(currentDepth), 100, Easing.Linear);
                    await mergeBoxTextTitleReference.barBox.ScaleTo(1, 100, Easing.Linear);
                    await mergeBoxTextTitleReference.barText.ScaleTo(1, 100, Easing.Linear);
                }
                catch { }
            };

            return animationTap;
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

        private TapGestureRecognizer GetVivacityIncrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    await mergeBoxTextTitleReference.barBox.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                    await mergeBoxTextTitleReference.barText.ScaleTo(GetDepthIncrease(currentDepth), 100, Easing.Linear);
                    await mergeBoxTextTitleReference.barBox.ScaleTo(1, 100, Easing.Linear);
                    await mergeBoxTextTitleReference.barText.ScaleTo(1, 100, Easing.Linear);
                }
                catch { }
            };

            return vivacityTap;
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

    }

}
