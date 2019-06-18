using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelTeamplate.Model;
using ExcelTeamplate.Model.enums;
using ExcelTeamplate.TeamplateDbContext;
using ExcelTeamplate.WebAPI.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTeamplate.WebAPI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json", "multipart/form-data")]//此处为新增
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly TeamplateContext _context = null;
        private readonly IHostingEnvironment _hostingEnvironment = null;

        public ExcelController(TeamplateContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 上传Excel文件
        /// </summary>
        /// <param name="files"></param>
        /// <remarks>很神奇必须加一个参数IFormFile才能通过Form.Files获取文件流</remarks>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostImportExcel(IFormFile files)
        {
            // 写日志
            LogHelper log = new LogHelper(_context);
            log.LogWrite("Excel文件上传开始", "Excel", ActionType.Post, HttpContext.GetClientUserIp());
            var file = HttpContext.Request.Form.Files[0];
            // 上传文件
            string filepath = "文件为空";
            if(file != null)
            {
                FileHelper fileHelper = new FileHelper();
                filepath = fileHelper.SingleFileSave(HttpContext, _hostingEnvironment, file);
            }
            FileState state;
            if(filepath != "文件为空")
            {
                log.LogWrite("Excel文件上传成功", "Excel", ActionType.Post, HttpContext.GetClientUserIp());
                state = FileState.FileNotImport;
            }
            else
            {
                log.LogWrite("Excel文件上传失败", "Excel", ActionType.Post, HttpContext.GetClientUserIp());
                state = FileState.FileUploadFail;
            }
            Attach excelFile = new Attach();
            excelFile.AddTime = DateTime.Now;
            excelFile.ClientIP = HttpContext.GetClientUserIp();
            excelFile.FileName = file.FileName;
            excelFile.FilePath = filepath;
            excelFile.FileSize = file.Length;
            excelFile.FileState = state;
            _context.Add<Attach>(excelFile);
            _context.SaveChanges();
            // 获取参数
            string fields = HttpContextHelper.GetString(HttpContext, "fields");
            var arrryField = fields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            // 创建excel模型专属表
            Data data = new Data();
            data.AddTime = DateTime.Now;
            data.DataType = DataType.DataIsLive;
            data.TableName = fields;
            _context.Add<Data>(data);
            _context.SaveChanges();
            Main main = new Main();
            main.AddTime = DateTime.Now;
            main.AttachId = excelFile.Id;
            main.ClientIP = HttpContext.GetClientUserIp();
            main.DataId = data.Id;
            _context.Add<Main>(main);
            int mainid = _context.SaveChanges();
            if(mainid > 0)
            {
                return Ok(new { mainid = mainid });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}