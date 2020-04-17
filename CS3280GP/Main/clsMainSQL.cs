using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GP.Main
{
    class clsMainSQL
    {
        /// <summary>
        /// Gets all Items
        /// </summary>
        /// <returns>The items</returns>
        public string GetItems()
        {
            try
            {
                string sSQL = "SELECT * FROM Items";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// pulls invoice info
        /// </summary>
        /// <returns></returns>
        public string GetInvoiceId()
        {
            try
            {
                string sSQL = "SELECT MAX(InvoiceId) FROM Invoices";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        #region Creates/Updates

        /// <summary>
        /// creates new invoice
        /// </summary>
        /// <param name="date"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        public string CreateInvoice(string date, string totalCost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost) VALUES ( '" + date + "'," + totalCost + ")";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        //rest of the SQL tommorrow when I find out what exact tables we are going to have.

        #endregion

        /// <summary>
        /// updates invoice
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public string UpdateInvoice(int id, string date, string cost)
        {
            try
            {
                string sSQL = "UPDATE Invoice SET InvoiceDate = " + date + ", TotalCost = " + cost + "WHERE InvoiceId = " + id.ToString() + ";";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// delete invoice
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        public string DeleteInvoice(int InvoiceNum)
        {
            try
            {
                string sSQL = "DELETE FROM Invoices WHERE InvoiceId = " + InvoiceNum.ToString();
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// delets item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteItem(int id)
        {
            try
            {
                string sSQL = "DELETE FROM ItemList WHERE InvoiceId = " + id.ToString();
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
    }
}
