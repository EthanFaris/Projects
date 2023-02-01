using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members 
        private MarkType[] mResults; // Holds the current results of cells in the active game 
        private bool mPlayer1Turn; // True if it is Player1's turn (X) or Player2's turn (O) 
        private bool mGameEnded; // True if the game has ended

        #endregion

        #region Constructor 

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion 

        public void NewGame() // Starts a new game
        {
            mResults = new MarkType[9]; // Create a new blank array of free cells 

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free; 
            }

            mPlayer1Turn = true; // Make sure player 1 starts the game 

            // Interate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                // Reset to default values on game startup
                Button.Content = string.Empty;
                Button.Background = Brushes.White;
                Button.Foreground = Brushes.Blue;
            });

            mGameEnded = false; // Make sure game is not finished 
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Handles a button click event
        {
            if (mGameEnded) // Start a new game on the click after the game is finished
            {
                NewGame();
                return;
            }

            var button = (Button)sender; // Cast the sender to a button

            var column = Grid.GetColumn(button); // Find the buttons position in the array
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free) return; // Do nothing if the user clicks a filled box 

            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought; // Set cell value based on which players turn it is 

            button.Content = mPlayer1Turn ? "X" : "O"; // Set button text to the result 

            if (!mPlayer1Turn) button.Foreground = Brushes.Red; // Change noughts to green
            
            mPlayer1Turn ^= true; // Toggle player turns 

            CheckForWinner();
        }

        public void CheckForWinner()
        {
            #region Horizontal wins
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0]) // Check for horizontal win (R1)
            {
                mGameEnded = true; // Game ends 

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green; // Highlight winning cells in green 
            }
            
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3]) // Check for horizontal win (R2)
            {
                mGameEnded = true; // Game ends 

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green; // Highlight winning cells in green   
            }

            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6]) // Check for horizontal win (R3)
            {
                mGameEnded = true; // Game ends 

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green; // Highlight winning cells in green
            }
            #endregion

            #region Veritcal wins
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0]) // Check for vertical win (C1)
            {
                mGameEnded = true; // Game ends 

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green; // Highlight winning cells in green   
            }

            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1]) // Check for vertical win (C2)
            {
                mGameEnded = true; // Game ends 

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green; // Highlight winning cells in green   
            }

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2]) // Check for vertical win (C3)
            {
                mGameEnded = true; // Game ends 

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green; // Highlight winning cells in green   
            }
            #endregion

            #region Diagonal wins 
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0]) // Check for Diagonal win (D1)
            {
                mGameEnded = true; // Game ends 

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green; // Highlight winning cells in green   
            }

            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2]) // Check for vertical win (D2)
            {
                mGameEnded = true; // Game ends 

                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green; // Highlight winning cells in green   
            }
            #endregion

            #region No winners
            if (!mResults.Any(f => f == MarkType.Free))
            {
                mGameEnded = true; // Game ended

                Container.Children.Cast<Button>().ToList().ForEach(Button =>
                {
                    Button.Background = Brushes.Orange; // Change each cell to orange if there is no winner
                });
            }
            #endregion
        }
    
    }
}
