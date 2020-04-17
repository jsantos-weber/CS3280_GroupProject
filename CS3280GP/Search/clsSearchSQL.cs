using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GP.Search
{
    public class clsSearchSQL
    {
        string sAllInvoiceNum;
        string sAllInvoiceDate;
        string sAllTotalCost;
        string sSelection;
        string sInvoiceNum; //this is assigned a value when the user selects from the dropdown or from the datagrid
        string sInvoiceDate;  //this is assigned a value when the user selects from the dropdown or from the datagrid
        string sTotalCost;  //this is assigned a value when the user selects from the dropdown or from the datagrid

        //SQL code 

        /// <summary>
        /// This SQL gets all the invoice numbers from the invoices table
        /// </summary>
        /// <returns>all invoice numbers</returns>
        public string AllInvoiceNum()
        {
           sAllInvoiceNum = "SELECT InvoiceNum FROM Invoices";
            return sAllInvoiceNum;
        }

        /// <summary>
        /// This SQL gets all invoice dates from the invoice table
        /// </summary>
        /// <returns>all invoice dates</returns>
        public string AllInvoiceDate()
        {
           sAllInvoiceDate = "SELECT InvoiceDate FROM Invoices";
            return sAllInvoiceDate;
        }

        /// <summary>
        /// this SQL returns all total costs from the invoice table
        /// </summary>
        /// <returns>all total costs</returns>
        public string AllTotalCost()
        {
            sAllTotalCost = "SELECT TotalCost FROM Invoices ORDER BY TotalCost ASC";
            return sAllTotalCost;
        }
        /// <summary>
        /// This method will display the results of the user's InvoiceNum selection.
        /// </summary>
        /// <returns>user's invoicenum selection</returns>
        public string DisplayInvoiceNum()
        {
            
                sSelection = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNum;
                return sSelection;
            
        }
        /// <summary>
        ///This sql will get the user's invoicedate selection
        /// </summary>
        /// <returns>user's invoicedate selection</returns>
        public string DisplayInvoiceDate()
        {
            sSelection = "SELECT * FROM Invoices WHERE InvoiceDate = #" + sInvoiceDate + "#";
            return sSelection;
        }
        /// <summary>
        /// this sql will get the user's totalcost selection
        /// </summary>
        /// <returns>user's total cost selection</returns>
        public string DisplayTotalCost()
        {
            sSelection = "SELECT * FROM Invoices WHERE TotalCost = " + sTotalCost;
            return sSelection;
        }
        /// <summary>
        /// this sql will get the invoicenum and invoice date
        /// </summary>
        /// <returns>all invoices with selected invoicenum and invoicedate</returns>
        public string DisplayNumAndDate()
        {
            sSelection = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNum + "AND InvoiceDate = #" + sInvoiceDate + "#";
            return sSelection;
        }
        /// <summary>
        /// this sql gets the invoicenum, date, and total cost
        /// </summary>
        /// <returns>all invoices with selected invoicenum, invoicedate, and total cost</returns>
        public string DisplayNumDateCost()
        {
            sSelection = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNum + "AND InvoiceDate = #" + sInvoiceDate + "# AND TotalCost = " + sTotalCost;
            return sSelection;
        }
        /// <summary>
        /// this sql gets the invoicedate and total cost
        /// </summary>
        /// <returns>all invoices with selected invoicedate and total cost</returns>
        public string DisplayDateAndCost()
        {
            sSelection = "SELECT * FROM Invoices WHERE InvoiceDate = #" + sInvoiceDate + "# AND TotalCost = " + sTotalCost;
            return sSelection;
        }
        /// <summary>
        /// this sql gets the invoicenum and total cost
        /// </summary>
        /// <returns>all invoices with selected invoicenum and total cost</returns>
        public string DisplayNumAndCost()
        {
            sSelection = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNum + "AND TotalCost = " + sTotalCost;
            return sSelection;
        }

    }
}
