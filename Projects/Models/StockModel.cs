using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Portfolio.Models
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
            set { type = value; }
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
        public void CalculateIndividualRating()
        {
            
        }

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