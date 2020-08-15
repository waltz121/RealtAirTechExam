using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons
{
    public class UtilitySettings
    {
        public static string WebApiUrl { get; protected set; }

        public static void SetWebApiUrl(string url)
        {
            WebApiUrl = url;
        }
    }
}
