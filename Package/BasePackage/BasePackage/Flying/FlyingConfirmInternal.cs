using Laavor.Buttons;
using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Flying
    {
        /// <summary>
        /// Class FlyingConfirmInternal
        /// </summary>
        public class FlyingConfirmInternal : StackLayout
        {
            private Frame frame;
            private StackLayout dataItems;
            private Grid grid;

            private ButtonBox buttonConfirm;
            private ButtonBox buttonCancel;
            private Label labelQuestion;

            private FlyingConfirm flyingConfirm;

            /// <summary>
            /// Informs if is flying (Open)
            /// </summary>
            public bool IsFlying { get; private set; }

            private bool isInternal;

            private ColorUI borderColor = ColorUI.Black;
            private ColorUI borderColorButtons = ColorUI.Black;
            private ColorUI colorUI = ColorUI.White;
            private ColorUI colorUIButtons = ColorUI.BlueSky;
            private FontAttributes fontTypeQuestion = FontAttributes.None;
            private FontAttributes fontTypeButtons = FontAttributes.None;
            private ColorUI textColorQuestion = ColorUI.Black;
            private ColorUI textColorButtons = ColorUI.Black;

            /// <summary>
            /// Constructor of FlyingConfirmInternal
            /// </summary>
            public FlyingConfirmInternal()
            {
                InitAll();
            }

            private void InitAll()
            {
                Children.Clear();

                IsFlying = false;

                this.Orientation = StackOrientation.Vertical;
                this.Spacing = 0;
                this.WidthRequest = Width;
                this.HorizontalOptions = LayoutOptions.CenterAndExpand;
                this.VerticalOptions = LayoutOptions.CenterAndExpand;

                dataItems = new StackLayout();
                dataItems.Margin = new Thickness(-10, -10, -10, -10);
                dataItems.VerticalOptions = LayoutOptions.Center;
                dataItems.FlowDirection = FlowDirection.MatchParent;
                dataItems.Spacing = 0;
                dataItems.WidthRequest = Width;

                frame = new Frame();
                frame.BorderColor = Colors.Get(borderColor);
                frame.VerticalOptions = LayoutOptions.Center;
                frame.BackgroundColor = Colors.Get(colorUI);
                frame.HasShadow = true;

                frame.Content = dataItems;
                frame.Margin = new Thickness(8, 8, 8, 8);

                AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(this, new Rectangle(0.5, 0.5, 1.0, 1.0));

                IsVisible = false;

                isInternal = true;

                grid = new Grid
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

                grid.RowSpacing = 0;
                grid.HorizontalOptions = LayoutOptions.Center;

                Grid.SetRow(frame, 0);
                Grid.SetColumn(frame, 0);
                grid.Children.Add(frame);

                Children.Add(grid);
                isInternal = false;

                StackLayout stack = new StackLayout();
                labelQuestion = new Label();
                labelQuestion.Text = TextQuestion;
                labelQuestion.HorizontalOptions = LayoutOptions.Center;
                labelQuestion.FontSize = FontSizeQuestion;
                labelQuestion.Margin = new Thickness(2, 0, 5, 5);
                labelQuestion.TextColor = Colors.Get(textColorQuestion);
                labelQuestion.LineBreakMode = LineBreakMode.WordWrap;
                stack.Children.Add(labelQuestion);
                dataItems.Orientation = StackOrientation.Vertical;
                dataItems.HorizontalOptions = LayoutOptions.Center;
                dataItems.Children.Add(stack);

                StackLayout stackButtons = new StackLayout();
                buttonConfirm = new ButtonBox();
                buttonConfirm.Text = TextConfirm;
                buttonConfirm.FontSize = FontSizeButtons;
                buttonConfirm.Touched += ButtonConfirm_Touched;

                buttonCancel = new ButtonBox();
                buttonCancel.Text = TextCancel;
                buttonCancel.FontSize = FontSizeButtons;
                buttonCancel.Touched += ButtonCancel_Touched;

                stackButtons.Orientation = StackOrientation.Horizontal;
                stackButtons.HorizontalOptions = LayoutOptions.Center;
                stackButtons.Children.Add(buttonConfirm);
                stackButtons.Children.Add(buttonCancel);
                stackButtons.VerticalOptions = LayoutOptions.End;
                stackButtons.Margin = new Thickness(0, 0, 0, 0);

                dataItems.Children.Add(stackButtons);
            }

            public void AddItem(string key, FlyingConfirm confirm)
            {
                if(key == "__Laavor*+-")
                {
                    flyingConfirm = confirm;
                }
            }

            private void ButtonCancel_Touched(object sender, EventArgs e)
            {
                IsFlying = false;
                IsVisible = false;
                flyingConfirm.Cancel("__Laavor*+-");
            }

            private void ButtonConfirm_Touched(object sender, EventArgs e)
            {
                IsFlying = false;
                IsVisible = false;
                flyingConfirm.Confirm("__Laavor*+-");
            }

            /// <summary>
            /// Show Flying Confirm
            /// </summary>
            public void Show()
            {
                IsFlying = true;
                IsVisible = true;
            }

            /// <summary>
            /// Show Flying Confirm
            /// </summary>
            public void Hide()
            {
                IsFlying = false;
                IsVisible = false;
            }

            /// <summary>
            /// Enter the font size of text Question.
            /// </summary>
            public static readonly BindableProperty FontSizeQuestionProperty = BindableProperty.Create(
                propertyName: nameof(FontSizeQuestion),
                returnType: typeof(double),
                declaringType: typeof(FlyingConfirmInternal),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizeQuestionPropertyChanged);

            /// <summary>
            /// Enter the font size of text Question.
            /// </summary>
            public double FontSizeQuestion
            {
                get
                {
                    return (double)GetValue(FontSizeQuestionProperty);
                }
                set
                {
                    SetValue(FontSizeQuestionProperty, value);
                }
            }

            private static void FontSizeQuestionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                double fontSize = (double)newValue;

                if (flyingConfirmInternal.labelQuestion != null)
                {
                    flyingConfirmInternal.labelQuestion.FontSize = fontSize;
                }
            }

            /// <summary>
            /// Enter the font size of text Buttons.
            /// </summary>
            public static readonly BindableProperty FontSizeButtonsProperty = BindableProperty.Create(
                propertyName: nameof(FontSizeButtons),
                returnType: typeof(double),
                declaringType: typeof(FlyingConfirmInternal),
                defaultValue: 15.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizeButtonsPropertyChanged);

            /// <summary>
            /// Enter the font size of text Buttons.
            /// </summary>
            public double FontSizeButtons
            {
                get
                {
                    return (double)GetValue(FontSizeButtonsProperty);
                }
                set
                {
                    SetValue(FontSizeButtonsProperty, value);
                }
            }

            private static void FontSizeButtonsPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                double fontSize = (double)newValue;

                if (flyingConfirmInternal.buttonConfirm != null)
                {
                    flyingConfirmInternal.buttonConfirm.FontSize = fontSize;
                }

                if (flyingConfirmInternal.buttonCancel != null)
                {
                    flyingConfirmInternal.buttonCancel.FontSize = fontSize;
                }
            }

            /// <summary>
            /// Set FontTypeQuestion
            /// </summary>
            [Bindable(true)]
            public FontAttributes FontTypeQuestion
            {
                get
                {
                    return fontTypeQuestion;
                }
                set
                {
                    fontTypeQuestion = value;
                    FontTypeQuestionPropertyChanged();
                }
            }

            private void FontTypeQuestionPropertyChanged()
            {
                if (labelQuestion!= null)
                {
                    labelQuestion.FontAttributes = FontTypeQuestion;
                }
            }

            /// <summary>
            /// Set FontTypeButtons
            /// </summary>
            [Bindable(true)]
            public FontAttributes FontTypeButtons
            {
                get
                {
                    return fontTypeButtons;
                }
                set
                {
                    fontTypeButtons = value;
                    FontTypeButtonsPropertyChanged();
                }
            }

            private void FontTypeButtonsPropertyChanged()
            {
                if (buttonConfirm != null)
                {
                    buttonConfirm.FontType = fontTypeButtons;
                }

                if (buttonCancel != null)
                {
                    buttonCancel.FontType = fontTypeButtons;
                }
            }

            /// <summary>
            /// Enter the FontFamily Question.
            /// </summary>
            public static readonly BindableProperty FontFamilyQuestionProperty = BindableProperty.Create(
                propertyName: nameof(FontFamilyQuestion),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirmInternal),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontFamilyQuestionPropertyChanged);

            /// <summary>
            /// Enter the FontFamily Question.
            /// </summary>
            public string FontFamilyQuestion
            {
                get
                {
                    return (string)GetValue(FontFamilyQuestionProperty);
                }
                set
                {
                    SetValue(FontFamilyQuestionProperty, value);
                }
            }

            private static void FontFamilyQuestionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                string fontFamily = (string)newValue;

                if (flyingConfirmInternal.labelQuestion != null)
                {
                    flyingConfirmInternal.labelQuestion.FontFamily = fontFamily;
                }
            }

            /// <summary>
            /// Enter the FontFamily Buttons.
            /// </summary>
            public static readonly BindableProperty FontFamilyButtonsProperty = BindableProperty.Create(
                propertyName: nameof(FontFamilyButtons),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirmInternal),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontFamilyButtonsPropertyChanged);

            /// <summary>
            /// Enter the FontFamily Buttons.
            /// </summary>
            public string FontFamilyButtons
            {
                get
                {
                    return (string)GetValue(FontFamilyButtonsProperty);
                }
                set
                {
                    SetValue(FontFamilyButtonsProperty, value);
                }
            }

            private static void FontFamilyButtonsPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                string fontFamily = (string)newValue;

                if (flyingConfirmInternal.buttonConfirm != null)
                {
                    flyingConfirmInternal.buttonConfirm.FontFamily = fontFamily;
                }

                if (flyingConfirmInternal.buttonCancel != null)
                {
                    flyingConfirmInternal.buttonCancel.FontFamily = fontFamily;
                }
            }

            /// <summary>
            /// Set ColorUIButtons
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIButtons
            {
                get
                {
                    return colorUIButtons;
                }
                set
                {
                    colorUIButtons = value;
                    ColorUIButtonsPropertyChanged();
                }
            }

            private void ColorUIButtonsPropertyChanged()
            {
                if (buttonConfirm != null)
                {
                    buttonConfirm.ColorUI = colorUIButtons;
                }

                if (buttonCancel != null)
                {
                    buttonCancel.ColorUI = colorUIButtons;
                }
            }

            /// <summary>
            /// Set TextColorQuestion
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorQuestion
            {
                get
                {
                    return textColorQuestion;
                }
                set
                {
                    colorUIButtons = value;
                    ColorUIButtonsPropertyChanged();
                }
            }

            /// <summary>
            /// Set TextColorButtons
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColorButtons
            {
                get
                {
                    return textColorButtons;
                }
                set
                {
                    textColorButtons = value;
                    TextColorButtonsPropertyChanged();
                }
            }

            private void TextColorButtonsPropertyChanged()
            {
                if (buttonConfirm != null)
                {
                    buttonConfirm.TextColor = textColorButtons;
                }

                if (buttonCancel != null)
                {
                    buttonCancel.TextColor = textColorButtons;
                }
            }

            /// <summary>
            /// Set BorderColorButtons
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorButtons
            {
                get
                {
                    return borderColorButtons;
                }
                set
                {
                    borderColorButtons = value;
                    BorderColorButtonsPropertyChanged();
                }
            }

            private void BorderColorButtonsPropertyChanged()
            {
                if (buttonConfirm != null)
                {
                    buttonConfirm.BorderColor = borderColorButtons;
                }

                if (buttonCancel != null)
                {
                    buttonCancel.BorderColor = borderColorButtons;
                }
            }

            /// <summary>
            /// Set ColorUI
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUI
            {
                get
                {
                    return colorUI;
                }
                set
                {
                    colorUI = value;
                    ColorUIPropertyChanged(value);
                }
            }

            private void ColorUIPropertyChanged(ColorUI newValue)
            {
                if (frame != null)
                {
                    frame.BackgroundColor = Colors.Get(newValue);
                }
            }

            /// <summary>
            /// Set BorderColor
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColor
            {
                get
                {
                    return borderColor;
                }
                set
                {
                    borderColor = value;
                    BorderColorPropertyChanged();
                }
            }

            private void BorderColorPropertyChanged()
            {
                if (frame != null)
                {
                    frame.BorderColor = Colors.Get(borderColor);
                }
            }
           
            /// <summary>
            /// Enter the Text Confirm
            /// </summary>
            public static readonly BindableProperty TextConfirmProperty = BindableProperty.Create(
                propertyName: nameof(TextConfirm),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirmInternal),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextConfirmPropertyChanged);

            /// <summary>
            /// Enter the Text Confirm
            /// </summary>
            public string TextConfirm
            {
                get
                {
                    return (string)GetValue(TextConfirmProperty);
                }
                set
                {
                    SetValue(TextConfirmProperty, value);
                }
            }

            private static void TextConfirmPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                string text = (string)newValue;

                if (flyingConfirmInternal.buttonConfirm != null)
                {
                    flyingConfirmInternal.buttonConfirm.Text = text;
                }
            }

            /// <summary>
            /// Enter the text Cancel
            /// </summary>
            public static readonly BindableProperty TextCancelProperty = BindableProperty.Create(
                propertyName: nameof(TextCancel),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirmInternal),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextCancelPropertyChanged);

            /// <summary>
            /// Enter the Text Cancel
            /// </summary>
            public string TextCancel
            {
                get
                {
                    return (string)GetValue(TextCancelProperty);
                }
                set
                {
                    SetValue(TextCancelProperty, value);
                }
            }

            private static void TextCancelPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                string text = (string)newValue;

                if (flyingConfirmInternal.buttonCancel != null)
                {
                    flyingConfirmInternal.buttonCancel.Text = text;
                }
            }

            /// <summary>
            /// Enter the text Question
            /// </summary>
            public static readonly BindableProperty TextQuestionProperty = BindableProperty.Create(
                propertyName: nameof(TextQuestion),
                returnType: typeof(string),
                declaringType: typeof(FlyingConfirmInternal),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextQuestionPropertyChanged);

            /// <summary>
            /// Enter the text Question
            /// </summary>
            public string TextQuestion
            {
                get
                {
                    return (string)GetValue(TextQuestionProperty);
                }
                set
                {
                    SetValue(TextQuestionProperty, value);
                }
            }

            private static void TextQuestionPropertyChanged(object bindable, object oldValue, object newValue)
            {
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                string text = (string)newValue;

                if (flyingConfirmInternal.labelQuestion != null)
                {
                    flyingConfirmInternal.labelQuestion.Text = text;
                }
            }

            /// <summary>
            /// Enter the Width.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(FlyingConfirm),
                defaultValue: 250.0,
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
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                double width = (double)newValue;

                if (flyingConfirmInternal.frame != null)
                {
                    //flyingConfirmInternal.frame.WidthRequest = width;
                    //flyingConfirmInternal.grid.WidthRequest = width;
                }
            }

            /// <summary>
            /// Enter the Height.
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(FlyingConfirm),
                defaultValue: 60.0,
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
                FlyingConfirmInternal flyingConfirmInternal = (FlyingConfirmInternal)bindable;
                double height = (double)newValue;

                if (flyingConfirmInternal.frame != null)
                {
                    //flyingConfirmInternal.frame.HeightRequest = height;
                    //flyingConfirmInternal.grid.HeightRequest = height;
                }
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="child"></param>
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (!isInternal)
                {
                    if (child.GetType() == typeof(FlyingContent))
                    {
                        StackLayout userContentBox = (StackLayout)child;
                        for (int iS = 0; iS < userContentBox.Children.Count; iS++)
                        {
                            dataItems.Children.Add(userContentBox.Children[iS]);
                        }
                    }
                    else if (child.GetType() == typeof(FlyingBackContent))
                    {

                    }
                    else
                    {
                        Children.RemoveAt(Children.Count - 1);
                    }
                }
            }
        }
    }
}
