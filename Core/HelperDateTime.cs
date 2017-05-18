using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class HelperDateTime
    {
        public static string ConvertDateToString(DateTime? date, string format = "dd/MM/yyyy")
        {

            if (date != null)
            {
                string Result = Convert.ToDateTime(date).ToString(format);
                return Result;
            }
            else
            {
                string Result = "";
                return Result;
            }
            //else return "";
        }

        public static DateTime? ConvertDate(string s, bool notNull = true)
        {
            if (!string.IsNullOrEmpty(s))
            {
                string[] dateStr;
                if (s.Contains('-'))
                {
                    dateStr = s.Split('-');
                    var swap = dateStr[0];
                    dateStr[0] = dateStr[2];
                    dateStr[2] = swap;
                }
                else
                {
                    dateStr = s.Split('/');
                }
                return new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]),
                    Convert.ToInt32(dateStr[0]));
            }
            else
            {
                if (notNull)
                {
                    return new DateTime(0001, 1, 1);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
