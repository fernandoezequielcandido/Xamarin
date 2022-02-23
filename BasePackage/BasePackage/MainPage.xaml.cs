using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BasePackage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            List<Item> returnContent = new List<Item>();


            returnContent.Add(new Item { Name = "Monday.png", NameChosen = "MondaySelected.png", Value = "1" });
            returnContent.Add(new Item { Name = "Tuesday.png", NameChosen = "TuesdaySelected.png", Value = "2" });
            returnContent.Add(new Item { Name = "Wednesday.png", NameChosen = "WednesdaySelected.png", Value = "3" });

            //  string st = LaavorLicense.CreateLicense("create8laavor8hahhdsahj78798/*-*/+/**-", 15000);

            //  var et = "74";



            //returnContent.Add(new Item { Name = "CasparDavidFriedrich.jpg" });
            //returnContent.Add(new Item { Name = "LeonardodaVinci.jpg" });
            //returnContent.Add(new Item { Name = "Monet.jpg" });
            //returnContent.Add(new Item { Name = "PieterBruegel.jpg" });
            //returnContent.Add(new Item { Name = "Rafael.png" });
            //returnContent.Add(new Item { Name = "Ticiano.jpg" });
            //returnContent.Add(new Item { Name = "VanGogh.jpg" });

            this.BindingContext = returnContent;
        }
    }
}
