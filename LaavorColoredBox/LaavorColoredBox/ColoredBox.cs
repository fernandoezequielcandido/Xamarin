using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorColoredBox
{
    /// <summary>
    /// Class ColoredBox
    /// </summary>
    public class ColoredBox : StackLayout
    {
        private StackLayout dataItems;
        private ScrollView scrollItems;

        /// <summary>
        /// Return the LastTouchedIndex
        /// </summary>
        public int LastTouchedIndex { get; private set; }

        /// <summary>
        /// Event call when button is Touched
        /// </summary>
        public event EventHandler Touched;
        private LineImage currentLastLine = null;

        private ColorUI currentColorUI = ColorUI.Red;

        private List<ColoredBoxImage> listBoxImage = new List<ColoredBoxImage>();
        private List<ColoredBoxContent> listBoxContent = new List<ColoredBoxContent>();

        /// <summary>
        /// Constructor of ColoredBox
        /// </summary>
        public ColoredBox()
        {
            dataItems = new StackLayout();
            dataItems.Spacing = 0;
            scrollItems = new ScrollView();
            scrollItems.Content = dataItems;
            Children.Add(scrollItems);

            this.Margin = new Thickness(0, 2, 0, 2);
        }

        /// <summary>
        /// Clear All Items
        /// </summary>
        public void Clear()
        {
            dataItems.Children.Clear();
      
            listBoxImage.Clear();
            listBoxContent.Clear();
        }
                     
        private void Touch_Tapped(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(TappedEventArgs))
            {
                this.LastTouchedIndex = (int)(e as TappedEventArgs).Parameter;
            }
            Touched?.Invoke(this, EventArgs.Empty);
        }

        private TapGestureRecognizer GetClick(int index)
        {
            var touched = new TapGestureRecognizer();
            touched.CommandParameter = index;
            touched.Tapped += Touch_Tapped;
            return touched;
        }

        private TapGestureRecognizer GetClickAnimation(Image img)
        {
            TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
            animationTapImg.Tapped += async (sender, e) =>
            {
                await img.ScaleTo(0.97, 70, Easing.Linear);
                await img.FadeTo(0.7, 10, Easing.SpringOut);
                await img.FadeTo(1, 70, Easing.SpringOut);
                await img.ScaleTo(1, 70, Easing.Linear);
            };

            return animationTapImg;
        }

        /// <summary>
        /// Enter the heightItem.
        /// </summary>
        public static readonly BindableProperty HeightItemProperty = BindableProperty.Create(
            propertyName: nameof(HeightItem),
            returnType: typeof(double?),
            declaringType: typeof(ColoredBox),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: HeightItemPropertyChanged);

        /// <summary>
        /// Enter the heightItem.
        /// </summary>
        public double? HeightItem
        {
            get
            {
                return (double?)GetValue(HeightItemProperty);
            }
            set
            {
                SetValue(HeightItemProperty, value);
            }
        }

        private static void HeightItemPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ColoredBox coloredBox = (ColoredBox)bindable;
            double coloredBoxHeight = (double)newValue;

            for (int i = 0; i < coloredBox.listBoxContent.Count; i++)
            {
                coloredBox.listBoxContent[i].HeightRequest = coloredBoxHeight;
                coloredBox.listBoxImage[i].HeightRequest = coloredBoxHeight;
            }
        }

        /// <summary>
        /// Enter the UIDesign.
        /// </summary>
        public static readonly BindableProperty UIDesignProperty = BindableProperty.Create(
            propertyName: nameof(UIDesign),
            returnType: typeof(UIDesign),
            declaringType: typeof(ColoredBox),
            defaultValue: UIDesign.Filled,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: UIDesignPropertyChanged);

        /// <summary>
        /// Enter the UIDesign.
        /// </summary>
        public UIDesign UIDesign
        {
            get
            {
                return (UIDesign)GetValue(UIDesignProperty);
            }
            set
            {
                SetValue(UIDesignProperty, value);
            }
        }

        private static void UIDesignPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ColoredBox coloredBox = (ColoredBox)bindable;
            UIDesign uIDesign = (UIDesign)newValue;

            for (int i = 0; i < coloredBox.listBoxImage.Count; i++)
            {
                coloredBox.listBoxImage[i].ChangeUIDesign("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", uIDesign);
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
                ColorUIPropertyChanged(this, currentColorUI, value);
                currentColorUI = value;
            }
        }

        private static void ColorUIPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ColoredBox coloredBox = (ColoredBox)bindable;
            ColorUI copyColorUI = (ColorUI)newValue;

            for (int i = 0; i < coloredBox.listBoxContent.Count; i++)
            {
                coloredBox.listBoxImage[i].ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", copyColorUI);
            }
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            if (child.GetType() == typeof(ColoredBoxContent))
            {
                ColoredBoxContent userItem = (ColoredBoxContent)child;

                StackLayout stackContent = new StackLayout();
                stackContent.Margin = new Thickness(2, 0, 2, 0);
                stackContent.Spacing = 0;

                Grid grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Star }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height =  GridLength.Auto},
                        new RowDefinition { Height =  1}
                    }
                };

                grid.RowSpacing = -1;

                ColoredBoxImage boxImage = new ColoredBoxImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI, UIDesign);
                LineImage lineImage = new LineImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ");

                lineImage.IsVisible = false;
                currentLastLine = lineImage;

                ColoredBoxContent item = new ColoredBoxContent();
                item.SetIndex("fernandoLaavor77+*_87WW", listBoxImage.Count);
                item.Margin = new Thickness(4, 0, 2, 2);

                if (Touched != null)
                {
                    boxImage.GestureRecognizers.Add(GetClickAnimation(boxImage));
                    boxImage.GestureRecognizers.Add(GetClick(item.Index));
                }

                if (userItem.Content != null)
                {
                    for (int iS = 0; iS < userItem.Children.Count; iS++)
                    {
                        if (Touched != null)
                        {
                            userItem.Children[item.Children.Count - 1].GestureRecognizers.Add(GetClickAnimation(boxImage));
                            userItem.Children[item.Children.Count - 1].GestureRecognizers.Add(GetClick(item.Index));
                        }
                    }

                    item.Content = userItem.Content;
                }
                else
                {
                    for (int iS = 0; iS < userItem.Children.Count; iS++)
                    {
                        item.Children.Add(userItem.Children[iS]);

                        if (Touched != null)
                        {
                            item.Children[item.Children.Count - 1].GestureRecognizers.Add(GetClickAnimation(boxImage));
                            item.Children[item.Children.Count - 1].GestureRecognizers.Add(GetClick(item.Index));
                        }
                    }
                }

                if (HeightItem.HasValue)
                {
                    boxImage.HeightRequest = HeightItem.Value;
                    item.HeightRequest = HeightItem.Value;
                }

                if (Touched != null)
                {
                    boxImage.GestureRecognizers.Add(GetClickAnimation(boxImage));
                    boxImage.GestureRecognizers.Add(GetClick(item.Index));

                    item.GestureRecognizers.Add(GetClickAnimation(boxImage));
                    item.GestureRecognizers.Add(GetClick(item.Index));
                }

                grid.GestureRecognizers.Add(GetClick(item.Index));

                if (currentLastLine != null)
                {
                    currentLastLine.IsVisible = true;
                }

                grid.Children.Add(boxImage, 0, 0);
                grid.Children.Add(lineImage, 0, 1);
                grid.Children.Add(item);

                stackContent.Children.Add(grid);

                dataItems.Children.Add(stackContent);

                dataItems.Spacing = 0;

                listBoxImage.Add(boxImage);
                listBoxContent.Add(item);

                this.ForceLayout();
                this.UpdateChildrenLayout();
            }
        }

      
    }
}
