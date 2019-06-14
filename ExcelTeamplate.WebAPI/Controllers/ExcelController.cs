using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelTeamplate.TeamplateDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTeamplate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly TeamplateContext _context = null;

        public ExcelController(TeamplateContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostImportExcel(FormCollection fc)
        {
            Console.WriteLine(fc.Files.Count);
            return BadRequest();
        }
    }
}