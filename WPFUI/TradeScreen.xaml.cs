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
            GroupedInventoryItem groupedItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (groupedItem != null)
            {
                Session.CurrentPlayer.Gold += groupedItem.Item.Value;
                Session.CurrentPlayer.RemoveItemFromInventory(groupedItem.Item);
                Session.CurrentTrader.AddItemToInventory(groupedItem.Item);
            }
            else
            {
                MessageBox.Show("An item must be selected first.");
            }
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (groupedItem != null && Session.CurrentPlayer.Gold >= groupedItem.Item.Value)
            {
                Session.CurrentPlayer.Gold -= groupedItem.Item.Value;
                Session.CurrentTrader.RemoveItemFromInventory(groupedItem.Item);
                Session.CurrentPlayer.AddItemToInventory(groupedItem.Item);
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
