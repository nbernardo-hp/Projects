using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.Controllers
{
    public class StocksController : Controller
    {
        // GET: Stocks
        public ActionResult TopDownAnalysis()
        {
            /*Get the information from the database for the preferences and parse it into the PreferencesModel*/
            try
            {
                var table = Models.DatabaseAccessModel.GetTable("preferences");
                if (table == null || table.Rows.Count <= 0)
                {
                    throw new Exception("no_data_projects");
                }
                foreach (DataRow row in table.Rows)
                {
                    Models.PreferencesModel.SetPreference(row.Field<string>("Preference").Trim(), row.Field<string>("Name").Trim(), row.Field<double>("Value"));
                }
                table.Clear();
                table.Dispose();

                Dictionary<string, List<Models.StockModel>> stocks = new Dictionary<string, List<Models.StockModel>>();
                var tables = new List<DataTable>() { Models.DatabaseAccessModel.GetTable("stocks"), Models.DatabaseAccessModel.GetTable("stockpreferences") };
                if(tables == null || tables.Count <= 0)
                {
                    throw new Exception("no_data_topdownanalysis");
                } else if(tables.Count == 1)
                {
                    throw new Exception(String.Format("no_data_{0}", (tables[0].Columns.Contains("Preference") ? "stocks" : "stockpreferences")));
                }
                int prefIndex = 0;
                foreach (DataRow row in tables[0].Rows)
                {
                    string type = row.Field<string>("Type").Trim();
                    if (!stocks.ContainsKey(type))
                    {
                        stocks.Add(type, new List<Models.StockModel>());
                    }
                    stocks[type].Add(new Models.StockModel(row, tables[1].Rows[prefIndex]));
                    prefIndex++;
                }
                return View(stocks);
            } catch (Exception ex)
            {
                return View("Error");
            }
        }//end Index
    }//end class
}//end namespace