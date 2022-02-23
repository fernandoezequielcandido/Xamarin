using System;
using System.Reflection;
using Xamarin.Forms;

namespace Laavor
{
    /// <summary>
    /// Class ArrowControl
    /// </summary>
    public class ArrowControl : Image
    {
        private ImageSource internalSource;
        private ColorUI currentColor;
        private Side currentSide;
        private DesignType currentDesignType;

        /// <summary>
        /// Number of item is a list
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Current value
        /// </summary>
        public bool Current { get; private set; }

        /// <summary>
        /// Constructor of ArrowImage
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="color"></param>
        /// <param name="side"></param>
        /// <param name="index"></param>
        /// <param name="current"></param>
        /// <param name="designType"></param>
        public ArrowControl(string hash, ColorUI color, Side side, int index, bool current, DesignType designType)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in Constructor");
            }

            currentColor = color;
            Index = index;
            Current = current;
            currentSide = side;
            currentDesignType = designType;

            Aspect = Aspect.Fill;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, side, currentDesignType));
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

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentSide, currentDesignType));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change Index
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="index"></param>
        public void ChangeIndex(string hash, int index)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            Index = index;

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentSide, currentDesignType));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        /// <summary>
        /// Change Current
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="current"></param>
        public void ChangeCurrent(string hash, bool current)
        {
            if (hash != "__Laavor*+-")
            {
                throw new Exception("Key in Invalid in ChangeColor");
            }

            Current = current;

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentSide, currentDesignType));
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

            byte[] imageBytes = Convert.FromBase64String(GetColor(currentColor, currentSide, currentDesignType));
            var streamImage = new System.IO.MemoryStream(imageBytes);

            this.internalSource = ImageSource.FromStream(() => streamImage);
            Source = internalSource;
        }

        private string GetImageSmoke(ColorUI color, Side side)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.BlackLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.BlackRight;
                    }
                case ColorUI.Blue:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.BlueLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.BlueRight;
                    }
                case ColorUI.Gray:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.GrayLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.GrayRight;
                    }
                case ColorUI.Green:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.GreenLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.GreenRight;
                    }
                case ColorUI.Red:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.RedLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.RedRight;
                    }
                case ColorUI.Yellow:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.YellowLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.YellowRight;
                    }
                case ColorUI.BlueLight:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.BlueLightLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.BlueLightRight;
                    }
                case ColorUI.GreenLight:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.GreenLightLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.GreenLightRight;
                    }
                case ColorUI.YellowLight:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.YellowLightLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.YellowLightRight;
                    }
                case ColorUI.White:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.WhiteLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.WhiteRight;
                    }
                case ColorUI.Pink:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.PinkLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.PinkRight;
                    }
                case ColorUI.Orange:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.OrangeLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.OrangeRight;
                    }
                case ColorUI.Brown:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.BrownLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.BrownRight;
                    }
                case ColorUI.Purple:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.PurpleLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.PurpleRight;
                    }
                case ColorUI.Turquoise:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.TurquoiseLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.TurquoiseRight;
                    }
                case ColorUI.PinkLight:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.PinkLightLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.PinkLightRight;
                    }
                case ColorUI.BlueSky:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.BlueSkyLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.BlueSkyRight;
                    }
                case ColorUI.RedLight:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.RedLightLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.RedLightRight;
                    }
                case ColorUI.GrayLight:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.GrayLightLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.GrayLightRight;
                    }
                case ColorUI.OrangeLight:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.OrangeLightLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.OrangeLightRight;
                    }
                case ColorUI.YellowDark:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.YellowDarkLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.YellowDarkRight;
                    }
                case ColorUI.BlueDark:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.BlueDarkLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.BlueDarkRight;
                    }
                case ColorUI.GreenDark:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.GreenDarkLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.GreenDarkRight;
                    }
                case ColorUI.Aqua:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.AquaLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.AquaRight;
                    }
                case ColorUI.Tan:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.TanLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.TanRight;
                    }
                case ColorUI.GreenDarkness:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.GreenDarknessLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.GreenDarknessRight;
                    }
                case ColorUI.BlueViolet:
                    if (side == Side.Left)
                    {
                        return ArrowsSmoke.BlueVioletLeft;
                    }
                    else
                    {
                        return ArrowsSmoke.BlueVioletRight;
                    }
                default:
                    return ArrowsSmoke.BlueSkyLeft;
            }
        }

        private string GetImageCadre(ColorUI color, Side side)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.BlackLeft;
                    }
                    else
                    {
                        return ArrowsCadre.BlackRight;
                    }
                case ColorUI.Blue:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.BlueLeft;
                    }
                    else
                    {
                        return ArrowsCadre.BlueRight;
                    }
                case ColorUI.Gray:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.GrayLeft;
                    }
                    else
                    {
                        return ArrowsCadre.GrayRight;
                    }
                case ColorUI.Green:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.GreenLeft;
                    }
                    else
                    {
                        return ArrowsCadre.GreenRight;
                    }
                case ColorUI.Red:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.RedLeft;
                    }
                    else
                    {
                        return ArrowsCadre.RedRight;
                    }
                case ColorUI.Yellow:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.YellowLeft;
                    }
                    else
                    {
                        return ArrowsCadre.YellowRight;
                    }
                case ColorUI.BlueLight:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.BlueLightLeft;
                    }
                    else
                    {
                        return ArrowsCadre.BlueLightRight;
                    }
                case ColorUI.GreenLight:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.GreenLightLeft;
                    }
                    else
                    {
                        return ArrowsCadre.GreenLightRight;
                    }
                case ColorUI.YellowLight:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.YellowLightLeft;
                    }
                    else
                    {
                        return ArrowsCadre.YellowLightRight;
                    }
                case ColorUI.White:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.WhiteLeft;
                    }
                    else
                    {
                        return ArrowsCadre.WhiteRight;
                    }
                case ColorUI.Pink:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.PinkLeft;
                    }
                    else
                    {
                        return ArrowsCadre.PinkRight;
                    }
                case ColorUI.Orange:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.OrangeLeft;
                    }
                    else
                    {
                        return ArrowsCadre.OrangeRight;
                    }
                case ColorUI.Brown:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.BrownLeft;
                    }
                    else
                    {
                        return ArrowsCadre.BrownRight;
                    }
                case ColorUI.Purple:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.PurpleLeft;
                    }
                    else
                    {
                        return ArrowsCadre.PurpleRight;
                    }
                case ColorUI.Turquoise:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.TurquoiseLeft;
                    }
                    else
                    {
                        return ArrowsCadre.TurquoiseRight;
                    }
                case ColorUI.PinkLight:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.PinkLightLeft;
                    }
                    else
                    {
                        return ArrowsCadre.PinkLightRight;
                    }
                case ColorUI.BlueSky:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.BlueSkyLeft;
                    }
                    else
                    {
                        return ArrowsCadre.BlueSkyRight;
                    }
                case ColorUI.RedLight:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.RedLightLeft;
                    }
                    else
                    {
                        return ArrowsCadre.RedLightRight;
                    }
                case ColorUI.GrayLight:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.GrayLightLeft;
                    }
                    else
                    {
                        return ArrowsCadre.GrayLightRight;
                    }
                case ColorUI.OrangeLight:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.OrangeLightLeft;
                    }
                    else
                    {
                        return ArrowsCadre.OrangeLightRight;
                    }
                case ColorUI.YellowDark:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.YellowDarkLeft;
                    }
                    else
                    {
                        return ArrowsCadre.YellowDarkRight;
                    }
                case ColorUI.BlueDark:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.BlueDarkLeft;
                    }
                    else
                    {
                        return ArrowsCadre.BlueDarkRight;
                    }
                case ColorUI.GreenDark:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.GreenDarkLeft;
                    }
                    else
                    {
                        return ArrowsCadre.GreenDarkRight;
                    }
                case ColorUI.Aqua:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.AquaLeft;
                    }
                    else
                    {
                        return ArrowsCadre.AquaRight;
                    }
                case ColorUI.Tan:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.TanLeft;
                    }
                    else
                    {
                        return ArrowsCadre.TanRight;
                    }
                case ColorUI.GreenDarkness:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.GreenDarknessLeft;
                    }
                    else
                    {
                        return ArrowsCadre.GreenDarknessRight;
                    }
                case ColorUI.BlueViolet:
                    if (side == Side.Left)
                    {
                        return ArrowsCadre.BlueVioletLeft;
                    }
                    else
                    {
                        return ArrowsCadre.BlueVioletRight;
                    }
                default:
                    return ArrowsCadre.BlueSkyLeft;
            }
        }

        private string GetImageAllonsy(ColorUI color, Side side)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.BlackLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.BlackRight;
                    }
                case ColorUI.Blue:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.BlueLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.BlueRight;
                    }
                case ColorUI.Gray:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.GrayLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.GrayRight;
                    }
                case ColorUI.Green:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.GreenLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.GreenRight;
                    }
                case ColorUI.Red:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.RedLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.RedRight;
                    }
                case ColorUI.Yellow:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.YellowLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.YellowRight;
                    }
                case ColorUI.BlueLight:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.BlueLightLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.BlueLightRight;
                    }
                case ColorUI.GreenLight:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.GreenLightLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.GreenLightRight;
                    }
                case ColorUI.YellowLight:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.YellowLightLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.YellowLightRight;
                    }
                case ColorUI.White:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.WhiteLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.WhiteRight;
                    }
                case ColorUI.Pink:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.PinkLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.PinkRight;
                    }
                case ColorUI.Orange:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.OrangeLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.OrangeRight;
                    }
                case ColorUI.Brown:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.BrownLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.BrownRight;
                    }
                case ColorUI.Purple:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.PurpleLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.PurpleRight;
                    }
                case ColorUI.Turquoise:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.TurquoiseLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.TurquoiseRight;
                    }
                case ColorUI.PinkLight:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.PinkLightLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.PinkLightRight;
                    }
                case ColorUI.BlueSky:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.BlueSkyLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.BlueSkyRight;
                    }
                case ColorUI.RedLight:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.RedLightLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.RedLightRight;
                    }
                case ColorUI.GrayLight:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.GrayLightLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.GrayLightRight;
                    }
                case ColorUI.OrangeLight:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.OrangeLightLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.OrangeLightRight;
                    }
                case ColorUI.YellowDark:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.YellowDarkLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.YellowDarkRight;
                    }
                case ColorUI.BlueDark:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.BlueDarkLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.BlueDarkRight;
                    }
                case ColorUI.GreenDark:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.GreenDarkLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.GreenDarkRight;
                    }
                case ColorUI.Aqua:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.AquaLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.AquaRight;
                    }
                case ColorUI.Tan:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.TanLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.TanRight;
                    }
                case ColorUI.GreenDarkness:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.GreenDarknessLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.GreenDarknessRight;
                    }
                case ColorUI.BlueViolet:
                    if (side == Side.Left)
                    {
                        return ArrowsAllonsy.BlueVioletLeft;
                    }
                    else
                    {
                        return ArrowsAllonsy.BlueVioletRight;
                    }
                default:
                    return ArrowsAllonsy.BlueSkyLeft;
            }
        }

        private string GetImageScratches(ColorUI color, Side side)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.BlackLeft;
                    }
                    else
                    {
                        return ArrowsScratches.BlackRight;
                    }
                case ColorUI.Blue:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.BlueLeft;
                    }
                    else
                    {
                        return ArrowsScratches.BlueRight;
                    }
                case ColorUI.Gray:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.GrayLeft;
                    }
                    else
                    {
                        return ArrowsScratches.GrayRight;
                    }
                case ColorUI.Green:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.GreenLeft;
                    }
                    else
                    {
                        return ArrowsScratches.GreenRight;
                    }
                case ColorUI.Red:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.RedLeft;
                    }
                    else
                    {
                        return ArrowsScratches.RedRight;
                    }
                case ColorUI.Yellow:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.YellowLeft;
                    }
                    else
                    {
                        return ArrowsScratches.YellowRight;
                    }
                case ColorUI.BlueLight:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.BlueLightLeft;
                    }
                    else
                    {
                        return ArrowsScratches.BlueLightRight;
                    }
                case ColorUI.GreenLight:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.GreenLightLeft;
                    }
                    else
                    {
                        return ArrowsScratches.GreenLightRight;
                    }
                case ColorUI.YellowLight:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.YellowLightLeft;
                    }
                    else
                    {
                        return ArrowsScratches.YellowLightRight;
                    }
                case ColorUI.White:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.WhiteLeft;
                    }
                    else
                    {
                        return ArrowsScratches.WhiteRight;
                    }
                case ColorUI.Pink:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.PinkLeft;
                    }
                    else
                    {
                        return ArrowsScratches.PinkRight;
                    }
                case ColorUI.Orange:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.OrangeLeft;
                    }
                    else
                    {
                        return ArrowsScratches.OrangeRight;
                    }
                case ColorUI.Brown:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.BrownLeft;
                    }
                    else
                    {
                        return ArrowsScratches.BrownRight;
                    }
                case ColorUI.Purple:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.PurpleLeft;
                    }
                    else
                    {
                        return ArrowsScratches.PurpleRight;
                    }
                case ColorUI.Turquoise:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.TurquoiseLeft;
                    }
                    else
                    {
                        return ArrowsScratches.TurquoiseRight;
                    }
                case ColorUI.PinkLight:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.PinkLightLeft;
                    }
                    else
                    {
                        return ArrowsScratches.PinkLightRight;
                    }
                case ColorUI.BlueSky:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.BlueSkyLeft;
                    }
                    else
                    {
                        return ArrowsScratches.BlueSkyRight;
                    }
                case ColorUI.RedLight:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.RedLightLeft;
                    }
                    else
                    {
                        return ArrowsScratches.RedLightRight;
                    }
                case ColorUI.GrayLight:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.GrayLightLeft;
                    }
                    else
                    {
                        return ArrowsScratches.GrayLightRight;
                    }
                case ColorUI.OrangeLight:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.OrangeLightLeft;
                    }
                    else
                    {
                        return ArrowsScratches.OrangeLightRight;
                    }
                case ColorUI.YellowDark:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.YellowDarkLeft;
                    }
                    else
                    {
                        return ArrowsScratches.YellowDarkRight;
                    }
                case ColorUI.BlueDark:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.BlueDarkLeft;
                    }
                    else
                    {
                        return ArrowsScratches.BlueDarkRight;
                    }
                case ColorUI.GreenDark:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.GreenDarkLeft;
                    }
                    else
                    {
                        return ArrowsScratches.GreenDarkRight;
                    }
                case ColorUI.Aqua:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.AquaLeft;
                    }
                    else
                    {
                        return ArrowsScratches.AquaRight;
                    }
                case ColorUI.Tan:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.TanLeft;
                    }
                    else
                    {
                        return ArrowsScratches.TanRight;
                    }
                case ColorUI.GreenDarkness:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.GreenDarknessLeft;
                    }
                    else
                    {
                        return ArrowsScratches.GreenDarknessRight;
                    }
                case ColorUI.BlueViolet:
                    if (side == Side.Left)
                    {
                        return ArrowsScratches.BlueVioletLeft;
                    }
                    else
                    {
                        return ArrowsScratches.BlueVioletRight;
                    }
                default:
                    return ArrowsScratches.BlueSkyLeft;
            }
        }

        private string GetImageFilled(ColorUI color, Side side)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.BlackLeft;
                    }
                    else
                    {
                        return ArrowsFilled.BlackRight;
                    }
                case ColorUI.Blue:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.BlueLeft;
                    }
                    else
                    {
                        return ArrowsFilled.BlueRight;
                    }
                case ColorUI.Gray:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.GrayLeft;
                    }
                    else
                    {
                        return ArrowsFilled.GrayRight;
                    }
                case ColorUI.Green:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.GreenLeft;
                    }
                    else
                    {
                        return ArrowsFilled.GreenRight;
                    }
                case ColorUI.Red:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.RedLeft;
                    }
                    else
                    {
                        return ArrowsFilled.RedRight;
                    }
                case ColorUI.Yellow:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.YellowLeft;
                    }
                    else
                    {
                        return ArrowsFilled.YellowRight;
                    }
                case ColorUI.BlueLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.BlueLightLeft;
                    }
                    else
                    {
                        return ArrowsFilled.BlueLightRight;
                    }
                case ColorUI.GreenLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.GreenLightLeft;
                    }
                    else
                    {
                        return ArrowsFilled.GreenLightRight;
                    }
                case ColorUI.YellowLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.YellowLightLeft;
                    }
                    else
                    {
                        return ArrowsFilled.YellowLightRight;
                    }
                case ColorUI.White:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.WhiteLeft;
                    }
                    else
                    {
                        return ArrowsFilled.WhiteRight;
                    }
                case ColorUI.Pink:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.PinkLeft;
                    }
                    else
                    {
                        return ArrowsFilled.PinkRight;
                    }
                case ColorUI.Orange:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.OrangeLeft;
                    }
                    else
                    {
                        return ArrowsFilled.OrangeRight;
                    }
                case ColorUI.Brown:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.BrownLeft;
                    }
                    else
                    {
                        return ArrowsFilled.BrownRight;
                    }
                case ColorUI.Purple:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.PurpleLeft;
                    }
                    else
                    {
                        return ArrowsFilled.PurpleRight;
                    }
                case ColorUI.Turquoise:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.TurquoiseLeft;
                    }
                    else
                    {
                        return ArrowsFilled.TurquoiseRight;
                    }
                case ColorUI.PinkLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.PinkLightLeft;
                    }
                    else
                    {
                        return ArrowsFilled.PinkLightRight;
                    }
                case ColorUI.BlueSky:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.BlueSkyLeft;
                    }
                    else
                    {
                        return ArrowsFilled.BlueSkyRight;
                    }
                case ColorUI.RedLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.RedLightLeft;
                    }
                    else
                    {
                        return ArrowsFilled.RedLightRight;
                    }
                case ColorUI.GrayLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.GrayLightLeft;
                    }
                    else
                    {
                        return ArrowsFilled.GrayLightRight;
                    }
                case ColorUI.OrangeLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.OrangeLightLeft;
                    }
                    else
                    {
                        return ArrowsFilled.OrangeLightRight;
                    }
                case ColorUI.YellowDark:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.YellowDarkLeft;
                    }
                    else
                    {
                        return ArrowsFilled.YellowDarkRight;
                    }
                case ColorUI.BlueDark:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.BlueDarkLeft;
                    }
                    else
                    {
                        return ArrowsFilled.BlueDarkRight;
                    }
                case ColorUI.GreenDark:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.GreenDarkLeft;
                    }
                    else
                    {
                        return ArrowsFilled.GreenDarkRight;
                    }
                case ColorUI.Aqua:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.AquaLeft;
                    }
                    else
                    {
                        return ArrowsFilled.AquaRight;
                    }
                case ColorUI.Tan:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.TanLeft;
                    }
                    else
                    {
                        return ArrowsFilled.TanRight;
                    }
                case ColorUI.GreenDarkness:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.GreenDarknessLeft;
                    }
                    else
                    {
                        return ArrowsFilled.GreenDarknessRight;
                    }
                case ColorUI.BlueViolet:
                    if (side == Side.Left)
                    {
                        return ArrowsFilled.BlueVioletLeft;
                    }
                    else
                    {
                        return ArrowsFilled.BlueVioletRight;
                    }
                default:
                    return ArrowsFilled.BlueSkyLeft;
            }
        }

        private string GetImageFit(ColorUI color, Side side)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.BlackLeft;
                    }
                    else
                    {
                        return ArrowsFit.BlackRight;
                    }
                case ColorUI.Blue:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.BlueLeft;
                    }
                    else
                    {
                        return ArrowsFit.BlueRight;
                    }
                case ColorUI.Gray:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.GrayLeft;
                    }
                    else
                    {
                        return ArrowsFit.GrayRight;
                    }
                case ColorUI.Green:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.GreenLeft;
                    }
                    else
                    {
                        return ArrowsFit.GreenRight;
                    }
                case ColorUI.Red:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.RedLeft;
                    }
                    else
                    {
                        return ArrowsFit.RedRight;
                    }
                case ColorUI.Yellow:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.YellowLeft;
                    }
                    else
                    {
                        return ArrowsFit.YellowRight;
                    }
                case ColorUI.BlueLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.BlueLightLeft;
                    }
                    else
                    {
                        return ArrowsFit.BlueLightRight;
                    }
                case ColorUI.GreenLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.GreenLightLeft;
                    }
                    else
                    {
                        return ArrowsFit.GreenLightRight;
                    }
                case ColorUI.YellowLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.YellowLightLeft;
                    }
                    else
                    {
                        return ArrowsFit.YellowLightRight;
                    }
                case ColorUI.White:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.WhiteLeft;
                    }
                    else
                    {
                        return ArrowsFit.WhiteRight;
                    }
                case ColorUI.Pink:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.PinkLeft;
                    }
                    else
                    {
                        return ArrowsFit.PinkRight;
                    }
                case ColorUI.Orange:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.OrangeLeft;
                    }
                    else
                    {
                        return ArrowsFit.OrangeRight;
                    }
                case ColorUI.Brown:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.BrownLeft;
                    }
                    else
                    {
                        return ArrowsFit.BrownRight;
                    }
                case ColorUI.Purple:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.PurpleLeft;
                    }
                    else
                    {
                        return ArrowsFit.PurpleRight;
                    }
                case ColorUI.Turquoise:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.TurquoiseLeft;
                    }
                    else
                    {
                        return ArrowsFit.TurquoiseRight;
                    }
                case ColorUI.PinkLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.PinkLightLeft;
                    }
                    else
                    {
                        return ArrowsFit.PinkLightRight;
                    }
                case ColorUI.BlueSky:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.BlueSkyLeft;
                    }
                    else
                    {
                        return ArrowsFit.BlueSkyRight;
                    }
                case ColorUI.Aqua:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.AquaLeft;
                    }
                    else
                    {
                        return ArrowsFit.AquaRight;
                    }
                case ColorUI.BlueDark:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.BlueDarkLeft;
                    }
                    else
                    {
                        return ArrowsFit.BlueDarkRight;
                    }
                case ColorUI.BlueViolet:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.BlueVioletLeft;
                    }
                    else
                    {
                        return ArrowsFit.BlueVioletRight;
                    }
                case ColorUI.GreenDark:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.GreenDarkLeft;
                    }
                    else
                    {
                        return ArrowsFit.GreenDarkRight;
                    }
                case ColorUI.GreenDarkness:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.GreenDarknessLeft;
                    }
                    else
                    {
                        return ArrowsFit.GreenDarknessRight;
                    }
                case ColorUI.OrangeLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.OrangeLightLeft;
                    }
                    else
                    {
                        return ArrowsFit.OrangeLightRight;
                    }
                case ColorUI.RedLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.RedLightLeft;
                    }
                    else
                    {
                        return ArrowsFit.RedLightRight;
                    }
                case ColorUI.Tan:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.TanLeft;
                    }
                    else
                    {
                        return ArrowsFit.TanRight;
                    }
                case ColorUI.YellowDark:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.YellowDarkLeft;
                    }
                    else
                    {
                        return ArrowsFit.YellowDarkRight;
                    }
                case ColorUI.GrayLight:
                    if (side == Side.Left)
                    {
                        return ArrowsFit.GrayLightLeft;
                    }
                    else
                    {
                        return ArrowsFit.GrayLightRight;
                    }
                default:
                    return ArrowsFit.BlueSkyLeft;
            }
        }

        private string GetImageShinning(ColorUI color, Side side)
        {
            switch (color)
            {
                case ColorUI.Black:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.BlackLeft;
                    }
                    else
                    {
                        return ArrowsShinning.BlackRight;
                    }
                case ColorUI.Blue:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.BlueLeft;
                    }
                    else
                    {
                        return ArrowsShinning.BlueRight;
                    }
                case ColorUI.Gray:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.GrayLeft;
                    }
                    else
                    {
                        return ArrowsShinning.GrayRight;
                    }
                case ColorUI.Green:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.GreenLeft;
                    }
                    else
                    {
                        return ArrowsShinning.GreenRight;
                    }
                case ColorUI.Red:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.RedLeft;
                    }
                    else
                    {
                        return ArrowsShinning.RedRight;
                    }
                case ColorUI.Yellow:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.YellowLeft;
                    }
                    else
                    {
                        return ArrowsShinning.YellowRight;
                    }
                case ColorUI.BlueLight:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.BlueLightLeft;
                    }
                    else
                    {
                        return ArrowsShinning.BlueLightRight;
                    }
                case ColorUI.GreenLight:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.GreenLightLeft;
                    }
                    else
                    {
                        return ArrowsShinning.GreenLightRight;
                    }
                case ColorUI.YellowLight:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.YellowLightLeft;
                    }
                    else
                    {
                        return ArrowsShinning.YellowLightRight;
                    }
                case ColorUI.White:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.WhiteLeft;
                    }
                    else
                    {
                        return ArrowsShinning.WhiteRight;
                    }
                case ColorUI.Pink:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.PinkLeft;
                    }
                    else
                    {
                        return ArrowsShinning.PinkRight;
                    }
                case ColorUI.Orange:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.OrangeLeft;
                    }
                    else
                    {
                        return ArrowsShinning.OrangeRight;
                    }
                case ColorUI.Brown:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.BrownLeft;
                    }
                    else
                    {
                        return ArrowsShinning.BrownRight;
                    }
                case ColorUI.Purple:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.PurpleLeft;
                    }
                    else
                    {
                        return ArrowsShinning.PurpleRight;
                    }
                case ColorUI.Turquoise:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.TurquoiseLeft;
                    }
                    else
                    {
                        return ArrowsShinning.TurquoiseRight;
                    }
                case ColorUI.PinkLight:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.PinkLightLeft;
                    }
                    else
                    {
                        return ArrowsShinning.PinkLightRight;
                    }
                case ColorUI.BlueSky:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.BlueSkyLeft;
                    }
                    else
                    {
                        return ArrowsShinning.BlueSkyRight;
                    }
                case ColorUI.Aqua:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.AquaLeft;
                    }
                    else
                    {
                        return ArrowsShinning.AquaRight;
                    }
                case ColorUI.BlueDark:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.BlueDarkLeft;
                    }
                    else
                    {
                        return ArrowsShinning.BlueDarkRight;
                    }
                case ColorUI.BlueViolet:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.BlueVioletLeft;
                    }
                    else
                    {
                        return ArrowsShinning.BlueVioletRight;
                    }
                case ColorUI.GreenDark:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.GreenDarkLeft;
                    }
                    else
                    {
                        return ArrowsShinning.GreenDarkRight;
                    }
                case ColorUI.GreenDarkness:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.GreenDarknessLeft;
                    }
                    else
                    {
                        return ArrowsShinning.GreenDarknessRight;
                    }
                case ColorUI.OrangeLight:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.OrangeLightLeft;
                    }
                    else
                    {
                        return ArrowsShinning.OrangeLightRight;
                    }
                case ColorUI.RedLight:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.RedLightLeft;
                    }
                    else
                    {
                        return ArrowsShinning.RedLightRight;
                    }
                case ColorUI.Tan:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.TanLeft;
                    }
                    else
                    {
                        return ArrowsShinning.TanRight;
                    }
                case ColorUI.YellowDark:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.YellowDarkLeft;
                    }
                    else
                    {
                        return ArrowsShinning.YellowDarkRight;
                    }
                case ColorUI.GrayLight:
                    if (side == Side.Left)
                    {
                        return ArrowsShinning.GrayLightLeft;
                    }
                    else
                    {
                        return ArrowsShinning.GrayLightRight;
                    }
                default:
                    return ArrowsShinning.BlueSkyLeft;
            }
        }

        private string GetColor(ColorUI color, Side side, DesignType designType)
        {
            MethodInfo methodToInvoke = GetType().GetMethod("GetImage" + designType.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);

            object[] parametersInvoke = { color, side };

            var returnStringColor = (string)methodToInvoke.Invoke(this, parametersInvoke);
            return returnStringColor;
        }
    }
}
