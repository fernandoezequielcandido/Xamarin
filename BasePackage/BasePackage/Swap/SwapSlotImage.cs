using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Laavor
{
    namespace Swap
    {
        /// <summary>
        /// Class SwapSlotImage
        /// </summary>
        public class SwapSlotImage : StackLayout
        {
            /// <summary>
            /// Returns the List of the chosen items.
            /// </summary>
            public List<SwapChosenItem> ItemsChosen { get; private set; }

            /// <summary>
            /// Call when swap Image
            /// </summary>
            public event EventHandler OnSwap;

            private int countItems = 0;

            /// <summary>
            /// Constructor of SwapLotImage
            /// </summary>
            public SwapSlotImage()
            {
                Spacing = 0;
                ItemsChosen = new List<SwapChosenItem>();
                this.Orientation = StackOrientation.Horizontal;
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="indexImage"></param>
            /// <param name="numberContent"></param>
            /// <param name="valueImage"></param>
            /// <param name="valueContent"></param>
            /// <param name="source"></param>
            public void Update(string hash, int indexImage, int numberContent, string valueImage, string valueContent, string source)
            {
                if (hash == "__Laavor*+-")
                {
                    if (numberContent <= (ItemsChosen.Count) && ItemsChosen.Count > 0)
                    {
                        ItemsChosen[numberContent - 1].Update("__Laavor*+-", indexImage, numberContent, valueImage, valueContent, source);
                        OnSwap?.Invoke(this, EventArgs.Empty);
                    }
                }
            }

            /// <summary>
            /// Property to inform SpaceBetween images rating
            /// </summary>
            public static readonly BindableProperty SpaceBetweenProperty = BindableProperty.Create(
                     propertyName: nameof(SpaceBetween),
                     returnType: typeof(int),
                     declaringType: typeof(SwapSlotImage),
                     defaultValue: 0,
                     defaultBindingMode: BindingMode.OneWay,
                     propertyChanged: SpaceBetweenPropertyChanged);

            /// <summary>
            /// Property to inform SpaceBetween images rating
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
                SwapSlotImage swapSlotImage = (SwapSlotImage)bindable;
                int copyMargin = (int)newValue;

                for (int iItem = 0; iItem < swapSlotImage.Children.Count; iItem++)
                {
                    SwapSlotContent image = (SwapSlotContent)swapSlotImage.Children[iItem];
                    image.Margin = copyMargin;
                }

                double padMargin = 0;

                if (swapSlotImage.Margin.Left >= 0)
                {
                    padMargin = swapSlotImage.Margin.Left - swapSlotImage.SpaceBetween;

                    if (padMargin < 0)
                    {
                        padMargin = 0;
                    }
                }
                else
                {
                    padMargin = swapSlotImage.Margin.Left;
                }

                swapSlotImage.Margin = new Thickness(padMargin, swapSlotImage.Margin.Top, swapSlotImage.Margin.Right, swapSlotImage.Margin.Bottom);
            }

            /// <summary>
            /// Enter the ImageWidth.
            /// </summary>
            public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(
                propertyName: nameof(ImageWidth),
                returnType: typeof(double),
                declaringType: typeof(SwapSlotImage),
                defaultValue: 100.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageWidthChanged);

            /// <summary>
            /// Enter the ImageWidth.
            /// </summary>
            public double ImageWidth
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

            private static void ImageWidthChanged(object bindable, object oldValue, object newValue)
            {
                SwapSlotImage slotImage = (SwapSlotImage)bindable;
                double width = (double)newValue;

                for (int iItem = 0; iItem < slotImage.Children.Count; iItem++)
                {
                    if (slotImage.Children[iItem].GetType() == typeof(SwapSlotContent))
                    {
                        SwapSlotContent slotContent = (SwapSlotContent)slotImage.Children[iItem];
                        slotContent.ChangeWidth("__Laavor*+-", width);
                    }
                }
            }

            /// <summary>
            /// Enter the ImageWidth.
            /// </summary>
            public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create(
                propertyName: nameof(ImageHeight),
                returnType: typeof(double),
                declaringType: typeof(SwapSlotImage),
                defaultValue: 100.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: ImageHeightChanged);

            /// <summary>
            /// Enter the ImageHeight.
            /// </summary>
            public double ImageHeight
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

            private static void ImageHeightChanged(object bindable, object oldValue, object newValue)
            {
                SwapSlotImage slotImage = (SwapSlotImage)bindable;
                double height = (double)newValue;
                for (int iItem = 0; iItem < slotImage.Children.Count; iItem++)
                {
                    if (slotImage.Children[iItem].GetType() == typeof(SwapSlotContent))
                    {
                        SwapSlotContent slotContent = (SwapSlotContent)slotImage.Children[iItem];
                        slotContent.ChangeHeight("__Laavor*+-", height);
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

                if (child.GetType() == typeof(SwapSlotContent))
                {
                    SwapSlotContent slotContent = (SwapSlotContent)child;
                    (child as SwapSlotContent).ChangeHeight("__Laavor*+-", ImageHeight);
                    (child as SwapSlotContent).ChangeWidth("__Laavor*+-", ImageWidth);

                    string valueImage = "";
                    string sourceImage = "";
                    if (slotContent.Children.Count > 0)
                    {
                        for (int iCI = 0; iCI < slotContent.Children.Count; iCI++)
                        {
                            if (slotContent.Children[iCI].GetType() == typeof(SwapSlotContentImage))
                            {
                                SwapSlotContentImage slotContentImage = (SwapSlotContentImage)slotContent.Children[iCI];
                                valueImage = slotContentImage.Value;
                                sourceImage = slotContentImage.Image;
                                break;
                            }
                        }
                    }

                    ItemsChosen.Insert(countItems, new SwapChosenItem("__Laavor*+-", 0, (countItems + 1), slotContent.Value, valueImage, sourceImage));
                    slotContent.InformSlotImage("__Laavor*+-", this);
                    slotContent.Margin = SpaceBetween;

                    if (countItems == 0)
                    {
                        double padMargin = 0;

                        if (slotContent.Margin.Left >= 0)
                        {
                            padMargin = slotContent.Margin.Left - SpaceBetween;

                            if (padMargin < 0)
                            {
                                padMargin = 0;
                            }
                        }
                        else
                        {
                            padMargin = slotContent.Margin.Left;
                        }

                        slotContent.Margin = new Thickness(padMargin, slotContent.Margin.Top, slotContent.Margin.Right, slotContent.Margin.Bottom);
                    }

                    countItems++;

                    (child as SwapSlotContent).InformNumber("__Laavor*+-", countItems);
                }
            }
        }
    }
}
