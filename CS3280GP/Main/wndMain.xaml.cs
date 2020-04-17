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
using System.Windows.Shapes;

namespace CS3280GP.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        Search.wndSearch searchWindow;
        Items.wndItems searchItems;
        
        public wndMain()
        {
            InitializeComponent();
            searchWindow = new Search.wndSearch(this);
            searchItems = new Items.wndItems(this);
        }


        private void Add_Item(object sender, RoutedEventArgs e)
        {
            //adds item
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //delete item
        }

        private void Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //detects when the combobox choose an item to update cost
        }

        private void New_InvoiceClick(object sender, RoutedEventArgs e)
        {
            //adds new invoice
        }

        private void Edit_InvoiceClick(object sender, RoutedEventArgs e)
        {
            //edits current invoice
        }

        private void Search_InvoiceClick(object sender, RoutedEventArgs e)
        {
            //opens search window
            searchWindow = new Search.wndSearch(this);
            searchWindow.Show();
            searchWindow.Topmost = true;
        }

        private void Item_TableClick(object sender, RoutedEventArgs e)
        {
            //opens item table window
            searchItems = new Items.wndItems(this);
            searchItems.Show();
            searchItems.Topmost = true;
        }

        private void OnClose(object sender, EventArgs e)
        {
            //what to do when closed
           
            
        }

        private void Quanitiy_Number_Check(object sender, KeyEventArgs e)
        {
            //amount of itemsm are numeric only
        }
    }
}
