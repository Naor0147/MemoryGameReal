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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MemoryGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game_page : Page
    {
        public int GameTheme=1;//1 is Card 2 is football 
        public int gameSize = 6;
        
        public Game_page()
        {
            this.InitializeComponent();

            for (int i = 0; i < gameSize; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                my_G.RowDefinitions.Add(rowDef);
                ColumnDefinition colDef = new ColumnDefinition();
                my_G.ColumnDefinitions.Add(colDef);
            }
            Button button;
            for (int i = 0; i < gameSize; i++)
            {
               /* button = new Button();
                button.Content = GameTheme;
                button.FontSize = 40;*/
                

                string _imageAdress = $"ms-appx:///football_players/Football_{i+1}.png";
                Image a = new Image();
                a.Source = new BitmapImage(new Uri(_imageAdress));
                Grid.SetColumn(a, i);

                
                Grid.SetRow(a, i);
                my_G.Children.Add(a);
                
            }
          



        }
        public string getPhoto()
        {
            return "Sdf";
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GameTheme = (int)e.Parameter;
        }
    }
}
