using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Coming soon";
            return View();
        }//end Index

        public ActionResult Resume()
        {
            try
            {
                var workHistory = new List<Models.JobModel>();
                var education = new List<Models.EducationModel>();
                var workHistoryData = Models.DatabaseAccessModel.GetTable("workhistory");
                var educationData = Models.DatabaseAccessModel.GetTable("education");
                var jobs = workHistoryData.AsEnumerable().Select(x => x.Field<int>("Job_Id")).Distinct();
                int jobCount = jobs.Count();
                for (int i = 0; i < jobCount; i++)
                {
                    var temp = workHistoryData.AsEnumerable().Select(x => x).Where(x => x.Field<int>("Job_Id") == jobs.ElementAt(i));
                    workHistory.Add(new Models.JobModel(temp));
                }//end for
                foreach (DataRow row in educationData.Rows)
                {
                    education.Add(new Models.EducationModel(row));
                }
                return View(Tuple.Create(education, workHistory));
            } catch (Exception ex)
            {
                return View("Error");
            }
        }//end Resume

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }//end Contact
    }//end class
}//end namespace