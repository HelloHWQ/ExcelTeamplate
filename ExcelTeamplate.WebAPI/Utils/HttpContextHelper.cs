using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelTeamplate.WebAPI.Utils
{
    public class HttpContextHelper
    {
        public static string GetString(HttpContext context, string key)
        {
            string ret = "";
            ret = context.Request.Query[key];
            if(string.IsNullOrEmpty(ret))
            {
                ret = context.Request.Form[key];
            }
            return ret;
        }
    }
}
