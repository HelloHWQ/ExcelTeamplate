using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelTeamplate.TeamplateDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExcelTeamplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly TeamplateContext _context = null;

        public FieldController(TeamplateContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取服务端所包含的字段
        /// </summary>
        /// <param name="pageindex">分页获取的索引</param>
        /// <param name="pagesize">分页获取的页大小</param>
        /// <param name="keyword">字段搜索关键字</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFieldList(int pageindex = 0, int pagesize = 0,string keyword = "")
        {
            _context.Datas.FromSql("select name from syscolumns where id in (select id from sysobjects)");
            return BadRequest();
        }
    }
}