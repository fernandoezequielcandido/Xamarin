using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    /// <summary>
    /// Class LaavorFormer
    /// </summary>
    public class LaavorFormer : StackLayout
    {
        /// <summary>
        /// Set Touch
        /// </summary>
        protected TapGestureRecognizer Touch
        {
            get
            {
                return Touch;
            }

            set
            {
                VivacityPropertyChanged();
                Touch = value;
            }
        }
        
        /// <summary>
        /// Set Objects to Vivacity
        /// </summary>
        protected List<View> ObjectsVivacity;

        /// <summary>
        /// Set if is ReadOnly
        /// </summary>
        protected bool ReadOnly;

        /// <summary>
        /// Constructor LaavorFormer
        /// </summary>
        public LaavorFormer()
        {
            ReadOnly = false;
            ObjectsVivacity = new List<View>();
        }

        /// <summary>
        /// Set Touch
        /// </summary>
        public void SetTouch(string Key, TapGestureRecognizer tap)
        {
            if (Key == "__Laavor*+-")
            {
                Touch = tap;
            }
        }

        /// <summary>
        /// Property to set Vivacity.
        /// </summary>
        public static readonly BindableProperty VivacityProperty = BindableProperty.Create(
                 propertyName: nameof(Vivacity),
                 returnType: typeof(Vivacity),
                 declaringType: typeof(LaavorFormer),
                 defaultValue: Vivacity.Decrease,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: VivacityPropertyChanged);

        /// <summary>
        /// Property to set Vivacity.
        /// </summary>
        public Vivacity Vivacity
        {
            get
            {
                return (Vivacity)GetValue(VivacityProperty);
            }
            set
            {
                SetValue(VivacityProperty, value);
            }
        }

        /// <summary>
        /// Call when Vivacity is Changed
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected static void VivacityPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorFormer laavorFormer = (LaavorFormer)bindable;
            laavorFormer.VivacityPropertyChanged();
        }
        
        /// <summary>
        /// Call when Vivacity is Changed
        /// </summary>
        protected void VivacityPropertyChanged()
        {
            if (!ReadOnly && ObjectsVivacity != null)
            {
                for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                {
                    ObjectsVivacity[iO].GestureRecognizers.Clear();
                    ObjectsVivacity[iO].GestureRecognizers.Add(GetVivacity());
                    ObjectsVivacity[iO].GestureRecognizers.Add(Touch);

                    ObjectsVivacity[iO].Opacity = 1.0;
                }
            }
        }

        /// <summary>
        /// Property to set Depth of Vivacity.
        /// </summary>
        public static readonly BindableProperty DepthProperty = BindableProperty.Create(
                 propertyName: nameof(Depth),
                 returnType: typeof(Depth),
                 declaringType: typeof(LaavorFormer),
                 defaultValue: Depth.LessMedium,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: DepthPropertyChanged);

        /// <summary>
        /// Property to set Depth of Vivacity.
        /// </summary>
        public Depth Depth
        {
            get
            {
                return (Depth)GetValue(DepthProperty);
            }
            set
            {
                SetValue(DepthProperty, value);
            }
        }

        /// <summary>
        /// Call when Depth is Changed
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected static void DepthPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorFormer laavorBase = (LaavorFormer)bindable;
            if (!laavorBase.ReadOnly)
            {
                laavorBase.VivacityPropertyChanged();
            }
        }

        /// <summary>
        /// Property to set VivacitySpeed.
        /// </summary>
        public static readonly BindableProperty VivacitySpeedProperty = BindableProperty.Create(
                 propertyName: nameof(VivacitySpeed),
                 returnType: typeof(VivacitySpeed),
                 declaringType: typeof(LaavorFormer),
                 defaultValue: VivacitySpeed.Fast,
                 defaultBindingMode: BindingMode.OneWay,
                 propertyChanged: VivacitySpeedPropertyChanged);

        /// <summary>
        /// Property to set VivacitySpeed.
        /// </summary>
        public VivacitySpeed VivacitySpeed
        {
            get
            {
                return (VivacitySpeed)GetValue(VivacitySpeedProperty);
            }
            set
            {
                SetValue(VivacitySpeedProperty, value);
            }
        }

        /// <summary>
        /// Call when VivacitySpeed is Changed
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected static void VivacitySpeedPropertyChanged(object bindable, object oldValue, object newValue)
        {
            LaavorFormer laavorBase = (LaavorFormer)bindable;
            laavorBase.VivacityPropertyChanged();
        }

        /// <summary>
        /// Set Objects Vivacity
        /// </summary>
        /// <returns></returns>
        public void AddObjectsVivacity(string hash, View view)
        {
            if (hash == "__Laavor*+-")
            {
                ObjectsVivacity.Add(view);  
            }
        }

        /// <summary>
        /// Get Vivacity
        /// </summary>
        /// <returns></returns>
        public TapGestureRecognizer GetVivacity(string hash)
        {
            if (hash == "__Laavor*+-")
            {
                if (Vivacity != Vivacity.None)
                {
                    MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + Vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
                    TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
                    return touchVivavicity;
                }
            }

            return new TapGestureRecognizer();
        }

        /// <summary>
        /// Get Vivacity
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacity()
        {
            if (Vivacity != Vivacity.None)
            {
                MethodInfo methodToInvoke = GetType().GetMethod("GetVivacity" + Vivacity.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
                TapGestureRecognizer touchVivavicity = (TapGestureRecognizer)methodToInvoke.Invoke(this, null);
                return touchVivavicity;
            }
            else
            {
                return new TapGestureRecognizer();
            }
        }

        /// <summary>
        /// Use to create VivacityDecrease is Auto Call
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacityDecrease()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].ScaleTo(GetDepthDecrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].ScaleTo(GetDepthDecrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                    }

                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };

            return animationTap;
        }

        /// <summary>
        /// Use to create DepthDecrease is Auto Call
        /// </summary>
        /// <returns></returns>
        protected double GetDepthDecrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 0.88;
            }
            else if (depth == Depth.LessMedium)
            {
                return 0.95;
            }
            else if (depth == Depth.Medium)
            {
                return 0.90;
            }
            else
            {
                return 0.75;
            }
        }

        /// <summary>
        /// Use to create VivacityIncrease is Auto Call
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacityIncrease()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].ScaleTo(GetDepthIncrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].ScaleTo(GetDepthIncrease(Depth), (uint)VivacitySpeed, Easing.Linear);
                    }

                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].ScaleTo(1, (uint)VivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };

            return vivacityTap;
        }

        /// <summary>
        /// Use to create DepthIncrease is Auto Call
        /// </summary>
        /// <returns></returns>
        protected double GetDepthIncrease(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 1.01;
            }
            else if (depth == Depth.LessMedium)
            {
                return 1.07;
            }
            else if (depth == Depth.Medium)
            {
                return 1.11;
            }
            else
            {
                return 1.15;
            }
        }

        /// <summary>
        /// Use to create VivacityRotation is Auto Call
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacityRotation()
        {
            TapGestureRecognizer vivacityTap = new TapGestureRecognizer();
            vivacityTap.Tapped += async (sender, e) =>
            {
                try
                {
                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].RotateTo(GetDepthRotation(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].RotateTo(GetDepthRotation(Depth), (uint)VivacitySpeed, Easing.Linear);
                    }

                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].RotateTo(0, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].RotateTo(0, (uint)VivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return vivacityTap;
        }

        /// <summary>
        /// Use to create DepthRotation is Auto Call
        /// </summary>
        /// <returns></returns>
        protected int GetDepthRotation(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 200;
            }
            else if (depth == Depth.LessMedium)
            {
                return 250;
            }
            else if (depth == Depth.Medium)
            {
                return 300;
            }
            else
            {
                return 360;
            }
        }

        /// <summary>
        /// Use to create VivacityJump is Auto Call
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacityJump()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(0, GetDepthJump(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(0, GetDepthJump(Depth), (uint)VivacitySpeed, Easing.Linear);
                    }

                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        /// <summary>
        /// Use to create DepthJump is Auto Call
        /// </summary>
        /// <returns></returns>
        protected double GetDepthJump(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return -1.5;
            }
            else if (depth == Depth.LessMedium)
            {
                return -2.0;
            }
            else if (depth == Depth.Medium)
            {
                return -2.7;
            }
            else
            {
                return -3.4;
            }
        }

        /// <summary>
        /// Use to create VivacityDown is Auto Call
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacityDown()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(0, GetDepthDown(Depth), (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(0, GetDepthDown(Depth), (uint)VivacitySpeed, Easing.Linear);
                    }

                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        /// <summary>
        /// Use to create DepthDown is Auto Call
        /// </summary>
        /// <returns></returns>
        protected double GetDepthDown(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 1.5;
            }
            else if (depth == Depth.LessMedium)
            {
                return 2.0;
            }
            else if (depth == Depth.Medium)
            {
                return 2.7;
            }
            else
            {
                return 3.4;
            }
        }

        /// <summary>
        /// Use to create VivacityLeft is Auto Call
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacityLeft()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(GetDepthLeft(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(GetDepthLeft(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                    }

                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        /// <summary>
        /// Use to create DepthLeft is Auto Call
        /// </summary>
        /// <returns></returns>
        protected double GetDepthLeft(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return -2.00;
            }
            else if (depth == Depth.LessMedium)
            {
                return -3.0;
            }
            else if (depth == Depth.Medium)
            {
                return -5.0;
            }
            else
            {
                return -10.0;
            }
        }

        /// <summary>
        /// Use to create VivacityRight is Auto Call
        /// </summary>
        /// <returns></returns>
        protected TapGestureRecognizer GetVivacityRight()
        {
            TapGestureRecognizer animationTap = new TapGestureRecognizer();
            animationTap.Tapped += async (sender, e) =>
            {
                try
                {
                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(GetDepthRight(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(GetDepthRight(Depth), 0, (uint)VivacitySpeed, Easing.Linear);
                    }

                    for (int iO = 0; iO < ObjectsVivacity.Count; iO++)
                    {
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                        await ObjectsVivacity[iO].TranslateTo(0, 0, (uint)VivacitySpeed, Easing.Linear);
                    }
                }
                catch { }
            };
            return animationTap;
        }

        /// <summary>
        /// Use to create DepthRight is Auto Call
        /// </summary>
        /// <returns></returns>
        protected double GetDepthRight(Depth depth)
        {
            if (depth == Depth.Small)
            {
                return 2.00;
            }
            else if (depth == Depth.LessMedium)
            {
                return 3.0;
            }
            else if (depth == Depth.Medium)
            {
                return 5.0;
            }
            else
            {
                return 10.0;
            }
        }

    }
}
