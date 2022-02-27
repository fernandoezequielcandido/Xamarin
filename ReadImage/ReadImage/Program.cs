using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReadImage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //readColorsLine();

            readColorsAll();
            //string _2 = "d://img//Aqua.png";
            //Byte[] byte_2 = System.IO.File.ReadAllBytes(_2);
            //string string_2 = Convert.ToBase64String(byte_2);
            //var ef = 0;

            //string _3 = "d://img//3.png";
            //Byte[] byte_3 = System.IO.File.ReadAllBytes(_3);
            //string string_3 = Convert.ToBase64String(byte_3);

            //string _4 = "d://img//4.png";
            //Byte[] byte_4 = System.IO.File.ReadAllBytes(_4);
            //string string_4 = Convert.ToBase64String(byte_4);

            //   var _5 = "5";
            //   readColorsAllResxLeft();

            //  readColorsAllResxRight();

            //string _1 = "d://img//1.png";
            //Byte[] byte_1 = System.IO.File.ReadAllBytes(_1);
            //string string_1 = Convert.ToBase64String(byte_1);

            var et = 0;
            // readColorsAllResxSelected();

            //            readColorsAllResx();
            printColors();

            // readLetters();

            // readColorsAllResxSelected();


            // readIcons();

            //string default_ = "d://img//default.png";
            //Byte[] bytedefault_ = System.IO.File.ReadAllBytes(default_);
            //string stringdefault_ = Convert.ToBase64String(bytedefault_);


            //string Filled = "d://img//Filled.png";
            //Byte[] byteFilled = System.IO.File.ReadAllBytes(Filled);
            //string stringFilled = Convert.ToBase64String(byteFilled);

            //string Fit = "d://img//Fit.png";
            //Byte[] byteFit = System.IO.File.ReadAllBytes(Fit);
            //string stringFit = Convert.ToBase64String(byteFit);

            ////string Scratches = "d://img//Scratches.png";
            ////Byte[] byteScratches = System.IO.File.ReadAllBytes(Scratches);
            ////string stringScratches = Convert.ToBase64String(byteScratches);

            //string Shinning = "d://img//Shinning.png";
            //Byte[] byteShinning = System.IO.File.ReadAllBytes(Shinning);
            //string stringShinning = Convert.ToBase64String(byteShinning);

            //string Standard = "d://img//Standard.png";
            //Byte[] byteStandard = System.IO.File.ReadAllBytes(Standard);
            //string stringStandard = Convert.ToBase64String(byteStandard);

            //string Tile = "d://img//Tile.png";
            //Byte[] byteTile = System.IO.File.ReadAllBytes(Tile);
            //string stringTile = Convert.ToBase64String(byteTile);


            //var es1 = 0;
            //string checkGreenDark = "d://img//greenDark.png";
            //Byte[] bytecheckGreenDark = System.IO.File.ReadAllBytes(checkGreenDark);
            //string stringCopycheckGreenDark = Convert.ToBase64String(bytecheckGreenDark);

            //string checkBlueDark = "d://img//blueDark.png";
            //Byte[] bytecheckBlueDark = System.IO.File.ReadAllBytes(checkBlueDark);
            //string stringCopycheckBlueDark = Convert.ToBase64String(bytecheckBlueDark);


            //string aqua = "d://img//aqua.png";
            //Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            //string stringaqua = Convert.ToBase64String(byteaqua);

            //string oliva = "d://img//oliva.png";
            //Byte[] byteoliva = System.IO.File.ReadAllBytes(oliva);
            //string stringoliva = Convert.ToBase64String(byteoliva);

            //string str1 = "d://img//black.png";
            //Byte[] byte1 = System.IO.File.ReadAllBytes(str1);
            //string stringCopy1 = Convert.ToBase64String(byte1);

            //string str2 = "d://img//blue.png";
            //Byte[] byte2 = System.IO.File.ReadAllBytes(str2);
            //string stringCopy2 = Convert.ToBase64String(byte2);

            //string str3 = "d://img//gray.png";
            //Byte[] byte3 = System.IO.File.ReadAllBytes(str3);
            //string stringCopy3 = Convert.ToBase64String(byte3);

            //string str4 = "d://img//green.png";
            //Byte[] byte4 = System.IO.File.ReadAllBytes(str4);
            //string stringCopy4 = Convert.ToBase64String(byte4);

            //string str5 = "d://img//red.png";
            //Byte[] byte5 = System.IO.File.ReadAllBytes(str5);
            //string stringCopy5 = Convert.ToBase64String(byte5);

            //string checkBlackaaf = "d://img//blue.png";
            //Byte[] bytecheckBlackaaf = System.IO.File.ReadAllBytes(checkBlackaaf);
            //string stringCopycheckBlackaaf = Convert.ToBase64String(bytecheckBlackaaf);

            //string checkBlueSky = "d://img//blueSky.png";
            //Byte[] bytecheckBlueSky = System.IO.File.ReadAllBytes(checkBlueSky);
            //string stringCopycheckBlueSky = Convert.ToBase64String(bytecheckBlueSky);


            //string checkBlack = "d://img//black.png";
            //Byte[] bytecheckBlack = System.IO.File.ReadAllBytes(checkBlack);
            //string stringCopycheckBlack = Convert.ToBase64String(bytecheckBlack);

            //string checkGreen = "d://img//green.png";
            //Byte[] bytecheckGreen = System.IO.File.ReadAllBytes(checkGreen);
            //string stringCopycheckGreen = Convert.ToBase64String(bytecheckGreen);

            //string checkGray = "d://img//gray.png";
            //Byte[] bytecheckGray = System.IO.File.ReadAllBytes(checkGray);
            //string stringCopycheckGray = Convert.ToBase64String(bytecheckGray);

            //string checkRed = "d://img//red.png";
            //Byte[] bytecheckRed = System.IO.File.ReadAllBytes(checkRed);
            //string stringCopycheckRed = Convert.ToBase64String(bytecheckRed);



            //string checkBlackaa = "d://img//turquoise.png";
            //Byte[] bytecheckBlackaa = System.IO.File.ReadAllBytes(checkBlackaa);
            //string stringCopycheckBlackaa = Convert.ToBase64String(bytecheckBlackaa);





            //string checkYellow = "d://img//yellow.png";
            //Byte[] bytecheckYellow = System.IO.File.ReadAllBytes(checkYellow);
            //string stringCopycheckYellow = Convert.ToBase64String(bytecheckYellow);

            //string checkOrange = "d://img//orange.png";
            //Byte[] bytecheckOrange = System.IO.File.ReadAllBytes(checkOrange);
            //string stringCopycheckOrange = Convert.ToBase64String(bytecheckOrange);

            //string checkPink = "d://img//pink.png";
            //Byte[] bytecheckPink = System.IO.File.ReadAllBytes(checkPink);
            //string stringCopycheckPink = Convert.ToBase64String(bytecheckPink);

            //string checkWhite = "d://img//white.png";
            //Byte[] bytecheckWhite = System.IO.File.ReadAllBytes(checkWhite);
            //string stringCopycheckWhite = Convert.ToBase64String(bytecheckWhite);

            //string checkBlueLight = "d://img//blueLight.png";
            //Byte[] bytecheckBlueLight = System.IO.File.ReadAllBytes(checkBlueLight);
            //string stringCopycheckBlueLight = Convert.ToBase64String(bytecheckBlueLight);

            //string checkYellowLight = "d://img//yellowLight.png";
            //Byte[] bytecheckYellowLight = System.IO.File.ReadAllBytes(checkYellowLight);
            //string stringCopycheckYellowLight = Convert.ToBase64String(bytecheckYellowLight);

            //string checkGreenLight = "d://img//greenLight.png";
            //Byte[] bytecheckGreenLight = System.IO.File.ReadAllBytes(checkGreenLight);
            //string stringCopycheckGreenLight = Convert.ToBase64String(bytecheckGreenLight);

            //string checkPurple = "d://img//purple.png";
            //Byte[] bytecheckPurple = System.IO.File.ReadAllBytes(checkPurple);
            //string stringCopycheckPurple = Convert.ToBase64String(bytecheckPurple);

            ////string checkBlueSky = "d://img//blueSky.png";
            ////Byte[] bytecheckBlueSky = System.IO.File.ReadAllBytes(checkBlueSky);
            ////string stringCopycheckBlueSky = Convert.ToBase64String(bytecheckBlueSky);

            //string checkBrown = "d://img//brown.png";
            //Byte[] bytecheckBrown = System.IO.File.ReadAllBytes(checkBrown);
            //string stringCopycheckBrown = Convert.ToBase64String(bytecheckBrown);

            //string checkPinkLight = "d://img//pinkLight.png";
            //Byte[] bytecheckPinkLight = System.IO.File.ReadAllBytes(checkPinkLight);
            //string stringCopycheckPinkLight = Convert.ToBase64String(bytecheckPinkLight);

            //string tan = "d://img//tan.png";
            //Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            //string stringtan = Convert.ToBase64String(bytetan);

            //string aqua = "d://img//aqua.png";
            //Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            //string stringaqua = Convert.ToBase64String(byteaqua);

            //string checkRedLight = "d://img//redLight.png";
            //Byte[] bytecheckRedLight = System.IO.File.ReadAllBytes(checkRedLight);
            //string stringCopycheckRedLight = Convert.ToBase64String(bytecheckRedLight);

            //string checkGrayLight = "d://img//grayLight.png";
            //Byte[] bytecheckGrayLight = System.IO.File.ReadAllBytes(checkGrayLight);
            //string stringCopycheckGrayLight = Convert.ToBase64String(bytecheckGrayLight);

            //string checkorangeLight = "d://img//orangeLight.png";
            //Byte[] bytecheckorangeLight = System.IO.File.ReadAllBytes(checkorangeLight);
            //string stringCopycheckorangeLight = Convert.ToBase64String(bytecheckorangeLight);

            //string checkyellowDark = "d://img//yellowDark.png";
            //Byte[] bytecheckyellowDark = System.IO.File.ReadAllBytes(checkyellowDark);
            //string stringCopycheckyellowDark = Convert.ToBase64String(bytecheckyellowDark);

            //string checkblueDark = "d://img//blueDark.png";
            //Byte[] bytecheckblueDark = System.IO.File.ReadAllBytes(checkblueDark);
            //string stringCopycheckblueDark = Convert.ToBase64String(bytecheckblueDark);

            //string checkgreenDark = "d://img//greenDark.png";
            //Byte[] bytecheckgreenDark = System.IO.File.ReadAllBytes(checkgreenDark);
            //string stringCopycheckgreenDark = Convert.ToBase64String(bytecheckgreenDark);

            //string aqua = "d://img//aqua.png";
            //Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            //string stringaqua = Convert.ToBase64String(byteaqua);

            //string tan = "d://img//tan.png";
            //Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            //string stringtan = Convert.ToBase64String(bytetan);
            //var et = 0;

        }

        public static void printColors()
        {
            List<string>  _colors = new List<string>();
            foreach (var field in typeof(Xamarin.Forms.Color).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.Default | BindingFlags.NonPublic))
            {
                FieldsColor fieldsColor = new FieldsColor();
                if (field != null && !String.IsNullOrEmpty(field.Name))
                {
                    fieldsColor.Name = field.Name;
                   
                }
                
                    _colors.Add(field.Name);
            }
        }

        public static void readColors()
        {
            StringBuilder stringBuilder = new StringBuilder();

            //string black = "d://img//black.png";
            //Byte[] byteblack = System.IO.File.ReadAllBytes(black);
            //string stringblack = Convert.ToBase64String(byteblack);

            //string blue = "d://img//blue.png";
            //Byte[] byteblue = System.IO.File.ReadAllBytes(blue);
            //string stringblue = Convert.ToBase64String(byteblue);

            //string gray = "d://img//gray.png";
            //Byte[] bytegray = System.IO.File.ReadAllBytes(gray);
            //string stringgray = Convert.ToBase64String(bytegray);

//            string AliceBlue = "d://img//AliceBlue.png";
//            Byte[] byteAliceBlue = System.IO.File.ReadAllBytes(AliceBlue);
//            string stringAliceBlue = Convert.ToBase64String(byteAliceBlue);
//            stringBuilder.AppendLine("string AliceBlue = " + "\"" + stringAliceBlue + "\";");

//            string AntiqueWhite = "d://img//AntiqueWhite.png";
//            Byte[] byteAntiqueWhite = System.IO.File.ReadAllBytes(AntiqueWhite);
//            string stringAntiqueWhite = Convert.ToBase64String(byteAntiqueWhite);
//            stringBuilder.AppendLine("string AntiqueWhite = " + "\"" + stringAntiqueWhite + "\";");

//            string Aqua = "d://img//Aqua.png";
//            Byte[] byteAqua = System.IO.File.ReadAllBytes(Aqua);
//            string stringAqua = Convert.ToBase64String(byteAqua);
//            stringBuilder.AppendLine("string Aqua = " + "\"" + stringAqua + "\";");

//            string Aquamarine = "d://img//Aquamarine.png";
//            Byte[] byteAquamarine = System.IO.File.ReadAllBytes(Aquamarine);
//            string stringAquamarine = Convert.ToBase64String(byteAquamarine);
//            stringBuilder.AppendLine("string Aquamarine = " + "\"" + stringAquamarine + "\";");

//            string Azure = "d://img//Azure.png";
//            Byte[] byteAzure = System.IO.File.ReadAllBytes(Azure);
//            string stringAzure = Convert.ToBase64String(byteAzure);
//            stringBuilder.AppendLine("string Azure = " + "\"" + stringAzure + "\";");

//            string Beige = "d://img//Beige.png";
//            Byte[] byteBeige = System.IO.File.ReadAllBytes(Beige);
//            string stringBeige = Convert.ToBase64String(byteBeige);
//            stringBuilder.AppendLine("string Beige = " + "\"" + stringBeige + "\";");

//            string Bisque = "d://img//Bisque.png";
//            Byte[] byteBisque = System.IO.File.ReadAllBytes(Bisque);
//            string stringBisque = Convert.ToBase64String(byteBisque);
//            stringBuilder.AppendLine("string Bisque = " + "\"" + stringBisque + "\";");

//            string Black = "d://img//Black.png";
//            Byte[] byteBlack = System.IO.File.ReadAllBytes(Black);
//            string stringBlack = Convert.ToBase64String(byteBlack);
//            stringBuilder.AppendLine("string Black = " + "\"" + stringBlack + "\";");

//            string BlanchedAlmond = "d://img//BlanchedAlmond.png";
//            Byte[] byteBlanchedAlmond = System.IO.File.ReadAllBytes(BlanchedAlmond);
//            string stringBlanchedAlmond = Convert.ToBase64String(byteBlanchedAlmond);
//            stringBuilder.AppendLine("string BlanchedAlmond = " + "\"" + stringBlanchedAlmond + "\";");

//            string Blue = "d://img//Blue.png";
//            Byte[] byteBlue = System.IO.File.ReadAllBytes(Blue);
//            string stringBlue = Convert.ToBase64String(byteBlue);
//            stringBuilder.AppendLine("string Blue = " + "\"" + stringBlue + "\";");

//            string BlueViolet = "d://img//BlueViolet.png";
//            Byte[] byteBlueViolet = System.IO.File.ReadAllBytes(BlueViolet);
//            string stringBlueViolet = Convert.ToBase64String(byteBlueViolet);
//            stringBuilder.AppendLine("string BlueViolet = " + "\"" + stringBlueViolet + "\";");

//            string Brown = "d://img//Brown.png";
//            Byte[] byteBrown = System.IO.File.ReadAllBytes(Brown);
//            string stringBrown = Convert.ToBase64String(byteBrown);
//            stringBuilder.AppendLine("string Brown = " + "\"" + stringBrown + "\";");

//            string BurlyWood = "d://img//BurlyWood.png";
//            Byte[] byteBurlyWood = System.IO.File.ReadAllBytes(BurlyWood);
//            string stringBurlyWood = Convert.ToBase64String(byteBurlyWood);
//            stringBuilder.AppendLine("string BurlyWood = " + "\"" + stringBurlyWood + "\";");

//            string CadetBlue = "d://img//CadetBlue.png";
//            Byte[] byteCadetBlue = System.IO.File.ReadAllBytes(CadetBlue);
//            string stringCadetBlue = Convert.ToBase64String(byteCadetBlue);
//            stringBuilder.AppendLine("string Azure = " + "\"" + stringCadetBlue + "\";");
            
//            string Chartreuse = "d://img//Chartreuse.png";
//            Byte[] byteChartreuse = System.IO.File.ReadAllBytes(Chartreuse);
//            string stringChartreuse = Convert.ToBase64String(byteChartreuse);
//            stringBuilder.AppendLine("string Chartreuse = " + "\"" + stringChartreuse + "\";");

//            string Chocolate = "d://img//Chocolate.png";
//            Byte[] byteChocolate = System.IO.File.ReadAllBytes(Chocolate);
//            string stringChocolate = Convert.ToBase64String(byteChocolate);
//            stringBuilder.AppendLine("string Chocolate = " + "\"" + stringChocolate + "\";");

//            string Coral = "d://img//Coral.png";
//            Byte[] byteCoral = System.IO.File.ReadAllBytes(Coral);
//            string stringCoral = Convert.ToBase64String(byteCoral);
//            stringBuilder.AppendLine("string Coral = " + "\"" + stringCoral + "\";");

//            string CornflowerBlue = "d://img//CornflowerBlue.png";
//            Byte[] byteCornflowerBlue = System.IO.File.ReadAllBytes(CornflowerBlue);
//            string stringCornflowerBlue = Convert.ToBase64String(byteCornflowerBlue);
//            stringBuilder.AppendLine("string CornflowerBlue = " + "\"" + stringCornflowerBlue + "\";");

//            string Cornsilk = "d://img//Cornsilk.png";
//            Byte[] byteCornsilk = System.IO.File.ReadAllBytes(Cornsilk);
//            string stringCornsilk = Convert.ToBase64String(byteCornsilk);
//            stringBuilder.AppendLine("string Cornsilk = " + "\"" + stringCornsilk + "\";");

//            string Crimson = "d://img//Crimson.png";
//            Byte[] byteCrimson = System.IO.File.ReadAllBytes(Crimson);
//            string stringCrimson = Convert.ToBase64String(byteCrimson);
//            stringBuilder.AppendLine("string Crimson = " + "\"" + stringCrimson + "\";");

//            string Cyan = "d://img//Cyan.png";
//            Byte[] byteCyan = System.IO.File.ReadAllBytes(Cyan);
//            string stringCyan = Convert.ToBase64String(byteCyan);
//            stringBuilder.AppendLine("string Cyan = " + "\"" + stringCyan + "\";");

//            string DarkBlue = "d://img//DarkBlue.png";
//            Byte[] byteDarkBlue = System.IO.File.ReadAllBytes(DarkBlue);
//            string stringDarkBlue = Convert.ToBase64String(byteDarkBlue);
//            stringBuilder.AppendLine("string DarkBlue = " + "\"" + stringDarkBlue + "\";");

//            string DarkCyan = "d://img//DarkCyan.png";
//            Byte[] byteDarkCyan = System.IO.File.ReadAllBytes(DarkCyan);
//            string stringDarkCyan = Convert.ToBase64String(byteDarkCyan);
//            stringBuilder.AppendLine("string DarkCyan = " + "\"" + stringDarkCyan + "\";");

//            string DarkGoldenrod = "d://img//DarkGoldenrod.png";
//            Byte[] byteDarkGoldenrod = System.IO.File.ReadAllBytes(DarkGoldenrod);
//            string stringDarkGoldenrod = Convert.ToBase64String(byteDarkGoldenrod);
//            stringBuilder.AppendLine("string DarkGoldenrod = " + "\"" + stringDarkGoldenrod + "\";");

//            string DarkGray = "d://img//DarkGray.png";
//            Byte[] byteDarkGray = System.IO.File.ReadAllBytes(DarkGray);
//            string stringDarkGray = Convert.ToBase64String(byteDarkGray);
//            stringBuilder.AppendLine("string DarkGray = " + "\"" + stringDarkGray + "\";");

//            string DarkGreen = "d://img//DarkGreen.png";
//            Byte[] byteDarkGreen = System.IO.File.ReadAllBytes(DarkGreen);
//            string stringDarkGreen = Convert.ToBase64String(byteDarkGreen);
//            stringBuilder.AppendLine("string DarkGreen = " + "\"" + stringDarkGreen + "\";");

//            string DarkKhaki = "d://img//DarkKhaki.png";
//            Byte[] byteDarkKhaki = System.IO.File.ReadAllBytes(DarkKhaki);
//            string stringDarkKhaki = Convert.ToBase64String(byteDarkKhaki);
//            stringBuilder.AppendLine("string DarkKhaki = " + "\"" + stringDarkKhaki + "\";");

//            string DarkMagenta = "d://img//DarkMagenta.png";
//            Byte[] byteDarkMagenta = System.IO.File.ReadAllBytes(DarkMagenta);
//            string stringDarkMagenta = Convert.ToBase64String(byteDarkMagenta);
//            stringBuilder.AppendLine("string DarkMagenta = " + "\"" + stringDarkMagenta + "\";");

//            string DarkOliveGreen = "d://img//DarkOliveGreen.png";
//            Byte[] byteDarkOliveGreen = System.IO.File.ReadAllBytes(DarkOliveGreen);
//            string stringDarkOliveGreen = Convert.ToBase64String(byteDarkOliveGreen);
//            stringBuilder.AppendLine("string DarkOliveGreen = " + "\"" + stringDarkOliveGreen + "\";");

//            string DarkOrange = "d://img//DarkOrange.png";
//            Byte[] byteDarkOrange = System.IO.File.ReadAllBytes(DarkOrange);
//            string stringDarkOrange = Convert.ToBase64String(byteDarkOrange);
//            stringBuilder.AppendLine("string DarkGray = " + "\"" + stringDarkOrange + "\";");

//            string DarkOrchid = "d://img//DarkOrchid.png";
//            Byte[] byteDarkOrchid = System.IO.File.ReadAllBytes(DarkOrchid);
//            string stringDarkOrchid = Convert.ToBase64String(byteDarkOrchid);
//            stringBuilder.AppendLine("string DarkOrchid = " + "\"" + stringDarkOrchid + "\";");

//            string DarkRed = "d://img//DarkRed.png";
//            Byte[] byteDarkRed = System.IO.File.ReadAllBytes(DarkRed);
//            string stringDarkRed = Convert.ToBase64String(byteDarkRed);
//            stringBuilder.AppendLine("string DarkRed = " + "\"" + stringDarkRed + "\";");

//            string DarkSalmon = "d://img//DarkSalmon.png";
//            Byte[] byteDarkSalmon = System.IO.File.ReadAllBytes(DarkSalmon);
//            string stringDarkSalmon = Convert.ToBase64String(byteDarkSalmon);
//            stringBuilder.AppendLine("string DarkSalmon = " + "\"" + stringDarkSalmon + "\";");

//            string DarkSeaGreen = "d://img//DarkSeaGreen.png";
//            Byte[] byteDarkSeaGreen = System.IO.File.ReadAllBytes(DarkSeaGreen);
//            string stringDarkSeaGreen = Convert.ToBase64String(byteDarkSeaGreen);
//            stringBuilder.AppendLine("string DarkSalmon = " + "\"" + stringDarkSeaGreen + "\";");

//            string DarkSlateBlue = "d://img//DarkSlateBlue.png";
//            Byte[] byteDarkSlateBlue = System.IO.File.ReadAllBytes(DarkSlateBlue);
//            string stringDarkSlateBlue = Convert.ToBase64String(byteDarkSlateBlue);
//            stringBuilder.AppendLine("string DarkSlateBlue = " + "\"" + stringDarkSlateBlue + "\";");

//            string DarkSlateGray = "d://img//DarkSlateGray.png";
//            Byte[] byteDarkSlateGray = System.IO.File.ReadAllBytes(DarkSlateGray);
//            string stringDarkSlateGray = Convert.ToBase64String(byteDarkSlateGray);
//            stringBuilder.AppendLine("string DarkSlateGray = " + "\"" + stringDarkSlateGray + "\";");

//            string DarkTurquoise = "d://img//DarkTurquoise.png";
//            Byte[] byteDarkTurquoise = System.IO.File.ReadAllBytes(DarkTurquoise);
//            string stringDarkTurquoise = Convert.ToBase64String(byteDarkTurquoise);
//            stringBuilder.AppendLine("string DarkTurquoise = " + "\"" + stringDarkTurquoise + "\";");

//            string DarkViolet = "d://img//DarkViolet.png";
//            Byte[] byteDarkViolet = System.IO.File.ReadAllBytes(DarkViolet);
//            string stringDarkViolet = Convert.ToBase64String(byteDarkViolet);
//            stringBuilder.AppendLine("string DarkViolet = " + "\"" + stringDarkViolet + "\";");

//            string DeepPink = "d://img//DeepPink.png";
//            Byte[] byteDeepPink = System.IO.File.ReadAllBytes(DeepPink);
//            string stringDeepPink = Convert.ToBase64String(byteDeepPink);
//            stringBuilder.AppendLine("string DeepPink = " + "\"" + stringDeepPink + "\";");

//            string DeepSkyBlue = "d://img//DeepSkyBlue.png";
//            Byte[] byteDeepSkyBlue = System.IO.File.ReadAllBytes(DeepSkyBlue);
//            string stringDeepSkyBlue = Convert.ToBase64String(byteDeepSkyBlue);
//            stringBuilder.AppendLine("string DeepSkyBlue = " + "\"" + stringDeepSkyBlue + "\";");

//            string DimGray = "d://img//DimGray.png";
//            Byte[] byteDimGray = System.IO.File.ReadAllBytes(DimGray);
//            string stringDimGray = Convert.ToBase64String(byteDimGray);
//            stringBuilder.AppendLine("string DarkSalmon = " + "\"" + stringDimGray + "\";");

//            string DodgerBlue = "d://img//DodgerBlue.png";
//            Byte[] byteDodgerBlue = System.IO.File.ReadAllBytes(DodgerBlue);
//            string stringDodgerBlue = Convert.ToBase64String(byteDodgerBlue);
//            stringBuilder.AppendLine("string DodgerBlue = " + "\"" + stringDodgerBlue + "\";");

//            string Firebrick = "d://img//Firebrick.png";
//            Byte[] byteFirebrick = System.IO.File.ReadAllBytes(Firebrick);
//            string stringFirebrick = Convert.ToBase64String(byteFirebrick);
//            stringBuilder.AppendLine("string Firebrick = " + "\"" + stringFirebrick + "\";");

//            string FloralWhite = "d://img//FloralWhite.png";
//            Byte[] byteFloralWhite = System.IO.File.ReadAllBytes(FloralWhite);
//            string stringFloralWhite = Convert.ToBase64String(byteFloralWhite);
//            stringBuilder.AppendLine("string FloralWhite = " + "\"" + stringFloralWhite + "\";");

//            string ForestGreen = "d://img//ForestGreen.png";
//            Byte[] byteForestGreen = System.IO.File.ReadAllBytes(ForestGreen);
//            string stringForestGreen = Convert.ToBase64String(byteForestGreen);
//            stringBuilder.AppendLine("string ForestGreen = " + "\"" + stringForestGreen + "\";");

//            string Fuchsia = "d://img//Fuchsia.png";
//            Byte[] byteFuchsia = System.IO.File.ReadAllBytes(Fuchsia);
//            string stringFuchsia = Convert.ToBase64String(byteFuchsia);
//            stringBuilder.AppendLine("string Fuchsia = " + "\"" + stringFuchsia + "\";");

//            string GainsBoro = "d://img//GainsBoro.png";
//            Byte[] byteGainsBoro = System.IO.File.ReadAllBytes(GainsBoro);
//            string stringGainsBoro = Convert.ToBase64String(byteGainsBoro);
//            stringBuilder.AppendLine("string DodgerBlue = " + "\"" + stringGainsBoro + "\";");

//            string GhostWhite = "d://img//GhostWhite.png";
//            Byte[] byteGhostWhite = System.IO.File.ReadAllBytes(GhostWhite);
//            string stringGhostWhite = Convert.ToBase64String(byteGhostWhite);
//            stringBuilder.AppendLine("string GhostWhite = " + "\"" + stringGhostWhite + "\";");

//            string Gold = "d://img//Gold.png";
//            Byte[] byteGold = System.IO.File.ReadAllBytes(Gold);
//            string stringGold = Convert.ToBase64String(byteGold);
//            stringBuilder.AppendLine("string Gold = " + "\"" + stringGold + "\";");

//            string Goldenrod = "d://img//Goldenrod.png";
//            Byte[] byteGoldenrod = System.IO.File.ReadAllBytes(Goldenrod);
//            string stringGoldenrod = Convert.ToBase64String(byteGoldenrod);
//            stringBuilder.AppendLine("string Goldenrod = " + "\"" + stringGoldenrod + "\";");

//            string Gray = "d://img//Gray.png";
//            Byte[] byteGray = System.IO.File.ReadAllBytes(Gray);
//            string stringGray = Convert.ToBase64String(byteGray);
//            stringBuilder.AppendLine("string Gray = " + "\"" + stringGray + "\";");

//            string Green = "d://img//Green.png";
//            Byte[] byteGreen = System.IO.File.ReadAllBytes(Green);
//            string stringGreen = Convert.ToBase64String(byteGreen);
//            stringBuilder.AppendLine("string Green = " + "\"" + stringGreen + "\";");

//            string GreenYellow = "d://img//GreenYellow.png";
//            Byte[] byteGreenYellow = System.IO.File.ReadAllBytes(GreenYellow);
//            string stringGreenYellow = Convert.ToBase64String(byteGreenYellow);
//            stringBuilder.AppendLine("string GreenYellow = " + "\"" + stringGreenYellow + "\";");

//            string HoneyDew = "d://img//HoneyDew.png";
//            Byte[] byteHoneyDew = System.IO.File.ReadAllBytes(HoneyDew);
//            string stringHoneyDew = Convert.ToBase64String(byteHoneyDew);
//            stringBuilder.AppendLine("string HoneyDew = " + "\"" + stringHoneyDew + "\";");

//            string HotPink = "d://img//HotPink.png";
//            Byte[] byteHotPink = System.IO.File.ReadAllBytes(HotPink);
//            string stringHotPink = Convert.ToBase64String(byteHotPink);
//            stringBuilder.AppendLine("string HotPink = " + "\"" + stringHotPink + "\";");

//            string IndianRed = "d://img//IndianRed.png";
//            Byte[] byteIndianRed = System.IO.File.ReadAllBytes(IndianRed);
//            string stringIndianRed = Convert.ToBase64String(byteIndianRed);
//            stringBuilder.AppendLine("string IndianRed = " + "\"" + stringIndianRed + "\";");

//            string Indigo = "d://img//Indigo.png";
//            Byte[] byteIndigo = System.IO.File.ReadAllBytes(Indigo);
//            string stringIndigo = Convert.ToBase64String(byteIndigo);
//            stringBuilder.AppendLine("string Indigo = " + "\"" + stringIndigo + "\";");

//            string Ivory = "d://img//Ivory.png";
//            Byte[] byteIvory = System.IO.File.ReadAllBytes(Ivory);
//            string stringIvory = Convert.ToBase64String(byteIvory);
//            stringBuilder.AppendLine("string Ivory = " + "\"" + stringIvory + "\";");

//            string Khaki = "d://img//Khaki.png";
//            Byte[] byteKhaki = System.IO.File.ReadAllBytes(Khaki);
//            string stringKhaki = Convert.ToBase64String(byteKhaki);
//            stringBuilder.AppendLine("string Khaki = " + "\"" + stringKhaki + "\";");

//            string Lavender = "d://img//Lavender.png";
//            Byte[] byteLavender = System.IO.File.ReadAllBytes(Lavender);
//            string stringLavender = Convert.ToBase64String(byteLavender);
//            stringBuilder.AppendLine("string HotPink = " + "\"" + stringLavender + "\";");

//            string LavenderBlush = "d://img//LavenderBlush.png";
//            Byte[] byteLavenderBlush = System.IO.File.ReadAllBytes(LavenderBlush);
//            string stringLavenderBlush = Convert.ToBase64String(byteLavenderBlush);
//            stringBuilder.AppendLine("string LavenderBlush = " + "\"" + stringLavenderBlush + "\";");

//            string LawnGreen = "d://img//LawnGreen.png";
//            Byte[] byteLawnGreen = System.IO.File.ReadAllBytes(LawnGreen);
//            string stringLawnGreen = Convert.ToBase64String(byteLawnGreen);
//            stringBuilder.AppendLine("string LawnGreen = " + "\"" + stringLawnGreen + "\";");

//            string LemonChiffon = "d://img//LemonChiffon.png";
//            Byte[] byteLemonChiffon = System.IO.File.ReadAllBytes(LemonChiffon);
//            string stringLemonChiffon = Convert.ToBase64String(byteLemonChiffon);
//            stringBuilder.AppendLine("string LemonChiffon = " + "\"" + stringLemonChiffon + "\";");

//            string LightBlue = "d://img//LightBlue.png";
//            Byte[] byteLightBlue = System.IO.File.ReadAllBytes(LightBlue);
//            string stringLightBlue = Convert.ToBase64String(byteLightBlue);
//            stringBuilder.AppendLine("string LightBlue = " + "\"" + stringLightBlue + "\";");

//            string LightCoral = "d://img//LightCoral.png";
//            Byte[] byteLightCoral = System.IO.File.ReadAllBytes(LightCoral);
//            string stringLightCoral = Convert.ToBase64String(byteLightCoral);
//            stringBuilder.AppendLine("string LightCoral = " + "\"" + stringLightCoral + "\";");
            
//            string LightCyan = "d://img//LightCyan.png";
//            Byte[] byteLightCyan = System.IO.File.ReadAllBytes(LightCyan);
//            string stringLightCyan = Convert.ToBase64String(byteLightCyan);
//            stringBuilder.AppendLine("string LightCyan = " + "\"" + stringLightCyan + "\";");

//            string LightGoldenrodYellow = "d://img//LightGoldenrodYellow.png";
//            Byte[] byteLightGoldenrodYellow = System.IO.File.ReadAllBytes(LightGoldenrodYellow);
//            string stringLightGoldenrodYellow = Convert.ToBase64String(byteLightGoldenrodYellow);
//            stringBuilder.AppendLine("string LightGoldenrodYellow = " + "\"" + stringLightGoldenrodYellow + "\";");

//            string LightGray = "d://img//LightGray.png";
//            Byte[] byteLightGray = System.IO.File.ReadAllBytes(LightGray);
//            string stringLightGray = Convert.ToBase64String(byteLightGray);
//            stringBuilder.AppendLine("string LightGray = " + "\"" + stringLightGray + "\";");

//            string LightGreen = "d://img//LightGreen.png";
//            Byte[] byteLightGreen = System.IO.File.ReadAllBytes(LightGreen);
//            string stringLightGreen = Convert.ToBase64String(byteLightGreen);
//            stringBuilder.AppendLine("string LightGreen = " + "\"" + stringLightGreen + "\";");

//            string LightPink = "d://img//LightPink.png";
//            Byte[] byteLightPink = System.IO.File.ReadAllBytes(LightPink);
//            string stringLightPink = Convert.ToBase64String(byteLightPink);
//            stringBuilder.AppendLine("string LightPink = " + "\"" + stringLightPink + "\";");

//            string LightSalmon = "d://img//LightSalmon.png";
//            Byte[] byteLightSalmon = System.IO.File.ReadAllBytes(LightSalmon);
//            string stringLightSalmon = Convert.ToBase64String(byteLightSalmon);
//            stringBuilder.AppendLine("string LightSalmon = " + "\"" + stringLightSalmon + "\";");

//            string LightSeaGreen = "d://img//LightSeaGreen.png";
//            Byte[] byteLightSeaGreen = System.IO.File.ReadAllBytes(LightSeaGreen);
//            string stringLightSeaGreen = Convert.ToBase64String(byteLightSeaGreen);
//            stringBuilder.AppendLine("string LightSeaGreen = " + "\"" + stringLightSeaGreen + "\";");

//            string LightSkyBlue = "d://img//LightSkyBlue.png";
//            Byte[] byteLightSkyBlue = System.IO.File.ReadAllBytes(LightSkyBlue);
//            string stringLightSkyBlue = Convert.ToBase64String(byteLightSkyBlue);
//            stringBuilder.AppendLine("string LightSkyBlue = " + "\"" + stringLightSkyBlue + "\";");

//            string LightSlateGray = "d://img//LightSlateGray.png";
//            Byte[] byteLightSlateGray = System.IO.File.ReadAllBytes(LightSlateGray);
//            string stringLightSlateGray = Convert.ToBase64String(byteLightSlateGray);
//            stringBuilder.AppendLine("string LightSlateGray = " + "\"" + stringLightSlateGray + "\";");

//            String LightSteelBlue = "d://img//LightSteelBlue.png";
//            Byte[] byteLightSteelBlue = System.IO.File.ReadAllBytes(LightSteelBlue);
//            string stringLightSteelBlue = Convert.ToBase64String(byteLightSteelBlue);
//            stringBuilder.AppendLine("string LightSteelBlue = " + "\"" + stringLightSteelBlue + "\";");

//            string LightYellow = "d://img//LightYellow.png";
//            Byte[] byteLightYellow = System.IO.File.ReadAllBytes(LightYellow);
//            string stringLightYellow = Convert.ToBase64String(byteLightYellow);
//            stringBuilder.AppendLine("string LightYellow = " + "\"" + stringLightYellow + "\";");

//            string Lime = "d://img//Lime.png";
//            Byte[] byteLime = System.IO.File.ReadAllBytes(Lime);
//            string stringLime = Convert.ToBase64String(byteLime);
//            stringBuilder.AppendLine("string Lime = " + "\"" + stringLime + "\";");
            
//            string LimeGreen = "d://img//LimeGreen.png";
//            Byte[] byteLimeGreen = System.IO.File.ReadAllBytes(LimeGreen);
//            string stringLimeGreen = Convert.ToBase64String(byteLimeGreen);
//            stringBuilder.AppendLine("string LimeGreen = " + "\"" + stringLimeGreen + "\";");

//            string Linen = "d://img//Linen.png";
//            Byte[] byteLinen = System.IO.File.ReadAllBytes(Linen);
//            string stringLinen = Convert.ToBase64String(byteLinen);
//            stringBuilder.AppendLine("string Linen = " + "\"" + stringLinen + "\";");

//            string Magenta = "d://img//Magenta.png";
//            Byte[] byteMagenta = System.IO.File.ReadAllBytes(Magenta);
//            string stringMagenta = Convert.ToBase64String(byteMagenta);
//            stringBuilder.AppendLine("string Magenta = " + "\"" + stringv + "\";");

//            string Maroon = "d://img//Maroon.png";
//            Byte[] byteMaroon = System.IO.File.ReadAllBytes(Maroon);
//            string stringMaroon = Convert.ToBase64String(byteMaroon);
//            stringBuilder.AppendLine("string Maroon = " + "\"" + stringMaroon + "\";");

//            string MediumAquamarine = "d://img//MediumAquamarine.png";
//            Byte[] byteMediumAquamarine = System.IO.File.ReadAllBytes(MediumAquamarine);
//            string stringMediumAquamarine = Convert.ToBase64String(byteMediumAquamarine);
//            stringBuilder.AppendLine("string MediumAquamarine = " + "\"" + stringMediumAquamarine + "\";");

//            string MediumBlue = "d://img//MediumBlue.png";
//            Byte[] byteMediumBlue = System.IO.File.ReadAllBytes(MediumBlue);
//            string stringMediumBlue = Convert.ToBase64String(byteMediumBlue);
//            stringBuilder.AppendLine("string MediumBlue = " + "\"" + stringMediumBlue + "\";");

//            string MediumorChid = "d://img//MediumorChid.png";
//            Byte[] byteMediumorChid = System.IO.File.ReadAllBytes(MediumorChid);
//            string stringMediumorChid = Convert.ToBase64String(byteMediumorChid);
//            stringBuilder.AppendLine("string MediumorChid = " + "\"" + stringMediumorChid + "\";");

//            string MediumPurple = "d://img//MediumPurple.png";
//            Byte[] byteMediumPurple = System.IO.File.ReadAllBytes(MediumPurple);
//            string stringMediumPurple = Convert.ToBase64String(byteMediumPurple);
//            stringBuilder.AppendLine("string MediumPurple = " + "\"" + stringMediumPurple + "\";");

//            string MediumSeaGreen = "d://img//MediumSeaGreen.png";
//            Byte[] byteMediumSeaGreen = System.IO.File.ReadAllBytes(MediumSeaGreen);
//            string stringMediumSeaGreen = Convert.ToBase64String(byteMediumSeaGreen);
//            stringBuilder.AppendLine("string MediumSeaGreen = " + "\"" + stringMediumSeaGreen + "\";");

//mediumslateblue	#7B68EE	123, 104, 238
//mediumspringgreen	#00FA9A	0, 250, 154
//mediumturquoise	#48D1CC	72, 209, 204
//mediumvioletred	#C71585	199, 21, 133
//midnightblue	#191970	25, 25, 112
//mintcream	#F5FFFA	245, 255, 250
//mistyrose	#FFE4E1	255, 228, 225
//moccasin	#FFE4B5	255, 228, 181
//navajowhite	#FFDEAD	255, 222, 173
//navy	#000080	0, 0, 128
//oldlace	#FDF5E6	253, 245, 230
//olive	#808000	128, 128, 0
//olivedrab	#6B8E23	107, 142, 35
//orange	#FFA500	255, 165, 0
//orangered	#FF4500	255, 69, 0
//orchid	#DA70D6	218, 112, 214
//palegoldenrod	#EEE8AA	238, 232, 170
//palegreen	#98FB98	152, 251, 152
//paleturquoise	#AFEEEE	175, 238, 238
//palevioletred	#DB7093	219, 112, 147
//papayawhip	#FFEFD5	255, 239, 213
//peachpuff	#FFDAB9	255, 218, 185
//peru	#CD853F	205, 133, 63
//pink	#FFC0CB	255, 192, 203
//plum	#DDA0DD	221, 160, 221
//powderblue	#B0E0E6	176, 224, 230
//purple	#800080	128, 0, 128
//red	#FF0000	255, 0, 0
//rosybrown	#BC8F8F	188, 143, 143
//royalblue	#4169E1	65, 105, 225
//saddlebrown	#8B4513	139, 69, 19
//salmon	#FA8072	250, 128, 114
//sandybrown	#F4A460	244, 164, 96
//seagreen	#2E8B57	46, 139, 87
//seashell	#FFF5EE	255, 245, 238
//sienna	#A0522D	160, 82, 45
//silver	#C0C0C0	192, 192, 192
//skyblue	#87CEEB	135, 206, 235
//slateblue	#6A5ACD	106, 90, 205
//slategray	#708090	112, 128, 144
//snow	#FFFAFA	255, 250, 250
//springgreen	#00FF7F	0, 255, 127
//steelblue	#4682B4	70, 130, 180
//tan	#D2B48C	210, 180, 140
//teal	#008080	0, 128, 128
//thistle	#D8BFD8	216, 191, 216
//tomato	#FF6347	255, 99, 71
//turquoise	#40E0D0	64, 224, 208
//violet	#EE82EE	238, 130, 238
//wheat	#F5DEB3	245, 222, 179
//white	#FFFFFF	255, 255, 255
//whitesmoke	#F5F5F5	245, 245, 245
//yellow	#FFFF00	255, 255, 0
//yellowgreen	#9ACD32	154, 205, 50


//            string green = "d://img//green.png";
//            Byte[] bytegreen = System.IO.File.ReadAllBytes(green);
//            string stringgreen = Convert.ToBase64String(bytegreen);

//            string orange = "d://img//orange.png";
//            Byte[] byteorange = System.IO.File.ReadAllBytes(orange);
//            string stringorange = Convert.ToBase64String(byteorange);

//            string purple = "d://img//purple.png";
//            Byte[] bytepurple = System.IO.File.ReadAllBytes(purple);
//            string stringpurple = Convert.ToBase64String(bytepurple);

//            string yellow = "d://img//yellow.png";
//            Byte[] byteyellow = System.IO.File.ReadAllBytes(yellow);
//            string stringyellow = Convert.ToBase64String(byteyellow);



            var Hedem = 0;
        }

        private static void readColorsLine()
        {
            StringBuilder stringBuilder = new StringBuilder();

            //string checkRedLight = "d://img//redLight.png";
            //Byte[] bytecheckRedLight = System.IO.File.ReadAllBytes(checkRedLight);
            //string stringCopycheckRedLight = Convert.ToBase64String(bytecheckRedLight);

            //stringBuilder.AppendLine("string RedLight = " + "\"" + stringCopycheckRedLight + "\";");

            //string checkGrayLight = "d://img//grayLight.png";
            //Byte[] bytecheckGrayLight = System.IO.File.ReadAllBytes(checkGrayLight);
            //string stringCopycheckGrayLight = Convert.ToBase64String(bytecheckGrayLight);

            //stringBuilder.AppendLine("string GrayLight = " + "\"" + stringCopycheckGrayLight + "\";");

            //string checkorangeLight = "d://img//orangeLight.png";
            //Byte[] bytecheckorangeLight = System.IO.File.ReadAllBytes(checkorangeLight);
            //string stringCopycheckorangeLight = Convert.ToBase64String(bytecheckorangeLight);

            //stringBuilder.AppendLine("string OrangeLight = " + "\"" + stringCopycheckorangeLight + "\";");

            //string checkyellowDark = "d://img//yellowDark.png";
            //Byte[] bytecheckyellowDark = System.IO.File.ReadAllBytes(checkyellowDark);
            //string stringCopycheckyellowDark = Convert.ToBase64String(bytecheckyellowDark);

            //stringBuilder.AppendLine("string YellowDark = " + "\"" + stringCopycheckyellowDark + "\";");

            string checkblueDark = "d://img//blueDark.png";
            Byte[] bytecheckblueDark = System.IO.File.ReadAllBytes(checkblueDark);
            string stringCopycheckblueDark = Convert.ToBase64String(bytecheckblueDark);

            stringBuilder.AppendLine("string BlueDark = " + "\"" + stringCopycheckblueDark + "\";");

            string checkgreenDark = "d://img//greenDark.png";
            Byte[] bytecheckgreenDark = System.IO.File.ReadAllBytes(checkgreenDark);
            string stringCopycheckgreenDark = Convert.ToBase64String(bytecheckgreenDark);

            stringBuilder.AppendLine("string GreenDark = " + "\"" + stringCopycheckgreenDark + "\";");

            string aqua = "d://img//aqua.png";
            Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            string stringaqua = Convert.ToBase64String(byteaqua);

            stringBuilder.AppendLine("string Aqua = " + "\"" + stringaqua + "\";");

            string tan = "d://img//tan.png";
            Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            string stringtan = Convert.ToBase64String(bytetan);

            stringBuilder.AppendLine("string Tan = " + "\"" + stringtan + "\";");

            string greenDarkness = "d://img//greenDarkness.png";
            Byte[] bytegreenDarkness = System.IO.File.ReadAllBytes(greenDarkness);
            string stringgreenDarkness = Convert.ToBase64String(bytegreenDarkness);

            stringBuilder.AppendLine("string GreenDarkness = " + "\"" + stringgreenDarkness + "\";");

            string blueViolet = "d://img//blueViolet.png";
            Byte[] byteblueViolet = System.IO.File.ReadAllBytes(blueViolet);
            string stringblueViolet = Convert.ToBase64String(byteblueViolet);

            stringBuilder.AppendLine("string BlueViolet = " + "\"" + stringblueViolet + "\";");

            var et = 0;
        }

        private static void readColorsAllResxRight()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string blue = "d://img//blue.png";
            Byte[] byteblue = System.IO.File.ReadAllBytes(blue);
            string stringblue = Convert.ToBase64String(byteblue);
            stringBuilder.AppendLine("CheckBoxTraining Blue = new CheckBoxTraining();");
            stringBuilder.AppendLine("<data name = \"BlueRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblue);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string black = "d://img//black.png";
            Byte[] byteblack = System.IO.File.ReadAllBytes(black);
            string stringblack = Convert.ToBase64String(byteblack);

            stringBuilder.AppendLine("<data name = \"BlackRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblack);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string gray = "d://img//gray.png";
            Byte[] bytegray = System.IO.File.ReadAllBytes(gray);
            string stringgray = Convert.ToBase64String(bytegray);

            stringBuilder.AppendLine("<data name = \"GrayRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgray);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string green = "d://img//green.png";
            Byte[] bytegreen = System.IO.File.ReadAllBytes(green);
            string stringgreen = Convert.ToBase64String(bytegreen);

            stringBuilder.AppendLine("<data name = \"GreenRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreen);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string red = "d://img//red.png";
            Byte[] bytered = System.IO.File.ReadAllBytes(red);
            string stringred = Convert.ToBase64String(bytered);

            stringBuilder.AppendLine("<data name = \"RedRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringred);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellow = "d://img//yellow.png";
            Byte[] byteyellow = System.IO.File.ReadAllBytes(yellow);
            string stringyellow = Convert.ToBase64String(byteyellow);

            stringBuilder.AppendLine("<data name = \"YellowRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellow);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueSky = "d://img//blueSky.png";
            Byte[] byteblueSky = System.IO.File.ReadAllBytes(blueSky);
            string stringblueSky = Convert.ToBase64String(byteblueSky);

            stringBuilder.AppendLine("<data name = \"BlueSkyRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueSky);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string brown = "d://img//brown.png";
            Byte[] bytebrown = System.IO.File.ReadAllBytes(brown);
            string stringbrown = Convert.ToBase64String(bytebrown);

            stringBuilder.AppendLine("<data name = \"BrownRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringbrown);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenLight = "d://img//greenLight.png";
            Byte[] bytegreenLight = System.IO.File.ReadAllBytes(greenLight);
            string stringgreenLight = Convert.ToBase64String(bytegreenLight);

            stringBuilder.AppendLine("<data name = \"GreenLightRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pinkLight = "d://img//pinkLight.png";
            Byte[] bytepinkLight = System.IO.File.ReadAllBytes(pinkLight);
            string stringpinkLight = Convert.ToBase64String(bytepinkLight);

            stringBuilder.AppendLine("<data name = \"PinkLightRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpinkLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowLight = "d://img//yellowLight.png";
            Byte[] byteyellowLight = System.IO.File.ReadAllBytes(yellowLight);
            string stringyellowLight = Convert.ToBase64String(byteyellowLight);

            stringBuilder.AppendLine("<data name = \"YellowLightRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueLight = "d://img//blueLight.png";
            Byte[] byteblueLight = System.IO.File.ReadAllBytes(blueLight);
            string stringblueLight = Convert.ToBase64String(byteblueLight);

            stringBuilder.AppendLine("<data name = \"BlueLightRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string turquoise = "d://img//turquoise.png";
            Byte[] byteturquoise = System.IO.File.ReadAllBytes(turquoise);
            string stringturquoise = Convert.ToBase64String(byteturquoise);

            stringBuilder.AppendLine("<data name = \"TurquoiseRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringturquoise);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string purple = "d://img//purple.png";
            Byte[] bytepurple = System.IO.File.ReadAllBytes(purple);
            string stringpurple = Convert.ToBase64String(bytepurple);

            stringBuilder.AppendLine("<data name = \"PurpleRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpurple);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pink = "d://img//pink.png";
            Byte[] bytepink = System.IO.File.ReadAllBytes(pink);
            string stringpink = Convert.ToBase64String(bytepink);

            stringBuilder.AppendLine("<data name = \"PinkRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpink);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string orange = "d://img//orange.png";
            Byte[] byteorange = System.IO.File.ReadAllBytes(orange);
            string stringorange = Convert.ToBase64String(byteorange);

            stringBuilder.AppendLine("<data name = \"OrangeRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorange);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string white = "d://img//white.png";
            Byte[] bytewhite = System.IO.File.ReadAllBytes(white);
            string stringwhite = Convert.ToBase64String(bytewhite);

            stringBuilder.AppendLine("<data name = \"WhiteRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringwhite);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string grayLight = "d://img//grayLight.png";
            Byte[] bytegrayLight = System.IO.File.ReadAllBytes(grayLight);
            string stringgrayLight = Convert.ToBase64String(bytegrayLight);

            stringBuilder.AppendLine("<data name = \"GrayLightRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgrayLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string redLight = "d://img//redLight.png";
            Byte[] byteredLight = System.IO.File.ReadAllBytes(redLight);
            string stringredLight = Convert.ToBase64String(byteredLight);

            stringBuilder.AppendLine("<data name = \"RedLightRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringredLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            //string oliva = "d://img//oliva.png";
            //Byte[] byteoliva = System.IO.File.ReadAllBytes(oliva);
            //string stringoliva = Convert.ToBase64String(byteoliva);

            string orangeLight = "d://img//orangeLight.png";
            Byte[] byteorangeLight = System.IO.File.ReadAllBytes(orangeLight);
            string stringorangeLight = Convert.ToBase64String(byteorangeLight);

            stringBuilder.AppendLine("<data name = \"OrangeLightRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorangeLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowDark = "d://img//yellowDark.png";
            Byte[] byteyellowDark = System.IO.File.ReadAllBytes(yellowDark);
            string stringyellowDark = Convert.ToBase64String(byteyellowDark);

            stringBuilder.AppendLine("<data name = \"YellowDarkRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDark = "d://img//greenDark.png";
            Byte[] bytegreenDark = System.IO.File.ReadAllBytes(greenDark);
            string stringgreenDark = Convert.ToBase64String(bytegreenDark);

            stringBuilder.AppendLine("<data name = \"GreenDarkRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueDark = "d://img//blueDark.png";
            Byte[] byteblueDark = System.IO.File.ReadAllBytes(blueDark);
            string stringblueDark = Convert.ToBase64String(byteblueDark);

            stringBuilder.AppendLine("<data name = \"BlueDarkRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string aqua = "d://img//aqua.png";
            Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            string stringaqua = Convert.ToBase64String(byteaqua);

            stringBuilder.AppendLine("<data name = \"AquaRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringaqua);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string tan = "d://img//tan.png";
            Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            string stringtan = Convert.ToBase64String(bytetan);

            stringBuilder.AppendLine("<data name = \"TanRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringtan);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDarkness = "d://img//greenDarkness.png";
            Byte[] bytegreenDarkness = System.IO.File.ReadAllBytes(greenDarkness);
            string stringgreenDarkness = Convert.ToBase64String(bytegreenDarkness);

            stringBuilder.AppendLine("<data name = \"GreenDarknessRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDarkness);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueViolet = "d://img//blueViolet.png";
            Byte[] byteblueViolet = System.IO.File.ReadAllBytes(blueViolet);
            string stringblueViolet = Convert.ToBase64String(byteblueViolet);

            stringBuilder.AppendLine("<data name = \"BlueVioletRight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueViolet);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            var hedem = 42;
        }

        private static void readColorsAllResxLeft()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string blue = "d://img//blue.png";
            Byte[] byteblue = System.IO.File.ReadAllBytes(blue);
            string stringblue = Convert.ToBase64String(byteblue);
            stringBuilder.AppendLine("CheckBoxTraining Blue = new CheckBoxTraining();");
            stringBuilder.AppendLine("<data name = \"BlueLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblue);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string black = "d://img//black.png";
            Byte[] byteblack = System.IO.File.ReadAllBytes(black);
            string stringblack = Convert.ToBase64String(byteblack);

            stringBuilder.AppendLine("<data name = \"BlackLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblack);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string gray = "d://img//gray.png";
            Byte[] bytegray = System.IO.File.ReadAllBytes(gray);
            string stringgray = Convert.ToBase64String(bytegray);

            stringBuilder.AppendLine("<data name = \"GrayLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgray);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string green = "d://img//green.png";
            Byte[] bytegreen = System.IO.File.ReadAllBytes(green);
            string stringgreen = Convert.ToBase64String(bytegreen);

            stringBuilder.AppendLine("<data name = \"GreenLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreen);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string red = "d://img//red.png";
            Byte[] bytered = System.IO.File.ReadAllBytes(red);
            string stringred = Convert.ToBase64String(bytered);

            stringBuilder.AppendLine("<data name = \"RedLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringred);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellow = "d://img//yellow.png";
            Byte[] byteyellow = System.IO.File.ReadAllBytes(yellow);
            string stringyellow = Convert.ToBase64String(byteyellow);

            stringBuilder.AppendLine("<data name = \"YellowLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellow);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueSky = "d://img//blueSky.png";
            Byte[] byteblueSky = System.IO.File.ReadAllBytes(blueSky);
            string stringblueSky = Convert.ToBase64String(byteblueSky);

            stringBuilder.AppendLine("<data name = \"BlueSkyLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueSky);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string brown = "d://img//brown.png";
            Byte[] bytebrown = System.IO.File.ReadAllBytes(brown);
            string stringbrown = Convert.ToBase64String(bytebrown);

            stringBuilder.AppendLine("<data name = \"BrownLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringbrown);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenLight = "d://img//greenLight.png";
            Byte[] bytegreenLight = System.IO.File.ReadAllBytes(greenLight);
            string stringgreenLight = Convert.ToBase64String(bytegreenLight);

            stringBuilder.AppendLine("<data name = \"GreenLightLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pinkLight = "d://img//pinkLight.png";
            Byte[] bytepinkLight = System.IO.File.ReadAllBytes(pinkLight);
            string stringpinkLight = Convert.ToBase64String(bytepinkLight);

            stringBuilder.AppendLine("<data name = \"PinkLightLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpinkLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowLight = "d://img//yellowLight.png";
            Byte[] byteyellowLight = System.IO.File.ReadAllBytes(yellowLight);
            string stringyellowLight = Convert.ToBase64String(byteyellowLight);

            stringBuilder.AppendLine("<data name = \"YellowLightLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueLight = "d://img//blueLight.png";
            Byte[] byteblueLight = System.IO.File.ReadAllBytes(blueLight);
            string stringblueLight = Convert.ToBase64String(byteblueLight);

            stringBuilder.AppendLine("<data name = \"BlueLightLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string turquoise = "d://img//turquoise.png";
            Byte[] byteturquoise = System.IO.File.ReadAllBytes(turquoise);
            string stringturquoise = Convert.ToBase64String(byteturquoise);

            stringBuilder.AppendLine("<data name = \"TurquoiseLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringturquoise);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string purple = "d://img//purple.png";
            Byte[] bytepurple = System.IO.File.ReadAllBytes(purple);
            string stringpurple = Convert.ToBase64String(bytepurple);

            stringBuilder.AppendLine("<data name = \"PurpleLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpurple);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pink = "d://img//pink.png";
            Byte[] bytepink = System.IO.File.ReadAllBytes(pink);
            string stringpink = Convert.ToBase64String(bytepink);

            stringBuilder.AppendLine("<data name = \"PinkLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpink);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string orange = "d://img//orange.png";
            Byte[] byteorange = System.IO.File.ReadAllBytes(orange);
            string stringorange = Convert.ToBase64String(byteorange);

            stringBuilder.AppendLine("<data name = \"OrangeLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorange);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string white = "d://img//white.png";
            Byte[] bytewhite = System.IO.File.ReadAllBytes(white);
            string stringwhite = Convert.ToBase64String(bytewhite);

            stringBuilder.AppendLine("<data name = \"WhiteLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringwhite);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string grayLight = "d://img//grayLight.png";
            Byte[] bytegrayLight = System.IO.File.ReadAllBytes(grayLight);
            string stringgrayLight = Convert.ToBase64String(bytegrayLight);

            stringBuilder.AppendLine("<data name = \"GrayLightLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgrayLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string redLight = "d://img//redLight.png";
            Byte[] byteredLight = System.IO.File.ReadAllBytes(redLight);
            string stringredLight = Convert.ToBase64String(byteredLight);

            stringBuilder.AppendLine("<data name = \"RedLightLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringredLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            //string oliva = "d://img//oliva.png";
            //Byte[] byteoliva = System.IO.File.ReadAllBytes(oliva);
            //string stringoliva = Convert.ToBase64String(byteoliva);

            string orangeLight = "d://img//orangeLight.png";
            Byte[] byteorangeLight = System.IO.File.ReadAllBytes(orangeLight);
            string stringorangeLight = Convert.ToBase64String(byteorangeLight);

            stringBuilder.AppendLine("<data name = \"OrangeLightLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorangeLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowDark = "d://img//yellowDark.png";
            Byte[] byteyellowDark = System.IO.File.ReadAllBytes(yellowDark);
            string stringyellowDark = Convert.ToBase64String(byteyellowDark);

            stringBuilder.AppendLine("<data name = \"YellowDarkLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDark = "d://img//greenDark.png";
            Byte[] bytegreenDark = System.IO.File.ReadAllBytes(greenDark);
            string stringgreenDark = Convert.ToBase64String(bytegreenDark);

            stringBuilder.AppendLine("<data name = \"GreenDarkLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueDark = "d://img//blueDark.png";
            Byte[] byteblueDark = System.IO.File.ReadAllBytes(blueDark);
            string stringblueDark = Convert.ToBase64String(byteblueDark);

            stringBuilder.AppendLine("<data name = \"BlueDarkLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string aqua = "d://img//aqua.png";
            Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            string stringaqua = Convert.ToBase64String(byteaqua);

            stringBuilder.AppendLine("<data name = \"AquaLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringaqua);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string tan = "d://img//tan.png";
            Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            string stringtan = Convert.ToBase64String(bytetan);

            stringBuilder.AppendLine("<data name = \"TanLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringtan);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDarkness = "d://img//greenDarkness.png";
            Byte[] bytegreenDarkness = System.IO.File.ReadAllBytes(greenDarkness);
            string stringgreenDarkness = Convert.ToBase64String(bytegreenDarkness);

            stringBuilder.AppendLine("<data name = \"GreenDarknessLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDarkness);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueViolet = "d://img//blueViolet.png";
            Byte[] byteblueViolet = System.IO.File.ReadAllBytes(blueViolet);
            string stringblueViolet = Convert.ToBase64String(byteblueViolet);

            stringBuilder.AppendLine("<data name = \"BlueVioletLeft\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueViolet);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            var hedem = 42;
        }

        private static void readColorsAllResx()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string blue = "d://img//blue.png";
            Byte[] byteblue = System.IO.File.ReadAllBytes(blue);
            string stringblue = Convert.ToBase64String(byteblue);
            stringBuilder.AppendLine("CheckBoxTraining Blue = new CheckBoxTraining();");
            stringBuilder.AppendLine("<data name = \"Blue\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblue);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string black = "d://img//black.png";
            Byte[] byteblack = System.IO.File.ReadAllBytes(black);
            string stringblack = Convert.ToBase64String(byteblack);

            stringBuilder.AppendLine("<data name = \"Black\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblack);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string gray = "d://img//gray.png";
            Byte[] bytegray = System.IO.File.ReadAllBytes(gray);
            string stringgray = Convert.ToBase64String(bytegray);

            stringBuilder.AppendLine("<data name = \"Gray\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgray);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string green = "d://img//green.png";
            Byte[] bytegreen = System.IO.File.ReadAllBytes(green);
            string stringgreen = Convert.ToBase64String(bytegreen);

            stringBuilder.AppendLine("<data name = \"Green\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreen);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string red = "d://img//red.png";
            Byte[] bytered = System.IO.File.ReadAllBytes(red);
            string stringred = Convert.ToBase64String(bytered);

            stringBuilder.AppendLine("<data name = \"Red\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringred);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellow = "d://img//yellow.png";
            Byte[] byteyellow = System.IO.File.ReadAllBytes(yellow);
            string stringyellow = Convert.ToBase64String(byteyellow);

            stringBuilder.AppendLine("<data name = \"Yellow\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellow);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueSky = "d://img//blueSky.png";
            Byte[] byteblueSky = System.IO.File.ReadAllBytes(blueSky);
            string stringblueSky = Convert.ToBase64String(byteblueSky);

            stringBuilder.AppendLine("<data name = \"BlueSky\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueSky);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string brown = "d://img//brown.png";
            Byte[] bytebrown = System.IO.File.ReadAllBytes(brown);
            string stringbrown = Convert.ToBase64String(bytebrown);

            stringBuilder.AppendLine("<data name = \"Brown\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringbrown);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenLight = "d://img//greenLight.png";
            Byte[] bytegreenLight = System.IO.File.ReadAllBytes(greenLight);
            string stringgreenLight = Convert.ToBase64String(bytegreenLight);

            stringBuilder.AppendLine("<data name = \"GreenLight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pinkLight = "d://img//pinkLight.png";
            Byte[] bytepinkLight = System.IO.File.ReadAllBytes(pinkLight);
            string stringpinkLight = Convert.ToBase64String(bytepinkLight);

            stringBuilder.AppendLine("<data name = \"PinkLight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpinkLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowLight = "d://img//yellowLight.png";
            Byte[] byteyellowLight = System.IO.File.ReadAllBytes(yellowLight);
            string stringyellowLight = Convert.ToBase64String(byteyellowLight);

            stringBuilder.AppendLine("<data name = \"YellowLight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueLight = "d://img//blueLight.png";
            Byte[] byteblueLight = System.IO.File.ReadAllBytes(blueLight);
            string stringblueLight = Convert.ToBase64String(byteblueLight);

            stringBuilder.AppendLine("<data name = \"BlueLight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string turquoise = "d://img//turquoise.png";
            Byte[] byteturquoise = System.IO.File.ReadAllBytes(turquoise);
            string stringturquoise = Convert.ToBase64String(byteturquoise);

            stringBuilder.AppendLine("<data name = \"Turquoise\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringturquoise);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string purple = "d://img//purple.png";
            Byte[] bytepurple = System.IO.File.ReadAllBytes(purple);
            string stringpurple = Convert.ToBase64String(bytepurple);

            stringBuilder.AppendLine("<data name = \"Purple\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpurple);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pink = "d://img//pink.png";
            Byte[] bytepink = System.IO.File.ReadAllBytes(pink);
            string stringpink = Convert.ToBase64String(bytepink);

            stringBuilder.AppendLine("<data name = \"Pink\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpink);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string orange = "d://img//orange.png";
            Byte[] byteorange = System.IO.File.ReadAllBytes(orange);
            string stringorange = Convert.ToBase64String(byteorange);

            stringBuilder.AppendLine("<data name = \"Orange\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorange);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string white = "d://img//white.png";
            Byte[] bytewhite = System.IO.File.ReadAllBytes(white);
            string stringwhite = Convert.ToBase64String(bytewhite);

            stringBuilder.AppendLine("<data name = \"White\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringwhite);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string grayLight = "d://img//grayLight.png";
            Byte[] bytegrayLight = System.IO.File.ReadAllBytes(grayLight);
            string stringgrayLight = Convert.ToBase64String(bytegrayLight);

            stringBuilder.AppendLine("<data name = \"GrayLight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgrayLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string redLight = "d://img//redLight.png";
            Byte[] byteredLight = System.IO.File.ReadAllBytes(redLight);
            string stringredLight = Convert.ToBase64String(byteredLight);

            stringBuilder.AppendLine("<data name = \"RedLight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringredLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            //string oliva = "d://img//oliva.png";
            //Byte[] byteoliva = System.IO.File.ReadAllBytes(oliva);
            //string stringoliva = Convert.ToBase64String(byteoliva);

            string orangeLight = "d://img//orangeLight.png";
            Byte[] byteorangeLight = System.IO.File.ReadAllBytes(orangeLight);
            string stringorangeLight = Convert.ToBase64String(byteorangeLight);

            stringBuilder.AppendLine("<data name = \"OrangeLight\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorangeLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowDark = "d://img//yellowDark.png";
            Byte[] byteyellowDark = System.IO.File.ReadAllBytes(yellowDark);
            string stringyellowDark = Convert.ToBase64String(byteyellowDark);

            stringBuilder.AppendLine("<data name = \"YellowDark\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDark = "d://img//greenDark.png";
            Byte[] bytegreenDark = System.IO.File.ReadAllBytes(greenDark);
            string stringgreenDark = Convert.ToBase64String(bytegreenDark);

            stringBuilder.AppendLine("<data name = \"GreenDark\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueDark = "d://img//blueDark.png";
            Byte[] byteblueDark = System.IO.File.ReadAllBytes(blueDark);
            string stringblueDark = Convert.ToBase64String(byteblueDark);

            stringBuilder.AppendLine("<data name = \"BlueDark\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string aqua = "d://img//aqua.png";
            Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            string stringaqua = Convert.ToBase64String(byteaqua);

            stringBuilder.AppendLine("<data name = \"Aqua\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringaqua);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string tan = "d://img//tan.png";
            Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            string stringtan = Convert.ToBase64String(bytetan);

            stringBuilder.AppendLine("<data name = \"Tan\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringtan);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDarkness = "d://img//greenDarkness.png";
            Byte[] bytegreenDarkness = System.IO.File.ReadAllBytes(greenDarkness);
            string stringgreenDarkness = Convert.ToBase64String(bytegreenDarkness);

            stringBuilder.AppendLine("<data name = \"GreenDarkness\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDarkness);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueViolet = "d://img//blueViolet.png";
            Byte[] byteblueViolet = System.IO.File.ReadAllBytes(blueViolet);
            string stringblueViolet = Convert.ToBase64String(byteblueViolet);

            stringBuilder.AppendLine("<data name = \"BlueViolet\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueViolet);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            var hedem = 42;
        }

        private static void readColorsAllResxSelected()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string blue = "d://img//blue.png";
            Byte[] byteblue = System.IO.File.ReadAllBytes(blue);
            string stringblue = Convert.ToBase64String(byteblue);
            stringBuilder.AppendLine("<data name = \"BlueSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblue);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string black = "d://img//black.png";
            Byte[] byteblack = System.IO.File.ReadAllBytes(black);
            string stringblack = Convert.ToBase64String(byteblack);

            stringBuilder.AppendLine("<data name = \"BlackSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblack);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string gray = "d://img//gray.png";
            Byte[] bytegray = System.IO.File.ReadAllBytes(gray);
            string stringgray = Convert.ToBase64String(bytegray);

            stringBuilder.AppendLine("<data name = \"GraySelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgray);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string green = "d://img//green.png";
            Byte[] bytegreen = System.IO.File.ReadAllBytes(green);
            string stringgreen = Convert.ToBase64String(bytegreen);

            stringBuilder.AppendLine("<data name = \"GreenSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreen);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string red = "d://img//red.png";
            Byte[] bytered = System.IO.File.ReadAllBytes(red);
            string stringred = Convert.ToBase64String(bytered);

            stringBuilder.AppendLine("<data name = \"RedSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringred);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellow = "d://img//yellow.png";
            Byte[] byteyellow = System.IO.File.ReadAllBytes(yellow);
            string stringyellow = Convert.ToBase64String(byteyellow);

            stringBuilder.AppendLine("<data name = \"YellowSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellow);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueSky = "d://img//blueSky.png";
            Byte[] byteblueSky = System.IO.File.ReadAllBytes(blueSky);
            string stringblueSky = Convert.ToBase64String(byteblueSky);

            stringBuilder.AppendLine("<data name = \"BlueSkySelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueSky);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string brown = "d://img//brown.png";
            Byte[] bytebrown = System.IO.File.ReadAllBytes(brown);
            string stringbrown = Convert.ToBase64String(bytebrown);

            stringBuilder.AppendLine("<data name = \"BrownSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringbrown);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenLight = "d://img//greenLight.png";
            Byte[] bytegreenLight = System.IO.File.ReadAllBytes(greenLight);
            string stringgreenLight = Convert.ToBase64String(bytegreenLight);

            stringBuilder.AppendLine("<data name = \"GreenLightSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pinkLight = "d://img//pinkLight.png";
            Byte[] bytepinkLight = System.IO.File.ReadAllBytes(pinkLight);
            string stringpinkLight = Convert.ToBase64String(bytepinkLight);

            stringBuilder.AppendLine("<data name = \"PinkLightSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpinkLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowLight = "d://img//yellowLight.png";
            Byte[] byteyellowLight = System.IO.File.ReadAllBytes(yellowLight);
            string stringyellowLight = Convert.ToBase64String(byteyellowLight);

            stringBuilder.AppendLine("<data name = \"YellowLightSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueLight = "d://img//blueLight.png";
            Byte[] byteblueLight = System.IO.File.ReadAllBytes(blueLight);
            string stringblueLight = Convert.ToBase64String(byteblueLight);

            stringBuilder.AppendLine("<data name = \"BlueLightSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string turquoise = "d://img//turquoise.png";
            Byte[] byteturquoise = System.IO.File.ReadAllBytes(turquoise);
            string stringturquoise = Convert.ToBase64String(byteturquoise);

            stringBuilder.AppendLine("<data name = \"TurquoiseSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringturquoise);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string purple = "d://img//purple.png";
            Byte[] bytepurple = System.IO.File.ReadAllBytes(purple);
            string stringpurple = Convert.ToBase64String(bytepurple);

            stringBuilder.AppendLine("<data name = \"PurpleSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpurple);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string pink = "d://img//pink.png";
            Byte[] bytepink = System.IO.File.ReadAllBytes(pink);
            string stringpink = Convert.ToBase64String(bytepink);

            stringBuilder.AppendLine("<data name = \"PinkSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringpink);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string orange = "d://img//orange.png";
            Byte[] byteorange = System.IO.File.ReadAllBytes(orange);
            string stringorange = Convert.ToBase64String(byteorange);

            stringBuilder.AppendLine("<data name = \"OrangeSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorange);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string white = "d://img//white.png";
            Byte[] bytewhite = System.IO.File.ReadAllBytes(white);
            string stringwhite = Convert.ToBase64String(bytewhite);

            stringBuilder.AppendLine("<data name = \"WhiteSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringwhite);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string grayLight = "d://img//grayLight.png";
            Byte[] bytegrayLight = System.IO.File.ReadAllBytes(grayLight);
            string stringgrayLight = Convert.ToBase64String(bytegrayLight);

            stringBuilder.AppendLine("<data name = \"GrayLightSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgrayLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string redLight = "d://img//redLight.png";
            Byte[] byteredLight = System.IO.File.ReadAllBytes(redLight);
            string stringredLight = Convert.ToBase64String(byteredLight);

            stringBuilder.AppendLine("<data name = \"RedLightSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringredLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            //string oliva = "d://img//oliva.png";
            //Byte[] byteoliva = System.IO.File.ReadAllBytes(oliva);
            //string stringoliva = Convert.ToBase64String(byteoliva);

            string orangeLight = "d://img//orangeLight.png";
            Byte[] byteorangeLight = System.IO.File.ReadAllBytes(orangeLight);
            string stringorangeLight = Convert.ToBase64String(byteorangeLight);

            stringBuilder.AppendLine("<data name = \"OrangeLightSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringorangeLight);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string yellowDark = "d://img//yellowDark.png";
            Byte[] byteyellowDark = System.IO.File.ReadAllBytes(yellowDark);
            string stringyellowDark = Convert.ToBase64String(byteyellowDark);

            stringBuilder.AppendLine("<data name = \"YellowDarkSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringyellowDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDark = "d://img//greenDark.png";
            Byte[] bytegreenDark = System.IO.File.ReadAllBytes(greenDark);
            string stringgreenDark = Convert.ToBase64String(bytegreenDark);

            stringBuilder.AppendLine("<data name = \"GreenDarkSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueDark = "d://img//blueDark.png";
            Byte[] byteblueDark = System.IO.File.ReadAllBytes(blueDark);
            string stringblueDark = Convert.ToBase64String(byteblueDark);

            stringBuilder.AppendLine("<data name = \"BlueDarkSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueDark);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string aqua = "d://img//aqua.png";
            Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            string stringaqua = Convert.ToBase64String(byteaqua);

            stringBuilder.AppendLine("<data name = \"AquaSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringaqua);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string tan = "d://img//tan.png";
            Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            string stringtan = Convert.ToBase64String(bytetan);

            stringBuilder.AppendLine("<data name = \"TanSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringtan);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string greenDarkness = "d://img//greenDarkness.png";
            Byte[] bytegreenDarkness = System.IO.File.ReadAllBytes(greenDarkness);
            string stringgreenDarkness = Convert.ToBase64String(bytegreenDarkness);

            stringBuilder.AppendLine("<data name = \"GreenDarknessSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringgreenDarkness);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            string blueViolet = "d://img//blueViolet.png";
            Byte[] byteblueViolet = System.IO.File.ReadAllBytes(blueViolet);
            string stringblueViolet = Convert.ToBase64String(byteblueViolet);

            stringBuilder.AppendLine("<data name = \"BlueVioletSelected\" xml:space=\"preserve\">");
            stringBuilder.Append("<value>");
            stringBuilder.Append(stringblueViolet);
            stringBuilder.Append("</value>");
            stringBuilder.AppendLine("</data>");

            var hedem = 42;
        }
        private static void readColorsAll()
        {
            StringBuilder stringBuilder = new StringBuilder();

            //string blue = "d://img2//blue.png";
            //Byte[] byteblue = System.IO.File.ReadAllBytes(blue);
            //string stringblue = Convert.ToBase64String(byteblue);

            //stringBuilder.AppendLine("string Blue = " + "\"" + stringblue + "\";");

            //string black = "d://img2//black.png";
            //Byte[] byteblack = System.IO.File.ReadAllBytes(black);
            //string stringblack = Convert.ToBase64String(byteblack);

            //stringBuilder.AppendLine("string Black = " + "\"" + stringblack + "\";");

            //string gray = "d://img2//gray.png";
            //Byte[] bytegray = System.IO.File.ReadAllBytes(gray);
            //string stringgray = Convert.ToBase64String(bytegray);

            //stringBuilder.AppendLine("string Gray = " + "\"" + stringgray + "\";");

            //string green = "d://img2//green.png";
            //Byte[] bytegreen = System.IO.File.ReadAllBytes(green);
            //string stringgreen = Convert.ToBase64String(bytegreen);

            //stringBuilder.AppendLine("string Green = " + "\"" + stringgreen + "\";");

            //string red = "d://img2//red.png";
            //Byte[] bytered = System.IO.File.ReadAllBytes(red);
            //string stringred = Convert.ToBase64String(bytered);

            //stringBuilder.AppendLine("string Red = " + "\"" + stringred + "\";");

            //string yellow = "d://img2//yellow.png";
            //Byte[] byteyellow = System.IO.File.ReadAllBytes(yellow);
            //string stringyellow = Convert.ToBase64String(byteyellow);

            //stringBuilder.AppendLine("string Yellow = " + "\"" + stringyellow + "\";");

            //string blueSky = "d://img2//blueSky.png";
            //Byte[] byteblueSky = System.IO.File.ReadAllBytes(blueSky);
            //string stringblueSky = Convert.ToBase64String(byteblueSky);

            //stringBuilder.AppendLine("string BlueSky = " + "\"" + stringblueSky + "\";");

            //string brown = "d://img2//brown.png";
            //Byte[] bytebrown = System.IO.File.ReadAllBytes(brown);
            //string stringbrown = Convert.ToBase64String(bytebrown);

            //stringBuilder.AppendLine("string Brown = " + "\"" + stringbrown + "\";");

            //string greenLight = "d://img2//greenLight.png";
            //Byte[] bytegreenLight = System.IO.File.ReadAllBytes(greenLight);
            //string stringgreenLight = Convert.ToBase64String(bytegreenLight);

            //stringBuilder.AppendLine("string GreenLight = " + "\"" + stringgreenLight + "\";");

            //string pinkLight = "d://img2//pinkLight.png";
            //Byte[] bytepinkLight = System.IO.File.ReadAllBytes(pinkLight);
            //string stringpinkLight = Convert.ToBase64String(bytepinkLight);

            //stringBuilder.AppendLine("string PinkLight = " + "\"" + stringpinkLight + "\";");

            //string yellowLight = "d://img2//yellowLight.png";
            //Byte[] byteyellowLight = System.IO.File.ReadAllBytes(yellowLight);
            //string stringyellowLight = Convert.ToBase64String(byteyellowLight);

            //stringBuilder.AppendLine("string YellowLight = " + "\"" + stringyellowLight + "\";");

            //string blueLight = "d://img2//blueLight.png";
            //Byte[] byteblueLight = System.IO.File.ReadAllBytes(blueLight);
            //string stringblueLight = Convert.ToBase64String(byteblueLight);

            //stringBuilder.AppendLine("string BlueLight = " + "\"" + stringblueLight + "\";");

            //string turquoise = "d://img2//turquoise.png";
            //Byte[] byteturquoise = System.IO.File.ReadAllBytes(turquoise);
            //string stringturquoise = Convert.ToBase64String(byteturquoise);

            //stringBuilder.AppendLine("string Turquoise = " + "\"" + stringturquoise + "\";");

            //string purple = "d://img2//purple.png";
            //Byte[] bytepurple = System.IO.File.ReadAllBytes(purple);
            //string stringpurple = Convert.ToBase64String(bytepurple);

            //stringBuilder.AppendLine("string Purple = " + "\"" + stringpurple + "\";");

            //string pink = "d://img2//pink.png";
            //Byte[] bytepink = System.IO.File.ReadAllBytes(pink);
            //string stringpink = Convert.ToBase64String(bytepink);

            //stringBuilder.AppendLine("string Pink = " + "\"" + stringpink + "\";");

            //string orange = "d://img2//orange.png";
            //Byte[] byteorange = System.IO.File.ReadAllBytes(orange);
            //string stringorange = Convert.ToBase64String(byteorange);

            //stringBuilder.AppendLine("string Orange = " + "\"" + stringorange + "\";");

            //string white = "d://img2//white.png";
            //Byte[] bytewhite = System.IO.File.ReadAllBytes(white);
            //string stringwhite = Convert.ToBase64String(bytewhite);

            //stringBuilder.AppendLine("string White = " + "\"" + stringwhite + "\";");

            string grayLight = "d://img2//grayLight.png";
            Byte[] bytegrayLight = System.IO.File.ReadAllBytes(grayLight);
            string stringgrayLight = Convert.ToBase64String(bytegrayLight);

            stringBuilder.AppendLine("string GrayLight = " + "\"" + stringgrayLight + "\";");

            //string redLight = "d://img2//redLight.png";
            //Byte[] byteredLight = System.IO.File.ReadAllBytes(redLight);
            //string stringredLight = Convert.ToBase64String(byteredLight);

            //stringBuilder.AppendLine("string RedLight = " + "\"" + stringredLight + "\";");

            //string orangeLight = "d://img2//orangeLight.png";
            //Byte[] byteorangeLight = System.IO.File.ReadAllBytes(orangeLight);
            //string stringorangeLight = Convert.ToBase64String(byteorangeLight);

            //stringBuilder.AppendLine("string OrangeLight = " + "\"" + stringorangeLight + "\";");

            //string yellowDark = "d://img2//yellowDark.png";
            //Byte[] byteyellowDark = System.IO.File.ReadAllBytes(yellowDark);
            //string stringyellowDark = Convert.ToBase64String(byteyellowDark);

            //stringBuilder.AppendLine("string YellowDark = " + "\"" + stringyellowDark + "\";");

            //string greenDark = "d://img2//greenDark.png";
            //Byte[] bytegreenDark = System.IO.File.ReadAllBytes(greenDark);
            //string stringgreenDark = Convert.ToBase64String(bytegreenDark);

            //stringBuilder.AppendLine("string GreenDark = " + "\"" + stringgreenDark + "\";");

            //string blueDark = "d://img2//blueDark.png";
            //Byte[] byteblueDark = System.IO.File.ReadAllBytes(blueDark);
            //string stringblueDark = Convert.ToBase64String(byteblueDark);

            //stringBuilder.AppendLine("string BlueDark = " + "\"" + stringblueDark + "\";");

            //string aqua = "d://img2//aqua.png";
            //Byte[] byteaqua = System.IO.File.ReadAllBytes(aqua);
            //string stringaqua = Convert.ToBase64String(byteaqua);

            //stringBuilder.AppendLine("string Aqua = " + "\"" + stringaqua + "\";");

            //string tan = "d://img2//tan.png";
            //Byte[] bytetan = System.IO.File.ReadAllBytes(tan);
            //string stringtan = Convert.ToBase64String(bytetan);

            //stringBuilder.AppendLine("string Tan = " + "\"" + stringtan + "\";");

            //string greenDarkness = "d://img2//greenDarkness.png";
            //Byte[] bytegreenDarkness = System.IO.File.ReadAllBytes(greenDarkness);
            //string stringgreenDarkness = Convert.ToBase64String(bytegreenDarkness);

            //stringBuilder.AppendLine("string GreenDarkness = " + "\"" + stringgreenDarkness + "\";");

            //string blueViolet = "d://img2//blueViolet.png";
            //Byte[] byteblueViolet = System.IO.File.ReadAllBytes(blueViolet);
            //string stringblueViolet = Convert.ToBase64String(byteblueViolet);

            //stringBuilder.AppendLine("string BlueViolet = " + "\"" + stringblueViolet + "\";");

            var hedemnew = 42;
        }


        public static void readLetters()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string a = "d://img//a.png";
            Byte[] bytea = System.IO.File.ReadAllBytes(a);
            string stringCopya = Convert.ToBase64String(bytea);

            stringBuilder.AppendLine("string A = " + "\"" + stringCopya + "\";");

            string b = "d://img//b.png";
            Byte[] byteb = System.IO.File.ReadAllBytes(b);
            string stringCopyb = Convert.ToBase64String(byteb);

            stringBuilder.AppendLine("string B = " + "\"" + stringCopyb + "\";");

            string c = "d://img//c.png";
            Byte[] bytec = System.IO.File.ReadAllBytes(c);
            string stringCopyc = Convert.ToBase64String(bytec);

            stringBuilder.AppendLine("string C = " + "\"" + stringCopyc + "\";");

            string d = "d://img//d.png";
            Byte[] byted = System.IO.File.ReadAllBytes(d);
            string stringCopyd = Convert.ToBase64String(byted);

            stringBuilder.AppendLine("string D = " + "\"" + stringCopyd + "\";");

            string e = "d://img//e.png";
            Byte[] bytee = System.IO.File.ReadAllBytes(e);
            string stringCopye = Convert.ToBase64String(bytee);

            stringBuilder.AppendLine("string E = " + "\"" + stringCopye + "\";");

            string f = "d://img//f.png";
            Byte[] bytef = System.IO.File.ReadAllBytes(f);
            string stringCopyf = Convert.ToBase64String(bytef);

            stringBuilder.AppendLine("string F = " + "\"" + stringCopyf + "\";");

            string g = "d://img//g.png";
            Byte[] byteg = System.IO.File.ReadAllBytes(g);
            string stringCopyg = Convert.ToBase64String(byteg);

            stringBuilder.AppendLine("string G = " + "\"" + stringCopyg + "\";");

            string h = "d://img//h.png";
            Byte[] byteh = System.IO.File.ReadAllBytes(h);
            string stringCopyh = Convert.ToBase64String(byteh);

            stringBuilder.AppendLine("string H = " + "\"" + stringCopyh + "\";");

            string i = "d://img//i.png";
            Byte[] bytei = System.IO.File.ReadAllBytes(i);
            string stringCopyi = Convert.ToBase64String(bytei);

            stringBuilder.AppendLine("string I = " + "\"" + stringCopyi + "\";");

            string j = "d://img//j.png";
            Byte[] bytej = System.IO.File.ReadAllBytes(j);
            string stringCopyj = Convert.ToBase64String(bytej);

            stringBuilder.AppendLine("string J = " + "\"" + stringCopyj + "\";");

            string k = "d://img//k.png";
            Byte[] bytek = System.IO.File.ReadAllBytes(k);
            string stringCopyk = Convert.ToBase64String(bytek);

            stringBuilder.AppendLine("string K = " + "\"" + stringCopyk + "\";");

            string l = "d://img//l.png";
            Byte[] bytel = System.IO.File.ReadAllBytes(l);
            string stringCopyl = Convert.ToBase64String(bytel);

            stringBuilder.AppendLine("string L = " + "\"" + stringCopyl + "\";");

            string m = "d://img//m.png";
            Byte[] bytem = System.IO.File.ReadAllBytes(m);
            string stringCopym = Convert.ToBase64String(bytem);

            stringBuilder.AppendLine("string M = " + "\"" + stringCopym + "\";");

            string n = "d://img//n.png";
            Byte[] byten = System.IO.File.ReadAllBytes(n);
            string stringCopyn = Convert.ToBase64String(byten);

            stringBuilder.AppendLine("string N = " + "\"" + stringCopyn + "\";");

            string o = "d://img//o.png";
            Byte[] byteo = System.IO.File.ReadAllBytes(o);
            string stringCopyo = Convert.ToBase64String(byteo);

            stringBuilder.AppendLine("string O = " + "\"" + stringCopyo + "\";");

            string p = "d://img//p.png";
            Byte[] bytep = System.IO.File.ReadAllBytes(p);
            string stringCopyp = Convert.ToBase64String(bytep);

            stringBuilder.AppendLine("string P = " + "\"" + stringCopyp + "\";");

            string q = "d://img//q.png";
            Byte[] byteq = System.IO.File.ReadAllBytes(q);
            string stringCopyq = Convert.ToBase64String(byteq);

            stringBuilder.AppendLine("string Q = " + "\"" + stringCopyq + "\";");

            string r = "d://img//r.png";
            Byte[] byter = System.IO.File.ReadAllBytes(r);
            string stringCopyr = Convert.ToBase64String(byter);

            stringBuilder.AppendLine("string R = " + "\"" + stringCopyr + "\";");

            string s = "d://img//s.png";
            Byte[] bytes = System.IO.File.ReadAllBytes(s);
            string stringCopys = Convert.ToBase64String(bytes);

            stringBuilder.AppendLine("string S = " + "\"" + stringCopys + "\";");

            string t = "d://img//t.png";
            Byte[] bytet = System.IO.File.ReadAllBytes(t);
            string stringCopyt = Convert.ToBase64String(bytet);

            stringBuilder.AppendLine("string T = " + "\"" + stringCopyt + "\";");

            string u = "d://img//u.png";
            Byte[] byteu = System.IO.File.ReadAllBytes(u);
            string stringCopyu = Convert.ToBase64String(byteu);

            stringBuilder.AppendLine("string U = " + "\"" + stringCopyu + "\";");

            string v = "d://img//v.png";
            Byte[] bytev = System.IO.File.ReadAllBytes(v);
            string stringCopyv = Convert.ToBase64String(bytev);

            stringBuilder.AppendLine("string V = " + "\"" + stringCopyv + "\";");

            string w = "d://img//w.png";
            Byte[] bytew = System.IO.File.ReadAllBytes(w);
            string stringCopyw = Convert.ToBase64String(bytew);

            stringBuilder.AppendLine("string W = " + "\"" + stringCopyw + "\";");

            string x = "d://img//x.png";
            Byte[] bytex = System.IO.File.ReadAllBytes(x);
            string stringCopyx = Convert.ToBase64String(bytex);

            stringBuilder.AppendLine("string X = " + "\"" + stringCopyx + "\";");

            string y = "d://img//y.png";
            Byte[] bytey = System.IO.File.ReadAllBytes(y);
            string stringCopyy = Convert.ToBase64String(bytey);

            stringBuilder.AppendLine("string Y = " + "\"" + stringCopyy + "\";");

            string z = "d://img//z.png";
            Byte[] bytez = System.IO.File.ReadAllBytes(z);
            string stringCopyz = Convert.ToBase64String(bytez);

            stringBuilder.AppendLine("string Z = " + "\"" + stringCopyz + "\";");

            var esd = 0;
        }

        public static void readIcons()
        {

            string checkBlack = "d://img//Configuration.png";
            Byte[] bytecheckBlack = System.IO.File.ReadAllBytes(checkBlack);
            string stringCopycheckBlack = Convert.ToBase64String(bytecheckBlack);

            string checkBlue = "d://img//Cut.png";
            Byte[] bytecheckBlue = System.IO.File.ReadAllBytes(checkBlue);
            string stringCopycheckBlue = Convert.ToBase64String(bytecheckBlue);

            string checkGray = "d://img//Like.png";
            Byte[] bytecheckGray = System.IO.File.ReadAllBytes(checkGray);
            string stringCopycheckGray = Convert.ToBase64String(bytecheckGray);

            string checkGreen = "d://img//Mail.png";
            Byte[] bytecheckGreen = System.IO.File.ReadAllBytes(checkGreen);
            string stringCopycheckGreen = Convert.ToBase64String(bytecheckGreen);

            string checkRed = "d://img//Question.png";
            Byte[] bytecheckRed = System.IO.File.ReadAllBytes(checkRed);
            string stringCopycheckRed = Convert.ToBase64String(bytecheckRed);

            string checkYellow = "d://img//Share.png";
            Byte[] bytecheckYellow = System.IO.File.ReadAllBytes(checkYellow);
            string stringCopycheckYellow = Convert.ToBase64String(bytecheckYellow);

            string checkOrange = "d://img//Copy.png";
            Byte[] bytecheckOrange = System.IO.File.ReadAllBytes(checkOrange);
            string stringCopycheckOrange = Convert.ToBase64String(bytecheckOrange);

            string checkPink = "d://img//Edit.png";
            Byte[] bytecheckPink = System.IO.File.ReadAllBytes(checkPink);
            string stringCopycheckPink = Convert.ToBase64String(bytecheckPink);

            string checkWhite = "d://img//Paste.png";
            Byte[] bytecheckWhite = System.IO.File.ReadAllBytes(checkWhite);
            string stringCopycheckWhite = Convert.ToBase64String(bytecheckWhite);

            string checkBlueLight = "d://img//Pencil.png";
            Byte[] bytecheckBlueLight = System.IO.File.ReadAllBytes(checkBlueLight);
            string stringCopycheckBlueLight = Convert.ToBase64String(bytecheckBlueLight);

            string checkYellowLight = "d://img//Plus.png";
            Byte[] bytecheckYellowLight = System.IO.File.ReadAllBytes(checkYellowLight);
            string stringCopycheckYellowLight = Convert.ToBase64String(bytecheckYellowLight);

            string checkGreenLight = "d://img//Subtraction.png";
            Byte[] bytecheckGreenLight = System.IO.File.ReadAllBytes(checkGreenLight);
            string stringCopycheckGreenLight = Convert.ToBase64String(bytecheckGreenLight);

            string checkBrown = "d://img//Sphere.png";
            Byte[] bytecheckBrown = System.IO.File.ReadAllBytes(checkBrown);
            string stringCopycheckBrown = Convert.ToBase64String(bytecheckBrown);

            string checkPurple = "d://img//Star.png";
            Byte[] bytecheckPurple = System.IO.File.ReadAllBytes(checkPurple);
            string stringCopycheckPurple = Convert.ToBase64String(bytecheckPurple);

            string checkEye = "d://img//Eye.png";
            Byte[] bytecheckEye = System.IO.File.ReadAllBytes(checkEye);
            string stringCopycheckEye = Convert.ToBase64String(bytecheckEye);

            string checkBox = "d://img//Box.png";
            Byte[] bytecheckBox = System.IO.File.ReadAllBytes(checkBox);
            string stringCopycheckBox = Convert.ToBase64String(bytecheckBox);

            string checkSearchLeft = "d://img//SearchLeft.png";
            Byte[] bytecheckSearchLeft = System.IO.File.ReadAllBytes(checkSearchLeft);
            string stringCopycheckSearchLeft = Convert.ToBase64String(bytecheckSearchLeft);

            string heart = "d://img//Heart.png";
            Byte[] byteHeart = System.IO.File.ReadAllBytes(heart);
            string stringHeart = Convert.ToBase64String(byteHeart);

            //string flag = "d://img//Flag.png";
            //Byte[] byteFlag = System.IO.File.ReadAllBytes(flag);
            //string stringCopyFlag = Convert.ToBase64String(byteFlag);

            //string ArrowLeft = "d://img//ArrowLeft.png";
            //Byte[] byteArrowLeft = System.IO.File.ReadAllBytes(ArrowLeft);
            //string stringArrowLeft = Convert.ToBase64String(byteArrowLeft);

            //string ArrowRight = "d://img//ArrowRight.png";
            //Byte[] byteArrowRight = System.IO.File.ReadAllBytes(ArrowRight);
            //string stringArrowRight = Convert.ToBase64String(byteArrowRight);

            //string ArrowUp = "d://img//ArrowUp.png";
            //Byte[] byteArrowUp = System.IO.File.ReadAllBytes(ArrowUp);
            //string stringArrowUp = Convert.ToBase64String(byteArrowUp);

            //string ArrowDown = "d://img//ArrowDown.png";
            //Byte[] byteArrowDown = System.IO.File.ReadAllBytes(ArrowDown);
            //string stringArrowDown = Convert.ToBase64String(byteArrowDown);

            //string Keyboard = "d://img//Keyboard.png";
            //Byte[] byteKeyboard = System.IO.File.ReadAllBytes(Keyboard);
            //string stringKeyboard = Convert.ToBase64String(byteKeyboard);

            //string Person = "d://img//Person.png";
            //Byte[] bytePerson = System.IO.File.ReadAllBytes(Person);
            //string stringPerson = Convert.ToBase64String(bytePerson);

            //string FolderOpen = "d://img//FolderOpen.png";
            //Byte[] byteFolderOpen = System.IO.File.ReadAllBytes(FolderOpen);
            //string stringFolderOpen = Convert.ToBase64String(byteFolderOpen);

            //string FolderClose = "d://img//FolderClose.png";
            //Byte[] byteFolderClose = System.IO.File.ReadAllBytes(FolderClose);
            //string stringFolderClose = Convert.ToBase64String(byteFolderClose);

            var es = 0;
        }

        public void readAllIcons()
        {

            string checkBlack2dd = "d://img//Configuration.png";
            Byte[] bytecheckBlack2dd = System.IO.File.ReadAllBytes(checkBlack2dd);
            string stringCopycheckBlack2dd = Convert.ToBase64String(bytecheckBlack2dd);

            string checkBlackdd = "d://img//Box.png";
            Byte[] bytecheckBlackdd = System.IO.File.ReadAllBytes(checkBlackdd);
            string stringCopycheckBlackdd = Convert.ToBase64String(bytecheckBlackdd);
                    
            string checkBlackaa = "d://img//Copy.png";
            Byte[] bytecheckBlackaa = System.IO.File.ReadAllBytes(checkBlackaa);
            string stringCopycheckBlackaa = Convert.ToBase64String(bytecheckBlackaa);

            //string checkBlack2 = "d://img//graySphere.png";
            //Byte[] bytecheckBlack2 = System.IO.File.ReadAllBytes(checkBlack2);
            //string stringCopycheckBlack2 = Convert.ToBase64String(bytecheckBlack2);

            //string checkBlack3 = "d://img//eyeBlue.png";
            //Byte[] bytecheckBlack3 = System.IO.File.ReadAllBytes(checkBlack3);
            //string stringCopycheckBlack3 = Convert.ToBase64String(bytecheckBlack3);

            //string checkBlack4 = "d://img//eyeGray.png";
            //Byte[] bytecheckBlack4 = System.IO.File.ReadAllBytes(checkBlack4);
            //string stringCopycheckBlack4 = Convert.ToBase64String(bytecheckBlack4);

            string checkBlack = "d://img//Cut.png";
            Byte[] bytecheckBlack = System.IO.File.ReadAllBytes(checkBlack);
            string stringCopycheckBlack = Convert.ToBase64String(bytecheckBlack);

            string checkBlue = "d://img//Edit.png";
            Byte[] bytecheckBlue = System.IO.File.ReadAllBytes(checkBlue);
            string stringCopycheckBlue = Convert.ToBase64String(bytecheckBlue);

            string checkGray = "d://img//Eye.png";
            Byte[] bytecheckGray = System.IO.File.ReadAllBytes(checkGray);
            string stringCopycheckGray = Convert.ToBase64String(bytecheckGray);

            string checkGreen = "d://img//Flag.png";
            Byte[] bytecheckGreen = System.IO.File.ReadAllBytes(checkGreen);
            string stringCopycheckGreen = Convert.ToBase64String(bytecheckGreen);

            string checkRed = "d://img//Like.png";
            Byte[] bytecheckRed = System.IO.File.ReadAllBytes(checkRed);
            string stringCopycheckRed = Convert.ToBase64String(bytecheckRed);

            string checkYellow = "d://img//Mail.png";
            Byte[] bytecheckYellow = System.IO.File.ReadAllBytes(checkYellow);
            string stringCopycheckYellow = Convert.ToBase64String(bytecheckYellow);

            string checkOrange = "d://img//Paste.png";
            Byte[] bytecheckOrange = System.IO.File.ReadAllBytes(checkOrange);
            string stringCopycheckOrange = Convert.ToBase64String(bytecheckOrange);

            string checkPink = "d://img//Pencil.png";
            Byte[] bytecheckPink = System.IO.File.ReadAllBytes(checkPink);
            string stringCopycheckPink = Convert.ToBase64String(bytecheckPink);

            string checkWhite = "d://img//Plus.png";
            Byte[] bytecheckWhite = System.IO.File.ReadAllBytes(checkWhite);
            string stringCopycheckWhite = Convert.ToBase64String(bytecheckWhite);

            string checkBlueLight = "d://img//Question.png";
            Byte[] bytecheckBlueLight = System.IO.File.ReadAllBytes(checkBlueLight);
            string stringCopycheckBlueLight = Convert.ToBase64String(bytecheckBlueLight);

            string checkYellowLight = "d://img//SearchLeft.png";
            Byte[] bytecheckYellowLight = System.IO.File.ReadAllBytes(checkYellowLight);
            string stringCopycheckYellowLight = Convert.ToBase64String(bytecheckYellowLight);

            string checkGreenLight = "d://img//Share.png";
            Byte[] bytecheckGreenLight = System.IO.File.ReadAllBytes(checkGreenLight);
            string stringCopycheckGreenLight = Convert.ToBase64String(bytecheckGreenLight);

            string checkBrown = "d://img//Sphere.png";
            Byte[] bytecheckBrown = System.IO.File.ReadAllBytes(checkBrown);
            string stringCopycheckBrown = Convert.ToBase64String(bytecheckBrown);

            string checkPurple = "d://img//Star.png";
            Byte[] bytecheckPurple = System.IO.File.ReadAllBytes(checkPurple);
            string stringCopycheckPurple = Convert.ToBase64String(bytecheckPurple);

            string checkTurquoise = "d://img//Subtraction.png";
            Byte[] bytecheckTurquoise = System.IO.File.ReadAllBytes(checkTurquoise);
            string stringCopycheckTurquoise = Convert.ToBase64String(bytecheckTurquoise);

            var et = 0;
        }

        private void readRadio()
        {
            string radioBlack = "d://images//radioBlack.png";
            Byte[] byteRadioBlack = System.IO.File.ReadAllBytes(radioBlack);
            string stringCopyRadioBlack = Convert.ToBase64String(byteRadioBlack);

            string radioBlackFull = "d://images//radioBlackFull.png";
            Byte[] byteRadioBlackFull = System.IO.File.ReadAllBytes(radioBlackFull);
            string stringCopyRadioBlackFull = Convert.ToBase64String(byteRadioBlackFull);

            string radioBlue = "d://images//radioBlue.png";
            Byte[] byteRadioBlue = System.IO.File.ReadAllBytes(radioBlue);
            string stringCopyRadioBlue = Convert.ToBase64String(byteRadioBlue);

            string radioBlueFull = "d://images//radioBlueFull.png";
            Byte[] byteRadioBlueFull = System.IO.File.ReadAllBytes(radioBlueFull);
            string stringCopyRadioBlueFull = Convert.ToBase64String(byteRadioBlueFull);

            string radioGray = "d://images//radioGray.png";
            Byte[] byteRadioGray = System.IO.File.ReadAllBytes(radioGray);
            string stringCopyRadioGray = Convert.ToBase64String(byteRadioGray);

            string radioGrayFull = "d://images//radioGrayFull.png";
            Byte[] byteRadioGrayFull = System.IO.File.ReadAllBytes(radioGrayFull);
            string stringCopyRadioGrayFull = Convert.ToBase64String(byteRadioGrayFull);

            string radioGreen = "d://images//radioGreen.png";
            Byte[] byteRadioGreen = System.IO.File.ReadAllBytes(radioGreen);
            string stringCopyRadioGreen = Convert.ToBase64String(byteRadioGreen);

            string radioGreenFull = "d://images//RadioGreenFull.png";
            Byte[] byteRadioGreenFull = System.IO.File.ReadAllBytes(radioGreenFull);
            string stringCopyRadioGreenFull = Convert.ToBase64String(byteRadioGreenFull);

            string radioRed = "d://images//radioRed.png";
            Byte[] byteRadioRed = System.IO.File.ReadAllBytes(radioRed);
            string stringCopyRadioRed = Convert.ToBase64String(byteRadioRed);

            string radioRedFull = "d://images//radioRedFull.png";
            Byte[] byteRadioRedFull = System.IO.File.ReadAllBytes(radioRedFull);
            string stringCopyRadioRedFull = Convert.ToBase64String(byteRadioRedFull);

            string radioYellow = "d://images//radioYellow.png";
            Byte[] byteradioYellow = System.IO.File.ReadAllBytes(radioYellow);
            string stringCopyradioYellow = Convert.ToBase64String(byteradioYellow);

            string radioYellowFull = "d://images//radioYellowFull.png";
            Byte[] byteradioYellowFull = System.IO.File.ReadAllBytes(radioYellowFull);
            string stringCopyradioYellowFull = Convert.ToBase64String(byteradioYellowFull);

            string radioOrange = "d://images//radioOrange.png";
            Byte[] byteradioOrange = System.IO.File.ReadAllBytes(radioOrange);
            string stringCopyradioOrange = Convert.ToBase64String(byteradioOrange);

            string radioOrangeFull = "d://images//radioOrangeFull.png";
            Byte[] byteradioOrangeFull = System.IO.File.ReadAllBytes(radioOrangeFull);
            string stringCopyradioOrangeFull = Convert.ToBase64String(byteradioOrangeFull);

            string radioPink = "d://images//radioPink.png";
            Byte[] byteradioPink = System.IO.File.ReadAllBytes(radioPink);
            string stringCopyradioPink = Convert.ToBase64String(byteradioPink);

            string radioPinkFull = "d://images//radioPinkFull.png";
            Byte[] byteradioPinkFull = System.IO.File.ReadAllBytes(radioPinkFull);
            string stringCopyradioPinkFull = Convert.ToBase64String(byteradioPinkFull);

            string radioWhite = "d://images//radioWhite.png";
            Byte[] byteradioWhite = System.IO.File.ReadAllBytes(radioWhite);
            string stringCopyradioWhite = Convert.ToBase64String(byteradioWhite);

            string radioWhiteFull = "d://images//radioWhiteFull.png";
            Byte[] byteradioWhiteFull = System.IO.File.ReadAllBytes(radioWhiteFull);
            string stringCopyradioWhiteFull = Convert.ToBase64String(byteradioWhiteFull);

            string radioBlueLight = "d://images//radioBlueLight.png";
            Byte[] byteradioBlueLight = System.IO.File.ReadAllBytes(radioBlueLight);
            string stringCopyradioBlueLight = Convert.ToBase64String(byteradioBlueLight);

            string radioBlueLightFull = "d://images//radioBlueLightFull.png";
            Byte[] byteradioBlueLightFull = System.IO.File.ReadAllBytes(radioBlueLightFull);
            string stringCopyradioBlueLightFull = Convert.ToBase64String(byteradioBlueLightFull);

            string radioYellowLight = "d://images//radioYellowLight.png";
            Byte[] byteradioYellowLight = System.IO.File.ReadAllBytes(radioYellowLight);
            string stringCopyradioYellowLight = Convert.ToBase64String(byteradioYellowLight);

            string radioYellowLightFull = "d://images//radioYellowLightFull.png";
            Byte[] byteradioYellowLightFull = System.IO.File.ReadAllBytes(radioYellowLightFull);
            string stringCopyradioYellowLightFull = Convert.ToBase64String(byteradioYellowLightFull);

            string radioGreenLight = "d://images//radioGreenLight.png";
            Byte[] byteradioGreenLight = System.IO.File.ReadAllBytes(radioGreenLight);
            string stringCopyradioGreenLight = Convert.ToBase64String(byteradioGreenLight);

            string radioGreenLightFull = "d://images//radioGreenLightFull.png";
            Byte[] byteradioGreenLightFull = System.IO.File.ReadAllBytes(radioGreenLightFull);
            string stringCopyradioGreenLightFull = Convert.ToBase64String(byteradioGreenLightFull);

            string radioBrown = "d://images//radioBrown.png";
            Byte[] byteradioBrown = System.IO.File.ReadAllBytes(radioBrown);
            string stringCopyradioBrown = Convert.ToBase64String(byteradioBrown);

            string radioBrownFull = "d://images//radioBrownFull.png";
            Byte[] byteradioBrownFull = System.IO.File.ReadAllBytes(radioBrownFull);
            string stringCopyradioBrownFull = Convert.ToBase64String(byteradioBrownFull);

            string radioPurple = "d://images//radioPurple.png";
            Byte[] byteradioPurple = System.IO.File.ReadAllBytes(radioPurple);
            string stringCopyradioPurple = Convert.ToBase64String(byteradioPurple);

            string radioPurpleFull = "d://images//radioPurpleFull.png";
            Byte[] byteradioPurpleFull = System.IO.File.ReadAllBytes(radioPurpleFull);
            string stringCopyradioPurpleFull = Convert.ToBase64String(byteradioPurpleFull);

            string radioTurquoise = "d://images//radioTurquoise.png";
            Byte[] byteradioTurquoise = System.IO.File.ReadAllBytes(radioTurquoise);
            string stringCopyradioTurquoise = Convert.ToBase64String(byteradioTurquoise);

            string radioTurquoiseFull = "d://images//radioTurquoiseFull.png";
            Byte[] byteradioTurquoiseFull = System.IO.File.ReadAllBytes(radioTurquoiseFull);
            string stringCopyradioTurquoiseFull = Convert.ToBase64String(byteradioTurquoiseFull);

            string radioPinkLight = "d://images//radioPinkLight.png";
            Byte[] byteradioPinkLight = System.IO.File.ReadAllBytes(radioPinkLight);
            string stringCopyradioPinkLight = Convert.ToBase64String(byteradioPinkLight);

            string radioPinkLightFull = "d://images//radioPinkLightFull.png";
            Byte[] byteradioPinkLightFull = System.IO.File.ReadAllBytes(radioPinkLightFull);
            string stringCopyradioPinkLightFull = Convert.ToBase64String(byteradioPinkLightFull);

            string radioBlueSky = "d://images//radioBlueSky.png";
            Byte[] byteradioBlueSky = System.IO.File.ReadAllBytes(radioBlueSky);
            string stringCopyradioBlueSky = Convert.ToBase64String(byteradioBlueSky);

            string radioBlueSkyFull = "d://images//radioBlueSkyFull.png";
            Byte[] byteradioBlueSkyFull = System.IO.File.ReadAllBytes(radioBlueSkyFull);
            string stringCopyradioBlueSkyFull = Convert.ToBase64String(byteradioBlueSkyFull);

        }

        private void readCollapse()
        {
            string black = "d://images//blackClose.png";
            Byte[] byteblack = System.IO.File.ReadAllBytes(black);
            string stringCopyblack = Convert.ToBase64String(byteblack);

            string blackOpen = "d://images//blackOpen.png";
            Byte[] byteblackOpen = System.IO.File.ReadAllBytes(blackOpen);
            string stringCopyblackOpen = Convert.ToBase64String(byteblackOpen);

            string blackOpenScene = "d://images//black.png";
            Byte[] byteblackOpenScene = System.IO.File.ReadAllBytes(blackOpenScene);
            string stringCopyblackOpenScene = Convert.ToBase64String(byteblackOpenScene);

            //
            string white = "d://images//whiteClose.png";
            Byte[] bytewhite = System.IO.File.ReadAllBytes(white);
            string stringCopywhite = Convert.ToBase64String(bytewhite);

            string whiteOpen = "d://images//whiteOpen.png";
            Byte[] bytewhiteOpen = System.IO.File.ReadAllBytes(whiteOpen);
            string stringCopywhiteOpen = Convert.ToBase64String(bytewhiteOpen);

            string whiteOpenScene = "d://images//white.png";
            Byte[] bytewhiteOpenScene = System.IO.File.ReadAllBytes(whiteOpenScene);
            string stringCopywhiteOpenScene = Convert.ToBase64String(bytewhiteOpenScene);
            //
            string yellow = "d://images//yellowClose.png";
            Byte[] byteyellow = System.IO.File.ReadAllBytes(yellow);
            string stringCopyyellow = Convert.ToBase64String(byteyellow);

            string yellowOpen = "d://images//yellowOpen.png";
            Byte[] byteyellowOpen = System.IO.File.ReadAllBytes(yellowOpen);
            string stringCopyyellowOpen = Convert.ToBase64String(byteyellowOpen);

            string yellowOpenScene = "d://images//yellow.png";
            Byte[] byteyellowOpenScene = System.IO.File.ReadAllBytes(yellowOpenScene);
            string stringCopyyellowOpenScene = Convert.ToBase64String(byteyellowOpenScene);
            //
            string blue = "d://images//blueClose.png";
            Byte[] byteblue = System.IO.File.ReadAllBytes(blue);
            string stringCopyblue = Convert.ToBase64String(byteblue);

            string blueOpen = "d://images//blueOpen.png";
            Byte[] byteblueOpen = System.IO.File.ReadAllBytes(blueOpen);
            string stringCopyblueOpen = Convert.ToBase64String(byteblueOpen);

            string blueOpenScene = "d://images//blue.png";
            Byte[] byteblueOpenScene = System.IO.File.ReadAllBytes(blueOpenScene);
            string stringCopyblueOpenScene = Convert.ToBase64String(byteblueOpenScene);
            //
            string brown = "d://images//brownClose.png";
            Byte[] bytebrown = System.IO.File.ReadAllBytes(brown);
            string stringCopybrown = Convert.ToBase64String(bytebrown);

            string brownOpen = "d://images//brownOpen.png";
            Byte[] bytebrownOpen = System.IO.File.ReadAllBytes(brownOpen);
            string stringCopybrownOpen = Convert.ToBase64String(bytebrownOpen);

            string brownOpenScene = "d://images//brown.png";
            Byte[] bytebrownOpenScene = System.IO.File.ReadAllBytes(brownOpenScene);
            string stringCopybrownOpenScene = Convert.ToBase64String(bytebrownOpenScene);
            //
            string blueLight = "d://images//blueLightClose.png";
            Byte[] byteblueLight = System.IO.File.ReadAllBytes(blueLight);
            string stringCopyblueLight = Convert.ToBase64String(byteblueLight);

            string blueLightOpen = "d://images//blueLightOpen.png";
            Byte[] byteblueLightOpen = System.IO.File.ReadAllBytes(blueLightOpen);
            string stringCopyblueLightOpen = Convert.ToBase64String(byteblueLightOpen);

            string blueLightOpenScene = "d://images//blueLight.png";
            Byte[] byteblueLightOpenScene = System.IO.File.ReadAllBytes(blueLightOpenScene);
            string stringCopyblueLightOpenScene = Convert.ToBase64String(byteblueLightOpenScene);
            //
            string blueSky = "d://images//blueSkyclose.png";
            Byte[] byteblueSky = System.IO.File.ReadAllBytes(blueSky);
            string stringCopyblueSky = Convert.ToBase64String(byteblueSky);

            string blueSkyOpen = "d://images//blueSkyOpen.png";
            Byte[] byteblueSkyOpen = System.IO.File.ReadAllBytes(blueSkyOpen);
            string stringCopyblueSkyOpen = Convert.ToBase64String(byteblueSkyOpen);

            string blueSkyOpenScene = "d://images//blueSky.png";
            Byte[] byteblueSkyOpenScene = System.IO.File.ReadAllBytes(blueSkyOpenScene);
            string stringCopyblueSkyOpenScene = Convert.ToBase64String(byteblueSkyOpenScene);
            //
            string green = "d://images//greenClose.png";
            Byte[] bytegreen = System.IO.File.ReadAllBytes(green);
            string stringCopygreen = Convert.ToBase64String(bytegreen);

            string greenOpen = "d://images//greenOpen.png";
            Byte[] bytegreenOpen = System.IO.File.ReadAllBytes(greenOpen);
            string stringCopygreenOpen = Convert.ToBase64String(bytegreenOpen);

            string greenOpenScene = "d://images//green.png";
            Byte[] bytegreenOpenScene = System.IO.File.ReadAllBytes(greenOpenScene);
            string stringCopygreenOpenScene = Convert.ToBase64String(bytegreenOpenScene);
            //
            string greenLight = "d://images//greenLightClose.png";
            Byte[] bytegreenLight = System.IO.File.ReadAllBytes(greenLight);
            string stringCopygreenLight = Convert.ToBase64String(bytegreenLight);

            string greenLightOpen = "d://images//greenLightOpen.png";
            Byte[] bytegreenLightOpen = System.IO.File.ReadAllBytes(greenLightOpen);
            string stringCopygreenLightOpen = Convert.ToBase64String(bytegreenLightOpen);

            string greenLightOpenScene = "d://images//greenLight.png";
            Byte[] bytegreenLightOpenScene = System.IO.File.ReadAllBytes(greenLightOpenScene);
            string stringCopygreenLightOpenScene = Convert.ToBase64String(bytegreenLightOpenScene);
            //
            string orange = "d://images//orangeClose.png";
            Byte[] byteorange = System.IO.File.ReadAllBytes(orange);
            string stringCopyorange = Convert.ToBase64String(byteorange);

            string orangeOpen = "d://images//orangeOpen.png";
            Byte[] byteorangeOpen = System.IO.File.ReadAllBytes(orangeOpen);
            string stringCopyorangeOpen = Convert.ToBase64String(byteorangeOpen);

            string orangeOpenScene = "d://images//orange.png";
            Byte[] byteorangeOpenScene = System.IO.File.ReadAllBytes(orangeOpenScene);
            string stringCopyorangeOpenScene = Convert.ToBase64String(byteorangeOpenScene);
            //
            string purple = "d://images//purpleClose.png";
            Byte[] bytepurple = System.IO.File.ReadAllBytes(purple);
            string stringCopypurple = Convert.ToBase64String(bytepurple);

            string purpleOpen = "d://images//purpleOpen.png";
            Byte[] bytepurpleOpen = System.IO.File.ReadAllBytes(purpleOpen);
            string stringCopypurpleOpen = Convert.ToBase64String(bytepurpleOpen);

            string purpleOpenScene = "d://images//purple.png";
            Byte[] bytepurpleOpenScene = System.IO.File.ReadAllBytes(purpleOpenScene);
            string stringCopypurpleOpenScene = Convert.ToBase64String(bytepurpleOpenScene);
            //
            string pink = "d://images//pinkClose.png";
            Byte[] bytepink = System.IO.File.ReadAllBytes(pink);
            string stringCopypink = Convert.ToBase64String(bytepink);

            string pinkOpen = "d://images//pinkOpen.png";
            Byte[] bytepinkOpen = System.IO.File.ReadAllBytes(pinkOpen);
            string stringCopypinkOpen = Convert.ToBase64String(bytepinkOpen);

            string pinkOpenScene = "d://images//pink.png";
            Byte[] bytepinkOpenScene = System.IO.File.ReadAllBytes(pinkOpenScene);
            string stringCopypinkOpenScene = Convert.ToBase64String(bytepinkOpenScene);
            //
            string pinkLight = "d://images//pinkLightClose.png";
            Byte[] bytepinkLight = System.IO.File.ReadAllBytes(pinkLight);
            string stringCopypinkLight = Convert.ToBase64String(bytepinkLight);

            string pinkLightOpen = "d://images//pinkLightOpen.png";
            Byte[] bytepinkLightOpen = System.IO.File.ReadAllBytes(pinkLightOpen);
            string stringCopypinkLightOpen = Convert.ToBase64String(bytepinkLightOpen);

            string pinkLightOpenScene = "d://images//pinkLight.png";
            Byte[] bytepinkLightOpenScene = System.IO.File.ReadAllBytes(pinkLightOpenScene);
            string stringCopypinkLightOpenScene = Convert.ToBase64String(bytepinkLightOpenScene);
            //
            string gray = "d://images//grayClose.png";
            Byte[] bytegray = System.IO.File.ReadAllBytes(gray);
            string stringCopygray = Convert.ToBase64String(bytegray);

            string grayOpen = "d://images//grayOpen.png";
            Byte[] bytegrayOpen = System.IO.File.ReadAllBytes(grayOpen);
            string stringCopygrayOpen = Convert.ToBase64String(bytegrayOpen);

            string grayOpenScene = "d://images//gray.png";
            Byte[] bytegrayOpenScene = System.IO.File.ReadAllBytes(grayOpenScene);
            string stringCopygrayOpenScene = Convert.ToBase64String(bytegrayOpenScene);
            //
            string turquoise = "d://images//turquoiseClose.png";
            Byte[] byteturquoise = System.IO.File.ReadAllBytes(turquoise);
            string stringCopyturquoise = Convert.ToBase64String(byteturquoise);

            string turquoiseOpen = "d://images//turquoiseOpen.png";
            Byte[] byteturquoiseOpen = System.IO.File.ReadAllBytes(turquoiseOpen);
            string stringCopyturquoiseOpen = Convert.ToBase64String(byteturquoiseOpen);

            string turquoiseOpenScene = "d://images//turquoise.png";
            Byte[] byteturquoiseOpenScene = System.IO.File.ReadAllBytes(turquoiseOpenScene);
            string stringCopyturquoiseOpenScene = Convert.ToBase64String(byteturquoiseOpenScene);
            //
            string red = "d://images//redClose.png";
            Byte[] bytered = System.IO.File.ReadAllBytes(red);
            string stringCopyred = Convert.ToBase64String(bytered);

            string redOpen = "d://images//redOpen.png";
            Byte[] byteredOpen = System.IO.File.ReadAllBytes(redOpen);
            string stringCopyredOpen = Convert.ToBase64String(byteredOpen);

            string redOpenScene = "d://images//red.png";
            Byte[] byteredOpenScene = System.IO.File.ReadAllBytes(redOpenScene);
            string stringCopyredOpenScene = Convert.ToBase64String(byteredOpenScene);
            //
            string yellowLight = "d://images//yellowLightClose.png";
            Byte[] byteyellowLight = System.IO.File.ReadAllBytes(yellowLight);
            string stringCopyyellowLight = Convert.ToBase64String(byteyellowLight);

            string yellowLightOpen = "d://images//yellowLightOpen.png";
            Byte[] byteyellowLightOpen = System.IO.File.ReadAllBytes(yellowLightOpen);
            string stringCopyyellowLightOpen = Convert.ToBase64String(byteyellowLightOpen);

            string yellowLightOpenScene = "d://images//yellowLight.png";
            Byte[] byteyellowLightOpenScene = System.IO.File.ReadAllBytes(yellowLightOpenScene);
            string stringCopyyellowLightOpenScene = Convert.ToBase64String(byteyellowLightOpenScene);
            //
        }


        private void readTitlesShadowBottom()
        {
            string titleblackLeft = "d://images//blackLeft.png";
            Byte[] byteblackLeft = System.IO.File.ReadAllBytes(titleblackLeft);
            string stringCopyblackLeft = Convert.ToBase64String(byteblackLeft);

            string titleblackRight = "d://images//blackRight.png";
            Byte[] byteblackRight = System.IO.File.ReadAllBytes(titleblackRight);
            string stringCopyblackRight = Convert.ToBase64String(byteblackRight);

            string titleblackCenter = "d://images//blackCenter.png";
            Byte[] byteblackCenter = System.IO.File.ReadAllBytes(titleblackCenter);
            string stringCopyblackCenter = Convert.ToBase64String(byteblackCenter);

            string titleblueLeft = "d://images//blueLeft.png";
            Byte[] byteblueLeft = System.IO.File.ReadAllBytes(titleblueLeft);
            string stringCopyblueLeft = Convert.ToBase64String(byteblueLeft);

            string titleblueRight = "d://images//blueRight.png";
            Byte[] byteblueRight = System.IO.File.ReadAllBytes(titleblueRight);
            string stringCopyblueRight = Convert.ToBase64String(byteblueRight);

            string titleblueCenter = "d://images//blueCenter.png";
            Byte[] byteblueCenter = System.IO.File.ReadAllBytes(titleblueCenter);
            string stringCopyblueCenter = Convert.ToBase64String(byteblueCenter);

            string titleblueSkyLeft = "d://images//blueSkyLeft.png";
            Byte[] byteblueSkyLeft = System.IO.File.ReadAllBytes(titleblueSkyLeft);
            string stringCopyblueSkyLeft = Convert.ToBase64String(byteblueSkyLeft);

            string titleblueSkyRight = "d://images//blueSkyRight.png";
            Byte[] byteblueSkyRight = System.IO.File.ReadAllBytes(titleblueSkyRight);
            string stringCopyblueSkyRight = Convert.ToBase64String(byteblueSkyRight);

            string titleblueSkyCenter = "d://images//blueSkyCenter.png";
            Byte[] byteblueSkyCenter = System.IO.File.ReadAllBytes(titleblueSkyCenter);
            string stringCopyblueSkyCenter = Convert.ToBase64String(byteblueSkyCenter);

            string titlebrownLeft = "d://images//brownLeft.png";
            Byte[] bytebrownLeft = System.IO.File.ReadAllBytes(titlebrownLeft);
            string stringCopybrowLeft = Convert.ToBase64String(bytebrownLeft);

            string titlebrownRight = "d://images//brownRight.png";
            Byte[] bytebrownRight = System.IO.File.ReadAllBytes(titlebrownRight);
            string stringCopybrownRight = Convert.ToBase64String(bytebrownRight);

            string titlebrownCenter = "d://images//brownCenter.png";
            Byte[] bytebrownCenter = System.IO.File.ReadAllBytes(titlebrownCenter);
            string stringCopybrownCenter = Convert.ToBase64String(bytebrownCenter);

            string titlegrayLeft = "d://images//grayLeft.png";
            Byte[] bytegrayLeft = System.IO.File.ReadAllBytes(titlegrayLeft);
            string stringCopygrayLeft = Convert.ToBase64String(bytegrayLeft);

            string titlegrayRight = "d://images//grayRight.png";
            Byte[] bytegrayRight = System.IO.File.ReadAllBytes(titlegrayRight);
            string stringCopygrayRight = Convert.ToBase64String(bytegrayRight);

            string titlegrayCenter = "d://images//grayCenter.png";
            Byte[] bytegrayCenter = System.IO.File.ReadAllBytes(titlegrayCenter);
            string stringCopygrayCenter = Convert.ToBase64String(bytegrayCenter);

            string titlegreenLeft = "d://images//greenLeft.png";
            Byte[] bytegreenLeft = System.IO.File.ReadAllBytes(titlegreenLeft);
            string stringCopygreenLeft = Convert.ToBase64String(bytegreenLeft);

            string titlegreenRight = "d://images//greenRight.png";
            Byte[] bytegreenRight = System.IO.File.ReadAllBytes(titlegreenRight);
            string stringCopygreenRight = Convert.ToBase64String(bytegreenRight);

            string titlegreenCenter = "d://images//greenCenter.png";
            Byte[] bytegreenCenter = System.IO.File.ReadAllBytes(titlegreenCenter);
            string stringCopygreenCenter = Convert.ToBase64String(bytegreenCenter);

            string titlegreenLightLeft = "d://images//greenLightLeft.png";
            Byte[] bytegreenLightLeft = System.IO.File.ReadAllBytes(titlegreenLightLeft);
            string stringCopygreenLightLeft = Convert.ToBase64String(bytegreenLightLeft);

            string titlegreenLightRight = "d://images//greenLightRight.png";
            Byte[] bytegreenLightRight = System.IO.File.ReadAllBytes(titlegreenLightRight);
            string stringCopygreenLightRight = Convert.ToBase64String(bytegreenLightRight);

            string titlegreenLightCenter = "d://images//greenLightCenter.png";
            Byte[] bytegreenLightCenter = System.IO.File.ReadAllBytes(titlegreenLightCenter);
            string stringCopygreenLightCenter = Convert.ToBase64String(bytegreenLightCenter);

            string titleorangeLeft = "d://images//orangeLeft.png";
            Byte[] byteorangeLeft = System.IO.File.ReadAllBytes(titleorangeLeft);
            string stringCopyorangeLeft = Convert.ToBase64String(byteorangeLeft);

            string titleorangeRight = "d://images//orangeRight.png";
            Byte[] byteorangeRight = System.IO.File.ReadAllBytes(titleorangeRight);
            string stringCopyorangeRight = Convert.ToBase64String(byteorangeRight);

            string titleorangeCenter = "d://images//orangeCenter.png";
            Byte[] byteorangeCenter = System.IO.File.ReadAllBytes(titleorangeCenter);
            string stringCopyorangeCenter = Convert.ToBase64String(byteorangeCenter);

            string titlepinkLeft = "d://images//pinkLeft.png";
            Byte[] bytepinkLeft = System.IO.File.ReadAllBytes(titlepinkLeft);
            string stringCopypinkLeft = Convert.ToBase64String(bytepinkLeft);

            string titlepinkRight = "d://images//pinkRight.png";
            Byte[] bytepinkRight = System.IO.File.ReadAllBytes(titlepinkRight);
            string stringCopypinkRight = Convert.ToBase64String(bytepinkRight);

            string titlepinkCenter = "d://images//pinkCenter.png";
            Byte[] bytepinkCenter = System.IO.File.ReadAllBytes(titlepinkCenter);
            string stringCopypinkCenter = Convert.ToBase64String(bytepinkCenter);

            string titlepinkLightLeft = "d://images//pinkLightLeft.png";
            Byte[] bytepinkLightLeft = System.IO.File.ReadAllBytes(titlepinkLightLeft);
            string stringCopypinkLightLeft = Convert.ToBase64String(bytepinkLightLeft);

            string titlepinkLightRight = "d://images//pinkLightRight.png";
            Byte[] bytepinkLightRight = System.IO.File.ReadAllBytes(titlepinkLightRight);
            string stringCopypinkLightRight = Convert.ToBase64String(bytepinkLightRight);

            string titlepinkLightCenter = "d://images//pinkLightCenter.png";
            Byte[] bytepinkLightCenter = System.IO.File.ReadAllBytes(titlepinkLightCenter);
            string stringCopypinkLightCenter = Convert.ToBase64String(bytepinkLightCenter);

            string titlepurpleLeft = "d://images//purpleLeft.png";
            Byte[] bytepurpleLeft = System.IO.File.ReadAllBytes(titlepurpleLeft);
            string stringCopypurpleLeft = Convert.ToBase64String(bytepurpleLeft);

            string titlepurpleRight = "d://images//purpleRight.png";
            Byte[] bytepurpleRight = System.IO.File.ReadAllBytes(titlepurpleRight);
            string stringCopypurpleRight = Convert.ToBase64String(bytepurpleRight);

            string titlepurpleCenter = "d://images//purpleCenter.png";
            Byte[] bytepurpleCenter = System.IO.File.ReadAllBytes(titlepurpleCenter);
            string stringCopypurpleCenter = Convert.ToBase64String(bytepurpleCenter);

            string titleredLeft = "d://images//redLeft.png";
            Byte[] byteredLeft = System.IO.File.ReadAllBytes(titleredLeft);
            string stringCopyredLeft = Convert.ToBase64String(byteredLeft);

            string titleredRight = "d://images//redRight.png";
            Byte[] byteredRight = System.IO.File.ReadAllBytes(titleredRight);
            string stringCopyredRight = Convert.ToBase64String(byteredRight);

            string titleredCenter = "d://images//redCenter.png";
            Byte[] byteredCenter = System.IO.File.ReadAllBytes(titleredCenter);
            string stringCopyredCenter = Convert.ToBase64String(byteredCenter);

            string titletorquoiseLeft = "d://images//torquoiseLeft.png";
            Byte[] bytetorquoiseLeft = System.IO.File.ReadAllBytes(titletorquoiseLeft);
            string stringCopytorquoiseLeft = Convert.ToBase64String(bytetorquoiseLeft);

            string titletorquoiseRight = "d://images//torquoiseRight.png";
            Byte[] bytetorquoiseRight = System.IO.File.ReadAllBytes(titletorquoiseRight);
            string stringCopytorquoiseRight = Convert.ToBase64String(bytetorquoiseRight);

            string titletorquoiseCenter = "d://images//torquoiseCenter.png";
            Byte[] bytetorquoiseCenter = System.IO.File.ReadAllBytes(titletorquoiseCenter);
            string stringCopytorquoiseCenter = Convert.ToBase64String(bytetorquoiseCenter);

            string titleYellowLeft = "d://images//yellowLeft.png";
            Byte[] byteYellowLeft = System.IO.File.ReadAllBytes(titleYellowLeft);
            string stringCopyYellowLeft = Convert.ToBase64String(byteYellowLeft);

            string titleYellowRight = "d://images//YellowRight.png";
            Byte[] byteYellowRight = System.IO.File.ReadAllBytes(titleYellowRight);
            string stringCopyYellowRight = Convert.ToBase64String(byteYellowRight);

            string titleYellowCenter = "d://images//YellowCenter.png";
            Byte[] byteYellowCenter = System.IO.File.ReadAllBytes(titleYellowCenter);
            string stringCopyYellowCenter = Convert.ToBase64String(byteYellowCenter);

            string titleYellowLightLeft = "d://images//YellowLightLeft.png";
            Byte[] byteYellowLightLeft = System.IO.File.ReadAllBytes(titleYellowLightLeft);
            string stringCopyYellowLightLeft = Convert.ToBase64String(byteYellowLightLeft);

            string titleYellowLightRight = "d://images//YellowLightRight.png";
            Byte[] byteYellowLightRight = System.IO.File.ReadAllBytes(titleYellowLightRight);
            string stringCopyYellowLightRight = Convert.ToBase64String(byteYellowLightRight);

            string titleYellowLightCenter = "d://images//YellowLightCenter.png";
            Byte[] byteYellowLightCenter = System.IO.File.ReadAllBytes(titleYellowLightCenter);
            string stringCopyYellowLightCenter = Convert.ToBase64String(byteYellowLightCenter);

            string titleblueLightLeft = "d://images//blueLightLeft.png";
            Byte[] byteblueLightLeft = System.IO.File.ReadAllBytes(titleblueLightLeft);
            string stringCopyblueLightLeft = Convert.ToBase64String(byteblueLightLeft);

            string titleblueLightRight = "d://images//blueLightRight.png";
            Byte[] byteblueLightRight = System.IO.File.ReadAllBytes(titleblueLightRight);
            string stringCopyblueLightRight = Convert.ToBase64String(byteblueLightRight);

            string titleblueLightCenter = "d://images//blueLightCenter.png";
            Byte[] byteblueLightCenter = System.IO.File.ReadAllBytes(titleblueLightCenter);
            string stringCopyblueLightCenter = Convert.ToBase64String(byteblueLightCenter);
            var et = 0;
        }

        private void readButtons()
        {
            string btnBrown = "d://images//btnBrown.png";
            Byte[] byteBrown = System.IO.File.ReadAllBytes(btnBrown);
            string stringCopyBrown = Convert.ToBase64String(byteBrown);

            string btnPurple = "d://images//btnPurple.png";
            Byte[] bytePurple = System.IO.File.ReadAllBytes(btnPurple);
            string stringCopyPurple = Convert.ToBase64String(bytePurple);

            string btnTurquoise = "d://images//btnTurquoise.png";
            Byte[] byteTurquoise = System.IO.File.ReadAllBytes(btnTurquoise);
            string stringCopyTurquoise = Convert.ToBase64String(byteTurquoise);

            string btnBlueSky = "d://images//btnBlueSky.png";
            Byte[] byteBlueSky = System.IO.File.ReadAllBytes(btnBlueSky);
            string stringCopyBlueSky = Convert.ToBase64String(byteBlueSky);

            string btnPinkLight = "d://images//btnPinkLight.png";
            Byte[] bytePinkLight = System.IO.File.ReadAllBytes(btnPinkLight);
            string stringCopyPinkLight = Convert.ToBase64String(bytePinkLight);
        }

        public void readBox()
        {
            string boxBlack = "d://images//boxBlack.png";
            Byte[] byteboxBlack = System.IO.File.ReadAllBytes(boxBlack);
            string stringCopyboxBlack = Convert.ToBase64String(byteboxBlack);

            string boxBlue = "d://images//boxBlue.png";
            Byte[] byteboxBlue = System.IO.File.ReadAllBytes(boxBlue);
            string stringCopyboxBlue = Convert.ToBase64String(byteboxBlue);

            string boxGray = "d://images//boxGray.png";
            Byte[] byteboxGray = System.IO.File.ReadAllBytes(boxGray);
            string stringCopyboxGray = Convert.ToBase64String(byteboxGray);

            string boxGreen = "d://images//boxGreen.png";
            Byte[] byteboxGreen = System.IO.File.ReadAllBytes(boxGreen);
            string stringCopyboxGreen = Convert.ToBase64String(byteboxGreen);

            string boxRed = "d://images//boxRed.png";
            Byte[] byteboxRed = System.IO.File.ReadAllBytes(boxRed);
            string stringCopyboxRed = Convert.ToBase64String(byteboxRed);

            string boxYellow = "d://images//boxYellow.png";
            Byte[] byteboxYellow = System.IO.File.ReadAllBytes(boxYellow);
            string stringCopyboxYellow = Convert.ToBase64String(byteboxYellow);

            string boxOrange = "d://images//boxOrange.png";
            Byte[] byteboxOrange = System.IO.File.ReadAllBytes(boxOrange);
            string stringCopyboxOrange = Convert.ToBase64String(byteboxOrange);

            string boxPink = "d://images//boxPink.png";
            Byte[] byteboxPink = System.IO.File.ReadAllBytes(boxPink);
            string stringCopyboxPink = Convert.ToBase64String(byteboxPink);

            string boxWhite = "d://images//boxWhite.png";
            Byte[] byteboxWhite = System.IO.File.ReadAllBytes(boxWhite);
            string stringCopyboxWhite = Convert.ToBase64String(byteboxWhite);

            string boxBlueLight = "d://images//boxBlueLight.png";
            Byte[] byteboxBlueLight = System.IO.File.ReadAllBytes(boxBlueLight);
            string stringCopyboxBlueLight = Convert.ToBase64String(byteboxBlueLight);

            string boxYellowLight = "d://images//boxYellowLight.png";
            Byte[] byteboxYellowLight = System.IO.File.ReadAllBytes(boxYellowLight);
            string stringCopyboxYellowLight = Convert.ToBase64String(byteboxYellowLight);

            string boxGreenLight = "d://images//boxGreenLight.png";
            Byte[] byteboxGreenLight = System.IO.File.ReadAllBytes(boxGreenLight);
            string stringCopyboxGreenLight = Convert.ToBase64String(byteboxGreenLight);

            string boxBrown = "d://images//boxBrown.png";
            Byte[] byteboxBrown = System.IO.File.ReadAllBytes(boxBrown);
            string stringCopyBrown = Convert.ToBase64String(byteboxBrown);

            string boxPurple = "d://images//boxPurple.png";
            Byte[] byteboxPurple = System.IO.File.ReadAllBytes(boxPurple);
            string stringCopyPurple = Convert.ToBase64String(byteboxPurple);

            string boxTurquoise = "d://images//boxTurquoise.png";
            Byte[] byteboxTurquoise = System.IO.File.ReadAllBytes(boxTurquoise);
            string stringCopyTurquoise = Convert.ToBase64String(byteboxTurquoise);

            string boxPinkLight = "d://images//boxPinkLight.png";
            Byte[] byteboxPinkLight = System.IO.File.ReadAllBytes(boxPinkLight);
            string stringCopyPinkLight = Convert.ToBase64String(byteboxPinkLight);

            string boxBlueSky = "d://images//boxBlueSky.png";
            Byte[] byteboxBlueSky = System.IO.File.ReadAllBytes(boxBlueSky);
            string stringCopyBlueSky = Convert.ToBase64String(byteboxBlueSky);

            string boxRedLight = "d://images//boxRedLight.png";
            Byte[] byteboxRedLight = System.IO.File.ReadAllBytes(boxRedLight);
            string stringCopyRedLight = Convert.ToBase64String(byteboxRedLight);

            string boxGrayLight = "d://images//boxGrayLight.png";
            Byte[] byteboxGrayLight = System.IO.File.ReadAllBytes(boxGrayLight);
            string stringCopyGrayLight = Convert.ToBase64String(byteboxGrayLight);

            var et = 0;
        }
        
        public void readLine()
        {
            string lineBlack = "d://images//box.png";
            Byte[] byteLineBlack = System.IO.File.ReadAllBytes(lineBlack);
            string stringCopyLineBlack = Convert.ToBase64String(byteLineBlack);

            string lineBlue = "d://images//lineBlue.png";
            Byte[] bytelineBlue = System.IO.File.ReadAllBytes(lineBlue);
            string stringCopylineBlue = Convert.ToBase64String(bytelineBlue);

            string lineGray = "d://images//lineGray.png";
            Byte[] bytelineGray = System.IO.File.ReadAllBytes(lineGray);
            string stringCopylineGray = Convert.ToBase64String(bytelineGray);

            string lineGreen = "d://images//lineGreen.png";
            Byte[] bytelineGreen = System.IO.File.ReadAllBytes(lineGreen);
            string stringCopylineGreen = Convert.ToBase64String(bytelineGreen);

            string lineRed = "d://images//lineRed.png";
            Byte[] bytelineRed = System.IO.File.ReadAllBytes(lineRed);
            string stringCopylineRed = Convert.ToBase64String(bytelineRed);

            string lineYellow = "d://images//lineYellow.png";
            Byte[] bytelineYellow = System.IO.File.ReadAllBytes(lineYellow);
            string stringCopylineYellow = Convert.ToBase64String(bytelineYellow);

            string lineOrange = "d://images//lineOrange.png";
            Byte[] bytelineOrange = System.IO.File.ReadAllBytes(lineOrange);
            string stringCopylineOrange = Convert.ToBase64String(bytelineOrange);

            string linePink = "d://images//linePink.png";
            Byte[] bytelinePink = System.IO.File.ReadAllBytes(linePink);
            string stringCopylinePink = Convert.ToBase64String(bytelinePink);

            string lineWhite = "d://images//lineWhite.png";
            Byte[] bytelineWhite = System.IO.File.ReadAllBytes(lineWhite);
            string stringCopylineWhite = Convert.ToBase64String(bytelineWhite);

            string lineBlueLight = "d://images//lineBlueLight.png";
            Byte[] bytelineBlueLight = System.IO.File.ReadAllBytes(lineBlueLight);
            string stringCopylineBlueLight = Convert.ToBase64String(bytelineBlueLight);

            string lineYellowLight = "d://images//lineYellowLight.png";
            Byte[] bytelineYellowLight = System.IO.File.ReadAllBytes(lineYellowLight);
            string stringCopylineYellowLight = Convert.ToBase64String(bytelineYellowLight);

            string lineGreenLight = "d://images//lineGreenLight.png";
            Byte[] bytelineGreenLight = System.IO.File.ReadAllBytes(lineGreenLight);
            string stringCopylineGreenLight = Convert.ToBase64String(bytelineGreenLight);

            string lineBrown = "d://images//lineBrown.png";
            Byte[] bytelineBrown = System.IO.File.ReadAllBytes(lineBrown);
            string stringCopylineBrown = Convert.ToBase64String(bytelineBrown);

            string linePurple = "d://images//linePurple.png";
            Byte[] bytelinePurple = System.IO.File.ReadAllBytes(linePurple);
            string stringCopylinePurple = Convert.ToBase64String(bytelinePurple);

            string lineTurquoise = "d://images//lineTurquoise.png";
            Byte[] bytelineTurquoise = System.IO.File.ReadAllBytes(lineTurquoise);
            string stringCopylineTurquoise = Convert.ToBase64String(bytelineTurquoise);

            string linePinkLight = "d://images//linePinkLight.png";
            Byte[] bytelinePinkLight = System.IO.File.ReadAllBytes(linePinkLight);
            string stringCopylinePinkLight = Convert.ToBase64String(bytelinePinkLight);

            string lineBlueSky = "d://images//lineBlueSky.png";
            Byte[] bytelineBlueSky = System.IO.File.ReadAllBytes(lineBlueSky);
            string stringCopylineBlueSky = Convert.ToBase64String(bytelineBlueSky);

            var er = 0;
        }

        public void readRadiosmoke()
        {
            string radioBlack = "d://images//radioBlack.png";
            Byte[] byteRadioBlack = System.IO.File.ReadAllBytes(radioBlack);
            string stringCopyRadioBlack = Convert.ToBase64String(byteRadioBlack);

            string radioBlackFull = "d://images//radioBlackFull.png";
            Byte[] byteRadioBlackFull = System.IO.File.ReadAllBytes(radioBlackFull);
            string stringCopyRadioBlackFull = Convert.ToBase64String(byteRadioBlackFull);

            string radioBlue = "d://images//radioBlue.png";
            Byte[] byteRadioBlue = System.IO.File.ReadAllBytes(radioBlue);
            string stringCopyRadioBlue = Convert.ToBase64String(byteRadioBlue);

            string radioBlueFull = "d://images//radioBlueFull.png";
            Byte[] byteRadioBlueFull = System.IO.File.ReadAllBytes(radioBlueFull);
            string stringCopyRadioBlueFull = Convert.ToBase64String(byteRadioBlueFull);

            string radioGray = "d://images//radioGray.png";
            Byte[] byteRadioGray = System.IO.File.ReadAllBytes(radioGray);
            string stringCopyRadioGray = Convert.ToBase64String(byteRadioGray);

            string radioGrayFull = "d://images//radioGrayFull.png";
            Byte[] byteRadioGrayFull = System.IO.File.ReadAllBytes(radioGrayFull);
            string stringCopyRadioGrayFull = Convert.ToBase64String(byteRadioGrayFull);

            string radioGreen = "d://images//radioGreen.png";
            Byte[] byteRadioGreen = System.IO.File.ReadAllBytes(radioGreen);
            string stringCopyRadioGreen = Convert.ToBase64String(byteRadioGreen);

            string radioGreenFull = "d://images//RadioGreenFull.png";
            Byte[] byteRadioGreenFull = System.IO.File.ReadAllBytes(radioGreenFull);
            string stringCopyRadioGreenFull = Convert.ToBase64String(byteRadioGreenFull);

            string radioRed = "d://images//radioRed.png";
            Byte[] byteRadioRed = System.IO.File.ReadAllBytes(radioRed);
            string stringCopyRadioRed = Convert.ToBase64String(byteRadioRed);

            string radioRedFull = "d://images//radioRedFull.png";
            Byte[] byteRadioRedFull = System.IO.File.ReadAllBytes(radioRedFull);
            string stringCopyRadioRedFull = Convert.ToBase64String(byteRadioRedFull);

            string radioYellow = "d://images//radioYellow.png";
            Byte[] byteradioYellow = System.IO.File.ReadAllBytes(radioYellow);
            string stringCopyradioYellow = Convert.ToBase64String(byteradioYellow);

            string radioYellowFull = "d://images//radioYellowFull.png";
            Byte[] byteradioYellowFull = System.IO.File.ReadAllBytes(radioYellowFull);
            string stringCopyradioYellowFull = Convert.ToBase64String(byteradioYellowFull);

            string radioOrange = "d://images//radioOrange.png";
            Byte[] byteradioOrange = System.IO.File.ReadAllBytes(radioOrange);
            string stringCopyradioOrange = Convert.ToBase64String(byteradioOrange);

            string radioOrangeFull = "d://images//radioOrangeFull.png";
            Byte[] byteradioOrangeFull = System.IO.File.ReadAllBytes(radioOrangeFull);
            string stringCopyradioOrangeFull = Convert.ToBase64String(byteradioOrangeFull);

            string radioPink = "d://images//radioPink.png";
            Byte[] byteradioPink = System.IO.File.ReadAllBytes(radioPink);
            string stringCopyradioPink = Convert.ToBase64String(byteradioPink);

            string radioPinkFull = "d://images//radioPinkFull.png";
            Byte[] byteradioPinkFull = System.IO.File.ReadAllBytes(radioPinkFull);
            string stringCopyradioPinkFull = Convert.ToBase64String(byteradioPinkFull);

            string radioWhite = "d://images//radioWhite.png";
            Byte[] byteradioWhite = System.IO.File.ReadAllBytes(radioWhite);
            string stringCopyradioWhite = Convert.ToBase64String(byteradioWhite);

            string radioWhiteFull = "d://images//radioWhiteFull.png";
            Byte[] byteradioWhiteFull = System.IO.File.ReadAllBytes(radioWhiteFull);
            string stringCopyradioWhiteFull = Convert.ToBase64String(byteradioWhiteFull);

            string radioBlueLight = "d://images//radioBlueLight.png";
            Byte[] byteradioBlueLight = System.IO.File.ReadAllBytes(radioBlueLight);
            string stringCopyradioBlueLight = Convert.ToBase64String(byteradioBlueLight);

            string radioBlueLightFull = "d://images//radioBlueLightFull.png";
            Byte[] byteradioBlueLightFull = System.IO.File.ReadAllBytes(radioBlueLightFull);
            string stringCopyradioBlueLightFull = Convert.ToBase64String(byteradioBlueLightFull);

            string radioYellowLight = "d://images//radioYellowLight.png";
            Byte[] byteradioYellowLight = System.IO.File.ReadAllBytes(radioYellowLight);
            string stringCopyradioYellowLight = Convert.ToBase64String(byteradioYellowLight);

            string radioYellowLightFull = "d://images//radioYellowLightFull.png";
            Byte[] byteradioYellowLightFull = System.IO.File.ReadAllBytes(radioYellowLightFull);
            string stringCopyradioYellowLightFull = Convert.ToBase64String(byteradioYellowLightFull);

            string radioGreenLight = "d://images//radioGreenLight.png";
            Byte[] byteradioGreenLight = System.IO.File.ReadAllBytes(radioGreenLight);
            string stringCopyradioGreenLight = Convert.ToBase64String(byteradioGreenLight);

            string radioGreenLightFull = "d://images//radioGreenLightFull.png";
            Byte[] byteradioGreenLightFull = System.IO.File.ReadAllBytes(radioGreenLightFull);
            string stringCopyradioGreenLightFull = Convert.ToBase64String(byteradioGreenLightFull);

            string radioBrown = "d://images//radioBrown.png";
            Byte[] byteradioBrown = System.IO.File.ReadAllBytes(radioBrown);
            string stringCopyradioBrown = Convert.ToBase64String(byteradioBrown);

            string radioBrownFull = "d://images//radioBrownFull.png";
            Byte[] byteradioBrownFull = System.IO.File.ReadAllBytes(radioBrownFull);
            string stringCopyradioBrownFull = Convert.ToBase64String(byteradioBrownFull);

            string radioPurple = "d://images//radioPurple.png";
            Byte[] byteradioPurple = System.IO.File.ReadAllBytes(radioPurple);
            string stringCopyradioPurple = Convert.ToBase64String(byteradioPurple);

            string radioPurpleFull = "d://images//radioPurpleFull.png";
            Byte[] byteradioPurpleFull = System.IO.File.ReadAllBytes(radioPurpleFull);
            string stringCopyradioPurpleFull = Convert.ToBase64String(byteradioPurpleFull);

            string radioTurquoise = "d://images//radioTurquoise.png";
            Byte[] byteradioTurquoise = System.IO.File.ReadAllBytes(radioTurquoise);
            string stringCopyradioTurquoise = Convert.ToBase64String(byteradioTurquoise);

            string radioTurquoiseFull = "d://images//radioTurquoiseFull.png";
            Byte[] byteradioTurquoiseFull = System.IO.File.ReadAllBytes(radioTurquoiseFull);
            string stringCopyradioTurquoiseFull = Convert.ToBase64String(byteradioTurquoiseFull);

            string radioPinkLight = "d://images//radioPinkLight.png";
            Byte[] byteradioPinkLight = System.IO.File.ReadAllBytes(radioPinkLight);
            string stringCopyradioPinkLight = Convert.ToBase64String(byteradioPinkLight);

            string radioPinkLightFull = "d://images//radioPinkLightFull.png";
            Byte[] byteradioPinkLightFull = System.IO.File.ReadAllBytes(radioPinkLightFull);
            string stringCopyradioPinkLightFull = Convert.ToBase64String(byteradioPinkLightFull);

            string radioBlueSky = "d://images//radioBlueSky.png";
            Byte[] byteradioBlueSky = System.IO.File.ReadAllBytes(radioBlueSky);
            string stringCopyradioBlueSky = Convert.ToBase64String(byteradioBlueSky);

            string radioBlueSkyFull = "d://images//radioBlueSkyFull.png";
            Byte[] byteradioBlueSkyFull = System.IO.File.ReadAllBytes(radioBlueSkyFull);
            string stringCopyradioBlueSkyFull = Convert.ToBase64String(byteradioBlueSkyFull);
            var er = 0;
        }

        public void readChecks()
        {
            string checkBlack = "d://images//checkBlack.png";
            Byte[] bytecheckBlack = System.IO.File.ReadAllBytes(checkBlack);
            string stringCopycheckBlack = Convert.ToBase64String(bytecheckBlack);

            string checkBlackFull = "d://images//checkBlackFull.png";
            Byte[] bytecheckBlackFull = System.IO.File.ReadAllBytes(checkBlackFull);
            string stringCopycheckBlackFull = Convert.ToBase64String(bytecheckBlackFull);

            string checkBlue = "d://images//checkBlue.png";
            Byte[] bytecheckBlue = System.IO.File.ReadAllBytes(checkBlue);
            string stringCopycheckBlue = Convert.ToBase64String(bytecheckBlue);

            string checkBlueFull = "d://images//checkBlueFull.png";
            Byte[] bytecheckBlueFull = System.IO.File.ReadAllBytes(checkBlueFull);
            string stringCopycheckBlueFull = Convert.ToBase64String(bytecheckBlueFull);

            string checkGray = "d://images//checkGray.png";
            Byte[] bytecheckGray = System.IO.File.ReadAllBytes(checkGray);
            string stringCopycheckGray = Convert.ToBase64String(bytecheckGray);

            string checkGrayFull = "d://images//checkGrayFull.png";
            Byte[] bytecheckGrayFull = System.IO.File.ReadAllBytes(checkGrayFull);
            string stringCopycheckGrayFull = Convert.ToBase64String(bytecheckGrayFull);

            string checkGreen = "d://images//checkGreen.png";
            Byte[] bytecheckGreen = System.IO.File.ReadAllBytes(checkGreen);
            string stringCopycheckGreen = Convert.ToBase64String(bytecheckGreen);

            string checkGreenFull = "d://images//checkGreenFull.png";
            Byte[] bytecheckGreenFull = System.IO.File.ReadAllBytes(checkGreenFull);
            string stringCopycheckGreenFull = Convert.ToBase64String(bytecheckGreenFull);

            string checkRed = "d://images//checkRed.png";
            Byte[] bytecheckRed = System.IO.File.ReadAllBytes(checkRed);
            string stringCopycheckRed = Convert.ToBase64String(bytecheckRed);

            string checkRedFull = "d://images//checkRedFull.png";
            Byte[] bytecheckRedFull = System.IO.File.ReadAllBytes(checkRedFull);
            string stringCopycheckRedFull = Convert.ToBase64String(bytecheckRedFull);

            string checkYellow = "d://images//checkYellow.png";
            Byte[] bytecheckYellow = System.IO.File.ReadAllBytes(checkYellow);
            string stringCopycheckYellow = Convert.ToBase64String(bytecheckYellow);

            string checkYellowFull = "d://images//checkYellowFull.png";
            Byte[] bytecheckYellowFull = System.IO.File.ReadAllBytes(checkYellowFull);
            string stringCopycheckYellowFull = Convert.ToBase64String(bytecheckYellowFull);

            string checkOrange = "d://images//checkOrange.png";
            Byte[] bytecheckOrange = System.IO.File.ReadAllBytes(checkOrange);
            string stringCopycheckOrange = Convert.ToBase64String(bytecheckOrange);

            string checkOrangeFull = "d://images//checkOrangeFull.png";
            Byte[] bytecheckOrangeFull = System.IO.File.ReadAllBytes(checkOrangeFull);
            string stringCopycheckOrangeFull = Convert.ToBase64String(bytecheckOrangeFull);

            string checkPink = "d://images//checkPink.png";
            Byte[] bytecheckPink = System.IO.File.ReadAllBytes(checkPink);
            string stringCopycheckPink = Convert.ToBase64String(bytecheckPink);

            string checkPinkFull = "d://images//checkPinkFull.png";
            Byte[] bytecheckPinkFull = System.IO.File.ReadAllBytes(checkPinkFull);
            string stringCopycheckPinkFull = Convert.ToBase64String(bytecheckPinkFull);

            string checkWhite = "d://images//checkWhite.png";
            Byte[] bytecheckWhite = System.IO.File.ReadAllBytes(checkWhite);
            string stringCopycheckWhite = Convert.ToBase64String(bytecheckWhite);

            string checkWhiteFull = "d://images//checkWhiteFull.png";
            Byte[] bytecheckWhiteFull = System.IO.File.ReadAllBytes(checkWhiteFull);
            string stringCopycheckWhiteFull = Convert.ToBase64String(bytecheckWhiteFull);

            string checkBlueLight = "d://images//checkBlueLight.png";
            Byte[] bytecheckBlueLight = System.IO.File.ReadAllBytes(checkBlueLight);
            string stringCopycheckBlueLight = Convert.ToBase64String(bytecheckBlueLight);

            string checkBlueLightFull = "d://images//checkBlueLightFull.png";
            Byte[] bytecheckBlueLightFull = System.IO.File.ReadAllBytes(checkBlueLightFull);
            string stringCopycheckBlueLightFull = Convert.ToBase64String(bytecheckBlueLightFull);

            string checkYellowLight = "d://images//checkYellowLight.png";
            Byte[] bytecheckYellowLight = System.IO.File.ReadAllBytes(checkYellowLight);
            string stringCopycheckYellowLight = Convert.ToBase64String(bytecheckYellowLight);

            string checkYellowLightFull = "d://images//checkYellowLightFull.png";
            Byte[] bytecheckYellowLightFull = System.IO.File.ReadAllBytes(checkYellowLightFull);
            string stringCopycheckYellowLightFull = Convert.ToBase64String(bytecheckYellowLightFull);

            string checkGreenLight = "d://images//checkGreenLight.png";
            Byte[] bytecheckGreenLight = System.IO.File.ReadAllBytes(checkGreenLight);
            string stringCopycheckGreenLight = Convert.ToBase64String(bytecheckGreenLight);

            string checkGreenLightFull = "d://images//checkGreenLightFull.png";
            Byte[] bytecheckGreenLightFull = System.IO.File.ReadAllBytes(checkGreenLightFull);
            string stringCopycheckGreenLightFull = Convert.ToBase64String(bytecheckGreenLightFull);

            string checkBrown = "d://images//checkBrown.png";
            Byte[] bytecheckBrown = System.IO.File.ReadAllBytes(checkBrown);
            string stringCopycheckBrown = Convert.ToBase64String(bytecheckBrown);

            string checkBrownFull = "d://images//checkBrownFull.png";
            Byte[] bytecheckBrownFull = System.IO.File.ReadAllBytes(checkBrownFull);
            string stringCopycheckBrownFull = Convert.ToBase64String(bytecheckBrownFull);

            string checkPurple = "d://images//checkPurple.png";
            Byte[] bytecheckPurple = System.IO.File.ReadAllBytes(checkPurple);
            string stringCopycheckPurple = Convert.ToBase64String(bytecheckPurple);

            string checkPurpleFull = "d://images//checkPurpleFull.png";
            Byte[] bytecheckPurpleFull = System.IO.File.ReadAllBytes(checkPurpleFull);
            string stringCopycheckPurpleFull = Convert.ToBase64String(bytecheckPurpleFull);

            string checkTurquoise = "d://images//checkTurquoise.png";
            Byte[] bytecheckTurquoise = System.IO.File.ReadAllBytes(checkTurquoise);
            string stringCopycheckTurquoise = Convert.ToBase64String(bytecheckTurquoise);

            string checkTurquoiseFull = "d://images//checkTurquoiseFull.png";
            Byte[] bytecheckTurquoiseFull = System.IO.File.ReadAllBytes(checkTurquoiseFull);
            string stringCopycheckTurquoiseFull = Convert.ToBase64String(bytecheckTurquoiseFull);

            string checkPinkLight = "d://images//checkPinkLight.png";
            Byte[] bytecheckPinkLight = System.IO.File.ReadAllBytes(checkPinkLight);
            string stringCopycheckPinkLight = Convert.ToBase64String(bytecheckPinkLight);

            string checkPinkLightFull = "d://images//checkPinkLightFull.png";
            Byte[] bytecheckPinkLightFull = System.IO.File.ReadAllBytes(checkPinkLightFull);
            string stringCopycheckPinkLightFull = Convert.ToBase64String(bytecheckPinkLightFull);

            string checkBlueSky = "d://images//checkBlueSky.png";
            Byte[] bytecheckBlueSky = System.IO.File.ReadAllBytes(checkBlueSky);
            string stringCopycheckBlueSky = Convert.ToBase64String(bytecheckBlueSky);

            string checkBlueSkyFull = "d://images//checkBlueSkyFull.png";
            Byte[] bytecheckBlueSkyFull = System.IO.File.ReadAllBytes(checkBlueSkyFull);
            string stringCopycheckBlueSkyFull = Convert.ToBase64String(bytecheckBlueSkyFull);
        }

    }
}
