using Xamarin.Forms;

namespace LaavorInputImage
{
    /// <summary>
    /// Colors UI Laavor
    /// </summary>
    public enum ColorUI
    {
        /// <summary>
        /// Black Color
        /// </summary>
        Black = 0,
        /// <summary>
        /// Blue Color
        /// </summary>
        Blue = 1,
        /// <summary>
        /// Gray Color
        /// </summary>
        Gray = 2,
        /// <summary>
        /// Green Color
        /// </summary>
        Green = 3,
        /// <summary>
        /// Red Color
        /// </summary>
        Red = 4,
        /// <summary>
        /// Yellow Color
        /// </summary>
        Yellow = 5,
        /// <summary>
        /// Orange Color
        /// </summary>
        Orange = 6,
        /// <summary>
        /// Pink Color
        /// </summary>
        Pink = 7,
        /// <summary>
        /// White Color
        /// </summary>
        White = 8,
        /// <summary>
        /// BlueLight Color
        /// </summary>
        BlueLight = 9,
        /// <summary>
        /// YellowLight Color
        /// </summary>
        YellowLight = 10,
        /// <summary>
        /// GreenLight Color
        /// </summary>,
        GreenLight = 11,
        /// <summary>
        /// Brown Color
        /// </summary>
        Brown = 12,
        /// <summary>
        /// Purple Color
        /// </summary>
        Purple = 13,
        /// <summary>
        /// Turquoise Color
        /// </summary>
        Turquoise = 14,
        /// <summary>
        /// PinkLight Color
        /// </summary>
        PinkLight = 15,
        /// <summary>
        /// BlueSky Color
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
                    return Color.FromHex("#000000");
                case ColorUI.Blue:
                    return Color.FromHex("#0000FF");
                case ColorUI.Gray:
                    return Color.FromHex("#808080");
                case ColorUI.Green:
                    return Color.FromHex("#008000");
                case ColorUI.Red:
                    return Color.FromHex("#FF0000");
                case ColorUI.Yellow:
                    return Color.FromHex("#FFFF00");
                case ColorUI.BlueLight:
                    return Color.FromHex("#5599FF");
                case ColorUI.GreenLight:
                    return Color.FromHex("#00FF00");
                case ColorUI.YellowLight:
                    return Color.FromHex("#FFEEAA");
                case ColorUI.White:
                    return Color.FromHex("#FFFFFF");
                case ColorUI.Pink:
                    return Color.FromHex("#FF00FF");
                case ColorUI.Orange:
                    return Color.FromHex("#FF6600");
                case ColorUI.Brown:
                    return Color.FromHex("#803300");
                case ColorUI.Purple:
                    return Color.FromHex("#800080");
                case ColorUI.Turquoise:
                    return Color.FromHex("#008080");
                case ColorUI.PinkLight:
                    return Color.FromHex("#FFAACC");
                case ColorUI.BlueSky:
                    return Color.FromHex("#5599FF");
                case ColorUI.GrayLight:
                    return Color.FromHex("#CCCCCC");
                case ColorUI.RedLight:
                    return Color.FromHex("#FF8080");
                case ColorUI.OrangeLight:
                    return Color.FromHex("#FFB380");
                case ColorUI.YellowDark:
                    return Color.FromHex("#FFCC00");
                case ColorUI.GreenDark:
                    return Color.FromHex("#225500");
                case ColorUI.BlueDark:
                    return Color.FromHex("#002255");
                case ColorUI.Aqua:
                    return Color.FromHex("#00FFFF");
                case ColorUI.Tan:
                    return Color.FromHex("#AC9D93");
                case ColorUI.GreenDarkness:
                    return Color.FromHex("#002200");
                case ColorUI.BlueViolet:
                    return Color.FromHex("#8A2BE2");
                default:
                    return Color.FromHex("#CCCCCC");
            }
        }
    }
}
