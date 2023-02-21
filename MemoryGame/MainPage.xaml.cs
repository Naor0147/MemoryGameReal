using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MemoryGame
{
    public enum levelType
    {
        easy , normal, hard 
    }
    public enum ThemeType
    {
        Cards, Football 
    }

    
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public levelType levelTypeSelect;
        public ThemeType themeTypeSelect;
        Data data= new Data();
        
        public MainPage()
        {

            this.InitializeComponent();
            
              
        }

        private void Card_button_Click(object sender, RoutedEventArgs e)
        {
            data.Theme=ThemeType.Cards;
            //Frame.Navigate(typeof(Game_page), 1);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data(levelTypeSelect,themeTypeSelect);
            Frame.Navigate(typeof(Game_page), data);
            

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string a = radioButton.Content.ToString();

            if (a == "Hard")
            {
                levelTypeSelect = levelType.hard;
            }
            else if(a== "Normal")
            {
                levelTypeSelect = levelType.normal;
            }
            else if (a == "Easy")
            {
                levelTypeSelect = levelType.easy;
            }
            else if (a== "Football")
            {
                themeTypeSelect = ThemeType.Football;
            }
            else if (a == "Cards")
            {
                themeTypeSelect = ThemeType.Cards;
            }
        }
    }
}
