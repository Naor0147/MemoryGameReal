using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        private Data GameSettings;//1 is Card 2 is football 
        public int gameSize = 6;
        //public Image[] cardArr=new Image[18];
        List<int[]> PosPositions = new List<int[]>();

        List<Image> Photos;
        public Game_page()
        {
            this.InitializeComponent();
/*
            List<Image> Photos = getPhotosList(2);// Get the photos 
            buildGrid(6);


       
            for (int i = 0; i < gameSize; i++)
            {
                /* button = new Button();
                 button.Content = GameTheme;
                 button.FontSize = 40;*/
/*
                Image a  = Photos[i];
                Grid.SetColumn(a, i);

                
                Grid.SetRow(a, i);
                my_G.Children.Add(a);
                
            }/// לעשות ליסט שיש שם את כל האימגיים ואז להוריד כל פעם שמתשמים 
           // לעשות עוד ליסט עם כל המספרים של הגרידים ואז שמים תמונה ומחסרים אותה 
          
            */


        }

        public void buildTheRandomPhotos(List<Image> ImageList)
        {
            List<Image> _photos = ImageList;

            int _PosIndex;
            int _ImageIndex;
            Random random= new Random();
            while (PosPositions.Any())
            {
                _ImageIndex = random.Next(_photos.Count);// the postion of the image in in List
               
                /*_PosIndex = random.Next(PosPositions.Count);// the postion of the image 
                int[] pos1 = PosPositions[_PosIndex];
                PosPositions.RemoveAt(_PosIndex);

                _PosIndex = random.Next(PosPositions.Count);// the postion of the image 
                int[] pos2 = PosPositions[_PosIndex];
                PosPositions.RemoveAt(_PosIndex);*/


                CardClass card = new CardClass(_photos[_ImageIndex], getPos(),getPos());
                //PosPositions.RemoveAt(_PosIndex);
                _photos.RemoveAt(_ImageIndex);

                card.addToGrid(Game_Grid);
            }
        }

        public int[] getPos()
        {
            Random random = new Random();

            int _PosIndex = random.Next(PosPositions.Count);// the postion of the image 
            int[] pos = PosPositions[_PosIndex];
            PosPositions.RemoveAt(_PosIndex);
            return pos;
        }


        public List<Image> getPhotosList()
        {
            List<Image> list = new List<Image>();

            if (GameSettings.Theme==ThemeType.Football)//Football players
            {
                for (int i = 0; i < 18; i++)
                {
                    string _imageAdress = $"ms-appx:///football_players/Football_{i + 1}.png";
                    Image a = new Image();
                    a.Source = new BitmapImage(new Uri(_imageAdress));
                    list.Add(a);
                }
            }
            else
            {
                //Card
                for (int i = 0; i < 67; i++)
                {
                    string _imageAdress = $"ms-appx:///cards_Photos/Cards_{i +1}.png";
                    Image a = new Image();
                    a.Source = new BitmapImage(new Uri(_imageAdress));
                    list.Add(a);
                }
            }
            return list;    
            

        }

        public void buildGrid()
        {
            levelType gridSize = GameSettings.levelDiffculty;
            int size = 2;// levelType == easy Defult

            if (gridSize ==levelType.normal)
            {
                size = 4;
            }
            else if( gridSize ==levelType.hard)
            {
                size = 6;
            }

            for (int i = 0; i < size; i++)// builds the the grids row and column
            {
                RowDefinition rowDef = new RowDefinition();
                Game_Grid.RowDefinitions.Add(rowDef);
                
                ColumnDefinition colDef = new ColumnDefinition();
                Game_Grid.ColumnDefinitions.Add(colDef);
            }

            // bulids a List of the all possible position of the Photos
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    PosPositions.Add(new int[] { i, j });
                }
            }
        }

        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            GameSettings = (Data)e.Parameter;
            buildGrid();
            Photos= getPhotosList();
            buildTheRandomPhotos(Photos);


            
        }
    }
}
