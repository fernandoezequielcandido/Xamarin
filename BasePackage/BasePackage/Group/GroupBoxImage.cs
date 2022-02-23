﻿using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Group
    {
        /// <summary>
        /// Class GroupBoxImage
        /// </summary>
        public class GroupBoxImage : StackLayout
        {
            private StackLayout dataItems;

            private GroupBoxContent groupContent;
            private GroupBoxImageAll groupAll;
            private Frame frame;

            private ColorUI contentColor = ColorUI.Transparent;
            private FontAttributes fontType = FontAttributes.Bold;
            private ColorUI textColor = ColorUI.Black;
            private ColorUI borderContentColor = ColorUI.Black;

            /// <summary>
            /// Constructor of GroupBoxImage
            /// </summary>
            public GroupBoxImage() : base()
            {
                this.HorizontalOptions = LayoutOptions.Center;
                dataItems = new StackLayout();
                Children.Add(dataItems);
            }

            /// <summary>
            /// Enter the font size.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(GroupBoxImage),
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
                GroupBoxImage groupBox = (GroupBoxImage)bindable;
                double fontSize = (double)newValue;

                if (groupBox.groupAll != null && groupBox.groupAll.barTitle != null)
                {
                    groupBox.groupAll.barTitle.FontSize = fontSize;
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
                declaringType: typeof(GroupBoxImage),
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
                GroupBoxImage groupBox = (GroupBoxImage)bindable;
                string fontFamily = (string)newValue;
                if (groupBox.groupAll != null && groupBox.groupAll.barTitle != null)
                {
                    groupBox.groupAll.barTitle.FontFamily = fontFamily;
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
            /// Enter the heightBarTitle
            /// </summary>
            public static readonly BindableProperty HeightBarTitleProperty = BindableProperty.Create(
                propertyName: nameof(HeightBarTitle),
                returnType: typeof(double),
                declaringType: typeof(GroupBoxImage),
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
                GroupBoxImage groupBoxImage = (GroupBoxImage)bindable;
                double groupHeight = (double)newValue;

                if (groupBoxImage.groupAll != null && groupBoxImage.groupAll.barTitle != null)
                {
                    groupBoxImage.groupAll.barTitle.HeightRequest = groupHeight;
                }
            }

            /// <summary>
            /// Enter the width GroupBox.
            /// </summary>
            public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
                propertyName: nameof(Width),
                returnType: typeof(double?),
                declaringType: typeof(GroupBoxImage),
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
                GroupBoxImage groupBoxImage = (GroupBoxImage)bindable;
                double groupBoxWidth = (double)newValue;
                if (groupBoxImage.groupAll != null && groupBoxImage.groupAll.barTitle != null)
                {
                    groupBoxImage.groupAll.barTitle.WidthRequest = groupBoxWidth;
                }

                if (groupBoxImage.frame != null)
                {
                    groupBoxImage.frame.WidthRequest = groupBoxWidth;
                }
            }

            /// <summary>
            /// Title.
            /// </summary>
            public static readonly BindableProperty TitleProperty = BindableProperty.Create(
                propertyName: nameof(Title),
                returnType: typeof(string),
                declaringType: typeof(GroupBoxImage),
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
                GroupBoxImage groupBoxImage = (GroupBoxImage)bindable;
                string title = (string)newValue;

                if (groupBoxImage.groupAll != null && groupBoxImage.groupAll.barTitle != null)
                {
                    groupBoxImage.groupAll.barTitle.Text = title;
                }
            }

            /// <summary>
            /// Set Image.
            /// </summary>
            public static readonly BindableProperty ImageProperty = BindableProperty.Create(
                propertyName: nameof(Image),
                returnType: typeof(string),
                declaringType: typeof(GroupBoxImage),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImagePropertyChanged);

            /// <summary>
            /// Set Image.
            /// </summary>
            public string Image
            {
                get
                {
                    return (string)GetValue(ImageProperty);
                }
                set
                {
                    SetValue(ImageProperty, value);
                }
            }

            private static void ImagePropertyChanged(object bindable, object oldValue, object newValue)
            {
                GroupBoxImage groupBoxImage = (GroupBoxImage)bindable;
                string imageSource = (string)newValue;
                if (groupBoxImage.groupAll != null && groupBoxImage.groupAll.barImage != null)
                {
                    groupBoxImage.groupAll.barImage.Source = imageSource;
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
                if (child.GetType() == typeof(GroupBoxContent))
                {
                    GroupBoxContent userItem = (GroupBoxContent)child;
                    base.OnChildAdded(child);

                    if(dataItems == null)
                    {
                        dataItems = new StackLayout();
                    }

                    groupContent = new GroupBoxContent();

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
                Image image = new Image();

                if (Width != null)
                {
                    image.WidthRequest = Width.Value;
                }

                image.Source = Image;
                image.HeightRequest = Height;
                image.Aspect = Aspect.Fill;
                image.Margin = new Thickness(2, 0, 2, 0);
                image.HorizontalOptions = LayoutOptions.FillAndExpand;
                image.VerticalOptions = LayoutOptions.FillAndExpand;

                if (Width.HasValue)
                {
                    image.WidthRequest = Width.Value;
                    image.HorizontalOptions = LayoutOptions.Center;
                }
                else
                {
                    image.Margin = new Thickness(4, 4, 4, 0);
                }

                image.HeightRequest = HeightBarTitle;

                GroupBoxTitle labelText = new GroupBoxTitle();
                labelText.Text = Title;
                labelText.TextColor = Colors.Get(TextColor);
                labelText.FontAttributes = FontType;
                labelText.BackgroundColor = Color.Transparent;
                labelText.FontFamily = FontFamily;
                labelText.HorizontalOptions = LayoutOptions.Center;
                labelText.FontSize = FontSize;

                AbsoluteLayout.SetLayoutFlags(labelText, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(labelText, new Rectangle(0.5, 0.5, -1, -1));

                groupAll = new GroupBoxImageAll() { barImage = image, barTitle = labelText };

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

                grid.Children.Add(image);
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