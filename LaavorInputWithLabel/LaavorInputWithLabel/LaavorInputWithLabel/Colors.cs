using Xamarin.Forms;

namespace LaavorInputWithLabel
{
    /// <summary>
    /// Colors UI Laavor
    /// </summary>
    public enum ColorUI
    {
        /// <summary>
        /// Aqua
        /// </summary>
        Aqua = 0,
        /// <summary>
        /// Black
        /// </summary>
        Black = 1,
        /// <summary>
        /// Blue
        /// </summary>
        Blue = 2,
        /// <summary>
        /// BlueDark
        /// </summary>
        BlueDark = 3,
        /// <summary>
        /// BlueLight
        /// </summary>
        BlueLight = 4,
        /// <summary>
        /// BlueSky
        /// </summary>
        BlueSky = 5,
        /// <summary>
        /// BlueViolet
        /// </summary>
        BlueViolet = 6,
        /// <summary>
        /// Brown
        /// </summary>
        Brown = 7,
        /// <summary>
        /// Gray
        /// </summary>
        Gray = 8,
        /// <summary>
        /// GrayLight
        /// </summary>
        GrayLight = 9,
        /// <summary>
        /// Green
        /// </summary>
        Green = 10,
        /// <summary>
        /// GreenDark
        /// </summary>
        GreenDark = 11,
        /// <summary>
        /// GreenDarkness
        /// </summary>
        GreenDarkness = 12,
        /// <summary>
        /// GreenLight
        /// </summary>
        GreenLight = 13,
        /// <summary>
        /// Orange
        /// </summary>
        Orange = 14,
        /// <summary>
        /// OrangeLight
        /// </summary>
        OrangeLight = 15,
        /// <summary>
        /// Pink
        /// </summary>
        Pink = 16,
        /// <summary>
        /// PinkLight 
        /// </summary>
        PinkLight = 17,
        /// <summary>
        /// Purple 
        /// </summary>
        Purple = 18,
        /// <summary>
        /// Red
        /// </summary>
        Red = 19,
        /// <summary>
        /// RedLight
        /// </summary>
        RedLight = 20,
        /// <summary>
        /// Tan
        /// </summary>
        Tan = 21,
        /// <summary>
        /// Transparent
        /// </summary>
        Transparent = 22,
        /// <summary>
        /// Turquoise 
        /// </summary>
        Turquoise = 23,
        /// <summary>
        /// White
        /// </summary>
        White = 24,
        /// <summary>
        /// Yellow
        /// </summary>
        Yellow = 25,
        /// <summary>
        /// YellowDark
        /// </summary>
        YellowDark = 26,
        /// <summary>
        /// YellowLight
        /// </summary>
        YellowLight = 27
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
                    return Color.White;
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
                case ColorUI.Transparent:
                    return Color.Transparent;
                default:
                    return Color.FromHex("#CCCCCC");
            }
        }
    }
}
