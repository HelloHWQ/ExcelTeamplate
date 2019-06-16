using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExcelTeamplate.Utils
{
    public class FileHelper
    {
        public async Task<Dictionary<string,string>> FileSave(HttpContext context, IHostingEnvironment _hostingEnvironment, IFormFileCollection files)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
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
                            await formFile.CopyToAsync(stream);
                        }
                        ret.Add(formFile.FileName, filePath);
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
