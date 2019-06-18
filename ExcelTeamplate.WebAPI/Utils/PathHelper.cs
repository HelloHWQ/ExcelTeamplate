using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelTeamplate.WebAPI.Utils
{
    public class PathHelper
    {
        /// <summary>
        /// 物理路径转换为相对路径
        /// </summary>
        /// <param name="path">物理路径</param>
        /// <returns></returns>
        public static string urlToVirtual(string path,IHostingEnvironment _hostingEnvironment)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            path = path.Replace(contentRootPath, "");
            return path.Replace(@"\", "/");
        }

        /// <summary>
        /// 把相对路径转换为物理路径
        /// </summary>
        /// <param name="path">物理路径</param>
        /// <param name="_hostingEnvironment"></param>
        /// <returns></returns>
        public static string virtualToUrl(string path, IHostingEnvironment _hostingEnvironment)
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            path = contentRootPath + path.Replace(@"/", @"\"); //转换成绝对路径  
            return path;
        }
    }
}
