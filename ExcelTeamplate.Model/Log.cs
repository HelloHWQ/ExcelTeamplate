using ExcelTeamplate.Model.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelTeamplate.Model
{
    public class Log
    {
        public int Id { set; get; }
        
        public string ClientIp { set; get; }

        /// <summary>
        /// 前期先记录http type后期可扩展与权限相关，定义枚举
        /// </summary>
        public ActionType ActionType { set; get; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType { set; get; }

        public DateTime AddTime { set; get; }

        public string Remark { set; get; }
    }
}
