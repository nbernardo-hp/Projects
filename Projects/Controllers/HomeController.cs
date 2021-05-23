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
        /// <summary>
        /// Gets the information for each project from the database and creates the model objects to use on the View.  If no data exists gives an error to the user.
        /// </summary>
        /// <returns>The view containing the information on the projects or an error if no information is retreived from the database.</returns>
        public ActionResult Index()
        {
            try
            {
                var table = Models.DatabaseAccessModel.GetTable("projects");
                if(table == null || table.Rows.Count <= 0)
                {
                    throw new Exception("no_data_projects");
                }
                var projects = new List<Models.ProjectModel>();
                var names = table.AsEnumerable().Select(x => x.Field<string>("Name")).Distinct();
                foreach (var name in names)
                {
                    projects.Add(new Models.ProjectModel(table.AsEnumerable().Select(x => x).Where(x => x.Field<string>("Name") == name)));
                }//end foreach
                ViewBag.Message = "Coming soon";
                return View(projects);
            } catch (Exception ex)
            {
                return View("Error");
            }//end try-catch
        }//end Index

        /// <summary>
        /// Gets the information for education and work history from the database and creates the model objects to use on the View.  If no data exists gives an error to the user.
        /// </summary>
        /// <returns>View containing the education and work history or an error page</returns>
        public ActionResult Resume()
        {
            try
            {
                var workHistory = new List<Models.JobModel>();
                var education = new List<Models.EducationModel>();
                var workHistoryData = Models.DatabaseAccessModel.GetTable("workhistory");
                var educationData = Models.DatabaseAccessModel.GetTable("education");
                if(workHistoryData == null || educationData == null)
                {
                    throw new Exception(String.Format("no_data_{0}",(workHistoryData == null ? "work" : "education")));
                }
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