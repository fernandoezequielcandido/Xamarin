using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace LaavorSwap
{
    /// <summary>
    /// Class SwapLabel
    /// </summary>
    public class SwapLabel : StackLayout
    {
        /// <summary>
        /// Returns current Label.
        /// </summary>
        public string CurrentLabel { get; private set; }

        /// <summary>
        /// Returns current index of label.
        /// </summary>
        public int CurrentIndex { get; private set; }

        private int currentIndex;

        private Frame frameReference;
        private FontAttributes currentFontType;

        LaavorLabelSwap labelReference;

        private List<SwapLabelItem> listItems;

        /// <summary>
        /// Event called when change label
        /// </summary>
        public event EventHandler OnSwap;

        /// <summary>
        /// Constructor of SwapLabel
        /// </summary>
        public SwapLabel() : base()
        {
            InitializeComponents();
            this.Spacing = 0;
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Horizontal;
            InitAll();
        }

        private void InitAll()
        {
            Children.Clear();

            CurrentLabel = "";
            currentIndex = 0;

            frameReference = new Frame();
            labelReference = new LaavorLabelSwap();
            listItems = new List<SwapLabelItem>();

            labelReference.Text = "";

            labelReference.setIndex("wertyafff7777_____784", 0);
            labelReference.FontAttributes = FontAttributes.Bold;
            labelReference.FontSize = FontSize;
            labelReference.TextColor = TextColor;
            labelReference.InputTransparent = false;
            labelReference.HorizontalTextAlignment = TextAlignment.Center;

            labelReference.Margin = new Thickness(-10, -17, -10, -17);

            frameReference.Content = labelReference;
            frameReference.WidthRequest = Width;
            
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Label_Clicked;
            labelReference.GestureRecognizers.Add(tapGestureRecognizer);
            labelReference.IsSelected = true;

            Children.Add(frameReference);
        }

        /// <summary>
        /// Enter the font family.
        /// </summary>
        public static readonly BindableProperty FontFamilyTitleProperty = BindableProperty.Create(
            propertyName: nameof(FontFamily),
            returnType: typeof(string),
            declaringType: typeof(SwapLabel),
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
                return (string)GetValue(FontFamilyTitleProperty);
            }
            set
            {
                SetValue(FontFamilyTitleProperty, value);
            }
        }

        private static void FontFamilyPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabel swapLabel = (SwapLabel)bindable;
            string copyFontFamily = (string)newValue;
            if (swapLabel.labelReference != null)
            {
                swapLabel.labelReference.FontFamily = copyFontFamily;
            }
        }

        /// <summary>
        /// Enter the fonttype title (None, Bold, Italic).
        /// </summary>
        [Bindable(true)]
        public FontAttributes FontType
        {
            get
            {
                return currentFontType;
            }
            set
            {
                FontTypePropertyChanged(this, currentFontType, value);
                currentFontType = value;
            }
        }

        private static void FontTypePropertyChanged(object bindable, FontAttributes oldValue, FontAttributes newValue)
        {
            SwapLabel swapLabel = (SwapLabel)bindable;
            FontAttributes copyFontType = newValue;
            if (swapLabel.labelReference != null)
            {
                swapLabel.labelReference.FontAttributes = copyFontType;
            }
        }

        /// <summary>
        /// Enter the Width.
        /// </summary>
        public new static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(double),
            declaringType: typeof(SwapLabel),
            defaultValue: 140.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: WidthPropertyChanged);

        /// <summary>
        /// Enter the font Width.
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
            SwapLabel swap = (SwapLabel)bindable;
            double copyWidth = (double)newValue;

            if (swap.frameReference != null)
            {
                swap.frameReference.WidthRequest = copyWidth;
                swap.WidthRequest = copyWidth;
            }
        }

        /// <summary>
        /// Enter the font size, represents only one number.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            propertyName: nameof(FontSize),
            returnType: typeof(double),
            declaringType: typeof(SwapLabel),
            defaultValue: 25.0,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: FontSizePropertyChanged);

        /// <summary>
        /// Enter the font size, represents only one number.
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
            SwapLabel swap = (SwapLabel)bindable;
            double copyFontSize = (double)newValue;

            if (swap.labelReference != null)
            {
                swap.labelReference.FontSize = copyFontSize;
            }
        }

        /// <summary>
        /// Enter the label textcolor when use unique color.
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color),
            declaringType: typeof(SwapLabel),
            defaultValue: Color.Gold,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: TextColorPropertyChanged);

        /// <summary>
        /// Enter the label texcolor when use unique color.
        /// </summary>
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        private static void TextColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabel swap = (SwapLabel)bindable;
            Color copyColor = (Color)newValue;

            if (swap.labelReference != null)
            {
                swap.labelReference.TextColor = copyColor;
            }
        }

        /// <summary>
        /// Enter the BorderColor.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
          propertyName: nameof(BorderColor),
          returnType: typeof(Color),
          declaringType: typeof(SwapLabelItem),
          defaultValue: Color.Black,
          defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the BorderColor.
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return (Color)GetValue(BorderColorProperty);
            }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        private static void BorderColorPropertyChanged(object bindable, object oldValue, object newValue)
        {
            SwapLabel swap = (SwapLabel)bindable;
            Color copyColor = (Color)newValue;

            if (swap.frameReference != null)
            {
                swap.frameReference.BorderColor = copyColor;
            }
        }

        /// <summary>
        /// Enter the backgroundcolor.
        /// </summary>
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
            propertyName: nameof(BackgroundColor),
            returnType: typeof(Color),
            declaringType: typeof(SwapLabelItem),
            defaultValue: Color.Transparent,
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Enter the backgroundcolor.
        /// </summary>
        public new Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(SwapLabelItem))
            {
                SwapLabelItem item = (SwapLabelItem)child;
                item.setIndex("wertyafff7777_____784", currentIndex);

                if (currentIndex == 0)
                {
                    labelReference.setIndex("wertyafff7777_____784", currentIndex);
                    labelReference.Text = item.Text;

                    if (item.UseSpecificTextColor)
                    {
                        labelReference.TextColor = item.TextColor;
                    }
                    else
                    {
                        labelReference.TextColor = TextColor;
                    }

                    if (item.UseSpecificBackgroundColor)
                    {
                        labelReference.BackgroundColor = item.BackgroundColor;
                        frameReference.BackgroundColor = item.BackgroundColor;
                    }
                    else
                    {
                        labelReference.BackgroundColor = BackgroundColor;
                        frameReference.BackgroundColor = BackgroundColor;
                    }

                    if (item.UseSpecificBorderColor)
                    {
                        frameReference.BorderColor = item.BorderColor;
                    }
                    else
                    {
                        frameReference.BorderColor = BorderColor;
                    }
                }

                listItems.Add(item);

                currentIndex++;
            }
        }

        private void Label_Clicked(object sender, EventArgs e)
        {
            var itemUser = (LaavorLabelSwap)sender;
            SwapLabelItem item;
            if ((itemUser.Index + 1) >= listItems.Count)
            {
                item = listItems[0];
                labelReference.Text = item.Text;
                labelReference.setIndex("wertyafff7777_____784", 0);
            }
            else
            {
                item = listItems[itemUser.Index + 1];
                labelReference.Text = item.Text;
                labelReference.setIndex("wertyafff7777_____784", (itemUser.Index + 1));
            }

            CurrentIndex = item.Index;

            if (item.UseSpecificTextColor)
            {
                labelReference.TextColor = item.TextColor;
            }
            else
            {
                labelReference.TextColor = TextColor;
            }

            if (item.UseSpecificBackgroundColor)
            {
                labelReference.BackgroundColor = item.BackgroundColor;
                frameReference.BackgroundColor = item.BackgroundColor;
            }
            else
            {
                labelReference.BackgroundColor = BackgroundColor;
                frameReference.BackgroundColor = BackgroundColor;
            }

            if (item.UseSpecificBorderColor)
            {
                frameReference.BorderColor = item.BorderColor;
            }
            else
            {
                frameReference.BorderColor = BorderColor;
            }

            if (OnSwap != null)
            {
                OnSwap?.Invoke(this, e);
            }
        }
    }
}
