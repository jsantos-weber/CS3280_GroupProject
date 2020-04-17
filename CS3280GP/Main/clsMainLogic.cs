using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CS3280GP.Search;

namespace CS3280GP.Main
{
    class clsMainLogic
    {
        clsDataAccess db;
        clsMainSQL Query;


        /// <summary>
        /// Initialize class level variables
        /// </summary>
        public clsMainLogic()
        {
            try
            {
                Query = new clsMainSQL();
                db = new clsDataAccess();
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// gets invoices
        /// </summary>
        /// <returns></returns>
        public List<clsLineItems> ListItems()
        {
            try
            {
                List<clsLineItems> listItems = new List<clsLineItems>();

                int rows = 0;
                DataSet rawdata = db.ExecuteSQLStatement(Query.GetItems(), ref rows);

                for(int x = 0; x < rows; x++)
                {
                    Double.TryParse(rawdata.Tables[0].Rows[x][2].ToString(), out double total);

                    listItems.Add(new clsLineItems
                    {
                        ItemCode = rawdata.Tables[0].Rows[x][0].ToString(),
                        ItemDesc = rawdata.Tables[0].Rows[x][1].ToString(),
                        Cost = total
                    });
                }
                return listItems;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// gets line items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<clsLineItems> GetLineItems(int id)
        {
            try
            {
                List<clsLineItems> listItems = new List<clsLineItems>();

                int rows = 0;
                string sSQL = Query.GetLineItems(id);
                DataSet rawdata = db.ExecuteSQLStatement(sSQL, ref rows);

                for(int x = 0; x < rows; x++)
                {
                    Double.TryParse(rawdata.Tables[0].Rows[x][2].ToString(), out double total);
                    Int32.TryParse(rawdata.Tables[0].Rows[x][3].ToString(), out int num);

                    listItems.Add(new clsLineItems
                    {
                        ItemCode = rawdata.Tables[0].Rows[x][0].ToString(),
                        ItemDesc = rawdata.Tables[0].Rows[x][1].ToString(),
                        Cost = total,
                        LineItemNum = num
                    });
                }
                return listItems;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }            
        }

        /// <summary>
        /// creates a new invoice
        /// </summary>
        /// <param name="date"></param>
        /// <param name="cost"></param>
        /// <param name="listItems"></param>
        /// <returns></returns>
        public int CreateInvoice(string date, string cost, List<clsLineItems> listItems)
        {

            try
            {
                db.ExecuteNonQuery(Query.CreateInvoice(date, cost));


                Int32.TryParse(db.ExecuteScalarSQL(Query.GetInvoiceId(date, cost)), out int id);
                CreateLineItems(id, listItems);
                return id;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// adds line items to invoice
        /// </summary>
        /// <param name="id"></param>
        /// <param name="listItems"></param>
        public void CreateLineItems(int id, List<clsLineItems> listItems)
        {
            try
            {
                foreach (var item in listItems)
                {
                    int x = item.LineItemNum;
                    string y = item.ItemCode;
                    db.ExecuteNonQuery(Query.CreateLineItems(id, item));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// updates invoice
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="cost"></param>
        public void UpdateInvoice(int id, string date, string cost)
        {
            try
            {
                db.ExecuteNonQuery(Query.UpdateInvoice(id, date, cost));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// updates line items
        /// </summary>
        /// <param name="id"></param>
        /// <param name="listItems"></param>
        public void UpdateLineItems(int id, List<clsLineItems> listItems)
        {
            try
            {
                DeleteLineItems(id);

                foreach(var item in listItems)
                {
                    int x = item.LineItemNum;
                    string y = item.ItemCode;
                    db.ExecuteNonQuery(Query.CreateLineItems(id, item));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// deletes invoice and makes sure to delete out line items
        /// </summary>
        /// <param name="id"></param>
        public void DeleteInvoice(int id)
        {
            try
            {
                DeleteLineItems(id);

                db.ExecuteNonQuery(Query.DeleteInvoice(id));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// deletes line items
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLineItems(int id)
        {
            try
            {
                db.ExecuteNonQuery(Query.DeleteLineItems(id));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }
}
