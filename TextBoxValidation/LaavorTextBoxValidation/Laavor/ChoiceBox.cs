using System;
using System.Collections;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorTextBoxValidation
{
    /// <summary>
    /// ChoiceBox Class
    /// </summary>
    public class ChoiceBox : LaavorBaseValidate
    {
        private StackLayout dataItems;
        private ScrollView scrollView;

        /// <summary>
        /// Call when item is chosen
        /// </summary>
        public event EventHandler Chosen;

        /// <summary>
        /// Call when is validate
        /// </summary>
        public event EventHandler Validate;

        private Label labelError;

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

        private Frame frameReference;
        private Grid gridReference;
        private Label labelDisplayText;

        private ArrowImage arrowImageReference;

        private string currentDisplayText = "Choice";
        private double currentFontSizeforDisplayText = 20.0;
        private double currentFontSizeforItems = 20.0;
        private FontAttributes currentFontTypeforItems;

        private ColorUI currentItemsBorderColor = ColorUI.White;
        private ColorUI currentColorUIItems = ColorUI.Black;
        private ColorUI currentTextColorItemsChosen = ColorUI.Black;
        private ColorUI currentTextColorItemsUnChosen = ColorUI.Black;
        private ColorUI currentColorArrow = ColorUI.Black;
        private ColorUI currentColorUIChosen = ColorUI.BlueSky;

        private Frame frameItemsReference;
        private Grid gridItemsReference;
        private Grid gridBaseReference;
        private double currentHeightItems = 70;

        private StackLayout stackItems;
        private StackLayout stackAll;

        private IEnumerable items = null;

        /// <summary>
        /// Constructor of ChoiceBox
        /// </summary>
        public ChoiceBox()
        {
            InitAll();

            if (!CanEmpty)
            {
                IsValid = true;
            }
        }

        private void InitAll()
        {
            IndexChosen = -1;
            ValueChosen = "";
            TextChosen = "";

            this.HorizontalOptions = LayoutOptions.Start;

            stackAll = new StackLayout();
            stackAll.Orientation = StackOrientation.Vertical;
            stackAll.Spacing = 0;

            stackItems = new StackLayout();
            stackItems.Orientation = StackOrientation.Vertical;
            stackItems.Spacing = 0;

            dataItems = new StackLayout();
            dataItems.Spacing = 0;

            scrollView = new ScrollView();
            scrollView.Margin = new Thickness(-15, -15, -15, -15);
            scrollView.Content = dataItems;
            scrollView.FlowDirection = FlowDirection.MatchParent;

            labelDisplayText = new Label();
            labelDisplayText.TextColor = Colors.Get(ColorUI.GrayLight);
            labelDisplayText.FontSize = currentFontSizeforDisplayText;
            labelDisplayText.Text = currentDisplayText;
            labelDisplayText.GestureRecognizers.Add(GetTouch());
            labelDisplayText.HorizontalOptions = LayoutOptions.Start;
            labelDisplayText.VerticalOptions = LayoutOptions.Center;

            arrowImageReference = new ArrowImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorArrow, ArrowDirection.Left);
            arrowImageReference.WidthRequest = WidthArrow;
            arrowImageReference.HeightRequest = HeightArrow;

            gridBaseReference = new Grid();
            gridBaseReference.ColumnSpacing = 0;
            gridBaseReference.RowSpacing = 0;
            gridBaseReference.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridBaseReference.ColumnDefinitions.Add(new ColumnDefinition { Width = Width - WidthArrow });
            gridBaseReference.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            gridBaseReference.Margin = new Thickness(-10, -10, -10, -10);
            Grid.SetRow(labelDisplayText, 0);
            Grid.SetColumn(labelDisplayText, 0);

            gridBaseReference.Children.Add(labelDisplayText);

            Grid.SetRow(arrowImageReference, 0);
            Grid.SetColumn(arrowImageReference, 1);

            gridBaseReference.Children.Add(arrowImageReference);

            frameReference = new Frame();
            frameReference.BorderColor = Colors.Get(BorderColor);
            frameReference.BackgroundColor = Colors.Get(ColorUI);
            frameReference.HasShadow = true;
            frameReference.WidthRequest = Width + 20;
            frameReference.Content = gridBaseReference;
            frameReference.GestureRecognizers.Add(GetTouch());

            gridReference = new Grid()
            {
                ColumnDefinitions =
                    {
                    new ColumnDefinition { Width = Width + 20 }
                    },
                RowDefinitions =
                    {
                    new RowDefinition { Height = GridLength.Auto },
                    }
            };

            gridReference.GestureRecognizers.Add(GetTouch());
            gridReference.Children.Add(frameReference);
            gridReference.RowSpacing = 0;
            gridReference.ColumnSpacing = 0;

            stackAll.Children.Add(gridReference);

            frameItemsReference = new Frame();
            frameItemsReference.BorderColor = Colors.Get(currentItemsBorderColor);
            frameItemsReference.BackgroundColor = Colors.Get(currentColorUIItems);
            frameItemsReference.HasShadow = true;
            frameItemsReference.HeightRequest = currentHeightItems;
            frameItemsReference.WidthRequest = Width + 20;
            frameItemsReference.Content = scrollView;

            gridItemsReference = new Grid
            {
                ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = Width + 20}
                    },
                RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto},
                    }
            };

            gridItemsReference.ColumnSpacing = 0;
            gridItemsReference.RowSpacing = 0;
            gridItemsReference.Children.Add(frameItemsReference);

            stackItems.Spacing = 0;
            stackItems.Children.Add(gridItemsReference);
            stackItems.IsVisible = false;

            stackAll.Children.Add(stackItems);

            Children.Add(stackAll);

            this.Spacing = 0;
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        public void ChangeChosen(string key, int index)
        {
            if (key == "HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122")
            {
                try
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(ChoiceItem))
                        {
                            ChoiceItem choiceItem = (ChoiceItem)dataItems.Children[iItem];

                            if (index != choiceItem.Index)
                            {
                                choiceItem.SetChosen("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", false);
                            }
                            else
                            {
                                if (index > -1)
                                {
                                    IsValid = true;
                                }

                                IndexChosen = index;
                                ValueChosen = choiceItem.Value;
                                TextChosen = choiceItem.Text;
                                labelDisplayText.Text = TextChosen;
                                stackItems.IsVisible = false;
                                arrowImageReference.ChangeDirection("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", ArrowDirection.Left);
                            }
                        }
                    }
                }
                catch { }
            }

            Chosen?.Invoke(this, EventArgs.Empty);
        }

        private void SetColorsInitialState()
        {
            frameReference.BackgroundColor = BackgroundColor;
            frameReference.BorderColor = Colors.Get(BorderColor);

            if (LabelMessageError != null && ChangeMessageLabel)
            {
                LabelMessageError.Text = "";
            }
        }

        private TapGestureRecognizer GetTouch()
        {
            var touch = new TapGestureRecognizer();
            touch.Tapped += Touch_Choice;
            return touch;
        }

        private void Touch_Choice(object sender, EventArgs e)
        {
            bool valueVisible = !stackItems.IsVisible;
            if (valueVisible)
            {
                arrowImageReference.ChangeDirection("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", ArrowDirection.Down);
            }
            else
            {
                arrowImageReference.ChangeDirection("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", ArrowDirection.Left);
            }
            stackItems.IsVisible = valueVisible;
        }

        /// <summary>
        /// Internal
        /// </summary>
        public override void ForceValidate()
        {
            validate(false);
        }

        private void validate(bool callEventValidate = true)
        {
            SetColorsInitialState();
            bool isValid = true;

            if (IndexChosen < 0)
            {
                if (!CanEmpty)
                {
                    isValid = false;

                    if (ChangeMessageLabel && LabelMessageError != null)
                    {
                        LabelMessageError.Text = "Can not be left blank.";
                    }
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
            if (callEventValidate)
            {
                Validate?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Set Color of Arrow
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorArrow
        {
            get
            {
                return currentColorArrow;
            }
            set
            {
                currentColorArrow = value;
                ColorClosePropertyChanged(currentColorArrow);
            }
        }

        private void ColorClosePropertyChanged(ColorUI newValue)
        {
            arrowImageReference.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", newValue);
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
        /// Informs if use the default messages of plugin laavor.
        /// </summary>
        public static readonly BindableProperty ChangeMessageLabelProperty = BindableProperty.Create(
            propertyName: nameof(ChangeMessageLabel),
            returnType: typeof(bool),
            declaringType: typeof(ChoiceBox),
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
        /// Property to report if ChoiceBox is nullable
        /// </summary>
        public static readonly BindableProperty CanEmptyProperty = BindableProperty.Create(
                 propertyName: nameof(CanEmpty),
                 returnType: typeof(bool),
                 declaringType: typeof(ChoiceBox),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: CanEmptyPropertyChanged);

        /// <summary>
        /// Property to report if ChoiceBox is nullable
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

        private static void CanEmptyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceBox choiceBox = (ChoiceBox)bindable;

            if (!choiceBox.CanEmpty && (choiceBox.IndexChosen < 0))
            {
                choiceBox.IsValid = false;
            }
        }

        /// <summary>
        /// Enter the DisplayText.
        /// </summary>
        [Bindable(true)]
        public string DisplayText
        {
            get
            {
                return currentDisplayText;
            }
            set
            {
                currentDisplayText = value;
                DisplayTextPropertyChanged();
            }
        }

        private void DisplayTextPropertyChanged()
        {
            if (labelDisplayText != null)
            {
                labelDisplayText.Text = currentDisplayText;
            }
        }

        /// <summary>
        /// Enter the Font Size for DisplayText.
        /// </summary>
        [Bindable(true)]
        public double FontSizeforDisplayText
        {
            get
            {
                return currentFontSizeforDisplayText;
            }
            set
            {
                currentFontSizeforDisplayText = value;
                FontSizeforDisplayTextPropertyChanged();
            }
        }

        private void FontSizeforDisplayTextPropertyChanged()
        {
            if (labelDisplayText != null)
            {
                labelDisplayText.FontSize = currentFontSizeforDisplayText;
            }
        }

        /// <summary>
        /// Enter the ColorUI.
        /// </summary>
        public static readonly BindableProperty ColorUIProperty = BindableProperty.Create(
         propertyName: nameof(ColorUI),
         returnType: typeof(ColorUI),
         declaringType: typeof(ChoiceBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIPropertyChanged);

        /// <summary>
        /// Enter the ColorUI.
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            ColorUI copyColor = (ColorUI)newValue;

            if (choiceBox.frameReference != null)
            {
                if (!choiceBox.IsValid)
                {
                    choiceBox.frameReference.BackgroundColor = Colors.Get(copyColor);
                }
            }
        }

        /// <summary>
        /// Set ColorUI
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUIItems
        {
            get
            {
                return currentColorUIItems;
            }
            set
            {
                currentColorUIItems = value;
                ColorUIItemsPropertyChanged();

            }
        }

        private void ColorUIItemsPropertyChanged()
        {
            if (frameItemsReference != null)
            {
                frameItemsReference.BackgroundColor = Colors.Get(currentColorUIItems);
            }
        }
        
        /// <summary>
        /// Enter the ColorUIError.
        /// </summary>
        public static readonly BindableProperty ColorUIErrorProperty = BindableProperty.Create(
         propertyName: nameof(ColorUIError),
         returnType: typeof(ColorUI),
         declaringType: typeof(ChoiceBox),
         defaultValue: ColorUI.Transparent,
         defaultBindingMode: BindingMode.OneWay,
         propertyChanged: ColorUIErrorPropertyChanged);

        /// <summary>
        /// Enter the ColorUIError.
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            ColorUI copyColorError = (ColorUI)newValue;

            if (choiceBox.frameReference != null)
            {
                if (!choiceBox.IsValid)
                {
                    choiceBox.frameReference.BackgroundColor = Colors.Get(copyColorError);
                }
            }
        }

        /// <summary>
        /// Enter the Width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(ChoiceBox),
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
                SetValue(WidthProperty, value + 20);
            }
        }

        private static void WidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            double copyWidth = (double)newValue + 20;

            if (choiceBox.frameReference != null)
            {
                choiceBox.frameReference.WidthRequest = copyWidth + 25;
                choiceBox.frameItemsReference.WidthRequest = copyWidth;

                choiceBox.gridReference.ColumnDefinitions[0].Width = copyWidth + 25 - choiceBox.WidthArrow;
                choiceBox.gridItemsReference.ColumnDefinitions[0].Width = copyWidth;

                choiceBox.gridBaseReference.ColumnDefinitions[0].Width = copyWidth - 25 - choiceBox.WidthArrow;
            }
        }

        /// <summary>
        /// Enter the HeightItems.
        /// </summary>
        [Bindable(true)]
        public double HeightItems
        {
            get
            {
                return currentHeightItems;
            }
            set
            {
                currentHeightItems = value;
                HeightItemsPropertyChanged();
            }
        }

        private void HeightItemsPropertyChanged()
        {
            if (frameReference != null)
            {
                frameItemsReference.HeightRequest = currentHeightItems;
            }
        }


        /// <summary>
        /// Enter the Font Size for Items.
        /// </summary>
        [Bindable(true)]
        public double FontSizeforItems
        {
            get
            {
                return currentFontSizeforItems;
            }
            set
            {
                currentFontSizeforItems = value;
                FontSizeforItemsPropertyChanged();
            }
        }

        private void FontSizeforItemsPropertyChanged()
        {
            for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
            {
                if (dataItems.Children[iItem].GetType() == typeof(ChoiceItem))
                {
                    ChoiceItem choiceItem = (ChoiceItem)dataItems.Children[iItem];
                    choiceItem.SetFontSize("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", currentFontSizeforItems);
                }
            }
        }

        /// <summary>
        /// Enter the Font Size for Items.
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontTypeforItems
        {
            get
            {
                return currentFontTypeforItems;
            }
            set
            {
                currentFontTypeforItems = value;
                FontTypeforItemsPropertyChanged();
            }
        }

        private void FontTypeforItemsPropertyChanged()
        {
            for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
            {
                if (dataItems.Children[iItem].GetType() == typeof(ChoiceItem))
                {
                    ChoiceItem choiceItem = (ChoiceItem)dataItems.Children[iItem];
                    choiceItem.SetFontType("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", currentFontTypeforItems);
                }
            }
        }

        /// <summary>
        /// Set TextColor
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
            for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
            {
                if (dataItems.Children[iItem].GetType() == typeof(ChoiceItem))
                {
                    ChoiceItem choiceItem = (ChoiceItem)dataItems.Children[iItem];
                    choiceItem.SetTexColorChosen("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", currentTextColorItemsChosen);
                }
            }
        }

        /// <summary>
        /// Set TextColor
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
            for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
            {
                if (dataItems.Children[iItem].GetType() == typeof(ChoiceItem))
                {
                    ChoiceItem choiceItem = (ChoiceItem)dataItems.Children[iItem];
                    choiceItem.SetTexColorUnChosen("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", currentTextColorItemsUnChosen);
                }
            }
        }

        /// <summary>
        /// Set ColorUIChosen
        /// </summary>
        [Bindable(true)]
        public ColorUI ColorUIChosen
        {
            get
            {
                return currentColorUIChosen;
            }
            set
            {
                currentColorUIChosen = value;
                ColorUIChosenPropertyChanged();

            }
        }

        private void ColorUIChosenPropertyChanged()
        {
            for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
            {
                if (dataItems.Children[iItem].GetType() == typeof(ChoiceItem))
                {
                    ChoiceItem choiceItem = (ChoiceItem)dataItems.Children[iItem];
                    choiceItem.SetColorUIUnChosen("HhaH77*-+/_PP(00000lAAVOR_7eteyreyryr_____7789455122", currentColorUIChosen);
                }
            }
        }

        /// <summary>
        /// Enter the BorderColor shows only when is invalid (Empty)
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColor),
           returnType: typeof(ColorUI),
           declaringType: typeof(ChoiceBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorPropertyChanged);

        /// <summary>
        /// Enter the BorderColor shows only when is invalid (Empty)
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            ColorUI copyBorderColor = (ColorUI)newValue;
            if (choiceBox.IsValid)
            {
                if (choiceBox.frameReference != null)
                {
                   choiceBox.frameReference.BorderColor = Colors.Get(copyBorderColor);
                }
            }
        }

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid (Empty)
        /// </summary>
        public static readonly BindableProperty BorderColorErrorProperty = BindableProperty.Create(
           propertyName: nameof(BorderColorError),
           returnType: typeof(ColorUI),
           declaringType: typeof(ChoiceBox),
           defaultValue: ColorUI.Black,
           defaultBindingMode: BindingMode.OneWay,
           propertyChanged: BorderColorErrorPropertyChanged);

        /// <summary>
        /// Enter the BorderColor Error shows only when is invalid (Empty)
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            ColorUI copyBorderColorError = (ColorUI)newValue;
            if (!choiceBox.IsValid)
            {
                if (choiceBox.frameReference != null)
                {
                    if (!choiceBox.IsValid)
                    {
                        choiceBox.frameReference.BorderColor = Colors.Get(copyBorderColorError);
                    }
                }
            }
        }

        /// <summary>
        /// Enter the Width Close Image.
        /// </summary>
        public static readonly BindableProperty WidthArrowProperty = BindableProperty.Create(
            propertyName: nameof(WidthArrow),
            returnType: typeof(double),
            declaringType: typeof(ChoiceBox),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthArrowPropertyChanged);

        /// <summary>
        /// Enter the WidthArrow Image.
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            double copyWidthClose = (double)newValue;

            if (choiceBox.arrowImageReference != null)
            {
                choiceBox.arrowImageReference.WidthRequest = copyWidthClose;
            }
        }

        /// <summary>
        /// Enter the Height Arrow Image.
        /// </summary>
        public static readonly BindableProperty HeightArrowProperty = BindableProperty.Create(
            propertyName: nameof(HeightArrow),
            returnType: typeof(double),
            declaringType: typeof(ChoiceBox),
            defaultValue: 25.0,
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            double copyHeightChoice = (double)newValue;

            if (choiceBox.arrowImageReference != null)
            {
                choiceBox.arrowImageReference.HeightRequest = copyHeightChoice;
            }
        }

        /// <summary>
        /// Enter ListItems(Data items).
        /// </summary>
        public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
            propertyName: nameof(ListItems),
            returnType: typeof(IEnumerable),
            declaringType: typeof(ChoiceBox),
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            choiceBox.items = (IEnumerable)newValue;
            choiceBox.InitAllBindable();
        }

        /// <summary>
        /// Enter the ValueField, only when using list.
        /// </summary>
        public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
            propertyName: nameof(ValueField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceBox),
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            choiceBox.InitAllBindable();
        }

        /// <summary>
        /// Enter the TextField, only when using list mvvm.
        /// </summary>
        public static readonly BindableProperty TextFieldProperty = BindableProperty.Create(
            propertyName: nameof(TextField),
            returnType: typeof(string),
            declaringType: typeof(ChoiceBox),
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
            ChoiceBox choiceBox = (ChoiceBox)bindable;
            choiceBox.InitAllBindable();
        }

        private void InitAllBindable()
        {
            ChoiceBox choiceBox = this;

            if (choiceBox.items != null && !string.IsNullOrEmpty(choiceBox.TextField) && !string.IsNullOrEmpty(choiceBox.ValueField))
            {
                dataItems.Children.Clear();

                var enumerator = choiceBox.items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object obj = enumerator.Current;
                    string textObj = obj.GetType().GetProperty(choiceBox.TextField).GetValue(obj).ToString();
                    string valueObj = obj.GetType().GetProperty(choiceBox.ValueField).GetValue(obj).ToString();

                    ChoiceItem item = new ChoiceItem("77__htu_KK_Laavor_*-+/.Ezequiel", this, dataItems.Children.Count, textObj, valueObj);
                    dataItems.Children.Add(item);
                }
            }
        }

        /// <summary>
        /// Internal
        /// </summary>
        /// <param name="child"></param>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(ChoiceItem))
            {
                ChoiceItem item = new ChoiceItem("77__htu_KK_Laavor_*-+/.Ezequiel", (ChoiceItem)child, this, dataItems.Children.Count);

                dataItems.Children.Add(item);
            }
        }
    }

}
