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

namespace TicTacToeGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        GameLogic _GameLogic = new GameLogic();
        private void PlayerClicksSpace(object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (!string.IsNullOrEmpty(space.Content?.ToString())) return;
            space.Content = _GameLogic.CurrentPlayer;
            var coordinates = space.Tag.ToString().Split(',');
            var xValue = int.Parse(coordinates[0]);
            var yValue = int.Parse(coordinates[1]);
            var buttonPosition = new Position() { x = xValue, y = yValue };
            _GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);
            if(_GameLogic.PlayerWins())
            {
                WinScreen.Text = $"{_GameLogic.CurrentPlayer} wins!!!";
                WinScreen.Visibility = Visibility.Visible;
            }
            _GameLogic.SetNextPlayer();
        }
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach(var control in gridBoard.Children)
            {
                if(control is Button)
                {
                    ((Button)control).Content = String.Empty;
                }
                _GameLogic = new GameLogic();
                WinScreen.Visibility = Visibility.Collapsed;
            }
        }
    }
}
