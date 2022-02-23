using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// SwitchContent
        /// </summary>
        public class SwitchContent : StackLayout
        {
            public State State { get; private set; }

            /// <summary>
            /// Event call when Switch is changed to on or off
            /// </summary>
            public event EventHandler ChangeState;

            private StackLayout stackTop;
            private Frame frame;
            private StackLayout stack;
            
            private ColorUI colorUIOn = ColorUI.YellowDark;
            private ColorUI colorUIOff = ColorUI.Transparent;
            private ColorUI borderColorOn = ColorUI.Black;
            private ColorUI borderColorOff = ColorUI.GrayLight;
            private ColorUI colorTopOn = ColorUI.Black;
            private ColorUI textColor = ColorUI.White;
            private FontAttributes fontType = FontAttributes.Bold;
            private SwitchContentItem content;

            private Label label;

            private bool isInternal = false;

            private int countContents = 0;

            /// <summary>
            /// Constructor of SwitchContent
            /// </summary>
            public SwitchContent()
            {
                InitAll();
            }

            private void InitAll()
            {
                isInternal = true;

                this.HorizontalOptions = LayoutOptions.Center;

                this.Orientation = StackOrientation.Horizontal;
                this.Spacing = 0;

                State = State.Off;

                stackTop = new StackLayout();

                stackTop.Orientation = StackOrientation.Horizontal;

                frame = new Frame();

                stack = new StackLayout();
                stack.Spacing = 0;

                stack.Orientation = StackOrientation.Vertical;

                label = new Label();
                label.Text = Text;
                label.TextColor = Color.Transparent;
                label.FontFamily = FontFamily;
                label.FontAttributes = fontType;
                label.Margin = new Thickness(5, 0, 0, 0);
                stackTop.Children.Add(label);
                
                frame.WidthRequest = Width;
                frame.HeightRequest = Height;
                
                stackTop.BackgroundColor = Color.Transparent;

                frame.BorderColor = Colors.Get(borderColorOff);
                frame.BackgroundColor = Colors.Get(colorUIOff);
                
                stack.Children.Add(stackTop);
                stack.Children.Add(frame);

                frame.GestureRecognizers.Add(GetTouch());
                
                this.Children.Add(stack);

                isInternal = false;
            }

            private void Touch_Tapped(object sender, EventArgs e)
            {
                ChangeStateColors();
                ChangeState?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetTouch()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += Touch_Tapped;
                return touch;
            }

            /// <summary>
            /// Enter the Height
            /// </summary>
            public new static readonly BindableProperty HeightProperty = BindableProperty.Create(
                propertyName: nameof(Height),
                returnType: typeof(double),
                declaringType: typeof(SwitchContent),
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
                SwitchContent inquirySwitchContent = (SwitchContent)bindable;
                double height = (double)newValue;

                if (inquirySwitchContent.frame != null)
                {
                    inquirySwitchContent.frame.HeightRequest = height;
                }
            }

            /// <summary>
            /// Enter the Width
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double),
                declaringType: typeof(SwitchContent),
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
                SwitchContent inquirySwitchContent = (SwitchContent)bindable;
                double width = (double)newValue;

                if (width != 0)
                {
                    if (inquirySwitchContent.frame != null)
                    {
                        inquirySwitchContent.frame.WidthRequest = width;
                    }
                }
            }

            /// <summary>
            /// Enter the Text when Chosen
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(SwitchContent),
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
                SwitchContent inquirySwitchContent = (SwitchContent)bindable;
                string text = (string)newValue;

                if (inquirySwitchContent.label != null)
                {
                    inquirySwitchContent.label.Text = text;
                }
            }

            /// <summary>
            /// Enter the InquirySwitchContent.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(SwitchContent),
                defaultValue: 20.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the InquirySwitchContent.
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
                SwitchContent inquiry = (SwitchContent)bindable;
                double fontSize = (double)newValue;

                if (inquiry.label != null)
                {
                    inquiry.label.FontSize = fontSize;
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
                if (label != null)
                {
                    label.FontAttributes = fontType;
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(SwitchContent),
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
                SwitchContent inquiry = (SwitchContent)bindable;
                string fontFamily = (string)newValue;

                if (inquiry.label != null)
                {
                    inquiry.label.FontFamily = fontFamily;
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
                if (label != null)
                {
                    if (State == State.On)
                    {
                        label.TextColor = Colors.Get(textColor);
                    }
                    else
                    {
                        label.TextColor = Color.Transparent;
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
                if (State == State.On)
                {
                    if (frame != null)
                    {
                        frame.BackgroundColor = Colors.Get(colorUIOn);
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
                if (State == State.Off)
                {
                    if (frame != null)
                    {
                        frame.BackgroundColor = Colors.Get(colorUIOff);
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
                if (State == State.On)
                {
                    if (frame != null)
                    {
                        frame.BorderColor = Colors.Get(borderColorOn);
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
                if (State == State.Off)
                {
                    if (frame != null)
                    {
                        frame.BorderColor = Colors.Get(borderColorOff);
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
                if (State == State.On)
                {
                    if (stackTop != null)
                    {
                        stackTop.BackgroundColor = Colors.Get(colorTopOn);
                    }
                }
            }

            /// <summary>
            /// Content
            /// </summary>
            [Bindable(true)]
            public SwitchContentItem Content
            {
                get
                {
                    return content;
                }
                set
                {
                    content = value;
                    ContentPropertyChanged();
                }
            }

            private void ContentPropertyChanged()
            {
                StackLayout stackTemp = new StackLayout();
                for (int iItem = 0; iItem < content.Children.Count; iItem++)
                {
                    if (content.Children[iItem].GetType() == typeof(StackLayout))
                    {
                        View item = content.Children[iItem];
                        item.GestureRecognizers.Add(GetTouch());
                        stackTemp.Children.Add(item);
                        AddTouch((StackLayout)item);
                    }
                }

                if (frame != null)
                {
                    frame.Content = stackTemp;
                }
            }

            private void AddTouch(StackLayout stack)
            {
                for (int iItem = 0; iItem < stack.Children.Count; iItem++)
                {
                    if (stack.Children[iItem].GetType() == typeof(StackLayout))
                    {
                        AddTouch((StackLayout)stack.Children[iItem]);
                    }
                    else
                    {
                        View item = stack.Children[iItem];
                        item.GestureRecognizers.Add(GetTouch());
                    }
                }
            }

            private void ChangeStateColors()
            {
                if (frame != null && stackTop != null && label != null)
                {
                    if (State == State.On)
                    {
                        frame.BackgroundColor = Colors.Get(colorUIOff);
                        frame.BorderColor = Colors.Get(borderColorOff);

                        stackTop.BackgroundColor = Color.Transparent;
                        label.TextColor = Color.Transparent;

                        State = State.Off;
                    }
                    else
                    {
                        frame.BackgroundColor = Colors.Get(colorUIOn);
                        frame.BorderColor = Colors.Get(borderColorOn);

                        stackTop.BackgroundColor = Colors.Get(colorTopOn);
                        label.TextColor = Colors.Get(textColor);

                        State = State.On;
                    }
                }
            }

            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);

                if (countContents < 1 && !isInternal && frame != null)
                {
                    if (countContents == 0)
                    {
                        if (child.GetType() == typeof(SwitchContentItem))
                        {
                            StackLayout stack = new StackLayout();
                            SwitchContentItem userContent = (SwitchContentItem)child;
                            for (int iItem = 0; iItem < userContent.Children.Count; iItem++)
                            {
                                View item = userContent.Children[iItem];
                                item.GestureRecognizers.Add(GetTouch());
                                stack.Children.Add(item);

                                if (item.GetType() == typeof(StackLayout))
                                {
                                    AddTouch((StackLayout)item);
                                }
                            }

                            frame.Content = stack;
                        }
                    }

                    countContents++;
                }
            }
        }
    }
}