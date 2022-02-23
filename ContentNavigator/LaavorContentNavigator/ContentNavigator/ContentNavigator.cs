using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace LaavorContentNavigator
{
    /// <summary>
    /// Clas ContentNavigator
    /// </summary>
    public class ContentNavigator : StackLayout
    {
        /// <summary>
        /// Returns current index of image, start in 0.
        /// </summary>
        public int CurrentIndex { get; private set; }

        private int currentIndex;

        private ArrowImage imageArrowLeftReference;
        private ArrowImage imageArrowRightReference;

        private StackLayout dataItems;
        private StackLayout stackLeft;
        private StackLayout stackCenter;
        private StackLayout stackContent;
        private StackLayout stackRight;
        private Frame frameReference;

        private const int arrowHeight = 70;
        private const int arrowWidth = 40;

        private DesignType currentDesignType = DesignType.Standard;
        private ColorUI currentColorUI = ColorUI.Black;

        private List<ContentNavigatorItem> listContent;

        /// <summary>
        /// Event called when selected Change Content
        /// </summary>
        public event EventHandler ChangeContent;

        /// <summary>
        /// Constructor of ContentNavigator        
        /// </summary>
        public ContentNavigator() : base()
        {
            InitializeComponents();
            this.Spacing = 0;
        }

        private void InitializeComponents()
        {
            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.Center;
            InitAll();
        }

        private TapGestureRecognizer GetClickLeftAnimation()
        {
            TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
            animationTapImg.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageArrowLeftReference.ScaleTo(0.80, 140, Easing.Linear);
                    await imageArrowLeftReference.ScaleTo(1, 140, Easing.Linear);
                }
                catch { }
            };

            return animationTapImg;
        }

        private TapGestureRecognizer GetClickRightAnimation()
        {
            TapGestureRecognizer animationTapImg = new TapGestureRecognizer();
            animationTapImg.Tapped += async (sender, e) =>
            {
                try
                {
                    await imageArrowRightReference.ScaleTo(0.80, 140, Easing.Linear);
                    await imageArrowRightReference.ScaleTo(1, 140, Easing.Linear);
                }
                catch { }
            };

            return animationTapImg;
        }

        private void InitAll()
        {
            Children.Clear();

            dataItems = new StackLayout();
            this.Orientation = StackOrientation.Vertical;
            dataItems.Orientation = StackOrientation.Horizontal;
            dataItems.HorizontalOptions = LayoutOptions.Center;
            dataItems.Spacing = 0;

            listContent = new List<ContentNavigatorItem>();

            imageArrowLeftReference = new ArrowImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI, Side.Left, 0, true, currentDesignType);
            imageArrowLeftReference.WidthRequest = arrowWidth;
            imageArrowLeftReference.HeightRequest = arrowHeight;
            imageArrowLeftReference.GestureRecognizers.Add(GetClickLeftAnimation());
            imageArrowLeftReference.GestureRecognizers.Add(GetClickLeft());
            imageArrowLeftReference.Opacity = 0.3;
       
            stackLeft = new StackLayout();
            stackLeft.Spacing = 0;
            stackLeft.HorizontalOptions = LayoutOptions.Center;
            stackLeft.Orientation = StackOrientation.Vertical;
            stackLeft.VerticalOptions = LayoutOptions.Center;
            stackLeft.Children.Add(imageArrowLeftReference);



            stackContent = new StackLayout();
            stackContent.Spacing = 0;

            frameReference = new Frame();
            frameReference.BorderColor = Color.Gray;
            frameReference.VerticalOptions = LayoutOptions.Start;
            frameReference.BackgroundColor = Color.Transparent;
            frameReference.Content = stackContent;

            stackCenter = new StackLayout();
            stackCenter.Spacing = 0;
            stackCenter.Margin = new Thickness(0.5, 5, 0.5, 0.5);
            stackCenter.HorizontalOptions = LayoutOptions.Center;
            stackCenter.Orientation = StackOrientation.Vertical;

            stackCenter.Children.Add(frameReference);

            if (ContentHeight != null)
            {
                stackContent.HeightRequest = ContentHeight.Value;
                stackCenter.HeightRequest = ContentHeight.Value;
            }

            if (ContentWidth != null)
            {
                stackContent.WidthRequest = ContentWidth.Value;
                stackCenter.WidthRequest = ContentWidth.Value;
            }


            imageArrowRightReference = new ArrowImage("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI, Side.Right, 0, true, currentDesignType);
            imageArrowRightReference.WidthRequest = arrowWidth;
            imageArrowRightReference.HeightRequest = arrowHeight;
            imageArrowRightReference.Opacity = 0.3;
            imageArrowRightReference.GestureRecognizers.Add(GetClickRightAnimation());
            imageArrowRightReference.GestureRecognizers.Add(GetClickRight());
            imageArrowRightReference.Margin = new Thickness(2.5, 0, 0, 0);
            
            stackRight = new StackLayout();
            stackRight.Spacing = 0;
            stackRight.HorizontalOptions = LayoutOptions.Center;
            stackRight.Orientation = StackOrientation.Vertical;
            stackRight.VerticalOptions = LayoutOptions.Center;
            stackRight.Children.Add(imageArrowRightReference);

            dataItems.Children.Add(stackLeft);
            dataItems.Children.Add(stackCenter);
            dataItems.Children.Add(stackRight);

            Children.Add(dataItems);
        }

        /// <summary>
        /// Change current item/index. The index must exist, otherwise it does nothing
        /// Does not call the ChangeContent event
        /// </summary>
        /// <param name="index"></param>
        public void NavigateToIndex(int index)
        {
            try
            {
                if (index >= listContent.Count || index < 0)
                {
                    return;
                }

                if (currentIndex != index)
                {
                    listContent[CurrentIndex].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                }

                ContentNavigatorItem item = listContent[index];
                stackContent.Children.Clear();
                stackContent.Children.Add(item.Content);
                imageArrowLeftReference.Opacity = 0.3;
                item.SetContent("VisibleLL4488*-+++kmasdflaavor___");
                
                if (index == 0)
                {
                    imageArrowLeftReference.Opacity = 0.3;
                    imageArrowRightReference.Opacity = 1;
                }
                else if (index == (listContent.Count - 1))
                {
                    imageArrowLeftReference.Opacity = 1;
                    imageArrowRightReference.Opacity = 0.3;
                }
                else
                {
                    imageArrowLeftReference.Opacity = 1;
                    imageArrowRightReference.Opacity = 1;
                }

                imageArrowRightReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);
                imageArrowLeftReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);

                CurrentIndex = item.Index;
            }
            catch { }
        }

        private void Left_Clicked(object sender, EventArgs e)
        {
            var itemUser = (ArrowImage)sender;

            try
            {
                ContentNavigatorItem item;
                if (itemUser.Index == 1)
                {
                    item = listContent[0];
                    stackContent.Children.Clear();
                    stackContent.Children.Add(item.Content);
                    imageArrowLeftReference.Opacity = 0.3;
                    item.SetContent("VisibleLL4488*-+++kmasdflaavor___");
                    listContent[itemUser.Index].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                }
                else if (itemUser.Index == 0)
                {
                    return;
                }
                else
                {
                    item = listContent[itemUser.Index - 1];
                    stackContent.Children.Clear();
                    stackContent.Children.Add(item.Content);
                    imageArrowLeftReference.Opacity = 1;
                    item.SetContent("VisibleLL4488*-+++kmasdflaavor___");
                    listContent[itemUser.Index].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                }

                if (item.Index < (listContent.Count - 1))
                {
                    imageArrowRightReference.Opacity = 1;
                }

                imageArrowRightReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);
                imageArrowLeftReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);

                CurrentIndex = item.Index;

                ChangeContent?.Invoke(this, e);
            }
            catch
            { }
        }

        private void Right_Clicked(object sender, EventArgs e)
        {
            var itemUser = (ArrowImage)sender;

            try
            {
                ContentNavigatorItem item;
                if (itemUser.Index == (listContent.Count - 2))
                {
                    item = listContent[itemUser.Index + 1];
                    stackContent.Children.Clear();
                    stackContent.Children.Add(item.Content);
                    imageArrowRightReference.Opacity = 0.3;
                    item.SetContent("VisibleLL4488*-+++kmasdflaavor___");
                    listContent[itemUser.Index].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                }
                else if (itemUser.Index == (listContent.Count - 1))
                {
                    return;
                }
                else
                {
                    imageArrowRightReference.Opacity = 1;
                    item = listContent[itemUser.Index + 1];
                    stackContent.Children.Clear();
                    stackContent.Children.Add(item.Content);
                    item.SetContent("VisibleLL4488*-+++kmasdflaavor___");
                    listContent[itemUser.Index].SetContent("InvisiblekktyRE35__00.)*+-////]]]}}}}}");
                }

                if (item.Index > 0)
                {
                    imageArrowLeftReference.Opacity = 1;
                }

                imageArrowRightReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);
                imageArrowLeftReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);

                CurrentIndex = item.Index;

                ChangeContent?.Invoke(this, e);
            }
            catch
            { }
        }

        private TapGestureRecognizer GetClickLeft()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Left_Clicked;
            return tapGestureRecognizer;
        }

        private TapGestureRecognizer GetClickRight()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Right_Clicked;
            return tapGestureRecognizer;
        }

        /// <summary>
        /// Enter the image height.
        /// </summary>
        public static readonly BindableProperty ContentHeightProperty = BindableProperty.Create(
            propertyName: nameof(ContentHeight),
            returnType: typeof(double?),
            declaringType: typeof(ContentNavigator),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ContentHeightPropertyChanged);

        /// <summary>
        /// Enter the Content Height.
        /// </summary>
        public double? ContentHeight
        {
            get
            {
                return (double?)GetValue(ContentHeightProperty);
            }
            set
            {
                SetValue(ContentHeightProperty, value);
            }
        }

        private static void ContentHeightPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ContentNavigator navigator = (ContentNavigator)bindable;

            if (newValue != null)
            {
                double contentHeight = (double)newValue;
                navigator.stackContent.HeightRequest = contentHeight;
                navigator.stackCenter.HeightRequest = contentHeight;
            }
        }

        /// <summary>
        /// Enter the image width.
        /// </summary>
        public static readonly BindableProperty ContentWidthProperty = BindableProperty.Create(
            propertyName: nameof(ContentWidth),
            returnType: typeof(double?),
            declaringType: typeof(ContentNavigator),
            defaultValue: null,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: ContentWidthPropertyChanged);

        /// <summary>
        /// Enter the Content width.
        /// </summary>
        public double? ContentWidth
        {
            get
            {
                return (double?)GetValue(ContentWidthProperty);
            }
            set
            {
                SetValue(ContentWidthProperty, value);
            }
        }

        private static void ContentWidthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            ContentNavigator navigator = (ContentNavigator)bindable;

            if (newValue != null)
            {
                double contentWidth = (double)newValue;
                navigator.stackContent.WidthRequest = contentWidth;
                navigator.stackCenter.WidthRequest = contentWidth;
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
                currentColorUI = value;
                ColorUIPropertyChanged();
            }
        }

        private void ColorUIPropertyChanged()
        {
            imageArrowRightReference.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI);
            imageArrowLeftReference.ChangeColor("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentColorUI);
        }

        /// <summary>
        /// Enter the Border color input.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            propertyName: nameof(BorderColor),
            returnType: typeof(Color),
            declaringType: typeof(ContentNavigator),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: BorderColorPropertyChanged);

        /// <summary>
        /// Enter the Border color.
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
            ContentNavigator contentNavigator = (ContentNavigator)bindable;
            Color copyBorderColor = (Color)newValue;

            if (contentNavigator.frameReference != null)
            {
                contentNavigator.frameReference.BorderColor = copyBorderColor;
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
                return currentDesignType;
            }
            set
            {
                currentDesignType = value;
                DesignTypePropertyChanged();
            }
        }

        private void DesignTypePropertyChanged()
        {
            imageArrowRightReference.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentDesignType);
            imageArrowLeftReference.ChangeDesignType("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", currentDesignType);
        }

        /// <summary>
        /// Internal.
        /// </summary>
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            if (child.GetType() == typeof(ContentNavigatorItem))
            {
                ContentNavigatorItem item = (ContentNavigatorItem)child;
                base.OnChildAdded(child);

                listContent.Add(item);

                if (item.Content != null)
                {

                }
                else
                {
                    StackLayout stack = new StackLayout();
                    for (int iS = 0; iS < item.Children.Count; iS++)
                    {
                        stack.Children.Add(item.Children[iS]);
                    }

                    item.Content = stack;

                    if (currentIndex == 0)
                    {
                        stackContent.Children.Clear();
                        for (int iS = 0; iS < item.Children.Count; iS++)
                        {
                            stackContent.Children.Add(item.Children[iS]);
                        }

                        item.SetContent("VisibleLL4488*-+++kmasdflaavor___");

                        imageArrowRightReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);
                        imageArrowLeftReference.ChangeIndex("hashlaavorForceIsImpossibile98743987238497**/+-ppçLLkJJ", item.Index);

                        imageArrowRightReference.Opacity = 1.0;
                    }
                }

                item.setIndex("wertyafff7777_____784", currentIndex);
                currentIndex++;

            }
        }

    }
}
