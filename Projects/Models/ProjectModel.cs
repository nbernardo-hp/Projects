using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Projects.Models
{
    public class ProjectModel
    {
        public ProjectModel()
        {
            Key = 0;
            Title = "";
            Description = "";
            Urls = new Dictionary<string, string>();
        }//end default constructor

        public ProjectModel(IEnumerable<DataRow> rows)
        {
            Key = rows.First().Field<int>("Id");
            Title = rows.First().Field<string>("Name");
            Description = rows.First().Field<string>("Description");
            Urls = new Dictionary<string, string>();
            var web = rows.Select(x => x.Field<string>("Website"));
            var url = rows.Select(x => x.Field<string>("Url"));
            for (int i = 0; i < web.Count() && i < url.Count(); i++)
            {
                var site = web.ElementAt(i);
                if (site.ToLower() == "youtube")
                {
                    HasVideo = true;
                }
                if (Urls.ContainsKey(site))
                {
                    Urls[site] = url.ElementAt(i);
                }
                else
                {
                    Urls.Add(site, url.ElementAt(i));
                }//end nested if-else
            }//end for
        }//end one argument constructor

        public ProjectModel(DataRow row)
        {
            Key = row.Field<int>("Id");
            Title = row.Field<string>("Name");
            Description = row.Field<string>("Description");
            Urls = new Dictionary<string, string>() { [row.Field<string>("Website")] = row.Field<string>("Url") };
        }//end on argument constructor

        public string TitleValue
        {
            get { return Title; }
            set { Title = value; }
        }

        public string DescriptionValue
        {
            get { return Description; }
            set { Description = value; }
        }

        public bool HasVideoValue
        {
            get { return HasVideo; }
            set { HasVideo = value; }
        }

        public string[] GetUrl(string site)
        {
            if (Urls.ContainsKey(site))
            {
                return new string[] { site, Urls[site] };
            }

            return null;
        }

        public Dictionary<string, string> GetUrls() { return Urls; }

        public void SetUrl(string site, string url)
        {
            if (Urls.ContainsKey(site))
            {
                Urls[site] = url;
            }
            else
            {
                Urls.Add(site, url);
            }
        }

        private int Key;
        private string Title;
        private string Description;
        private Dictionary<string, string> Urls;
        private bool HasVideo;
    }//end class
}//end namespace