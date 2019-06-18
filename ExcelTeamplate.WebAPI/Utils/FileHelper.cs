using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExcelTeamplate.WebAPI.Utils
{
    public class FileHelper
    {
        /// <summary>
        /// 单文件处理
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="files"></param>
        /// <param name="isAbs">是否返回物理路径</param>
        /// <returns></returns>
        public string SingleFileSave(HttpContext context,IHostingEnvironment hostingEnvironment,IFormFile file,bool isAbs=false)
        {
            string ret = "";
            try
            {
                // 程序内容根路径
                string contentRootPath = hostingEnvironment.ContentRootPath;
                if(file.Length > 0)
                {
                    string fileExt = GetFileExt(file.FileName);
                    string dirName = contentRootPath + "\\upload\\" + DateTime.Now.ToString("yyyy-MM-dd");
                    if (!Directory.Exists(dirName))
                    {
                        Directory.CreateDirectory(dirName);
                    }
                    string newFileName = System.Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
                    string filePath = dirName + "\\" + newFileName;
                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(stream);
                    }
                    if(isAbs == true)
                    {
                        ret = filePath;
                    }
                    else
                    {
                        ret = PathHelper.urlToVirtual(filePath, hostingEnvironment);
                    }
                }
                return ret;
            }
            catch(Exception e)
            {
                return ret;
            }
        }

        public Dictionary<string,object> FileSave(HttpContext context, IHostingEnvironment _hostingEnvironment, IFormFileCollection files)
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            try
            {
                long size = files.Sum(f => f.Length);
                string contentRootPath = _hostingEnvironment.ContentRootPath;
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {

                        string fileExt = GetFileExt(formFile.FileName); //文件扩展名，不含“.”
                        long fileSize = formFile.Length; //获得文件大小，以字节为单位
                        string dirName = contentRootPath + "\\upload\\" + DateTime.Now.ToString("yyyy-MM-dd");
                        if (!Directory.Exists(dirName))
                        {
                            Directory.CreateDirectory(dirName);
                        }
                        string newFileName = System.Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
                        var filePath = dirName + "\\" + newFileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        ret.Add(formFile.FileName, new { path = filePath, size = formFile.Length, url= PathHelper.urlToVirtual(filePath,_hostingEnvironment)});
                    }
                }
                return ret;
            }
            catch(Exception e)
            {
                return ret;
            }
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetFileExt(string fileName)
        {
            string ret = "";
            int index = fileName.IndexOf('.');
            ret = fileName.Substring(index+1);
            return ret;
        }
    }
}
