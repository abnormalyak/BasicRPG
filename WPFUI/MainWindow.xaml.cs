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
using Engine.EventArgs;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameSession _gameSession = new GameSession();
        public MainWindow()
        {
            InitializeComponent();

            _gameSession.OnMessageRaised += OnGameMessageRaised;

            DataContext = _gameSession;
        }

        private void OnClick_North(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveNorth();
        }

        private void OnClick_South(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveSouth();
        }

        private void OnClick_West(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveWest();
        }

        private void OnClick_East(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveEast();
        }
        
        private void OnClick_Attack(object sender, RoutedEventArgs e)
        {
            _gameSession.Attack();
        }
        private void OnClick_Trade(object sender, RoutedEventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen();
            tradeScreen.Owner = this;
            tradeScreen.DataContext = _gameSession;
            tradeScreen.ShowDialog();
        }

        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }

        
    }

    
}
