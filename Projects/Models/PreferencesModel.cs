using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projects.Models
{
    public static class PreferencesModel
    {
        public static Dictionary<string, string> GetDropDownItems(string key)
        {
            if(dropDown.ContainsKey(key))
            {
                return dropDown[key];
            }
            return null;
        }
        public static string GetDropDownItemValue(string key, string value)
        {
            if(dropDown.ContainsKey(key))
            {
                if(dropDown[key].ContainsKey(value))
                {
                    return dropDown[key][value];
                }
            }
            return null;
        }
        public static Dictionary<string, Dictionary<string, double>> GetPreferences()
        {
            return preferences;
        }
        public static double GetScore(string pref, string value)
        {
            if(preferences != null && preferences.ContainsKey(pref) && preferences[pref].ContainsKey(value))
            {
                return preferences[pref][value];
            }
            return double.MinValue;
        }
        public static void SetPreferences(Dictionary<string, Dictionary<string, double>> prefs)
        {
            preferences = prefs;
        }
        public static void SetPreferences(string pref, Dictionary<string, double> prefs)
        {
            if (preferences != null)
            {
                if (preferences.ContainsKey(pref))
                {
                    preferences[pref] = prefs;
                }
                else
                {
                    preferences.Add(pref, prefs);
                }//end nested if-else
            }//end if
        }//end SetPreferences(string, Dictionary<string, double>

        public static void SetPreference(string pref, string option, double value)
        {
            if(preferences.ContainsKey(pref) && preferences[pref].ContainsKey(option))
            {
                if(value >= 0)
                {
                    preferences[pref][option] = value;
                }//end nested if
            }//end if
        }//end SetPreference

        private static Dictionary<string, Dictionary<string, string>> dropDown = new Dictionary<string, Dictionary<string, string>>()
        {
            ["sma200"] = new Dictionary<string, string>()
            {
                ["up"] = "Up",
                ["upDown"] = "Up and Down",
                ["down"] = "Down"
            },
            ["sma5020"] = new Dictionary<string, string>()
            {
                ["above"] = "Above",
                ["at"] = "At",
                ["below"] = "Below"
            },
            ["chartPattern"] = new Dictionary<string, string>()
            {
                ["bullRun"] = "Bull Run",
                ["bullConsolidation"] = "Bull Consolidation",
                ["consolidation"] = "Consolidation",
                ["bearConsolidation"] = "Bear Consolidation",
                ["bearRun"] = "Bear Run"
            },
            ["unexpectedItems"] = new Dictionary<string, string>()
            {
                ["veryGood"] = "Very Good",
                ["good"] = "Good",
                ["average"] = "Average",
                ["bad"] = "Bad",
                ["veryBad"] = "Very Bad",
                ["noNews"] = "No News"
            }
        };
        private static Dictionary<string, Dictionary<string, double>> preferences = new Dictionary<string, Dictionary<string, double>>()
        {
            ["sma200"] = new Dictionary<string, double>()
            {
                ["up"] = 10,
                ["upDown"] = 5,
                ["down"] = 0
            },
            ["sma50"] = new Dictionary<string, double>()
            {
                ["above"] = 10,
                ["at"] = 5,
                ["below"] = 0
            },
            ["sma20"] = new Dictionary<string, double>()
            {
                ["above"] = 10,
                ["at"] = 5,
                ["below"] = 0
            },
            ["chartPattern"] = new Dictionary<string, double>()
            {
                ["bullRun"] = 10,
                ["bullConsolidation"] = 5,
                ["consolidation"] = 0,
                ["bearConsolidation"] = -5,
                ["bearRun"] = -10
            },
            ["unexpectedItems"] = new Dictionary<string, double>()
            {
                ["veryGood"] = 10,
                ["good"] = 5,
                ["average"] = 0,
                ["bad"] = -5,
                ["veryBad"] = -10,
                ["noNews"] = 0
            }
        };
    }//end class
}//end namespace