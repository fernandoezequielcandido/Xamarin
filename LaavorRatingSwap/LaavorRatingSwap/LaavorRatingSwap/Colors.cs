using Xamarin.Forms;

namespace LaavorRatingSwap
{
    /// <summary>
    /// Colors UI Laavor
    /// </summary>
    public enum ColorUI
    {
        /// <summary>
        /// Black
        /// </summary>
        Black = 0,
        /// <summary>
        /// Blue
        /// </summary>
        Blue = 1,
        /// <summary>
        /// Gray
        /// </summary>
        Gray = 2,
        /// <summary>
        /// Green
        /// </summary>
        Green = 3,
        /// <summary>
        /// Red
        /// </summary>
        Red = 4,
        /// <summary>
        /// Yellow
        /// </summary>
        Yellow = 5,
        /// <summary>
        /// Orange
        /// </summary>
        Orange = 6,
        /// <summary>
        /// Pink
        /// </summary>
        Pink = 7,
        /// <summary>
        /// White
        /// </summary>
        White = 8,
        /// <summary>
        /// BlueLight
        /// </summary>
        BlueLight = 9,
        /// <summary>
        /// YellowLight
        /// </summary>
        YellowLight = 10,
        /// <summary>
        /// GreenLight
        /// </summary>
        GreenLight = 11,
        /// <summary>
        /// Brown
        /// </summary>
        Brown = 12,
        /// <summary>
        /// Purple 
        /// </summary>
        Purple = 13,
        /// <summary>
        /// Turquoise 
        /// </summary>
        Turquoise = 14,
        /// <summary>
        /// PinkLight 
        /// </summary>
        PinkLight = 15,
        /// <summary>
        /// BlueSky
        /// </summary>
        BlueSky = 16,
        /// <summary>
        /// GrayLight
        /// </summary>
        GrayLight = 17,
        /// <summary>
        /// RedLight
        /// </summary>
        RedLight = 18,
        /// <summary>
        /// OrangeLight
        /// </summary>
        OrangeLight = 19,
        /// <summary>
        /// YellowDark
        /// </summary>
        YellowDark = 20,
        /// <summary>
        /// GreenDark
        /// </summary>
        GreenDark = 21,
        /// <summary>
        /// BlueDark
        /// </summary>
        BlueDark = 22,
        /// <summary>
        /// Aqua
        /// </summary>
        Aqua = 23,
        /// <summary>
        /// Tan
        /// </summary>
        Tan = 24,
        /// <summary>
        /// GreenDarkness
        /// </summary>
        GreenDarkness = 25,
        /// <summary>
        /// BlueViolet
        /// </summary>
        BlueViolet = 26
    }

    /// <summary>
    /// Class Colors
    /// </summary>
    public class Colors
    {
        /// <summary>
        /// Get Method
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color Get(ColorUI color)
        {
            switch (color)
            {
                case ColorUI.Black:
                    return Color.FromRgb(0, 0, 0);
                case ColorUI.Blue:
                    return Color.FromRgb(0, 0, 255);
                case ColorUI.Gray:
                    return Color.FromRgb(128, 128, 128);
                case ColorUI.Green:
                    return Color.FromRgb(0, 128, 0);
                case ColorUI.Red:
                    return Color.FromRgb(255, 0, 0);
                case ColorUI.Yellow:
                    return Color.FromRgb(255, 255, 0);
                case ColorUI.BlueLight:
                    return Color.FromRgb(170, 204, 255);
                case ColorUI.GreenLight:
                    return Color.FromRgb(0, 255, 0);
                case ColorUI.YellowLight:
                    return Color.FromRgb(255, 238, 170);
                case ColorUI.White:
                    return Color.FromRgb(255, 255, 255);
                case ColorUI.Pink:
                    return Color.FromRgb(255, 0, 255);
                case ColorUI.Orange:
                    return Color.FromRgb(255, 102, 0);
                case ColorUI.Brown:
                    return Color.FromRgb(128, 51, 0);
                case ColorUI.Purple:
                    return Color.FromRgb(128, 0, 128);
                case ColorUI.Turquoise:
                    return Color.FromRgb(0, 128, 128);
                case ColorUI.PinkLight:
                    return Color.FromRgb(255, 170, 204);
                case ColorUI.BlueSky:
                    return Color.FromRgb(85, 153, 255);
                case ColorUI.GrayLight:
                    return Color.FromRgb(204, 204, 204);
                case ColorUI.RedLight:
                    return Color.FromRgb(255, 128, 128);
                case ColorUI.OrangeLight:
                    return Color.FromRgb(255, 179, 128);
                case ColorUI.YellowDark:
                    return Color.FromRgb(255, 204, 0);
                case ColorUI.GreenDark:
                    return Color.FromRgb(34, 85, 0);
                case ColorUI.BlueDark:
                    return Color.FromRgb(0, 34, 85);
                case ColorUI.Aqua:
                    return Color.FromRgb(0, 255, 255);
                case ColorUI.Tan:
                    return Color.FromRgb(172, 157, 147);
                case ColorUI.GreenDarkness:
                    return Color.FromRgb(0, 34, 0);
                case ColorUI.BlueViolet:
                    return Color.FromRgb(138, 43, 226);
                default:
                    return Color.FromRgb(204, 204, 204);
            }
        }
    }
}
