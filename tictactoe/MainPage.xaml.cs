using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Text;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TicTacToe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Global Variables _rows is essential, don't delete it
        int _rows = 3; //no of rows
        int xWins = 0; //count wins for each player
        int oWins = 0;
        const int _iHeight = 100;
        int _iWidth = 100;
        int count = 0; 
        int win;
        Boolean turn = true;
        #endregion

        #region Constructor and set up code
        public MainPage() // constructor
        {
            this.InitializeComponent();
        }
        #endregion

        
        int a, b;
        Button[] buttonArray = new Button[10];
        private void setupTheButtons()
        {
            int x = 0; //increment each button 
            //adding 3x3 button array (9buttons) each having a tapped event also 3 rows and 3 cols
            for (a = 0; a < _rows; a++)
            {
                for (b = 0; b < _rows; b++)
                {
                    buttonArray[x] = new Button();
                    buttonArray[x].Height = 90;
                    buttonArray[x].Width = 90;
                    buttonArray[x].SetValue(Grid.RowProperty, a);
                    buttonArray[x].SetValue(Grid.ColumnProperty, b);
                    buttonArray[x].HorizontalAlignment = HorizontalAlignment.Center;
                    grdBoard.Children.Add(buttonArray[x]);
                    buttonArray[x].Background = new SolidColorBrush(Colors.LightBlue);
                    buttonArray[x].Tapped += new TappedEventHandler(Button1_Tapped);
                    x++;
                }
            }
        }
        public void finish()
        {
            if (count >= 9)
            {text.Text = "Game Over\nNo Winner";} //if all 9 buttons pressed no winner
            if (win == 1) //if winner was X
            {
                text.Text = "Player X wins";
                xWins++;
                wins.Text = " X=" + xWins + "    O=" + oWins;
                for (int z = 0; z < _rows * _rows; z++){ //makes sure to disable all the buttons when gameover
                    buttonArray[z].IsEnabled = false;
                }
            }
            if (win == 2) //if winner was O
            {
                text.Text = "Player O wins";
                oWins++;
                wins.Text = " X=" + xWins + "    O=" + oWins;
                for (int z = 0; z < _rows * _rows; z++){
                    buttonArray[z].IsEnabled = false;
                }
            }
        }
        #region CHECK FOR 3 IN A ROW
        public void winner()
        {   //START OF X
            if ((string)buttonArray[0].Content == "X" && (string)buttonArray[1].Content == "X" && (string)buttonArray[2].Content == "X")
            {
                buttonArray[0].Content = "-";
                buttonArray[1].Content = "-";
                buttonArray[2].Content = "-";
                win = 1;
            }
            else if ((string)buttonArray[3].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[5].Content == "X")
            {
                buttonArray[3].Content = "-";
                buttonArray[4].Content = "-";
                buttonArray[5].Content = "-";
                win = 1;
            }
            else if ((string)buttonArray[6].Content == "X" && (string)buttonArray[7].Content == "X" && (string)buttonArray[8].Content == "X")
            {
                buttonArray[6].Content = "-";
                buttonArray[7].Content = "-";
                buttonArray[8].Content = "-";
                win = 1;
            }
            else if ((string)buttonArray[0].Content == "X" && (string)buttonArray[3].Content == "X" && (string)buttonArray[6].Content == "X")
            {
                buttonArray[0].Content = "|";
                buttonArray[3].Content = "|";
                buttonArray[6].Content = "|";
                win = 1;
            }
            else if ((string)buttonArray[1].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[7].Content == "X")
            {
                buttonArray[1].Content = "|";
                buttonArray[4].Content = "|";
                buttonArray[7].Content = "|";
                win = 1;
            }
            else if ((string)buttonArray[2].Content == "X" && (string)buttonArray[5].Content == "X" && (string)buttonArray[8].Content == "X")
            {
                buttonArray[2].Content = "|";
                buttonArray[5].Content = "|";
                buttonArray[8].Content = "|";
                win = 1;
            }
            else if ((string)buttonArray[0].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[8].Content == "X")
            {
                buttonArray[0].Content = "\\";
                buttonArray[4].Content = "\\";
                buttonArray[8].Content = "\\";
                win = 1;
            }
            else if ((string)buttonArray[2].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[6].Content == "X")
            {
                buttonArray[2].Content = "/";
                buttonArray[4].Content = "/";
                buttonArray[6].Content = "/";
                win = 1;
            }
            //START OF O

            else if ((string)buttonArray[0].Content == "O" && (string)buttonArray[1].Content == "O" && (string)buttonArray[2].Content == "O")
            {
                buttonArray[0].Content = "-";
                buttonArray[1].Content = "-";
                buttonArray[2].Content = "-";
                win = 2;
            }
            else if ((string)buttonArray[3].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[5].Content == "O")
            {
                buttonArray[3].Content = "-";
                buttonArray[4].Content = "-";
                buttonArray[5].Content = "-";
                win = 2;
            }
            else if ((string)buttonArray[6].Content == "O" && (string)buttonArray[7].Content == "O" && (string)buttonArray[8].Content == "O")
            {
                buttonArray[6].Content = "-";
                buttonArray[7].Content = "-";
                buttonArray[8].Content = "-";
                win = 2;
            }
            else if ((string)buttonArray[0].Content == "O" && (string)buttonArray[3].Content == "O" && (string)buttonArray[6].Content == "O")
            {
                buttonArray[0].Content = "|";
                buttonArray[3].Content = "|";
                buttonArray[6].Content = "|";
                win = 2;
            }
            else if ((string)buttonArray[1].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[7].Content == "O")
            {
                buttonArray[1].Content = "|";
                buttonArray[4].Content = "|";
                buttonArray[7].Content = "|";
                win = 2;
            }
            else if ((string)buttonArray[2].Content == "O" && (string)buttonArray[5].Content == "O" && (string)buttonArray[8].Content == "O")
            {
                buttonArray[2].Content = "|";
                buttonArray[5].Content = "|";
                buttonArray[8].Content = "|";
                win = 2;
            }
            else if ((string)buttonArray[0].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[8].Content == "O")
            {
                buttonArray[0].Content = "\\";
                buttonArray[4].Content = "\\";
                buttonArray[8].Content = "\\";
                win = 2;
            }
            else if ((string)buttonArray[2].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[6].Content == "O")
            {
                buttonArray[2].Content = "/";
                buttonArray[4].Content = "/";
                buttonArray[6].Content = "/";
                win = 2;
            }
        }
        #endregion

        TextBlock text;
        public void turnNotfier() //textblock to show player turn
        {
            this.text = new TextBlock();
            text.Name = "textBox";
            text.HorizontalAlignment = HorizontalAlignment.Right;
            text.VerticalAlignment = VerticalAlignment.Bottom;
            text.Width = 250;
            text.Height = 150;
            text.FontSize = 30;
            text.FontWeight = FontWeights.Bold;
            text.FontFamily = new FontFamily("Century Gothic");
            text.Foreground = new SolidColorBrush(Colors.PaleVioletRed);
            if (turn == true)
            {  
                text.Text = "Player X turn";
                finish();   
            }
            else if (turn == false)
            {  
                text.Text = "Player O turn";
                finish();
            }
            rootGrid.Children.Add(text);
        }
        //button tapped for each button 
        //the boolean true = x turn false = o turn
        //will change the content of button and disable it/calls turn nofifier
        private void Button1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var current = sender as Button;
                if (turn == true)
                {
                    current.Content = "X";
                    current.FontSize = 50;
                    count++;
                    this.turn = false;
                    winner();
                    current.IsEnabled = false;
                text.Text = "";
                turnNotfier(); 
            }

                else if (turn == false)
                {
                    current.Content = "O";
                text.Text = "";
                this.turn = true;
                    current.FontSize = 50;
                    count++;
                    winner();
                    current.IsEnabled = false;
                    turnNotfier();
                
                }
        }

        Grid grdBoard;
        Button backButton;
        //creates the grid and back button
        private void createBoard()
        {
            //back button
            this.backButton = new Button();
            backButton.HorizontalAlignment = HorizontalAlignment.Left;
            backButton.VerticalAlignment = VerticalAlignment.Top;
            backButton.Height = 50;
            backButton.Width = 50;
            backButton.Background = new SolidColorBrush(Colors.Green);
            backButton.Content = "Back";
            rootGrid.Children.Add(backButton);
            backButton.Tapped += BackButton_Tapped;
            startButton.Visibility = Visibility.Collapsed;


            //grid
            this.grdBoard = new Grid();
            grdBoard.Name = "Board";
            grdBoard.HorizontalAlignment = HorizontalAlignment.Center;
            grdBoard.VerticalAlignment = VerticalAlignment.Top;
            grdBoard.Height = _iHeight * _rows;
            grdBoard.Width = _iWidth * _rows;
            grdBoard.Background = new SolidColorBrush(Colors.Gray);
            grdBoard.Margin = new Thickness(5);
            grdBoard.SetValue(Grid.RowProperty, 1);

            // add _rows number of row definitions and column definitions
            for (int i = 0; i < _rows; i++)
            {
                grdBoard.RowDefinitions.Add(new RowDefinition());
                grdBoard.ColumnDefinitions.Add(new ColumnDefinition());
            }
            try
            {
                rootGrid.Children.Remove(FindName("Board") as Grid);
            }
            catch { }
            rootGrid.Children.Add(grdBoard);

            Border brdr;
            int iR, iC;
            for (iR = 0; iR < _rows; iR++)
            {
                for (iC = 0; iC < _rows; iC++)
                {
                    #region Create one border element and add to the grid
                    brdr = new Border();
                    brdr.Height = 98;
                    brdr.Width = 98;
                    brdr.HorizontalAlignment = HorizontalAlignment.Center;
                    brdr.VerticalAlignment = VerticalAlignment.Center;
                    brdr.SetValue(Grid.RowProperty, iR);
                    brdr.SetValue(Grid.ColumnProperty, iC);
                    brdr.Background = new SolidColorBrush(Colors.LightBlue);
                    grdBoard.Children.Add(brdr);
                    #endregion

                }
            }
        }
        //start button
        private void tap1(object sender, TappedRoutedEventArgs e)
        {
            Button but = (Button)sender;
            turnNotfier();
            createBoard();
            setupTheButtons();
           
        }
        //backbutton
        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            rootGrid.Children.Remove(FindName("Board") as Grid);
            backButton.Visibility = Visibility.Collapsed;
            startButton.Visibility = Visibility.Visible;
            rootGrid.Children.Remove(FindName("textBox") as TextBlock);
            count = 0;
            text.Visibility = Visibility.Collapsed;
            win = 0;
        }
      
    }
}