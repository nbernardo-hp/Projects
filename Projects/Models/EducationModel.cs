using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Projects.Models
{
    public class EducationModel
    {
        public EducationModel()
        {
            Key = 0;
            Name = "";
            City = "";
            State = "";
            GPA = -1;
            GraduationDate = new DateTime();
            Major = "";
            Degree = "";
            Graduated = false;
        }//end default constructor

        public EducationModel(int key, string name, string city, string state, string major, string degree, double gpa, bool graduated, DateTime date)
        {
            Key = key;
            Name = name;
            City = city;
            State = state;
            GPA = gpa;
            GraduationDate = date;
            Degree = degree;
            Major = major;
            Graduated = graduated;
        }//end 6 argument constructor

        public EducationModel(int key, string name, string city, string state, string major, string degree, double gpa, bool graduated, int month, int day, int year)
        {
            Key = key;
            Name = name;
            City = city;
            State = state;
            GPA = gpa;
            GraduationDate = new DateTime(year, month, day);
            Major = major;
            Degree = degree;
            Graduated = graduated;
        }//end 8 argument constructor

        public EducationModel(DataRow row)
        {
            Key = row.Field<int>("Id");
            Name = row.Field<string>("Name");
            City = row.Field<string>("City");
            State = row.Field<string>("State");
            Major = row.Field<string>("Major");
            Degree = row.Field<string>("Degree");
            GPA = Convert.ToDouble(row.Field<decimal>("GPA"));
            SetGraduated(row.Field<string>("Graduated")[0]);
            if(row["Graduation_Date"].GetType() != typeof(DBNull))
            {
                GraduationDate = row.Field<DateTime>("Graduation_Date");
            } else
            {
                GraduationDate = new DateTime();
            }
        }//end 1 argument constructor
        public int KeyValue
        {
            get { return Key; }
            set
            {
                if(value >= 0)
                {
                    Key = value;
                }
            }
        }

        public string NameValue
        {
            get { return Name; }
            set { Name = value; }
        }
        public string CityValue
        {
            get { return City; }
            set { City = value; }
        }
        public string StateValue
        {
            get { return State; }
            set { State = value; }
        }
        public string MajorValue
        {
            get { return Major; }
            set { Major = value; }
        }
        public string DegreeValue
        {
            get { return Degree; }
            set { Degree = value; }
        }
        public double GPAValue
        {
            get { return GPA; }
            set
            {
                if(value >= 0)
                {
                    GPA = value;
                } else
                {
                    GPA = -1;
                }
            }
        }

        public bool GetGraduated() { return Graduated; }
        public void SetGraduated(bool grad) { Graduated = grad; }
        public void SetGraduated(char grad)
        {
            if(char.ToUpper(grad) == 'N')
            {
                Graduated = false;
            } else
            {
                Graduated = true;
            }
        }

        public string GetDate()
        {
            return String.Format("{0} {1}", GetMonthString(GraduationDate.Month), GraduationDate.Year);
        }

        /// <summary>
        /// Returns the month string for the month sent
        /// </summary>
        /// <param name="i">Month from the start or end date</param>
        /// <returns></returns>
        private string GetMonthString(int i)
        {
            switch (i)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                default:
                    return "December";
            }
        }//end GetMonthString

        [Required]
        private int Key;
        [Required]
        [Display(Name = "Name")]
        private string Name;
        [Required]
        [Display(Name = "City")]
        private string City;
        [Required]
        [Display(Name = "State")]
        private string State;
        private string Major;
        private double GPA;
        private bool Graduated;
        private DateTime GraduationDate;
        private string Degree;
    }//end class
}//end namespace