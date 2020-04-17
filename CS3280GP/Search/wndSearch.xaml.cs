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

namespace CS3280GP.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        
        Main.wndMain mainWindow;
        public wndSearch(Main.wndMain wndMain)
        {
            InitializeComponent();
           
            mainWindow = wndMain;
        }

        private void ClearSelectionBtn_Click(object sender, RoutedEventArgs e)
        {
            //this button will return the search window to its default settings
        }

        private void DisplayInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            //this button will return the user invoice selections to the datagrid
        }

        private void SelectInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            //this button will return the user invoice selection from the datagrid to the main window 
            //the search window will close and the main window will open, displaying the selected invoice data
            //invoice properties, invoiceNum, invoiceDate, and TotalCost, will be set based on selection made.
            //this data can then be called for use on the main window
            this.Close();
            
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //this button will return search window to default settings and close search window
            //followed by opening the main window
            this.Close();
            mainWindow.Search_Invoice.IsChecked = false;
            mainWindow.Item_Table.IsChecked = false;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            mainWindow.Search_Invoice.IsChecked = false;
            mainWindow.Item_Table.IsChecked = false;
        }
    }
}
