using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelTeamplate.TeamplateDbContext;
using ExcelTeamplate.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTeamplate.Controllers
{
    [EnableCors("AllowSameDomain")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly TeamplateContext _context = null;
        private readonly IHostingEnvironment _hostingEnvironment= null;

        public ExcelController(TeamplateContext context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok(new { code = 1 });
        }

        [HttpPost]
        public async Task<IActionResult> PostImportExcel(List<IFormFile> files)
        {
            Console.WriteLine(HttpContext.Request.Form.Files.Count);
            FileHelper fileHelper = new FileHelper();
            await fileHelper.FileSave(HttpContext, _hostingEnvironment, HttpContext.Request.Form.Files);
            return Ok(new { count = files.Count});
        }
    }
}