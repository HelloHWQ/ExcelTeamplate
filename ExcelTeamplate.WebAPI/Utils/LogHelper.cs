using ExcelTeamplate.Model;
using ExcelTeamplate.Model.enums;
using ExcelTeamplate.TeamplateDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelTeamplate.WebAPI.Utils
{
    public class LogHelper
    {
        private readonly TeamplateContext _context = null;
        public LogHelper(TeamplateContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="logtype"></param>
        /// <param name="at"></param>
        /// <param name="clientip"></param>
        public void LogWrite(string msg,string logtype,ActionType at,string clientip)
        {
            Log log = new Log();
            log.ActionType = at;
            log.AddTime = DateTime.Now;
            log.ClientIp = clientip;
            log.LogType = logtype;
            log.Remark = msg;
            _context.Add<Log>(log);
            _context.SaveChanges();
        }
    }
}
