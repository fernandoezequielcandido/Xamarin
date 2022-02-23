using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    namespace Flying
    {
        /// <summary>
        /// Class CloseControl
        /// </summary>
        public class CloseControl : Image
        {
            private ImageSource internalSource;
            private ColorUI currentColor;
            private DesignType currentDesignType;

            /// <summary>
            /// Constructor of CloseControl
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="color"></param>
            public CloseControl(string hash, ColorUI color)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in Constructor");
                }

                currentColor = color;

                Aspect = Aspect.Fill;
                HorizontalOptions = LayoutOptions.Start;
                VerticalOptions = LayoutOptions.Center;

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Change State Internal
            /// </summary>
            /// <param name="hash"></param>
            /// <param name="isChecked"></param>
            public void ChangeState(string hash, bool isChecked)
            {
                if (hash != "__Laavor*+-")
                {
                    throw new Exception("Key in Invalid in ChangeColor");
                }

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Change State Internal
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

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }

            /// <summary>
            /// Change State Internal
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

                byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentDesignType));
                var streamImage = new System.IO.MemoryStream(imageBytes);

                this.internalSource = ImageSource.FromStream(() => streamImage);
                Source = internalSource;
            }
      
            private string GetImageFilled(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return CloseFilled.Black;
                    case ColorUI.Blue:
                        return CloseFilled.Blue;
                    case ColorUI.Gray:
                        return CloseFilled.Gray;
                    case ColorUI.Green:
                        return CloseFilled.Green;
                    case ColorUI.Red:
                        return CloseFilled.Red;
                    case ColorUI.Yellow:
                        return CloseFilled.Yellow;
                    case ColorUI.BlueLight:
                        return CloseFilled.BlueLight;
                    case ColorUI.GreenLight:
                        return CloseFilled.GreenLight;
                    case ColorUI.YellowLight:
                        return CloseFilled.YellowLight;
                    case ColorUI.White:
                        return CloseFilled.White;
                    case ColorUI.Pink:
                        return CloseFilled.Pink;
                    case ColorUI.Orange:
                        return CloseFilled.Orange;
                    case ColorUI.Brown:
                        return CloseFilled.Brown;
                    case ColorUI.Purple:
                        return CloseFilled.Purple;
                    case ColorUI.Turquoise:
                        return CloseFilled.Turquoise;
                    case ColorUI.PinkLight:
                        return CloseFilled.PinkLight;
                    case ColorUI.BlueSky:
                        return CloseFilled.BlueSky;
                    case ColorUI.GrayLight:
                        return CloseFilled.GrayLight;
                    case ColorUI.RedLight:
                        return CloseFilled.RedLight;
                    case ColorUI.OrangeLight:
                        return CloseFilled.OrangeLight;
                    case ColorUI.YellowDark:
                        return CloseFilled.YellowDark;
                    case ColorUI.GreenDark:
                        return CloseFilled.GreenDark;
                    case ColorUI.BlueDark:
                        return CloseFilled.BlueDark;
                    case ColorUI.Aqua:
                        return CloseFilled.Aqua;
                    case ColorUI.Tan:
                        return CloseFilled.Tan;
                    case ColorUI.GreenDarkness:
                        return CloseFilled.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return CloseFilled.BlueViolet;
                    case ColorUI.Transparent:
                        return CloseFilled.White;
                    default:
                        return CloseFilled.Gray;
                }
            }

            private string GetImageFit(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return CloseFit.Black;
                    case ColorUI.Blue:
                        return CloseFit.Blue;
                    case ColorUI.Gray:
                        return CloseFit.Gray;
                    case ColorUI.Green:
                        return CloseFit.Green;
                    case ColorUI.Red:
                        return CloseFit.Red;
                    case ColorUI.Yellow:
                        return CloseFit.Yellow;
                    case ColorUI.BlueLight:
                        return CloseFit.BlueLight;
                    case ColorUI.GreenLight:
                        return CloseFit.GreenLight;
                    case ColorUI.YellowLight:
                        return CloseFit.YellowLight;
                    case ColorUI.White:
                        return CloseFit.White;
                    case ColorUI.Pink:
                        return CloseFit.Pink;
                    case ColorUI.Orange:
                        return CloseFit.Orange;
                    case ColorUI.Brown:
                        return CloseFit.Brown;
                    case ColorUI.Purple:
                        return CloseFit.Purple;
                    case ColorUI.Turquoise:
                        return CloseFit.Turquoise;
                    case ColorUI.PinkLight:
                        return CloseFit.PinkLight;
                    case ColorUI.BlueSky:
                        return CloseFit.BlueSky;
                    case ColorUI.GrayLight:
                        return CloseFit.GrayLight;
                    case ColorUI.RedLight:
                        return CloseFit.RedLight;
                    case ColorUI.OrangeLight:
                        return CloseFit.OrangeLight;
                    case ColorUI.YellowDark:
                        return CloseFit.YellowDark;
                    case ColorUI.GreenDark:
                        return CloseFit.GreenDark;
                    case ColorUI.BlueDark:
                        return CloseFit.BlueDark;
                    case ColorUI.Aqua:
                        return CloseFit.Aqua;
                    case ColorUI.Tan:
                        return CloseFit.Tan;
                    case ColorUI.GreenDarkness:
                        return CloseFit.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return CloseFit.BlueViolet;
                    case ColorUI.Transparent:
                        return CloseFit.White;
                    default:
                        return CloseFit.Gray;
                }
            }

            private string GetImageCadre(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return CloseCadre.Black;
                    case ColorUI.Blue:
                        return CloseCadre.Blue;
                    case ColorUI.Gray:
                        return CloseCadre.Gray;
                    case ColorUI.Green:
                        return CloseCadre.Green;
                    case ColorUI.Red:
                        return CloseCadre.Red;
                    case ColorUI.Yellow:
                        return CloseCadre.Yellow;
                    case ColorUI.BlueLight:
                        return CloseCadre.BlueLight;
                    case ColorUI.GreenLight:
                        return CloseCadre.GreenLight;
                    case ColorUI.YellowLight:
                        return CloseCadre.YellowLight;
                    case ColorUI.White:
                        return CloseCadre.White;
                    case ColorUI.Pink:
                        return CloseCadre.Pink;
                    case ColorUI.Orange:
                        return CloseCadre.Orange;
                    case ColorUI.Brown:
                        return CloseCadre.Brown;
                    case ColorUI.Purple:
                        return CloseCadre.Purple;
                    case ColorUI.Turquoise:
                        return CloseCadre.Turquoise;
                    case ColorUI.PinkLight:
                        return CloseCadre.PinkLight;
                    case ColorUI.BlueSky:
                        return CloseCadre.BlueSky;
                    case ColorUI.GrayLight:
                        return CloseCadre.GrayLight;
                    case ColorUI.RedLight:
                        return CloseCadre.RedLight;
                    case ColorUI.OrangeLight:
                        return CloseCadre.OrangeLight;
                    case ColorUI.YellowDark:
                        return CloseCadre.YellowDark;
                    case ColorUI.GreenDark:
                        return CloseCadre.GreenDark;
                    case ColorUI.BlueDark:
                        return CloseCadre.BlueDark;
                    case ColorUI.Aqua:
                        return CloseCadre.Aqua;
                    case ColorUI.Tan:
                        return CloseCadre.Tan;
                    case ColorUI.GreenDarkness:
                        return CloseCadre.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return CloseCadre.BlueViolet;
                    case ColorUI.Transparent:
                        return CloseCadre.White;
                    default:
                        return CloseCadre.Gray;
                }
            }

            private string GetImageSmoke(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return CloseSmoke.Black;
                    case ColorUI.Blue:
                        return CloseSmoke.Blue;
                    case ColorUI.Gray:
                        return CloseSmoke.Gray;
                    case ColorUI.Green:
                        return CloseSmoke.Green;
                    case ColorUI.Red:
                        return CloseSmoke.Red;
                    case ColorUI.Yellow:
                        return CloseSmoke.Yellow;
                    case ColorUI.BlueLight:
                        return CloseSmoke.BlueLight;
                    case ColorUI.GreenLight:
                        return CloseSmoke.GreenLight;
                    case ColorUI.YellowLight:
                        return CloseSmoke.YellowLight;
                    case ColorUI.White:
                        return CloseSmoke.White;
                    case ColorUI.Pink:
                        return CloseSmoke.Pink;
                    case ColorUI.Orange:
                        return CloseSmoke.Orange;
                    case ColorUI.Brown:
                        return CloseSmoke.Brown;
                    case ColorUI.Purple:
                        return CloseSmoke.Purple;
                    case ColorUI.Turquoise:
                        return CloseSmoke.Turquoise;
                    case ColorUI.PinkLight:
                        return CloseSmoke.PinkLight;
                    case ColorUI.BlueSky:
                        return CloseSmoke.BlueSky;
                    case ColorUI.GrayLight:
                        return CloseSmoke.GrayLight;
                    case ColorUI.RedLight:
                        return CloseSmoke.RedLight;
                    case ColorUI.OrangeLight:
                        return CloseSmoke.OrangeLight;
                    case ColorUI.YellowDark:
                        return CloseSmoke.YellowDark;
                    case ColorUI.GreenDark:
                        return CloseSmoke.GreenDark;
                    case ColorUI.BlueDark:
                        return CloseSmoke.BlueDark;
                    case ColorUI.Aqua:
                        return CloseSmoke.Aqua;
                    case ColorUI.Tan:
                        return CloseSmoke.Tan;
                    case ColorUI.GreenDarkness:
                        return CloseSmoke.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return CloseSmoke.BlueViolet;
                    case ColorUI.Transparent:
                        return CloseSmoke.White;
                    default:
                        return CloseSmoke.Gray;
                }
            }

            private string GetImageScratches(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return CloseScratches.Black;
                    case ColorUI.Blue:
                        return CloseScratches.Blue;
                    case ColorUI.Gray:
                        return CloseScratches.Gray;
                    case ColorUI.Green:
                        return CloseScratches.Green;
                    case ColorUI.Red:
                        return CloseScratches.Red;
                    case ColorUI.Yellow:
                        return CloseScratches.Yellow;
                    case ColorUI.BlueLight:
                        return CloseScratches.BlueLight;
                    case ColorUI.GreenLight:
                        return CloseScratches.GreenLight;
                    case ColorUI.YellowLight:
                        return CloseScratches.YellowLight;
                    case ColorUI.White:
                        return CloseScratches.White;
                    case ColorUI.Pink:
                        return CloseScratches.Pink;
                    case ColorUI.Orange:
                        return CloseScratches.Orange;
                    case ColorUI.Brown:
                        return CloseScratches.Brown;
                    case ColorUI.Purple:
                        return CloseScratches.Purple;
                    case ColorUI.Turquoise:
                        return CloseScratches.Turquoise;
                    case ColorUI.PinkLight:
                        return CloseScratches.PinkLight;
                    case ColorUI.BlueSky:
                        return CloseScratches.BlueSky;
                    case ColorUI.GrayLight:
                        return CloseScratches.GrayLight;
                    case ColorUI.RedLight:
                        return CloseScratches.RedLight;
                    case ColorUI.OrangeLight:
                        return CloseScratches.OrangeLight;
                    case ColorUI.YellowDark:
                        return CloseScratches.YellowDark;
                    case ColorUI.GreenDark:
                        return CloseScratches.GreenDark;
                    case ColorUI.BlueDark:
                        return CloseScratches.BlueDark;
                    case ColorUI.Aqua:
                        return CloseScratches.Aqua;
                    case ColorUI.Tan:
                        return CloseScratches.Tan;
                    case ColorUI.GreenDarkness:
                        return CloseScratches.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return CloseScratches.BlueViolet;
                    case ColorUI.Transparent:
                        return CloseScratches.White;
                    default:
                        return CloseScratches.Gray;
                }
            }

            private string GetImageShinning(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return CloseShinning.Black;
                    case ColorUI.Blue:
                        return CloseShinning.Blue;
                    case ColorUI.Gray:
                        return CloseShinning.Gray;
                    case ColorUI.Green:
                        return CloseShinning.Green;
                    case ColorUI.Red:
                        return CloseShinning.Red;
                    case ColorUI.Yellow:
                        return CloseShinning.Yellow;
                    case ColorUI.BlueLight:
                        return CloseShinning.BlueLight;
                    case ColorUI.GreenLight:
                        return CloseShinning.GreenLight;
                    case ColorUI.YellowLight:
                        return CloseShinning.YellowLight;
                    case ColorUI.White:
                        return CloseShinning.White;
                    case ColorUI.Pink:
                        return CloseShinning.Pink;
                    case ColorUI.Orange:
                        return CloseShinning.Orange;
                    case ColorUI.Brown:
                        return CloseShinning.Brown;
                    case ColorUI.Purple:
                        return CloseShinning.Purple;
                    case ColorUI.Turquoise:
                        return CloseShinning.Turquoise;
                    case ColorUI.PinkLight:
                        return CloseShinning.PinkLight;
                    case ColorUI.BlueSky:
                        return CloseShinning.BlueSky;
                    case ColorUI.GrayLight:
                        return CloseShinning.GrayLight;
                    case ColorUI.RedLight:
                        return CloseShinning.RedLight;
                    case ColorUI.OrangeLight:
                        return CloseShinning.OrangeLight;
                    case ColorUI.YellowDark:
                        return CloseShinning.YellowDark;
                    case ColorUI.GreenDark:
                        return CloseShinning.GreenDark;
                    case ColorUI.BlueDark:
                        return CloseShinning.BlueDark;
                    case ColorUI.Aqua:
                        return CloseShinning.Aqua;
                    case ColorUI.Tan:
                        return CloseShinning.Tan;
                    case ColorUI.GreenDarkness:
                        return CloseShinning.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return CloseShinning.BlueViolet;
                    case ColorUI.Transparent:
                        return CloseShinning.White;
                    default:
                        return CloseShinning.Gray;
                }
            }

            private string GetImageAllonsy(ColorUI color)
            {
                switch (color)
                {
                    case ColorUI.Black:
                        return CloseAllonsy.Black;
                    case ColorUI.Blue:
                        return CloseAllonsy.Blue;
                    case ColorUI.Gray:
                        return CloseAllonsy.Gray;
                    case ColorUI.Green:
                        return CloseAllonsy.Green;
                    case ColorUI.Red:
                        return CloseAllonsy.Red;
                    case ColorUI.Yellow:
                        return CloseAllonsy.Yellow;
                    case ColorUI.BlueLight:
                        return CloseAllonsy.BlueLight;
                    case ColorUI.GreenLight:
                        return CloseAllonsy.GreenLight;
                    case ColorUI.YellowLight:
                        return CloseAllonsy.YellowLight;
                    case ColorUI.White:
                        return CloseAllonsy.White;
                    case ColorUI.Pink:
                        return CloseAllonsy.Pink;
                    case ColorUI.Orange:
                        return CloseAllonsy.Orange;
                    case ColorUI.Brown:
                        return CloseAllonsy.Brown;
                    case ColorUI.Purple:
                        return CloseAllonsy.Purple;
                    case ColorUI.Turquoise:
                        return CloseAllonsy.Turquoise;
                    case ColorUI.PinkLight:
                        return CloseAllonsy.PinkLight;
                    case ColorUI.BlueSky:
                        return CloseAllonsy.BlueSky;
                    case ColorUI.GrayLight:
                        return CloseAllonsy.GrayLight;
                    case ColorUI.RedLight:
                        return CloseAllonsy.RedLight;
                    case ColorUI.OrangeLight:
                        return CloseAllonsy.OrangeLight;
                    case ColorUI.YellowDark:
                        return CloseAllonsy.YellowDark;
                    case ColorUI.GreenDark:
                        return CloseAllonsy.GreenDark;
                    case ColorUI.BlueDark:
                        return CloseAllonsy.BlueDark;
                    case ColorUI.Aqua:
                        return CloseAllonsy.Aqua;
                    case ColorUI.Tan:
                        return CloseAllonsy.Tan;
                    case ColorUI.GreenDarkness:
                        return CloseAllonsy.GreenDarkness;
                    case ColorUI.BlueViolet:
                        return CloseAllonsy.BlueViolet;
                    case ColorUI.Transparent:
                        return CloseAllonsy.White;
                    default:
                        return CloseAllonsy.Gray;
                }
            }

            private string GetColor(ColorUI color, DesignType designType)
            {
                MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + designType.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

                object[] parametersInvoke = { color };

                var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
                return returnStringColor;
            }
        }
    }
}
