using Xamarin.Forms;

namespace Laavor
{
    namespace Flying
    {
        /// <summary>
        /// Class Flying Box
        /// </summary>
        public class FlyingBox : AbsoluteLayout
        {
            private StackLayout dataItems = new StackLayout();

            private bool isInternal;

            /// <summary>
            /// Constructor of FlyingBox
            /// </summary>
            public FlyingBox()
            {
                isInternal = true;
                dataItems.Spacing = 0;

                AbsoluteLayout.SetLayoutBounds(dataItems, new Rectangle(0.0, 0.0, 1.0, 1.0));
                AbsoluteLayout.SetLayoutFlags(dataItems, AbsoluteLayoutFlags.All);

                this.Children.Add(dataItems);
                isInternal = false;
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
