using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelTeamplate.Model;
using ExcelTeamplate.TeamplateDbContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExcelTeamplate.Controllers
{
    [EnableCors("AllowSameDomain")]
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
        public IActionResult GetFieldList(int pageindex = 1, int pagesize = 10, string keyword = "")
        {
            if (string.IsNullOrEmpty(keyword))
            {
                var list = (from f in _context.Fields
                            where f.FieldState == true
                            select f).Skip((pageindex - 1) * pagesize).Take(pagesize);
                return Ok(list);
            }
            else
            {
                var list = (from f in _context.Fields
                            where f.FieldState == true && f.FieldText.Contains(keyword)
                            select f).Skip((pageindex - 1) * pagesize).Take(pagesize);
                return Ok(list);
            }
        }

        /// <summary>
        /// 录入字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostField(Model.Field field)
        {
            if (string.IsNullOrEmpty(field.FieldName) || string.IsNullOrEmpty(field.FieldText))
            {
                // 字段主要信息为空则不能录入
                return BadRequest();
            }
            _context.Fields.Add(field);
            _context.SaveChanges();
            return Ok(field);
        }

        /// <summary>
        /// 修改录入的字段
        /// </summary>
        /// <param name="id"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutField(int id, Field field)
        {
            if (field.Id != id)
            {
                return BadRequest();
            }
            _context.Entry(field).State = EntityState.Modified;
            _context.Entry(field).Property("Id").IsModified = false;

            _context.Entry(field).Property("FieldName").IsModified = false;

            _context.Entry(field).Property("FieldType").IsModified = false;

            _context.Entry(field).Property("FieldLength").IsModified = false;

            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// 删除字段信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteField(int id)
        {
            var field = _context.Fields.Find(id);
            if(field == null)
            {
                return BadRequest();
            }
            _context.Entry(field).State = EntityState.Deleted;
            _context.SaveChanges();
            return NoContent();
        }
    }
}