using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Choice
    {
        /// <summary>
        /// Class ChoiceTextShiftMultiple
        /// </summary>
        public class PickTextSwapLot : StackLayout
        {
            /// <summary>
            /// Returns the List f the chosen items.
            /// </summary>
            public List<PickChosenItem> ItemsChosen { get; private set; }

            private List<PickChosenItem> allItemsChosen;

            /// <summary>
            /// Call when text is chosen
            /// </summary>
            public event EventHandler Chosen;

            private ScrollView scroll;

            private const double spaceDecrease = 6.1;

            /// <summary>
            /// Internal use.
            /// </summary>
            private StackLayout dataItems;

            private int currentIndex = 0;

            private IEnumerable items = null;

            private List<PickTextBase> listText;

            private ChoiceOrientation choiceOrientation = ChoiceOrientation.Horizontal;

            private ColorUI colorUIChosen = ColorUI.Yellow;
            private ColorUI colorUIUnChosen = ColorUI.GrayLight;
            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColorChosen = ColorUI.Black;
            private ColorUI textColorUnChosen = ColorUI.Black;
            private ColorUI borderColorChosen = ColorUI.BlueSky;
            private ColorUI borderColorUnChosen = ColorUI.GrayLight;

            private Vivacity vivacity = Vivacity.Decrease;
            private Depth depth = Depth.Medium;
            private VivacitySpeed vivacitySpeed = VivacitySpeed.Normal;

            /// <summary>
            /// Constructor of ChoiceTextShiftMultiple
            /// </summary>
            public PickTextSwapLot()
            {
                ItemsChosen = new List<PickChosenItem>();
                allItemsChosen = new List<PickChosenItem>();

                this.HorizontalOptions = LayoutOptions.Center;

                dataItems = new StackLayout();
                dataItems.Spacing = 0;

                scroll = new ScrollView();
                scroll.Content = dataItems;

                if (ChoiceOrientation == ChoiceOrientation.Horizontal)
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

                listText = new List<PickTextBase>();
            }

            /// <summary>
            /// Internal
            /// </summary>
            private void UpdateData(int index, bool chosen)
            {
                if (ItemsChosen != null)
                {
                    if (chosen)
                    {
                        ItemsChosen.Add(allItemsChosen[index]);
                    }
                    else
                    {
                        ItemsChosen.Remove(allItemsChosen[index]);
                    }
                }
            }

            /// <summary>
            /// Property to inform SpaceBetween Text
            /// </summary>
            public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                     propertyName: nameof(SpaceBetween),
                     returnType: typeof(int),
                     declaringType: typeof(PickTextSwapLot),
                     defaultValue: 0,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: SpaceBetweenPropertyChanged);

            /// <summary>
            /// Property to inform SpaceBetween Text
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                int copySpace = (int)newValue;

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 1; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];

                                if (choiceTextShiftMultiple.ChoiceOrientation == ChoiceOrientation.Horizontal)
                                {
                                    choiceTextBase.Margin = new Thickness((copySpace - spaceDecrease), 0, 0, 0);
                                }
                                else
                                {
                                    choiceTextBase.Margin = new Thickness(0, (copySpace - spaceDecrease), 0, 0);
                                }
                            }
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

            private void SetSpace(PickTextBase choiceTextBase, int space)
            {
                if (ChoiceOrientation == ChoiceOrientation.Horizontal)
                {
                    choiceTextBase.Margin = new Thickness((space - spaceDecrease), 0, 0, 0);

                }
                else
                {
                    choiceTextBase.Margin = new Thickness(0, (space - spaceDecrease), 0, 0);
                }
            }

            /// <summary>
            /// Set ChoiceOrientation
            /// </summary>
            [Bindable(true)]
            public ChoiceOrientation ChoiceOrientation
            {
                get
                {
                    return choiceOrientation;
                }
                set
                {
                    choiceOrientation = value;
                    ChoiceOrientationPropertyChanged();
                }
            }

            private void ChoiceOrientationPropertyChanged()
            {
                if (scroll != null && dataItems != null)
                {
                    if (choiceOrientation == Laavor.ChoiceOrientation.Horizontal)
                    {
                        scroll.Orientation = ScrollOrientation.Horizontal;
                        dataItems.Orientation = StackOrientation.Horizontal;
                        scroll.WidthRequest = Width;
                        scroll.HeightRequest = -1;
                    }
                    else
                    {
                        scroll.Orientation = ScrollOrientation.Vertical;
                        dataItems.Orientation = StackOrientation.Vertical;
                        scroll.HeightRequest = Height;
                        scroll.WidthRequest = -1;
                    }
                }

                ChangeOrientation(choiceOrientation);
            }

            /// <summary>
            /// Initial Chosen by Index
            /// </summary>
            public static readonly BindableProperty InitialIndexChosenProperty = BindableProperty.Create(
                propertyName: nameof(InitialIndexChosen),
                returnType: typeof(int),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: -1,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: InitialIndexChosenPropertyChanged);

            /// <summary>
            /// Initial Chosen by Index
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;

                int copyIndex = (int)newValue;

                if(choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];

                                if (choiceTextBase.Index == copyIndex)
                                {
                                    choiceTextBase.IsChosen = true;
                                    choiceTextBase.TextColor = Colors.Get(choiceTextBase.TextColorChosen);
                                    choiceTextBase.BorderColor = Colors.Get(choiceTextBase.BorderColorChosen);
                                    choiceTextBase.BackgroundColor = Colors.Get(choiceTextBase.ColorUIChosen);

                                    choiceTextShiftMultiple.UpdateData(choiceTextBase.Index, choiceTextBase.IsChosen);

                                    choiceTextBase.Clicked += choiceTextShiftMultiple.ChoiceTextBase_Touched;
                                }
                                else
                                {
                                    choiceTextBase.IsChosen = false;
                                    choiceTextBase.TextColor = Colors.Get(choiceTextBase.TextColorUnChosen);
                                    choiceTextBase.BorderColor = Colors.Get(choiceTextBase.BorderColorUnChosen);
                                    choiceTextBase.BackgroundColor = Colors.Get(choiceTextBase.ColorUIUnChosen);
                                    choiceTextBase.Clicked -= choiceTextShiftMultiple.ChoiceTextBase_Touched;
                                    choiceTextBase.Clicked += choiceTextShiftMultiple.ChoiceTextBase_Touched;
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Initial Chosen by Value
            /// </summary>
            public static readonly BindableProperty InitialValueChosenProperty = BindableProperty.Create(
                propertyName: nameof(InitialValueChosen),
                returnType: typeof(string),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: "_laavor_nothing_2018_77",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: InitialValueChosenPropertyChanged);

            /// <summary>
            /// Initial Chosen by Value
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                string copyValue = newValue.ToString();

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                if (choiceTextBase.Value == copyValue)
                                {
                                    choiceTextBase.IsChosen = true;
                                    choiceTextBase.TextColor = Colors.Get(choiceTextBase.TextColorChosen);
                                    choiceTextBase.BorderColor = Colors.Get(choiceTextBase.BorderColorChosen);
                                    choiceTextBase.BackgroundColor = Colors.Get(choiceTextBase.ColorUIChosen);

                                    choiceTextShiftMultiple.UpdateData(choiceTextBase.Index, choiceTextBase.IsChosen);

                                    choiceTextBase.Clicked += choiceTextShiftMultiple.ChoiceTextBase_Touched;
                                }
                                else
                                {
                                    choiceTextBase.IsChosen = false;
                                    choiceTextBase.TextColor = Colors.Get(choiceTextBase.TextColorUnChosen);
                                    choiceTextBase.BorderColor = Colors.Get(choiceTextBase.BorderColorUnChosen);
                                    choiceTextBase.BackgroundColor = Colors.Get(choiceTextBase.ColorUIUnChosen);
                                    choiceTextBase.Clicked -= choiceTextShiftMultiple.ChoiceTextBase_Touched;
                                    choiceTextBase.Clicked += choiceTextShiftMultiple.ChoiceTextBase_Touched;
                                }
                            }
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
                declaringType: typeof(PickTextSwapLot),
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                double fontSize = (double)newValue;

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                choiceTextBase.FontSize = fontSize;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set TextColorChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorChosen
            {
                get
                {
                    return textColorChosen;
                }
                set
                {
                    textColorChosen = value;
                    TextColorChosenPropertyChanged();
                }
            }

            private void TextColorChosenPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                if (choiceTextBase.IsChosen)
                                {
                                    choiceTextBase.TextColorChosen = textColorChosen;
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set TextColorUnChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorUnChosen
            {
                get
                {
                    return textColorUnChosen;
                }
                set
                {
                    textColorUnChosen = value;
                    TextColorUnChosenPropertyChanged();
                }
            }

            private void TextColorUnChosenPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                if (!choiceTextBase.IsChosen)
                                {
                                    choiceTextBase.TextColorUnChosen = textColorUnChosen;
                                }
                            }
                        }
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
                    return colorUIChosen;
                }
                set
                {
                    colorUIChosen = value;
                    ColorUIChosenPropertyChanged();
                }
            }

            private void ColorUIChosenPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                if (choiceTextBase.IsChosen)
                                {
                                    choiceTextBase.BackgroundColor = Colors.Get(colorUIChosen);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set ColorUIUnChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIUnChosen
            {
                get
                {
                    return colorUIUnChosen;
                }
                set
                {
                    colorUIUnChosen = value;
                    ColorUIUnChosenPropertyChanged();
                }
            }

            private void ColorUIUnChosenPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                if (!choiceTextBase.IsChosen)
                                {
                                    choiceTextBase.BackgroundColor = Colors.Get(colorUIUnChosen);
                                }
                            }
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
                declaringType: typeof(PickTextSwapLot),
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                double copyBorderWidth = (double)newValue;

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                choiceTextBase.BorderWidth = copyBorderWidth;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the CornerRadius.
            /// </summary>
            public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
                propertyName: nameof(CornerRadius),
                returnType: typeof(int),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: 0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: CornerRadiusPropertyChanged);

            /// <summary>
            /// Enter the CornerRadius.
            /// </summary>
            public int CornerRadius
            {
                get
                {
                    return (int)GetValue(CornerRadiusProperty);
                }
                set
                {
                    SetValue(CornerRadiusProperty, value);
                }
            }

            private static void CornerRadiusPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                int corderRadius = (int)newValue;

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                choiceTextBase.CornerRadius = corderRadius;
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set BorderColorChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorChosen
            {
                get
                {
                    return borderColorChosen;
                }
                set
                {
                    borderColorChosen = value;
                    BorderColorChosenPropertyChanged();
                }
            }

            private void BorderColorChosenPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];

                                if (choiceTextBase.IsChosen)
                                {
                                    choiceTextBase.BorderColorChosen = borderColorChosen;
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set BorderColorUnChosen
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorUnChosen
            {
                get
                {
                    return borderColorUnChosen;
                }
                set
                {
                    borderColorUnChosen = value;
                    BorderColorUnChosenPropertyChanged();
                }
            }

            private void BorderColorUnChosenPropertyChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)dataItems.Children[iItem];
                            if (grid.Children[0].GetType() == typeof(PickTextBase))
                            {
                                PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];

                                if (!choiceTextBase.IsChosen)
                                {
                                    choiceTextBase.BorderColorUnChosen = borderColorUnChosen;
                                }
                            }
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
                declaringType: typeof(PickTextSwapLot),
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                string copyFontFamily = (string)newValue;

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(PickTextBase))
                        {
                            if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                            {
                                Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                                if (grid.Children[0].GetType() == typeof(PickTextBase))
                                {
                                    PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                    choiceTextBase.FontFamily = copyFontFamily;
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Enter ListItems(Data items).
            /// </summary>
            public static readonly BindableProperty ListItemsProperty = BindableProperty.Create(
                propertyName: nameof(ListItems),
                returnType: typeof(IEnumerable),
                declaringType: typeof(PickTextSwapLot),
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                choiceTextShiftMultiple.items = (IEnumerable)newValue;
                choiceTextShiftMultiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the ValueField, only when using list.
            /// </summary>
            public static readonly BindableProperty ValueFieldProperty = BindableProperty.Create(
                propertyName: nameof(ValueField),
                returnType: typeof(string),
                declaringType: typeof(PickTextSwapLot),
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                choiceTextShiftMultiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the TextChosenField, only when using list mvvm.
            /// </summary>
            public static readonly BindableProperty TextChosenFieldProperty = BindableProperty.Create(
                propertyName: nameof(TextChosenField),
                returnType: typeof(string),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextChosenFieldPropertyChanged);

            /// <summary>
            /// Enter the TextChosenField, only when using list mvvm.
            /// </summary>
            public string TextChosenField
            {
                get
                {
                    return (string)GetValue(TextChosenFieldProperty);
                }
                set
                {
                    SetValue(TextChosenFieldProperty, value);
                }
            }

            private static void TextChosenFieldPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                choiceTextShiftMultiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the TextUnChosenField, only when using list mvvm.
            /// </summary>
            public static readonly BindableProperty TextUnChosenFieldProperty = BindableProperty.Create(
                propertyName: nameof(TextUnChosenField),
                returnType: typeof(string),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextUnChosenFieldPropertyChanged);

            /// <summary>
            /// Enter the TextUnChosenField, only when using list mvvm.
            /// </summary>
            public string TextUnChosenField
            {
                get
                {
                    return (string)GetValue(TextUnChosenFieldProperty);
                }
                set
                {
                    SetValue(TextUnChosenFieldProperty, value);
                }
            }

            private static void TextUnChosenFieldPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                choiceTextShiftMultiple.InitAllBindable();
            }

            /// <summary>
            /// Enter the Height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: -1.0,
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                double height = (double)newValue;

                if (choiceTextShiftMultiple.scroll != null)
                {
                    if (choiceTextShiftMultiple.ChoiceOrientation == ChoiceOrientation.Vertical)
                    {
                        choiceTextShiftMultiple.scroll.HeightRequest = height;
                    }
                    else
                    {
                        choiceTextShiftMultiple.scroll.WidthRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter Widht.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: -1.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthPropertyChanged);

            /// <summary>
            /// Enter Widht.
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
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                double width = (double)newValue;

                if (choiceTextShiftMultiple.scroll != null)
                {
                    if (choiceTextShiftMultiple.ChoiceOrientation == ChoiceOrientation.Horizontal)
                    {
                        choiceTextShiftMultiple.scroll.WidthRequest = width;
                    }
                    else
                    {
                        choiceTextShiftMultiple.scroll.HeightRequest = -1;
                    }
                }
            }

            /// <summary>
            /// Enter the HeightBox.
            /// </summary>
            public static readonly BindableProperty HeightBoxProperty = BindableProperty.Create(
                propertyName: nameof(HeightBox),
                returnType: typeof(double),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: 55.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: HeightBoxPropertyChanged);

            /// <summary>
            /// Enter the HeightBox.
            /// </summary>
            public double HeightBox
            {
                get
                {
                    return (double)GetValue(HeightBoxProperty);
                }
                set
                {
                    SetValue(HeightBoxProperty, value);
                }
            }

            private static void HeightBoxPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                double height = (double)newValue;

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            grid.RowDefinitions[0].Height = height;
                        }
                    }
                }
            }

            /// <summary>
            /// Enter the WidthtBox.
            /// </summary>
            public static readonly BindableProperty WidthBoxProperty = BindableProperty.Create(
                propertyName: nameof(WidthBox),
                returnType: typeof(double),
                declaringType: typeof(PickTextSwapLot),
                defaultValue: 120.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: WidthBoxPropertyChanged);

            /// <summary>
            /// Enter the WidthBox.
            /// </summary>
            public double WidthBox
            {
                get
                {
                    return (double)GetValue(WidthBoxProperty);
                }
                set
                {
                    SetValue(WidthBoxProperty, value);
                }
            }

            private static void WidthBoxPropertyChanged(object bindable, object oldValue, object newValue)
            {
                PickTextSwapLot choiceTextShiftMultiple = (PickTextSwapLot)bindable;
                double width = (double)newValue;

                if (choiceTextShiftMultiple.dataItems != null)
                {
                    for (int iItem = 0; iItem < choiceTextShiftMultiple.dataItems.Children.Count; iItem++)
                    {
                        if (choiceTextShiftMultiple.dataItems.Children[iItem].GetType() == typeof(Grid))
                        {
                            Grid grid = (Grid)choiceTextShiftMultiple.dataItems.Children[iItem];
                            grid.ColumnDefinitions[0].Width = width;
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
                    return vivacity;
                }
                set
                {
                    vivacity = value;
                    VivacityChanged();
                }
            }

            private void VivacityChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(PickTextBase))
                        {
                            if (dataItems.Children[iItem].GetType() == typeof(Grid))
                            {
                                Grid grid = (Grid)dataItems.Children[iItem];
                                if (grid.Children[0].GetType() == typeof(PickTextBase))
                                {
                                    PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                    SetVivacity(choiceTextBase);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set Depth
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
                    DepthChanged();
                }
            }

            protected void DepthChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(PickTextBase))
                        {
                            if (dataItems.Children[iItem].GetType() == typeof(Grid))
                            {
                                Grid grid = (Grid)dataItems.Children[iItem];
                                if (grid.Children[0].GetType() == typeof(PickTextBase))
                                {
                                    PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                    SetVivacity(choiceTextBase);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Set VivacitySpeed
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
                    VivacitySpeedChanged();
                }
            }

            private void VivacitySpeedChanged()
            {
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(PickTextBase))
                        {
                            if (dataItems.Children[iItem].GetType() == typeof(Grid))
                            {
                                Grid grid = (Grid)dataItems.Children[iItem];
                                if (grid.Children[0].GetType() == typeof(PickTextBase))
                                {
                                    PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                    SetVivacity(choiceTextBase);
                                }
                            }
                        }
                    }
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
                if (dataItems != null)
                {
                    for (int iItem = 0; iItem < dataItems.Children.Count; iItem++)
                    {
                        if (dataItems.Children[iItem].GetType() == typeof(PickTextBase))
                        {
                            if (dataItems.Children[iItem].GetType() == typeof(Grid))
                            {
                                Grid grid = (Grid)dataItems.Children[iItem];
                                if (grid.Children[0].GetType() == typeof(PickTextBase))
                                {
                                    PickTextBase choiceTextBase = (PickTextBase)grid.Children[0];
                                    choiceTextBase.FontAttributes = fontType;
                                }
                            }
                        }
                    }
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
                    PickTextBase choiceTextBase = (PickTextBase)sender;
                    await choiceTextBase.ScaleTo(GetDepthDecrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await choiceTextBase.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
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
                    PickTextBase choiceTextBase = (PickTextBase)sender;
                    await choiceTextBase.ScaleTo(GetDepthIncrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await choiceTextBase.ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
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
                    PickTextBase choiceTextBase = (PickTextBase)sender;
                    await choiceTextBase.TranslateTo(0, GetDepthJump(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await choiceTextBase.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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
                    PickTextBase choiceTextBase = (PickTextBase)sender;
                    await choiceTextBase.RotateTo(GetDepthRotation(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await choiceTextBase.RotateTo(0, (uint)VivacitySpeed, Easing.Linear);
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
                    PickTextBase choiceTextBase = (PickTextBase)sender;
                    await choiceTextBase.TranslateTo(0, GetDepthDown(Depth), (uint)VivacitySpeed, Easing.Linear);
                    await choiceTextBase.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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

            private async void VivacityLeft(object sender, EventArgs e)
            {
                try
                {
                    PickTextBase choiceTextBase = (PickTextBase)sender;
                    await choiceTextBase.TranslateTo(GetDepthLeft(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                    await choiceTextBase.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                }
                catch { }
            }

            private double GetDepthLeft(Depth depth)
            {
                if (depth == Depth.LessMedium)
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
            /// Use to create VivacityRight is Auto Call
            /// </summary>
            public async void VivacityRight(object sender, EventArgs e)
            {
                try
                {
                    PickTextBase choiceTextBase = (PickTextBase)sender;
                    await choiceTextBase.TranslateTo(GetDepthRight(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                    await choiceTextBase.TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
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

            private void InitAllBindable()
            {
                PickTextSwapLot choiceTextShiftMultiple = this;

                if (dataItems != null)
                {
                    dataItems = new StackLayout();
                }

                if (choiceTextShiftMultiple.items != null && !string.IsNullOrEmpty(choiceTextShiftMultiple.TextChosenField) && !string.IsNullOrEmpty(choiceTextShiftMultiple.TextChosenField) && !string.IsNullOrEmpty(choiceTextShiftMultiple.ValueField))
                {
                    dataItems.Children.Clear();
                    listText = new List<PickTextBase>();

                    var enumerator = choiceTextShiftMultiple.ListItems.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        object obj = enumerator.Current;
                        string textUnchosenObj = obj.GetType().GetProperty(choiceTextShiftMultiple.TextUnChosenField).GetValue(obj).ToString();
                        string textChosenObj = obj.GetType().GetProperty(choiceTextShiftMultiple.TextChosenField).GetValue(obj).ToString();
                        string valueObj = obj.GetType().GetProperty(choiceTextShiftMultiple.ValueField).GetValue(obj).ToString();

                        PickTextBase item = new PickTextBase("__Laavor*+-", currentIndex, valueObj);
                        item.Text = textUnchosenObj;
                        item.TextUnChosen = textUnchosenObj;
                        item.TextChosen = textChosenObj;
                        item.TextColorChosen = choiceTextShiftMultiple.TextColorChosen;
                        item.TextColorUnChosen = choiceTextShiftMultiple.TextColorUnChosen;
                        item.ColorUIChosen = choiceTextShiftMultiple.ColorUIChosen;
                        item.ColorUIUnChosen = choiceTextShiftMultiple.ColorUIUnChosen;
                        item.BorderWidth = choiceTextShiftMultiple.BorderWidth;
                        item.CornerRadius = choiceTextShiftMultiple.CornerRadius;
                        item.BorderColorChosen = choiceTextShiftMultiple.BorderColorChosen;
                        item.BorderColorUnChosen = choiceTextShiftMultiple.BorderColorUnChosen;
                        item.FontSize = choiceTextShiftMultiple.FontSize;
                        item.FontType = choiceTextShiftMultiple.FontType;
                        item.FontFamily = choiceTextShiftMultiple.FontFamily;
                        item.Height = choiceTextShiftMultiple.HeightBox;
                        item.Width = choiceTextShiftMultiple.WidthBox;

                        SetVivacity(item);

                        item.Value = valueObj;

                        if ((InitialIndexChosen == -1 && InitialValueChosen == "_laavor_nothing_2018_77") || (InitialIndexChosen != currentIndex && InitialValueChosen != valueObj))
                        {
                            item.Clicked += ChoiceTextBase_Touched;
                        }
                        else if (InitialIndexChosen == currentIndex || InitialValueChosen == valueObj)
                        {
                            item.IsChosen = true;
                            item.TextColor = Colors.Get(TextColorChosen);
                            item.BorderColor = Colors.Get(BorderColorChosen);
                            item.BackgroundColor = Colors.Get(ColorUIChosen);

                            UpdateData(item.Index, item.IsChosen);
                        }

                        PickChosenItem chosen = new PickChosenItem(currentIndex, item.Text, item.Value);
                        allItemsChosen.Insert(currentIndex, chosen);

                        if (currentIndex > 0)
                        {
                            SetSpace(item, SpaceBetween);
                        }

                        currentIndex++;

                        Grid grid = new Grid
                        {
                            ColumnDefinitions =
                            {
                                new ColumnDefinition { Width = WidthBox }
                            },
                            RowDefinitions =
                            {
                                new RowDefinition { Height =  HeightBox}
                            }
                        };

                        grid.ColumnSpacing = 0;
                        grid.RowSpacing = 0;

                        grid.Children.Add(item);
                        dataItems.Children.Add(grid);
                    }
                }
            }

            /// <summary>
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if(dataItems == null)
                {
                    dataItems = new StackLayout();
                }

                if (child.GetType() == typeof(PickTextSwapItem))
                {
                    PickTextSwapItem choiceTextShiftItem = (PickTextSwapItem)child;
                    PickTextBase choiceTextBase = new PickTextBase("__Laavor*+-", currentIndex, choiceTextShiftItem.Value);

                    choiceTextBase.Text = choiceTextShiftItem.TextUnChosen;

                    choiceTextBase.TextUnChosen = choiceTextShiftItem.TextUnChosen;
                    choiceTextBase.TextChosen = choiceTextShiftItem.TextChosen;

                    choiceTextBase.TextColorChosen = this.TextColorChosen;
                    choiceTextBase.TextColorUnChosen = this.TextColorUnChosen;
                    choiceTextBase.ColorUIChosen = this.ColorUIChosen;
                    choiceTextBase.ColorUIUnChosen = this.ColorUIUnChosen;
                    choiceTextBase.BorderWidth = this.BorderWidth;
                    choiceTextBase.CornerRadius = this.CornerRadius;
                    choiceTextBase.BorderColorChosen = this.BorderColorChosen;
                    choiceTextBase.BorderColorUnChosen = this.BorderColorUnChosen;
                    choiceTextBase.Height = this.HeightBox;
                    choiceTextBase.Width = this.WidthBox;

                    SetVivacity(choiceTextBase);

                    choiceTextBase.FontSize = this.FontSize;
                    choiceTextBase.FontType = this.FontType;
                    choiceTextBase.FontFamily = this.FontFamily;

                    choiceTextBase.Value = choiceTextShiftItem.Value;

                    if (InitialIndexChosen == -1 || InitialIndexChosen != currentIndex)
                    {
                        choiceTextBase.Clicked += ChoiceTextBase_Touched;
                    }
                    else if (InitialIndexChosen == currentIndex || choiceTextBase.Value == InitialValueChosen)
                    {
                        choiceTextBase.TextColor = Colors.Get(TextColorChosen);
                        choiceTextBase.BorderColor = Colors.Get(BorderColorChosen);
                        choiceTextBase.BackgroundColor = Colors.Get(ColorUIChosen);

                        UpdateData(choiceTextBase.Index, choiceTextBase.IsChosen);

                        choiceTextBase.IsChosen = true;
                    }

                    PickChosenItem chosen = new PickChosenItem(currentIndex, choiceTextBase.Text, choiceTextBase.Value);
                    allItemsChosen.Insert(currentIndex, chosen);

                    if (currentIndex > 0)
                    {
                        SetSpace(choiceTextBase, SpaceBetween);
                    }

                    currentIndex++;

                    Grid grid = new Grid
                    {
                        ColumnDefinitions =
                            {
                                new ColumnDefinition { Width = WidthBox }
                            },
                        RowDefinitions =
                            {
                                new RowDefinition { Height =  HeightBox}
                            }
                    };

                    grid.ColumnSpacing = 0;
                    grid.RowSpacing = 0;

                    grid.Children.Add(choiceTextBase);
                    dataItems.Children.Add(grid);
                }
            }

            private void ChoiceTextBase_Touched(object sender, EventArgs e)
            {
                PickTextBase choiceTextBase = (PickTextBase)sender;

                if (!choiceTextBase.IsChosen)
                {
                    choiceTextBase.IsChosen = true;
                    choiceTextBase.TextColor = Colors.Get(choiceTextBase.TextColorChosen);
                    choiceTextBase.BorderColor = Colors.Get(choiceTextBase.BorderColorChosen);
                    choiceTextBase.BackgroundColor = Colors.Get(choiceTextBase.ColorUIChosen);
                    choiceTextBase.Text = choiceTextBase.TextChosen;
                }
                else
                {
                    choiceTextBase.IsChosen = false;
                    choiceTextBase.TextColor = Colors.Get(choiceTextBase.TextColorUnChosen);
                    choiceTextBase.BorderColor = Colors.Get(choiceTextBase.BorderColorUnChosen);
                    choiceTextBase.BackgroundColor = Colors.Get(choiceTextBase.ColorUIUnChosen);
                    choiceTextBase.Text = choiceTextBase.TextUnChosen;
                }

                UpdateData(choiceTextBase.Index, choiceTextBase.IsChosen);

                Chosen?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

