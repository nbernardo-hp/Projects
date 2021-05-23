using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projects.Models
{
    public class StockModel
    {
        public StockModel(DataRow sRow, DataRow pRow)
        {
            type = sRow.Field<string>("type")[0];
            name = sRow.Field<string>("name");
            symbol = sRow.Field<string>("symbol");
            sma200 = pRow.Field<string>("sma200");
            sma20 = pRow.Field<string>("sma20");
            sma50 = pRow.Field<string>("sma50");
            chartPattern = pRow.Field<string>("chartPattern");
            unexpectedItems = pRow.Field<string>("unexpectedItems");
            finvizRank = (sRow["finvizRank"].GetType() != typeof(DBNull)? sRow.Field<int>("finvizRank") : int.MinValue);
            individualRating = sRow.Field<double>("individualRating");
        }//end StockModel(DataTable)
        public char TypeValue
        {
            get { return type; }
            set { type = Char.ToLower(value); }
        }

        public string NameValue
        {
            get { return name; }
            set { name = value; }
        }

        public string SymbolValue
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public string SMA200Value
        {
            get { return sma200; }
            set { sma200 = value; }
        }
        public string SMA50Value
        {
            get { return sma50; }
            set { sma50 = value; }
        }
        public string SMA20Value
        {
            get { return sma20; }
            set { sma20 = value; }
        }
        public string ChartPatternValue
        {
            get { return chartPattern; }
            set { chartPattern = value; }
        }
        public string UnexpectedItemsValue
        {
            get { return unexpectedItems; }
            set { unexpectedItems = value; }
        }

        public int FinvizRankValue
        {
            get { return finvizRank; }
            set { finvizRank = value; }
        }

        public double IndividualRatingValue
        {
            get { return individualRating; }
            set
            {
                if(value >= 0)
                {
                    individualRating = value;
                } else
                {
                    individualRating = Double.MinValue;
                }
            }
        }

        /// <summary>
        /// Calculates and sets the individual rating of the stock based on the scores of each attribute
        /// </summary>
        public void CalculateIndividualRating()
        {
            /*Adds the values saved in the preferences for the stock attribute values.  If the stock is a sector stock add
             *the finviz rank value.  Divide the rating by a specific value based on the score of unexpected items and
             *if it is a market or sector*/
            individualRating = (Models.PreferencesModel.GetScore("sma200", sma200) + Models.PreferencesModel.GetScore("sma50", sma50) + Models.PreferencesModel.GetScore("sma20", sma20)) / 3;
            individualRating += Models.PreferencesModel.GetScore("chartPattern", chartPattern) + Models.PreferencesModel.GetScore("unexpectedItems", unexpectedItems);
            if(Models.PreferencesModel.GetScore("unexpectedItems", unexpectedItems) > 0)
            {
                individualRating /= (type == 'm' ? 3 : 4);
            } else
            {
                individualRating /= (type == 'm' ? 2 : 3);
            }//end if-else
            individualRating = Math.Round(individualRating, 1);
        }//end CalculateIndividualRating

        private char type;
        private string name;
        private string symbol;
        private string sma200;
        private string sma20;
        private string sma50;
        private string chartPattern;
        private string unexpectedItems;
        private int finvizRank;
        private double individualRating;
    }//end class
}//end namespace