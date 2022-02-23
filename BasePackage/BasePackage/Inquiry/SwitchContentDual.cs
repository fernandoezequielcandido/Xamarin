using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// SwitchContentDual
        /// </summary>
        public class SwitchContentDual : StackLayout
        {
            /// <summary>
            /// Call when Switch Content Dual is Chosen
            /// </summary>
            public event EventHandler Chosen;

            public Side SideChosen { get; private set; }

            public string ValueChosen { get; private set; }

            private StackLayout stackTopLeft;
            private StackLayout stackTopRight;
            private Frame frameLeft;
            private Frame frameRight;
            private Grid grid;
            private StackLayout stackLeft;
            private StackLayout stackRight;

            private ColorUI colorUIOn = ColorUI.YellowDark;
            private ColorUI colorUIOff = ColorUI.Transparent;
            private ColorUI borderColorOn = ColorUI.Black;
            private ColorUI borderColorOff = ColorUI.GrayLight;
            private ColorUI colorTopOn = ColorUI.Black;
            private ColorUI textColor = ColorUI.White;
            private FontAttributes fontType = FontAttributes.Bold;
            private SwitchContentItem contentLeft;
            private SwitchContentItem contentRight;

            private Label labelLeft;
            private Label labelRight;

            private bool isInternal = false;

            private int countContents = 0;

            /// <summary>
            /// Constructor of SwitchContentDual
            /// </summary>
            public SwitchContentDual()
            {
                InitAll();
            }

            private void InitAll()
            {
                isInternal = true;

                this.HorizontalOptions = LayoutOptions.Center;

                this.Orientation = StackOrientation.Horizontal;
                this.Spacing = 0;

                SideChosen = Side.Left;

                stackTopLeft = new StackLayout();
                stackTopRight = new StackLayout();

                stackTopLeft.Orientation = StackOrientation.Horizontal;
                stackTopRight.Orientation = StackOrientation.Horizontal;

                frameLeft = new Frame();
                frameRight = new Frame();

                stackLeft = new StackLayout();
                stackLeft.Spacing = 0;

                stackRight = new StackLayout();
                stackRight.Spacing = 0;

                stackLeft.Orientation = StackOrientation.Vertical;
                stackRight.Orientation = StackOrientation.Vertical;

                labelLeft = new Label();
                labelLeft.Text = Text;
                labelLeft.TextColor = Colors.Get(textColor);
                labelLeft.FontFamily = FontFamily;
                labelLeft.FontAttributes = fontType;
                labelLeft.Margin = new Thickness(5, 0, 0, 0);
                stackTopLeft.Children.Add(labelLeft);

                labelRight = new Label();
                labelRight.Text = Text;
                labelRight.TextColor = Color.Transparent;
                labelRight.FontFamily = FontFamily;
                labelRight.FontAttributes = fontType;
                labelRight.Margin = new Thickness(5, 0, 0, 0);
                stackTopRight.Children.Add(labelRight);

                stackTopRight.HeightRequest = 5;

                frameLeft.WidthRequest = (Width/2);
                frameRight.WidthRequest = (Width/2);

                frameLeft.HeightRequest = Height;
                frameRight.HeightRequest = Height;

                stackTopLeft.BackgroundColor = Colors.Get(colorTopOn);

                stackTopRight.BackgroundColor = Color.Transparent;

                frameLeft.BorderColor = Colors.Get(borderColorOn);
                frameLeft.BackgroundColor = Colors.Get(colorUIOn);

                frameRight.BorderColor = Colors.Get(borderColorOff);
                frameRight.BackgroundColor = Colors.Get(colorUIOff);


                grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Star },
                        new ColumnDefinition { Width = GridLength.Star }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto},
                        new RowDefinition { Height =  GridLength.Auto}
                    }
                };

                Grid.SetRow(stackTopLeft, 0);
                Grid.SetColumn(stackTopLeft, 0);
                grid.Children.Add(stackTopLeft);

                Grid.SetRow(stackTopRight, 0);
                Grid.SetColumn(stackTopRight, 1);
                grid.Children.Add(stackTopRight);

                Grid.SetRow(frameLeft, 1);
                Grid.SetColumn(frameLeft, 0);
                grid.Children.Add(frameLeft);

                Grid.SetRow(frameRight, 1);
                Grid.SetColumn(frameRight, 1);
                grid.Children.Add(frameRight);

                grid.ColumnSpacing = 0;
                grid.RowSpacing = 0;
                
                //stackLeft.Children.Add(stackTopLeft);
                //stackLeft.Children.Add(frameLeft);

                //stackRight.Children.Add(stackTopRight);
                //stackRight.Children.Add(frameRight);

                //this.Children.Add(stackLeft);
                //this.Children.Add(stackRight);

                this.Children.Add(grid);

                frameLeft.GestureRecognizers.Add(GetTouchLeft());
                frameRight.GestureRecognizers.Add(GetTouchRight());

                isInternal = false;
            }

            private void Touch_TappedLeft(object sender, EventArgs e)
            {
                ChosenItem(Side.Left);
                Chosen?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetTouchLeft()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Touch_TappedLeft;
                return touch;
            }

            private void Touch_TappedRight(object sender, EventArgs e)
            {
                ChosenItem(Side.Right);
                Chosen?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetTouchRight()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Touch_TappedRight;
                return touch;
            }

            /// <summary>
            /// Enter the Height
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(SwitchContentDual),
                defaultValue: 200.0,
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
                SwitchContentDual inquirySwitchContentDual = (SwitchContentDual)bindable;
                double height = (double)newValue;

                if (inquirySwitchContentDual.frameLeft != null)
                {
                    inquirySwitchContentDual.frameLeft.HeightRequest = height;
                }

                if (inquirySwitchContentDual.frameRight != null)
                {
                    inquirySwitchContentDual.frameRight.HeightRequest = height;
                }
            }

            /// <summary>
            /// Enter the Width
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(SwitchContentDual),
                defaultValue: 200.0,
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
                SwitchContentDual inquirySwitchContentDual = (SwitchContentDual)bindable;
                double width = (double)newValue;

                if (width != 0)
                {
                    if (inquirySwitchContentDual.frameLeft != null)
                    {
                        inquirySwitchContentDual.frameLeft.WidthRequest = (width/2);
                    }

                    if (inquirySwitchContentDual.frameRight != null)
                    {

                        inquirySwitchContentDual.frameRight.WidthRequest = (width/2);
                    }
                }
            }

            /// <summary>
            /// Enter the Text when Chosen
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(SwitchContentDual),
                defaultValue: "Chosen",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextPropertyChanged);

            /// <summary>
            /// Enter the Text when Chosen
            /// </summary>
            public string Text
            {
                get
                {
                    return (string)GetValue(TextProperty);
                }
                set
                {
                    SetValue(TextProperty, value);
                }
            }

            private static void TextPropertyChanged(object bindable, object oldValue, object newValue)
            {
                SwitchContentDual inquirySwitchContentDual = (SwitchContentDual)bindable;
                string text = (string)newValue;

                if (inquirySwitchContentDual.labelLeft != null)
                {
                    inquirySwitchContentDual.labelLeft.Text = text;
                }

                if (inquirySwitchContentDual.labelRight != null)
                {
                    inquirySwitchContentDual.labelRight.Text = text;
                }
            }

            /// <summary>
            /// Enter the InquirySwitchContentDual.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(SwitchContentDual),
                defaultValue: 20.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the InquirySwitchContentDual.
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
                SwitchContentDual inquiry = (SwitchContentDual)bindable;
                double fontSize = (double)newValue;

                if (inquiry.labelLeft != null)
                {
                    inquiry.labelLeft.FontSize = fontSize;
                }

                if (inquiry.labelRight != null)
                {
                    inquiry.labelRight.FontSize = fontSize;
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
                if (labelLeft != null)
                {
                    labelLeft.FontAttributes = fontType;
                }

                if (labelRight != null)
                {
                    labelRight.FontAttributes = fontType;
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(SwitchContentDual),
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
                SwitchContentDual inquiry = (SwitchContentDual)bindable;
                string fontFamily = (string)newValue;

                if (inquiry.labelLeft != null)
                {
                    inquiry.labelLeft.FontFamily = fontFamily;
                }

                if (inquiry.labelRight != null)
                {
                    inquiry.labelRight.FontFamily = fontFamily;
                }
            }

            /// <summary>
            /// Set TextColor
            /// </summary>
            [Bindable(true)]
            public ColorUI TextColor
            {
                get
                {
                    return textColor;
                }
                set
                {
                    textColor = value;
                    TextColorPropertyChanged();
                }
            }

            private void TextColorPropertyChanged()
            {
                if (labelLeft != null)
                {
                    if (SideChosen == Side.Left)
                    {
                        labelLeft.TextColor = Colors.Get(textColor);
                    }
                    else
                    {
                        labelLeft.TextColor = Color.Transparent;
                    }
                }

                if (labelRight != null)
                {
                    if (SideChosen == Side.Right)
                    {
                        labelRight.TextColor = Colors.Get(textColor);
                    }
                    else
                    {
                        labelRight.TextColor = Color.Transparent;
                    }
                }
            }

            /// <summary>
            /// Set ColorUIOn
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIOn
            {
                get
                {
                    return colorUIOn;
                }
                set
                {
                    colorUIOn = value;
                    ColorUIOnPropertyChanged();
                }
            }

            private void ColorUIOnPropertyChanged()
            {
                if (SideChosen == Side.Left)
                {
                    if (frameLeft != null)
                    {
                        frameLeft.BackgroundColor = Colors.Get(colorUIOn);
                    }

                    if (frameRight != null)
                    {
                        frameRight.BackgroundColor = Colors.Get(colorUIOff);
                    }
                }
                else
                {
                    if (frameRight != null)
                    {
                        frameRight.BackgroundColor = Colors.Get(colorUIOn);
                    }

                    if (frameLeft != null)
                    {
                        frameLeft.BackgroundColor = Colors.Get(colorUIOff);
                    }
                }
            }

            /// <summary>
            /// Set ColorUIOff
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorUIOff
            {
                get
                {
                    return colorUIOff;
                }
                set
                {
                    colorUIOff = value;
                    ColorUIOffPropertyChanged();
                }
            }

            private void ColorUIOffPropertyChanged()
            {
                if (SideChosen == Side.Left)
                {
                    if (frameLeft != null)
                    {
                        frameLeft.BackgroundColor = Colors.Get(colorUIOn);
                    }

                    if (frameRight != null)
                    {
                        frameRight.BackgroundColor = Colors.Get(colorUIOff);
                    }
                }
                else
                {
                    if (frameRight != null)
                    {
                        frameRight.BackgroundColor = Colors.Get(colorUIOn);
                    }

                    if (frameLeft != null)
                    {
                        frameLeft.BackgroundColor = Colors.Get(colorUIOff);
                    }
                }
            }

            /// <summary>
            /// Set BorderColorOn
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorOn
            {
                get
                {
                    return borderColorOn;
                }
                set
                {
                    borderColorOn = value;
                    BorderColorOnPropertyChanged();
                }
            }

            private void BorderColorOnPropertyChanged()
            {
                if (SideChosen == Side.Left)
                {
                    if (frameLeft != null)
                    {
                        frameLeft.BorderColor = Colors.Get(borderColorOn);
                    }

                    if (frameRight != null)
                    {
                        frameRight.BorderColor = Colors.Get(borderColorOff);
                    }
                }
                else
                {
                    if (frameRight != null)
                    {
                        frameRight.BorderColor = Colors.Get(borderColorOn);
                    }

                    if (frameLeft != null)
                    {
                        frameLeft.BorderColor = Colors.Get(borderColorOff);
                    }
                }
            }

            /// <summary>
            /// Set BorderColorOff
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderColorOff
            {
                get
                {
                    return borderColorOff;
                }
                set
                {
                    borderColorOff = value;
                    BorderColorOffPropertyChanged();
                }
            }

            private void BorderColorOffPropertyChanged()
            {
                if (SideChosen == Side.Left)
                {
                    if (frameLeft != null)
                    {
                        frameLeft.BorderColor = Colors.Get(borderColorOn);
                    }

                    if (frameRight != null)
                    {
                        frameRight.BorderColor = Colors.Get(borderColorOff);
                    }
                }
                else
                {
                    if (frameRight != null)
                    {
                        frameRight.BorderColor = Colors.Get(borderColorOn);
                    }

                    if (frameLeft != null)
                    {
                        frameLeft.BorderColor = Colors.Get(borderColorOff);
                    }
                }
            }

            /// <summary>
            /// ColorTopOn
            /// </summary>
            [Bindable(true)]
            public ColorUI ColorTopOn
            {
                get
                {
                    return colorTopOn;
                }
                set
                {
                    colorTopOn = value;
                    ColorTopOnPropertyChanged();
                }
            }

            private void ColorTopOnPropertyChanged()
            {
                if (SideChosen == Side.Left)
                {
                    if (stackTopLeft != null)
                    {
                        stackTopLeft.BackgroundColor = Colors.Get(colorTopOn);
                    }

                    if (stackTopRight != null)
                    {
                        stackTopRight.BackgroundColor = Color.Transparent;
                    }
                }
                else
                {
                    if (stackTopRight != null)
                    {
                        stackTopRight.BackgroundColor = Colors.Get(colorTopOn);
                    }

                    if (stackTopLeft != null)
                    {
                        stackTopLeft.BackgroundColor = Color.Transparent;
                    }
                }
            }

            /// <summary>
            /// ContentLeft
            /// </summary>
            [Bindable(true)]
            public SwitchContentItem ContentLeft
            {
                get
                {
                    return contentLeft;
                }
                set
                {
                    contentLeft = value;
                    ContentLeftPropertyChanged();
                }
            }

            private void ContentLeftPropertyChanged()
            {
                StackLayout leftTemp = new StackLayout();
                for (int iItem = 0; iItem < contentLeft.Children.Count; iItem++)
                {
                    if (contentLeft.Children[iItem].GetType() == typeof(StackLayout))
                    {
                        View item = contentLeft.Children[iItem];
                        item.GestureRecognizers.Add(GetTouchLeft());
                        leftTemp.Children.Add(item);
                        AddTouchLeft((StackLayout)item);
                    }
                }

                frameLeft.Content = leftTemp;
            }

            private void AddTouchLeft(StackLayout stack)
            {
                for (int iItem = 0; iItem < stack.Children.Count; iItem++)
                {
                    if (stack.Children[iItem].GetType() == typeof(StackLayout))
                    {
                        AddTouchLeft((StackLayout)stack.Children[iItem]);
                    }
                    else
                    {
                        View item = stack.Children[iItem];
                        item.GestureRecognizers.Add(GetTouchLeft());
                    }
                }
            }

            /// <summary>
            /// ContentRight
            /// </summary>
            [Bindable(true)]
            public SwitchContentItem ContentRight
            {
                get
                {
                    return contentRight;
                }
                set
                {
                    contentRight = value;
                    ContentRightPropertyChanged();
                }
            }

            private void ContentRightPropertyChanged()
            {
                StackLayout rightTemp = new StackLayout();
                for (int iItem = 0; iItem < contentRight.Children.Count; iItem++)
                {
                    if (contentRight.Children[iItem].GetType() == typeof(StackLayout))
                    {
                        View item = contentRight.Children[iItem];
                        item.GestureRecognizers.Add(GetTouchRight());
                        rightTemp.Children.Add(item);
                        AddTouchRight((StackLayout)item);
                    }
                }

                frameRight.Content = rightTemp;
            }

            private void AddTouchRight(StackLayout stack)
            {
                for (int iItem = 0; iItem < stack.Children.Count; iItem++)
                {
                    if (stack.Children[iItem].GetType() == typeof(StackLayout))
                    {
                        AddTouchRight((StackLayout)stack.Children[iItem]);
                    }
                    else
                    {
                        View item = stack.Children[iItem];
                        item.GestureRecognizers.Add(GetTouchRight());
                    }
                }
            }

            private void ChosenItem(Side side)
            {
                if (frameLeft != null && frameRight != null && stackTopRight != null && stackTopLeft != null && labelLeft != null && labelRight != null)
                {
                    if (side == Side.Left)
                    {
                        frameLeft.BackgroundColor = Colors.Get(colorUIOn);
                        frameLeft.BorderColor = Colors.Get(borderColorOn);

                        frameRight.BackgroundColor = Colors.Get(colorUIOff);
                        frameRight.BorderColor = Colors.Get(borderColorOff);

                        stackTopRight.BackgroundColor = Color.Transparent;
                        stackTopLeft.BackgroundColor = Colors.Get(colorTopOn);

                        labelRight.TextColor = Color.Transparent;
                        labelLeft.TextColor = Colors.Get(textColor);
                    }
                    else
                    {
                        frameLeft.BackgroundColor = Colors.Get(colorUIOff);
                        frameLeft.BorderColor = Colors.Get(borderColorOff);

                        frameRight.BackgroundColor = Colors.Get(colorUIOn);
                        frameRight.BorderColor = Colors.Get(borderColorOn);

                        stackTopRight.BackgroundColor = Colors.Get(colorTopOn);
                        stackTopLeft.BackgroundColor = Color.Transparent;

                        labelRight.TextColor = Colors.Get(textColor);
                        labelLeft.TextColor = Color.Transparent;
                    }
                }

                SideChosen = side;
                ValueChosen = "";
            }

            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (countContents < 2 && !isInternal && frameLeft != null && frameRight != null)
                {
                    if (countContents == 0)
                    {
                        if (child.GetType() == typeof(SwitchContentItem))
                        {
                            StackLayout leftTemp = new StackLayout();
                            SwitchContentItem userContent = (SwitchContentItem)child;
                            for (int iItem = 0; iItem < userContent.Children.Count; iItem++)
                            {
                                View item = userContent.Children[iItem];
                                item.GestureRecognizers.Add(GetTouchLeft());
                                leftTemp.Children.Add(item);

                                if (item.GetType() == typeof(StackLayout))
                                {
                                    AddTouchLeft((StackLayout)item);
                                }
                            }

                            frameLeft.Content = leftTemp;
                        }
                    }
                    else
                    {
                        if (child.GetType() == typeof(SwitchContentItem))
                        {
                            StackLayout rightTemp = new StackLayout();
                            SwitchContentItem userContent = (SwitchContentItem)child;
                            for (int iItem = 0; iItem < userContent.Children.Count; iItem++)
                            {
                                View item = userContent.Children[iItem];
                                item.GestureRecognizers.Add(GetTouchLeft());
                                rightTemp.Children.Add(item);

                                if (item.GetType() == typeof(StackLayout))
                                {
                                    AddTouchRight((StackLayout)item);
                                }
                            }

                            frameRight.Content = rightTemp;
                        }
                    }

                    countContents++;
                }
            }
        }
    }
}
