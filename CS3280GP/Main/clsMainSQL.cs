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
        #region gets

        /// <summary>
        /// Gets all Items
        /// </summary>
        /// <returns>The items</returns>
        public string GetItems()
        {
            try
            {
                string sSQL = "SELECT * FROM ItemDesc";
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
        public string GetInvoiceId(string date, string cost)
        {
            try
            {
                string sSQL = "SELECT MAX(InvoiceNum) FROM Invoices";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        public string GetLineItems(int invoiceId)
        {
            try
            {
                string sSql = "SELECT i.ItemCode, i.ItemDesc,i.Cost,l.Quantity " +
                                "FROM ItemDesc AS i " +
                                "INNER JOIN LineItems AS l ON i.ItemCode = l.ItemCode " +
                                "WHERE InvoiceNum = " + invoiceId;
                return sSql;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        #endregion
        #region Creates/Updates

        /// <summary>
        /// creates new invoice
        /// </summary>
        /// <param name="date"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        public string CreateInvoice(string Date, string Cost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost) VALUES ( '" + Date + "'," + Cost + ")";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public string CreateLineItems(int id, clsLineItems Item)
        {
            try
            {
                string sSQL = "INSERT INTO LineItems (InoviceNum,LineItemNum,ItemCode) VALUES (" + id.ToString() + "," +
                                Item.LineItemNum.ToString() + ", \"" + Item.ItemCode.ToString() + "\")";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

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
                string sSQL = "UPDATE Invoices SET InvoiceDate = " + date + ", TotalCost = " + cost + "WHERE InvoiceNum = " + id.ToString() + ";";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        #endregion

        /// <summary>
        /// delete invoice
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        public string DeleteInvoice(int IDNum)
        {
            try
            {
                string sSQL = "DELETE FROM Invoices WHERE InvoiceNum = " + IDNum.ToString();
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
        public string DeleteLineItems(int id)
        {
            try
            {
                string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = " + id.ToString();
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
    }
}
