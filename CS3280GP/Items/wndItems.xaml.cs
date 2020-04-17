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

namespace CS3280GP.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        Main.wndMain mainWindow;
        /// <summary>
        /// These are the booleans to check if something is currently being Edited or if a New Invoice is being Created
        /// </summary>
        public Boolean BeingEdited = false;
        public Boolean NewInvoice = false;



        /// <summary>
        /// I believe that this is just to start the DataGrid
        /// </summary>
        public wndItems(Main.wndMain wndMain)
        {
            InitializeComponent();
            mainWindow = wndMain;
        }

        /// <summary>
        /// This section will fill the DataGrid with the data that we desire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //In order to get what is going to appear in the DataGrid, we will have to tie in the queries in here to get what is needed.
            //To achieve this, We will call specific SQL queries through the methods we created and have them output here depending on the choice that was made
            //It will specifically call out the Items Code, Description, and Cost
            if (BeingEdited == false || NewInvoice == false)
            {
                ///This will check to see if there is currently something being edited or if there is a new invoice currently being entered
            }
            else
            {
                //Display an error message of some sort saying that there is currently something being updated or something along these lines
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            //All changes will be updated, the window will close and return user to the main window
            this.Close(); 
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //This will not update any changes, but will instead close the window and return user to the main window
            this.Close();
            mainWindow.Search_Invoice.IsChecked = false;
            mainWindow.Item_Table.IsChecked = false;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            mainWindow.Search_Invoice.IsChecked = false;
            mainWindow.Item_Table.IsChecked = false;
        }
    }
}


