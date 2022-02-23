using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Inquiry
    {
        /// <summary>
        /// Class InquirySwitchControl
        /// </summary>
        public class InquirySwitchControl : Image
        {
            private ImageSource internalSource;
            private DesignType currentDesignType;
            private ColorUI currentColor;

            /// <summary>
            /// Internal
            /// </summary>
            public InquirySwitchLabel Label { get; private set; }

            /// <summary>
            /// Inform State
            /// </summary>
            public State State { get; private set; }

            /// <summary>
            /// Constructor of InquirySwitchControl
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="color"></param>
            /// <param name="state"></param>
            public InquirySwitchControl(string hash, ColorUI color, State state, DesignType designType)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in Constructor");
                }

                currentDesignType = designType;
                currentColor = color;
                this.State = state;

                Aspect = Aspect.Fill;
                HorizontalOptions = LayoutOptions.Start;
                VerticalOptions = LayoutOptions.Center;

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, this.State, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="label"></param>
            public void setlabel(string hash, InquirySwitchLabel label)
            {
                if (hash != "__Laavor*+-")
                {
                    Label = label;
                }
            }

            /// <summary>
            /// Change ColorUI of InquirySwitch
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="color"></param>
            public void ChangeColor(string hash, ColorUI color)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in ChangeColor");
                }

                currentColor = color;

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, this.State, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }


            /// <summary>
            /// Change State of InquirySwitch
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="state"></param>
            public void ChangeState(string hash, State state)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in ChangeColor");
                }

                this.State = state;

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, this.State, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Change DesignType of InquirySwitch
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="designType"></param>
            public void ChangeDesignType(string hash, DesignType designType)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in ChangeColor");
                }

                currentDesignType = designType;

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, this.State, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }        

            private string GetImageFit(ColorUI color)
            {                
                switch (color)
                {                    
                    case ColorUI.Black:
                        return SwitchFit.Black;
                    case ColorUI.Blue:
                        return SwitchFit.Blue;
                    case ColorUI.Gray:
                        return SwitchFit.Gray;
                    case ColorUI.Green:
                        return SwitchFit.Green;
                    case ColorUI.Red:
                        return SwitchFit.Red;
                    case ColorUI.Yellow:
                        return SwitchFit.Yellow;
                    case ColorUI.BlueLight:
                        return SwitchFit.BlueLight;
                    case ColorUI.GreenLight:
                        return SwitchFit.GreenLight;
                    case ColorUI.YellowLight:
                        return SwitchFit.YellowLight;
                    case ColorUI.White:
                        return SwitchFit.White;
                    case ColorUI.Pink:
                        return SwitchFit.Pink;
                    case ColorUI.Orange:
                        return SwitchFit.Orange;
                    case ColorUI.Brown:
                        return SwitchFit.Brown;
                    case ColorUI.Purple:
                        return SwitchFit.Purple;
                    case ColorUI.Turquoise:
                        return SwitchFit.Turquoise;
                    case ColorUI.PinkLight:
                        return SwitchFit.PinkLight;
                    case ColorUI.BlueSky:
                        return SwitchFit.BlueSky;
                    case ColorUI.GrayLight:
                        return SwitchFit.GrayLight;
                    case ColorUI.RedLight:
                        return SwitchFit.RedLight;
                    case ColorUI.OrangeLight:
                        return SwitchFit.OrangeLight;
                    case ColorUI.YellowDark:
                        return SwitchFit.YellowDark;
                    case ColorUI.BlueDark:
                        return SwitchFit.BlueDark;
                    case ColorUI.GreenDark:
                        return SwitchFit.GreenDark;
                    case ColorUI.Aqua:
                        return SwitchFit.Aqua;
                    case ColorUI.Tan:
                        return SwitchFit.Tan;
                    case ColorUI.GreenDarkness:
                        return SwitchFit.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return SwitchFit.BlueViolet;
                    case ColorUI.Transparent:
                        return SwitchFit.White;
                    default:
                        return SwitchFit.BlueSky;
                }
            }

            private string GetImageDefaultFit()
            {
                return SwitchFit.Default;
            }

            private string GetImageFilled(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return SwitchFilled.Black;
                    case ColorUI.Blue:
                        return SwitchFilled.Blue;
                    case ColorUI.Gray:
                        return SwitchFilled.Gray;
                    case ColorUI.Green:
                        return SwitchFilled.Green;
                    case ColorUI.Red:
                        return SwitchFilled.Red;
                    case ColorUI.Yellow:
                        return SwitchFilled.Yellow;
                    case ColorUI.BlueLight:
                        return SwitchFilled.BlueLight;
                    case ColorUI.GreenLight:
                        return SwitchFilled.GreenLight;
                    case ColorUI.YellowLight:
                        return SwitchFilled.YellowLight;
                    case ColorUI.White:
                        return SwitchFilled.White;
                    case ColorUI.Pink:
                        return SwitchFilled.Pink;
                    case ColorUI.Orange:
                        return SwitchFilled.Orange;
                    case ColorUI.Brown:
                        return SwitchFilled.Brown;
                    case ColorUI.Purple:
                        return SwitchFilled.Purple;
                    case ColorUI.Turquoise:
                        return SwitchFilled.Turquoise;
                    case ColorUI.PinkLight:
                        return SwitchFilled.PinkLight;
                    case ColorUI.BlueSky:
                        return SwitchFilled.BlueSky;
                    case ColorUI.GrayLight:
                        return SwitchFilled.GrayLight;
                    case ColorUI.RedLight:
                        return SwitchFilled.RedLight;
                    case ColorUI.OrangeLight:
                        return SwitchFilled.OrangeLight;
                    case ColorUI.YellowDark:
                        return SwitchFilled.YellowDark;
                    case ColorUI.BlueDark:
                        return SwitchFilled.BlueDark;
                    case ColorUI.GreenDark:
                        return SwitchFilled.GreenDark;
                    case ColorUI.Aqua:
                        return SwitchFilled.Aqua;
                    case ColorUI.Tan:
                        return SwitchFilled.Tan;
                    case ColorUI.GreenDarkness:
                        return SwitchFilled.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return SwitchFilled.BlueViolet;
                    case ColorUI.Transparent:
                        return SwitchFilled.White;
                    default:
                        return SwitchFilled.BlueSky;
                }
            }

            private string GetImageDefaultFilled()
            {
                return SwitchFilled.Default;
            }

            private string GetImageAllonsy(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return SwitchAllonsy.Black;
                    case ColorUI.Blue:
                        return SwitchAllonsy.Blue;
                    case ColorUI.Gray:
                        return SwitchAllonsy.Gray;
                    case ColorUI.Green:
                        return SwitchAllonsy.Green;
                    case ColorUI.Red:
                        return SwitchAllonsy.Red;
                    case ColorUI.Yellow:
                        return SwitchAllonsy.Yellow;
                    case ColorUI.BlueLight:
                        return SwitchAllonsy.BlueLight;
                    case ColorUI.GreenLight:
                        return SwitchAllonsy.GreenLight;
                    case ColorUI.YellowLight:
                        return SwitchAllonsy.YellowLight;
                    case ColorUI.White:
                        return SwitchAllonsy.White;
                    case ColorUI.Pink:
                        return SwitchAllonsy.Pink;
                    case ColorUI.Orange:
                        return SwitchAllonsy.Orange;
                    case ColorUI.Brown:
                        return SwitchAllonsy.Brown;
                    case ColorUI.Purple:
                        return SwitchAllonsy.Purple;
                    case ColorUI.Turquoise:
                        return SwitchAllonsy.Turquoise;
                    case ColorUI.PinkLight:
                        return SwitchAllonsy.PinkLight;
                    case ColorUI.BlueSky:
                        return SwitchAllonsy.BlueSky;
                    case ColorUI.GrayLight:
                        return SwitchAllonsy.GrayLight;
                    case ColorUI.RedLight:
                        return SwitchAllonsy.RedLight;
                    case ColorUI.OrangeLight:
                        return SwitchAllonsy.OrangeLight;
                    case ColorUI.YellowDark:
                        return SwitchAllonsy.YellowDark;
                    case ColorUI.BlueDark:
                        return SwitchAllonsy.BlueDark;
                    case ColorUI.GreenDark:
                        return SwitchAllonsy.GreenDark;
                    case ColorUI.Aqua:
                        return SwitchAllonsy.Aqua;
                    case ColorUI.Tan:
                        return SwitchAllonsy.Tan;
                    case ColorUI.GreenDarkness:
                        return SwitchAllonsy.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return SwitchAllonsy.BlueViolet;
                    case ColorUI.Transparent:
                        return SwitchAllonsy.White;
                    default:
                        return SwitchAllonsy.BlueSky;
                }
            }

            private string GetImageDefaultAllonsy()
            {
                return SwitchAllonsy.Default;
            }

            private string GetImageShinning(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return SwitchShinning.Black;
                    case ColorUI.Blue:
                        return SwitchShinning.Blue;
                    case ColorUI.Gray:
                        return SwitchShinning.Gray;
                    case ColorUI.Green:
                        return SwitchShinning.Green;
                    case ColorUI.Red:
                        return SwitchShinning.Red;
                    case ColorUI.Yellow:
                        return SwitchShinning.Yellow;
                    case ColorUI.BlueLight:
                        return SwitchShinning.BlueLight;
                    case ColorUI.GreenLight:
                        return SwitchShinning.GreenLight;
                    case ColorUI.YellowLight:
                        return SwitchShinning.YellowLight;
                    case ColorUI.White:
                        return SwitchShinning.White;
                    case ColorUI.Pink:
                        return SwitchShinning.Pink;
                    case ColorUI.Orange:
                        return SwitchShinning.Orange;
                    case ColorUI.Brown:
                        return SwitchShinning.Brown;
                    case ColorUI.Purple:
                        return SwitchShinning.Purple;
                    case ColorUI.Turquoise:
                        return SwitchShinning.Turquoise;
                    case ColorUI.PinkLight:
                        return SwitchShinning.PinkLight;
                    case ColorUI.BlueSky:
                        return SwitchShinning.BlueSky;
                    case ColorUI.GrayLight:
                        return SwitchShinning.GrayLight;
                    case ColorUI.RedLight:
                        return SwitchShinning.RedLight;
                    case ColorUI.OrangeLight:
                        return SwitchShinning.OrangeLight;
                    case ColorUI.YellowDark:
                        return SwitchShinning.YellowDark;
                    case ColorUI.BlueDark:
                        return SwitchShinning.BlueDark;
                    case ColorUI.GreenDark:
                        return SwitchShinning.GreenDark;
                    case ColorUI.Aqua:
                        return SwitchShinning.Aqua;
                    case ColorUI.Tan:
                        return SwitchShinning.Tan;
                    case ColorUI.GreenDarkness:
                        return SwitchShinning.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return SwitchShinning.BlueViolet;
                    case ColorUI.Transparent:
                        return SwitchShinning.White;
                    default:
                        return SwitchShinning.BlueSky;
                }
            }

            private string GetImageDefaultShinning()
            {
                return SwitchShinning.Default;
            }

            private string GetImageScratches(ColorUI color)
            {
                switch (color)
                {
                    
                    case ColorUI.Black:
                        return SwitchScratches.Black;
                    case ColorUI.Blue:
                        return SwitchScratches.Blue;
                    case ColorUI.Gray:
                        return SwitchScratches.Gray;
                    case ColorUI.Green:
                        return SwitchScratches.Green;
                    case ColorUI.Red:
                        return SwitchScratches.Red;
                    case ColorUI.Yellow:
                        return SwitchScratches.Yellow;
                    case ColorUI.BlueLight:
                        return SwitchScratches.BlueLight;
                    case ColorUI.GreenLight:
                        return SwitchScratches.GreenLight;
                    case ColorUI.YellowLight:
                        return SwitchScratches.YellowLight;
                    case ColorUI.White:
                        return SwitchScratches.White;
                    case ColorUI.Pink:
                        return SwitchScratches.Pink;
                    case ColorUI.Orange:
                        return SwitchScratches.Orange;
                    case ColorUI.Brown:
                        return SwitchScratches.Brown;
                    case ColorUI.Purple:
                        return SwitchScratches.Purple;
                    case ColorUI.Turquoise:
                        return SwitchScratches.Turquoise;
                    case ColorUI.PinkLight:
                        return SwitchScratches.PinkLight;
                    case ColorUI.BlueSky:
                        return SwitchScratches.BlueSky;
                    case ColorUI.GrayLight:
                        return SwitchScratches.GrayLight;
                    case ColorUI.RedLight:
                        return SwitchScratches.RedLight;
                    case ColorUI.OrangeLight:
                        return SwitchScratches.OrangeLight;
                    case ColorUI.YellowDark:
                        return SwitchScratches.YellowDark;
                    case ColorUI.BlueDark:
                        return SwitchScratches.BlueDark;
                    case ColorUI.GreenDark:
                        return SwitchScratches.GreenDark;
                    case ColorUI.Aqua:
                        return SwitchScratches.Aqua;
                    case ColorUI.Tan:
                        return SwitchScratches.Tan;
                    case ColorUI.GreenDarkness:
                        return SwitchScratches.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return SwitchScratches.BlueViolet;
                    case ColorUI.Transparent:
                        return SwitchScratches.White;
                    default:
                        return SwitchScratches.BlueSky;
                }
            }

            private string GetImageDefaultScratches()
            {
                return SwitchScratches.Default;
            }

            private string GetImageCadre(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return SwitchCadre.Black;
                    case ColorUI.Blue:
                        return SwitchCadre.Blue;
                    case ColorUI.Gray:
                        return SwitchCadre.Gray;
                    case ColorUI.Green:
                        return SwitchCadre.Green;
                    case ColorUI.Red:
                        return SwitchCadre.Red;
                    case ColorUI.Yellow:
                        return SwitchCadre.Yellow;
                    case ColorUI.BlueLight:
                        return SwitchCadre.BlueLight;
                    case ColorUI.GreenLight:
                        return SwitchCadre.GreenLight;
                    case ColorUI.YellowLight:
                        return SwitchCadre.YellowLight;
                    case ColorUI.White:
                        return SwitchCadre.White;
                    case ColorUI.Pink:
                        return SwitchCadre.Pink;
                    case ColorUI.Orange:
                        return SwitchCadre.Orange;
                    case ColorUI.Brown:
                        return SwitchCadre.Brown;
                    case ColorUI.Purple:
                        return SwitchCadre.Purple;
                    case ColorUI.Turquoise:
                        return SwitchCadre.Turquoise;
                    case ColorUI.PinkLight:
                        return SwitchCadre.PinkLight;
                    case ColorUI.BlueSky:
                        return SwitchCadre.BlueSky;
                    case ColorUI.GrayLight:
                        return SwitchCadre.GrayLight;
                    case ColorUI.RedLight:
                        return SwitchCadre.RedLight;
                    case ColorUI.OrangeLight:
                        return SwitchCadre.OrangeLight;
                    case ColorUI.YellowDark:
                        return SwitchCadre.YellowDark;
                    case ColorUI.BlueDark:
                        return SwitchCadre.BlueDark;
                    case ColorUI.GreenDark:
                        return SwitchCadre.GreenDark;
                    case ColorUI.Aqua:
                        return SwitchCadre.Aqua;
                    case ColorUI.Tan:
                        return SwitchCadre.Tan;
                    case ColorUI.GreenDarkness:
                        return SwitchCadre.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return SwitchCadre.BlueViolet;
                    case ColorUI.Transparent:
                        return SwitchCadre.White;
                    default:
                        return SwitchCadre.BlueSky;
                }
            }

            private string GetImageDefaultCadre()
            {
                return SwitchCadre.Default;
            }

            private string GetImageSmoke(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return SwitchSmoke.Black;
                    case ColorUI.Blue:
                        return SwitchSmoke.Blue;
                    case ColorUI.Gray:
                        return SwitchSmoke.Gray;
                    case ColorUI.Green:
                        return SwitchSmoke.Green;
                    case ColorUI.Red:
                        return SwitchSmoke.Red;
                    case ColorUI.Yellow:
                        return SwitchSmoke.Yellow;
                    case ColorUI.BlueLight:
                        return SwitchSmoke.BlueLight;
                    case ColorUI.GreenLight:
                        return SwitchSmoke.GreenLight;
                    case ColorUI.YellowLight:
                        return SwitchSmoke.YellowLight;
                    case ColorUI.White:
                        return SwitchSmoke.White;
                    case ColorUI.Pink:
                        return SwitchSmoke.Pink;
                    case ColorUI.Orange:
                        return SwitchSmoke.Orange;
                    case ColorUI.Brown:
                        return SwitchSmoke.Brown;
                    case ColorUI.Purple:
                        return SwitchSmoke.Purple;
                    case ColorUI.Turquoise:
                        return SwitchSmoke.Turquoise;
                    case ColorUI.PinkLight:
                        return SwitchSmoke.PinkLight;
                    case ColorUI.BlueSky:
                        return SwitchSmoke.BlueSky;
                    case ColorUI.GrayLight:
                        return SwitchSmoke.GrayLight;
                    case ColorUI.RedLight:
                        return SwitchSmoke.RedLight;
                    case ColorUI.OrangeLight:
                        return SwitchSmoke.OrangeLight;
                    case ColorUI.YellowDark:
                        return SwitchSmoke.YellowDark;
                    case ColorUI.BlueDark:
                        return SwitchSmoke.BlueDark;
                    case ColorUI.GreenDark:
                        return SwitchSmoke.GreenDark;
                    case ColorUI.Aqua:
                        return SwitchSmoke.Aqua;
                    case ColorUI.Tan:
                        return SwitchSmoke.Tan;
                    case ColorUI.GreenDarkness:
                        return SwitchSmoke.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return SwitchSmoke.BlueViolet;
                    case ColorUI.Transparent:
                        return SwitchSmoke.White;
                    default:
                        return SwitchSmoke.BlueSky;
                }
            }

            private string GetImageDefaultSmoke()
            {
                return SwitchSmoke.Default;
            }

            private string GetColor(ColorUI color, State state, DesignType designType)
            {
                string returnStringColor;

                if (state == State.On)
                {
                    MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + designType.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

                    object[] parametersInvoke = { color };

                    returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
                }
                else
                {
                    MethodInfo methodToInvoke = GetType().GetMethod("GetImageDefault" + designType.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

                    returnStringColor = (string)methodToInvoke.Invoke(this, null);
                }
                return returnStringColor;
            }
        }

    }
}
