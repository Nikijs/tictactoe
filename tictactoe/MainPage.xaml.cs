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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TicTacToe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Global Variables _rows is essential, don't delete it
        int _rows;
        const int _iHeight = 100;
        int _iWidth = 100;
        int count = 0;
        String storedArray;
        Boolean turn = true;
        #endregion

        #region Constructor and set up code
        public MainPage() // constructor
        {
            this.InitializeComponent();
        }
        #endregion

        Button[] buttonArray;
        int a, b;

        private void setupThePieces()
        {
            int x = 0;
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

        #region CHECK FOR 3 IN A ROW
        public void winner()
        {   //START OF X
            if ((string)buttonArray[0].Content == "X" && (string)buttonArray[1].Content == "X" && (string)buttonArray[2].Content == "X")
            {
                buttonArray[0].Content = "-";
                buttonArray[1].Content = "-";
                buttonArray[2].Content = "-";
            }
            else if ((string)buttonArray[3].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[5].Content == "X")
            {
                buttonArray[3].Content = "-";
                buttonArray[4].Content = "-";
                buttonArray[5].Content = "-";
            }
            else if ((string)buttonArray[6].Content == "X" && (string)buttonArray[7].Content == "X" && (string)buttonArray[8].Content == "X")
            {
                buttonArray[6].Content = "-";
                buttonArray[7].Content = "-";
                buttonArray[8].Content = "-";
            }
            else if ((string)buttonArray[0].Content == "X" && (string)buttonArray[3].Content == "X" && (string)buttonArray[6].Content == "X")
            {
                buttonArray[0].Content = "|";
                buttonArray[3].Content = "|";
                buttonArray[6].Content = "|";
            }
            else if ((string)buttonArray[1].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[7].Content == "X")
            {
                buttonArray[1].Content = "|";
                buttonArray[4].Content = "|";
                buttonArray[7].Content = "|";
            }
            else if ((string)buttonArray[2].Content == "X" && (string)buttonArray[5].Content == "X" && (string)buttonArray[8].Content == "X")
            {
                buttonArray[2].Content = "|";
                buttonArray[5].Content = "|";
                buttonArray[8].Content = "|";
            }
            else if ((string)buttonArray[0].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[8].Content == "X")
            {
                buttonArray[0].Content = "\\";
                buttonArray[4].Content = "\\";
                buttonArray[8].Content = "\\";
            }
            else if ((string)buttonArray[2].Content == "X" && (string)buttonArray[4].Content == "X" && (string)buttonArray[6].Content == "X")
            {
                buttonArray[2].Content = "/";
                buttonArray[4].Content = "/";
                buttonArray[6].Content = "/";
            }
            //START OF O

            else if ((string)buttonArray[0].Content == "O" && (string)buttonArray[1].Content == "O" && (string)buttonArray[2].Content == "O")
            {
                buttonArray[0].Content = "-";
                buttonArray[1].Content = "-";
                buttonArray[2].Content = "-";

            }
            else if ((string)buttonArray[3].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[5].Content == "O")
            {
                buttonArray[3].Content = "-";
                buttonArray[4].Content = "-";
                buttonArray[5].Content = "-";
            }
            else if ((string)buttonArray[6].Content == "O" && (string)buttonArray[7].Content == "O" && (string)buttonArray[8].Content == "O")
            {
                buttonArray[6].Content = "-";
                buttonArray[7].Content = "-";
                buttonArray[8].Content = "-";
            }
            else if ((string)buttonArray[0].Content == "O" && (string)buttonArray[3].Content == "O" && (string)buttonArray[6].Content == "O")
            {
                buttonArray[0].Content = "|";
                buttonArray[3].Content = "|";
                buttonArray[6].Content = "|";
            }
            else if ((string)buttonArray[1].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[7].Content == "O")
            {
                buttonArray[1].Content = "|";
                buttonArray[4].Content = "|";
                buttonArray[7].Content = "|";
            }
            else if ((string)buttonArray[2].Content == "O" && (string)buttonArray[5].Content == "O" && (string)buttonArray[8].Content == "O")
            {
                buttonArray[2].Content = "|";
                buttonArray[5].Content = "|";
                buttonArray[8].Content = "|";
            }
            else if ((string)buttonArray[0].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[8].Content == "O")
            {
                buttonArray[0].Content = "\\";
                buttonArray[4].Content = "\\";
                buttonArray[8].Content = "\\";
            }
            else if ((string)buttonArray[2].Content == "O" && (string)buttonArray[4].Content == "O" && (string)buttonArray[6].Content == "O")
            {
                buttonArray[2].Content = "/";
                buttonArray[4].Content = "/";
                buttonArray[6].Content = "/";
            }
        }
        #endregion

        TextBlock text;
        public void turnNotfier()
        {
            this.text = new TextBlock();
            text.Name = "textBox";
            text.HorizontalAlignment = HorizontalAlignment.Right;
            text.VerticalAlignment = VerticalAlignment.Bottom;
            text.Width = 250;
            text.Height = 150;
            text.FontSize = 30;
            text.Foreground = new SolidColorBrush(Colors.GreenYellow);
            if (turn == true)
            {
                text.Text = "Player X turn";
            }
            else if (turn == false)
            {
                text.Text = "Player O turn";
            }

            rootGrid.Children.Add(text);

        }

        private void Button1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var current = sender as Button;

            if ((_rows * _rows) > (count))
            {
                if (turn == true)
                {
                    current.Content = "X";
                    current.Background = new SolidColorBrush(Colors.Red);
                    current.FontSize = 50;
                    count++;
                    this.turn = false;
                    winner();
                    if ((_rows * _rows) > (count))
                    {
                        text.Text = "";
                        turnNotfier();

                    }
                    else { text.Text = "Game over"; }


                }
                else if (turn == false)
                {
                    current.Content = "O";
                    this.turn = true;
                    current.FontSize = 50;
                    current.Background = new SolidColorBrush(Colors.Red);
                    count++;
                    winner();
                    if ((_rows * _rows) > (count))
                    {
                        text.Text = "";
                        turnNotfier();
                    }
                    else { text.Text = "Game over"; }

                }

                current.IsEnabled = false;
            }

        }

        Grid grdBoard;
        Button backButton;
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

        private void tap1(object sender, TappedRoutedEventArgs e)
        {
            Button but = (Button)sender;
            turnNotfier();
            createBoard();
            setupThePieces();
            spRadioButtons.Visibility = Visibility.Collapsed;


        }
        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            spRadioButtons.Visibility = Visibility.Visible;
            rootGrid.Children.Remove(FindName("Board") as Grid);
            backButton.Visibility = Visibility.Collapsed;
            startButton.Visibility = Visibility.Visible;
            rootGrid.Children.Remove(FindName("textBox") as TextBlock);
            count = 0;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton current = (RadioButton)sender;
            _rows = Convert.ToInt32(current.Tag);
            buttonArray = new Button[_rows * _rows];
        }
    }
}