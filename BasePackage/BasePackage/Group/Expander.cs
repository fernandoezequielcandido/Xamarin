using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Expander
        /// </summary>
        public class Expander: StackLayout
        {
            /// <summary>
            /// Get State (Open or Close)
            /// </summary>
            public StateExpander State { get; private set; }

            /// <summary>
            /// Call When State is changed
            /// </summary>
            public event EventHandler ChangeState;

            private StackLayout dataItems;

            private ExpanderContent groupContent;
            private ExpanderAll groupAll;
            private Frame frame;

            private ColorUI colorUI = ColorUI.Gray;
            private ColorUI contentColor = ColorUI.Transparent;
            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI borderContentColor = ColorUI.Black;
            private DesignType designType = DesignType.Shinning;

            /// <summary>
            /// Constructor of Collapse
            /// </summary>
            public Expander() : base()
            {
                InitialState = StateExpander.Open;
                this.HorizontalOptions = LayoutOptions.Center;
                dataItems = new StackLayout();
                Children.Add(dataItems);
            }

            private TapGestureRecognizer GetTouch()
            {
                var touch = new TapGestureRecognizer();
                touch.Tapped += ChangeState_Tapped;
                return touch;
            }

            private void ChangeState_Tapped(object sender, EventArgs e)
            {
                if (State == StateExpander.Open && frame != null)
                {
                    State = StateExpander.Close;
                    frame.IsVisible = false;
                }
                else
                {
                    if (frame != null)
                    {
                        State = StateExpander.Open;
                        frame.IsVisible = true;
                    }
                }

                if (groupAll.barControl != null)
                {
                    groupAll.barControl.ChangeState("__Laavor*+-", State);
                }

                ChangeState?.Invoke(this, EventArgs.Empty);
            }

            private TapGestureRecognizer GetTouchVivacity(ExpanderControl imageTitle, ExpanderTitle labelText)
            {
                TapGestureRecognizer animationTap = new TapGestureRecognizer();
                animationTap.Tapped += async (sender, e) =>
                {
                    await imageTitle.ScaleTo(0.97, 100, Easing.Linear);
                    await labelText.ScaleTo(0.97, 100, Easing.Linear);
                    await imageTitle.ScaleTo(1, 100, Easing.Linear);
                    await labelText.ScaleTo(1, 100, Easing.Linear);
                };

                return animationTap;
            }

            /// <summary>
            /// Enter the InitialState.
            /// </summary>
            public static readonly BindableProperty InitialStateProperty = BindableProperty.Create(
                propertyName: nameof(StateExpander),
                returnType: typeof(StateExpander),
                declaringType: typeof(Expander),
                defaultValue: StateExpander.Open,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: InitialStatePropertyChanged);

            /// <summary>
            /// Enter the InitialState.
            /// </summary>
            public StateExpander InitialState
            {
                get
                {
                    return (StateExpander)GetValue(InitialStateProperty);
                }
                set
                {
                    SetValue(InitialStateProperty, value);
                }
            }
        
            private static void InitialStatePropertyChanged(object bindable, object oldValue, object newValue)
            {
                Expander expander = (Expander)bindable;
                StateExpander state = (StateExpander)newValue;

                if (expander.frame != null)
                {
                    if (state == StateExpander.Open)
                    {
                        expander.frame.IsVisible = true;
                    }
                    else
                    {
                        expander.frame.IsVisible = false;
                    }
                }
            }

            private TapGestureRecognizer GetTouchVivacity(GroupBoxControl imageButton, AccordionTitle labelText)
            {
                TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
                animationTapImg.Tapped += async (sender, e) =>
                {
                    await imageButton.ScaleTo(0.97, 100, Easing.Linear);
                    await labelText.ScaleTo(0.97, 100, Easing.Linear);
                    await imageButton.ScaleTo(1, 100, Easing.Linear);
                    await labelText.ScaleTo(1, 100, Easing.Linear);
                };

                return animationTapImg;
            }

            /// <summary>
            /// Enter the font size.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(Expander),
                defaultValue: 15.0,
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
                Expander collapse = (Expander)bindable;
                double copyFontSize = (double)newValue;

                if (collapse.groupAll != null && collapse.groupAll.barTitle != null)
                {
                    collapse.groupAll.barTitle.FontSize = copyFontSize;
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
                if (groupAll != null && groupAll.barTitle != null)
                {
                    groupAll.barTitle.TextColor = Colors.Get(textColor);
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(Expander),
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
                Expander collapse = (Expander)bindable;
                string fontFamily = (string)newValue;
                if (collapse.groupAll != null && collapse.groupAll.barTitle != null)
                {
                    collapse.groupAll.barTitle.FontFamily = fontFamily;
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
                if (groupAll != null && groupAll.barTitle != null)
                {
                    groupAll.barTitle.FontAttributes = fontType;
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
                    ColorUIPropertyChanged();
                }
            }

            private void ColorUIPropertyChanged()
            {
                if (groupAll != null && groupAll.barControl != null)
                {
                    groupAll.barControl.ChangeColor("__Laavor*+-", colorUI);
                }
            }

            /// <summary>
            /// Enter the heightBarTitle
            /// </summary>
            public static readonly BindableProperty HeightBarTitleProperty = BindableProperty.Create(
                propertyName: nameof(HeightBarTitle),
                returnType: typeof(double),
                declaringType: typeof(Expander),
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
                Expander collapse = (Expander)bindable;
                double groupHeight = (double)newValue;

                if (collapse.groupAll != null && collapse.groupAll.barTitle != null)
                {
                    collapse.groupAll.barTitle.HeightRequest = groupHeight;
                }
            }

            /// <summary>
            /// Enter the width GroupBox.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double?),
                declaringType: typeof(Expander),
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
                Expander collapse = (Expander)bindable;
                double groupBoxWidth = (double)newValue;
                if (collapse.groupAll != null && collapse.groupAll.barTitle != null)
                {
                    collapse.groupAll.barTitle.WidthRequest = groupBoxWidth;
                }

                if (collapse.frame != null)
                {
                    collapse.frame.WidthRequest = groupBoxWidth;
                }
            }

            /// <summary>
            /// Title.
            /// </summary>
            public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                propertyName: nameof(Title),
                returnType: typeof(string),
                declaringType: typeof(Expander),
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
                Expander collapse = (Expander)bindable;
                string title = (string)newValue;

                if (collapse.groupAll != null && collapse.groupAll.barTitle != null)
                {
                    collapse.groupAll.barTitle.Text = title;
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
                if (groupAll != null && groupAll.barControl != null)
                {
                    groupAll.barControl.ChangeDesignType("__Laavor*+-", designType);
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
                    return contentColor;
                }
                set
                {
                    contentColor = value;
                    ContentColorPropertyChanged();
                }
            }

            private void ContentColorPropertyChanged()
            {
                if (frame != null)
                {
                    frame.BackgroundColor = Colors.Get(contentColor);
                }
            }

            /// <summary>
            /// Set BorderContentColor
            /// </summary>
            [Bindable(true)]
            public ColorUI BorderContentColor
            {
                get
                {
                    return borderContentColor;
                }
                set
                {
                    borderContentColor = value;
                    BorderContentColorPropertyChanged();
                }
            }

            private void BorderContentColorPropertyChanged()
            {
                if (frame != null)
                {
                    frame.BorderColor = Colors.Get(borderContentColor);
                }
            }

            /// <summary>
            /// Internal.
            /// </summary>
            protected override void OnChildAdded(Element child)
            {
                if (child.GetType() == typeof(ExpanderContent))
                {
                    ExpanderContent userItem = (ExpanderContent)child;
                    base.OnChildAdded(child);

                    if (dataItems == null)
                    {
                        dataItems = new StackLayout();
                    }

                    groupContent = new ExpanderContent();

                    if (Width.HasValue)
                    {
                        groupContent.WidthRequest = Width.Value;
                    }

                    if (userItem.Content != null)
                    {
                        groupContent.Content = userItem.Content;
                    }
                    else
                    {
                        for (int index = 0; index < userItem.Children.Count; index++)
                        {
                            groupContent.Children.Add(userItem.Children[index]);
                        }
                    }

                    frame = new Frame()
                    {
                        BorderColor = Colors.Get(BorderContentColor),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        BackgroundColor = Colors.Get(ContentColor),
                        HasShadow = true,
                        Margin = new Thickness(0, -1, 0, 0)
                    };

                    if (Width.HasValue)
                    {
                        frame.WidthRequest = Width.Value - 42;
                    }
                    else
                    {
                        frame.Margin = new Thickness(5, -1, 5, 5);
                        frame.HorizontalOptions = LayoutOptions.FillAndExpand;
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

                    frame.Content = groupContent;

                    grid.Children.Add(CreateBar(), 0, 0);
                    grid.RowSpacing = 0;

                    dataItems.Spacing = 0;

                    if (dataItems.Children.Count > 1)
                    {
                        this.Children.RemoveAt(this.Children.Count - 1);
                    }
                    grid.Children.Add(frame, 0, 1);

                    dataItems.Children.Add(grid);
                }
            }

            private View CreateBar()
            {
                ExpanderControl groupCollapseControl = new ExpanderControl("__Laavor*+-", DesignType, ColorUI, StateExpander.Open);

                if (Width.HasValue)
                {
                    groupCollapseControl.WidthRequest = Width.Value;
                    groupCollapseControl.HorizontalOptions = LayoutOptions.Center;
                }
                else
                {
                    groupCollapseControl.Margin = new Thickness(4, 4, 4, 0);
                }

                groupCollapseControl.HeightRequest = HeightBarTitle;

                ExpanderTitle labelText = new ExpanderTitle();
                labelText.Text = Title;
                labelText.TextColor = Colors.Get(TextColor);
                labelText.FontAttributes = FontType;
                labelText.BackgroundColor = Color.Transparent;
                labelText.FontFamily = FontFamily;
                labelText.HorizontalOptions = LayoutOptions.Center;
                labelText.FontSize = FontSize;

                AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

                groupAll = new ExpanderAll() { barControl = groupCollapseControl, barTitle = labelText };

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

                groupCollapseControl.GestureRecognizers.Add(GetTouchVivacity(groupCollapseControl, labelText));
                labelText.GestureRecognizers.Add(GetTouchVivacity(groupCollapseControl, labelText));
                groupCollapseControl.GestureRecognizers.Add(GetTouch());
                labelText.GestureRecognizers.Add(GetTouch());

                grid.Children.Add(groupCollapseControl);
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
}
