using System.ComponentModel;
using Xamarin.Forms;

namespace Laavor
{
    namespace Divider
    {
        /// <summary>
        /// Class Divider
        /// </summary>
        public class Divider : StackLayout
        {
            private DividerControl lineImageRight;
            private DividerControl lineImageLeft;

            private Image imageUser = null;
            private Label labelUser = null;

            private StackLayout stackRight;
            private StackLayout stackCenterRight;
            private StackLayout stackCenterLeft;
            private StackLayout stackLeft;

            private Grid gridLineLeft;
            private Grid gridLineRight;
            private Grid gridLabel;

            private LineSize currentLineSize = LineSize.One;
            private ColorUI colorUI = ColorUI.Black;
            private ColorUI textColor = ColorUI.Black;
            private FontAttributes fontType = FontAttributes.None;
            private ImagePosition imagePosition = ImagePosition.Right;
            private LineSize lineSize = LineSize.One;

            private double? currentImageWidth = null;
            private double? currentImageHeight = null;

            /// <summary>
            /// Constructor of Tabs
            /// </summary>
            public Divider()
            {
                Orientation = StackOrientation.Horizontal;
                InitAll();
            }

            private void InitAll()
            {
                Children.Clear();
                lineImageLeft = new DividerControl("__Laavor*+-", colorUI, currentLineSize);

                lineImageRight = new DividerControl("__Laavor*+-", colorUI, currentLineSize);

                gridLineLeft = new Grid
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

                gridLineLeft.ColumnSpacing = 0;
                gridLineLeft.RowSpacing = 0;
                gridLineLeft.Children.Add(lineImageLeft);

                StartMarginImages(false);

                stackLeft = new StackLayout();
                stackLeft.HorizontalOptions = LayoutOptions.FillAndExpand;
                stackLeft.IsVisible = true;
                stackLeft.Orientation = StackOrientation.Vertical;
                stackLeft.VerticalOptions = LayoutOptions.Center;
                stackLeft.Children.Add(gridLineLeft);

                stackCenterLeft = new StackLayout();
                stackCenterLeft.HorizontalOptions = LayoutOptions.Center;
                stackCenterLeft.IsVisible = false;
                stackCenterLeft.VerticalOptions = LayoutOptions.Center;
                stackCenterLeft.Orientation = StackOrientation.Vertical;

                stackCenterRight = new StackLayout();
                stackCenterRight.HorizontalOptions = LayoutOptions.Center;
                stackCenterRight.IsVisible = false;
                stackCenterRight.VerticalOptions = LayoutOptions.Center;
                stackCenterRight.Orientation = StackOrientation.Vertical;

                gridLineRight = new Grid
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

                gridLineRight.ColumnSpacing = 0;
                gridLineRight.RowSpacing = 0;
                gridLineRight.Children.Add(lineImageRight);


                stackRight = new StackLayout();
                stackRight.HorizontalOptions = LayoutOptions.FillAndExpand;
                stackRight.IsVisible = false;
                stackRight.Orientation = StackOrientation.Vertical;
                stackRight.Children.Add(gridLineRight);
                stackRight.VerticalOptions = LayoutOptions.Center;

                Children.Add(stackLeft);
                Children.Add(stackCenterLeft);
                Children.Add(stackCenterRight);
                Children.Add(stackRight);

                if (!string.IsNullOrEmpty(Image))
                {
                    imageUser = new Image();
                    imageUser.Source = Image;
                    stackCenterLeft.Children.Add(imageUser);
                    stackCenterLeft.IsVisible = true;
                    stackRight.IsVisible = true;
                }


                if (!string.IsNullOrEmpty(Text))
                {
                    labelUser = new Label();
                    labelUser.Text = Text;
                    labelUser.WidthRequest = 100;
                    labelUser.FontAttributes = FontType;
                    labelUser.FontFamily = FontFamily;
                    labelUser.FontSize = FontSize;
                    labelUser.TextColor = Colors.Get(textColor);
                    labelUser.LineBreakMode = LineBreakMode.NoWrap;
                    labelUser.HorizontalTextAlignment = TextAlignment.Center;
                    labelUser.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    stackCenterRight.IsVisible = true;
                    stackRight.IsVisible = true;
                }

            }

            private void StartLabel()
            {
                gridLabel = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Auto }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Star}
                    }
                };

                labelUser = new Label();
                labelUser.LineBreakMode = LineBreakMode.NoWrap;
                gridLabel.Children.Add(labelUser);



                if (ImagePosition == ImagePosition.Left)
                {
                    stackCenterRight.Children.Add(gridLabel);
                }
                else
                {
                    stackCenterLeft.Children.Add(gridLabel);
                }

                labelUser.VerticalOptions = LayoutOptions.Start;
            }

            private void StartMarginImages(bool defaultTwo)
            {
                if (defaultTwo)
                {
                    lineImageLeft.Margin = new Thickness(2, 0, 0, 0);
                    lineImageRight.Margin = new Thickness(0, 0, 2, 0);
                }
                else
                {
                    lineImageLeft.Margin = new Thickness(2, 0, 2, 0);
                    lineImageRight.Margin = new Thickness(0, 0, 0, 0);
                }
            }

            /// <summary>
            /// Enter the Text.
            /// </summary>
            public static readonly BindableProperty TextProperty = BindableProperty.Create(
                propertyName: nameof(Text),
                returnType: typeof(string),
                declaringType: typeof(Divider),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: TextPropertyChanged);

            /// <summary>
            /// Enter the Text.
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
                Divider tabs = (Divider)bindable;
                string copyText = (string)newValue;
                if (tabs.labelUser == null)
                {
                    tabs.StartLabel();
                }

                if (!string.IsNullOrEmpty(copyText))
                {
                    tabs.stackCenterRight.IsVisible = true;
                    tabs.stackRight.IsVisible = true;
                    tabs.stackLeft.IsVisible = true;
                    tabs.StartMarginImages(true);
                }

                tabs.labelUser.Text = copyText;
            }

            /// <summary>
            /// Enter the Image.
            /// </summary>
            public static readonly BindableProperty ImageProperty = BindableProperty.Create(
                propertyName: nameof(Image),
                returnType: typeof(string),
                declaringType: typeof(Divider),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImagePropertyChanged);

            /// <summary>
            /// Enter the Image.
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
                Divider tabs = (Divider)bindable;
                string copyImage = (string)newValue;
                if (tabs.imageUser == null)
                {
                    tabs.imageUser = new Image();

                    if (tabs.ImagePosition == ImagePosition.Left)
                    {
                        tabs.stackCenterLeft.Children.Add(tabs.imageUser);
                    }
                    else
                    {
                        tabs.stackCenterRight.Children.Add(tabs.imageUser);
                    }

                    tabs.imageUser.Aspect = Aspect.Fill;
                    tabs.imageUser.VerticalOptions = LayoutOptions.Center;
                }

                tabs.imageUser.Source = copyImage;

                if (tabs.currentImageWidth != null)
                {
                    tabs.imageUser.WidthRequest = tabs.ImageWidth.Value;
                }

                if (tabs.currentImageHeight != null)
                {
                    tabs.imageUser.HeightRequest = tabs.ImageHeight.Value;
                }

                if (!string.IsNullOrEmpty(copyImage))
                {
                    tabs.stackCenterLeft.IsVisible = true;
                    tabs.stackRight.IsVisible = true;
                    tabs.stackLeft.IsVisible = true;

                    tabs.StartMarginImages(true);
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
                if (lineImageLeft != null)
                {
                    lineImageLeft.ChangeColor("__Laavor*+-", colorUI);
                }

                if (lineImageRight != null)
                {
                    lineImageRight.ChangeColor("__Laavor*+-", colorUI);
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
                if (labelUser == null)
                {
                    StartLabel();
                }

                labelUser.FontAttributes = fontType;
            }

            /// <summary>
            /// Set ImagePosition
            /// </summary>
            [Bindable(true)]
            public ImagePosition ImagePosition
            {
                get
                {
                    return imagePosition;
                }
                set
                {
                    imagePosition = value;
                    ImagePositionPropertyChanged();
                }
            }

            private void ImagePositionPropertyChanged()
            {
                if (labelUser != null || imageUser != null)
                {
                    stackCenterLeft.Children.Clear();
                    stackCenterRight.Children.Clear();
                }

                if (labelUser != null)
                {
                    gridLabel = new Grid
                    {
                        ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = GridLength.Auto }
                        },
                        RowDefinitions =
                        {
                            new RowDefinition { Height =  GridLength.Star}
                        }
                    };
                    gridLabel.Children.Add(labelUser);

                    if (imagePosition == ImagePosition.Left)
                    {
                        stackCenterRight.Children.Add(gridLabel);
                    }
                    else
                    {
                        stackCenterLeft.Children.Add(gridLabel);
                    }
                }

                if (imageUser != null)
                {
                    if (imagePosition == ImagePosition.Left)
                    {
                        stackCenterLeft.Children.Add(imageUser);
                    }
                    else
                    {
                        stackCenterRight.Children.Add(imageUser);
                    }
                }
            }

            /// <summary>
            /// Set LineSize
            /// </summary>
            [Bindable(true)]
            public LineSize LineSize
            {
                get
                {
                    return lineSize;
                }
                set
                {
                    lineSize = value;
                    LineSizePropertyChanged();
                }
            }
        
            private void LineSizePropertyChanged()
            {
                if (lineImageLeft != null)
                {
                    lineImageLeft.ChangeSize("__Laavor*+-", lineSize);
                }

                if (lineImageRight != null)
                {
                    lineImageRight.ChangeSize("__Laavor*+-", lineSize);
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
                if (labelUser == null)
                {
                    StartLabel();
                }

                labelUser.TextColor = Colors.Get(textColor);
            }

            /// <summary>
            /// Enter the ImageHeight.
            /// </summary>
            public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
             propertyName: nameof(ImageHeight),
             returnType: typeof(double?),
             declaringType: typeof(Divider),
             defaultValue: null,
             defaultBindingMode: BindingMode.OneWay,
             propertyChanged: ImageHeightPropertyChanged);

            /// <summary>
            /// Enter the ImageHeight.
            /// </summary>
            public double? ImageHeight
            {
                get
                {
                    return (double)GetValue(ImageHeightProperty);
                }
                set
                {
                    SetValue(ImageHeightProperty, value);
                }
            }

            private static void ImageHeightPropertyChanged(object bindable, object oldValue, object newValue)
            {
                Divider tabs = (Divider)bindable;
                double ImageHeight = (double)newValue;

                if (tabs.imageUser != null)
                {
                    tabs.imageUser.HeightRequest = ImageHeight;
                }
            }

            /// <summary>
            /// Enter the ImageWidth.
            /// </summary>
            public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
             propertyName: nameof(ImageWidth),
             returnType: typeof(double?),
             declaringType: typeof(Divider),
             defaultValue: null,
             defaultBindingMode: BindingMode.OneWay,
             propertyChanged: ImageWidthPropertyChanged);

            /// <summary>
            /// Enter the ImageWidth.
            /// </summary>
            public double? ImageWidth
            {
                get
                {
                    return (double)GetValue(ImageWidthProperty);
                }
                set
                {
                    SetValue(ImageWidthProperty, value);
                }
            }

            private static void ImageWidthPropertyChanged(object bindable, object oldValue, object newValue)
            {
                Divider tabs = (Divider)bindable;
                double ImageWidth = (double)newValue;

                if (tabs.imageUser != null)
                {
                    tabs.imageUser.WidthRequest = ImageWidth;
                }
            }

            /// <summary>
            /// Enter the font family.
            /// </summary>
            public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
                propertyName: nameof(FontFamily),
                returnType: typeof(string),
                declaringType: typeof(Divider),
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
                Divider tabs = (Divider)bindable;
                string copyFontFamily = (string)newValue;
                if (tabs.labelUser == null)
                {
                    tabs.StartLabel();
                }

                tabs.labelUser.FontFamily = copyFontFamily;
            }

            /// <summary>
            /// Enter the font size of text.
            /// </summary>
            public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                propertyName: nameof(FontSize),
                returnType: typeof(double),
                declaringType: typeof(Divider),
                defaultValue: 25.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: FontSizePropertyChanged);

            /// <summary>
            /// Enter the font size of text.
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
                Divider tabs = (Divider)bindable;
                double copyFontSize = (double)newValue;
                if (tabs.labelUser == null)
                {
                    tabs.StartLabel();
                }

                tabs.labelUser.FontSize = copyFontSize;
            }
        }
    }
}
