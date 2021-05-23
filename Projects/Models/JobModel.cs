using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Projects.Models
{
    public class JobModel
    {
        public JobModel()
        {
            Id = 0;
            Company = "";
            City = "";
            State = "";
            JobTitle = "";
            StartDate = new DateTime();
            EndDate = new DateTime();
            JobDescription = new List<string>();
        }//end default constructor

        public JobModel(EnumerableRowCollection<DataRow> job)
        {
            Id = job.ElementAt(0).Field<int>("Job_Id");
            Company = job.ElementAt(0).Field<string>("Name");
            City = job.ElementAt(0).Field<string>("City");
            State = job.ElementAt(0).Field<string>("State");
            JobTitle = job.ElementAt(0).Field<string>("Title");
            StartDate = job.ElementAt(0).Field<DateTime>("StartDate");
            var endDate = job.ElementAt(0)["EndDate"];
            EndDate = (endDate.GetType() != typeof(DBNull) ? job.ElementAt(0).Field<DateTime>("EndDate") : new DateTime());

            JobDescription = job.Select(x => x.Field<string>("Description")).ToList<string>();
        }//end One argument constructor

        public JobModel(int id, string company, string job, DateTime start, DateTime end, List<string> desc)
        {
            Id = id;
            Company = company;
            JobTitle = job;
            StartDate = start;
            EndDate = end;
            JobDescription = desc;
        }//end 5 argument constructor

        //Get Methods
        public int GetId() { return Id; }
        public string GetJobTitle() { return JobTitle; }

        /// <summary>
        /// Returns the start or end date of the start or end date
        /// </summary>
        /// <param name="endDate">Indicates whether you are trying to get the start or end date</param>
        /// <returns>The month and year of the start or end date</returns>
        public string GetDate(bool endDate = false)
        {
            if(endDate && EndDate == new DateTime()) { return "Present"; }
            string month = GetMonthString((!endDate ? StartDate.Month : EndDate.Month));
            return month + " " + (!endDate ? StartDate.Year : EndDate.Year).ToString();
        }//end GetDate

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


        public List<string> GetJobDescription() { return JobDescription; }
        public string GetCompany() { return Company; }

        //Set Methods
        public void SetId(int id) { Id = id; }
        public void SetJobTitle(string job) { JobTitle = job; }
        public void SetStartDate(DateTime start) { StartDate = start; }
        public void SetEndDate(DateTime end) { EndDate = end; }
        public void SetDescription(List<string> desc) { JobDescription = desc; }
        public void AddDescription(string desc)
        {
            if(desc != "")
            {
                JobDescription.Add(desc);
            }//end if
        }//end AddDescription

        /// <summary>
        /// Returns the month string for the month sent
        /// </summary>
        /// <param name="i">Month from the start or end date</param>
        /// <returns></returns>
        private string GetMonthString(int i)
        {
            switch(i)
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

        [Key]
        private int Id;
        [Required]
        [Display(Name = "Company")]
        private string Company;
        private string City;
        private string State;
        [Required]
        [Display(Name = "Job Title")]
        private string JobTitle;
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        private DateTime StartDate;
        [Display(Name = "End Date")]
        private DateTime EndDate;
        private List<string> JobDescription;
    }//end class
}//end namespace