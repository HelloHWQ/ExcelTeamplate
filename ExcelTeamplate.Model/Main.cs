using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelTeamplate.Model
{
    public class Main
    {
        public int Id { set; get; }

        /// <summary>
        /// 数据表外键
        /// </summary>
        public int DataId { set; get; }

        /// <summary>
        /// 附件表外键
        /// </summary>
        public int AttachId { set; get; }

        public string ClientIP { set; get; }

        public string Token { set; get; }

        public DateTime AddTime { set; get; }

        /// <summary>
        /// 一对一关系的引用
        /// </summary>
        public Data Data { set; get; }
        public Attach Attach { set; get; }
    }
}
