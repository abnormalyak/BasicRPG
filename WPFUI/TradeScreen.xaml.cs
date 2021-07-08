using Engine.Models;
using Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        public GameSession Session => DataContext as GameSession;

        public TradeScreen()
        {
            InitializeComponent();
        }

        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;

            if (item != null)
            {
                Session.CurrentPlayer.Gold += item.Value;
                Session.CurrentPlayer.RemoveItemFromInventory(item);
                Session.CurrentTrader.AddItemToInventory(item);
            }
            else
            {
                MessageBox.Show("An item must be selected first.");
            }
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;

            if (item != null && Session.CurrentPlayer.Gold >= item.Value)
            {
                Session.CurrentPlayer.Gold -= item.Value;
                Session.CurrentTrader.RemoveItemFromInventory(item);
                Session.CurrentPlayer.AddItemToInventory(item);
            }
            else
            {
                MessageBox.Show("You do not have enough gold for that item.");
            }
        }

        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
