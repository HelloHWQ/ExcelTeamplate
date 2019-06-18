using ExcelTeamplate.Model.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelTeamplate.Model
{
    public class Data
    {
        public int Id { set; get; }

        /// <summary>
        /// 定义枚举 -1：已删除的数据 1：正常数据
        /// </summary>
        public DataType DataType { set; get; }

        /// <summary>
        /// 每一个excel模板对应一个表名
        /// </summary>
        public string TableName { set; get; }

        public DateTime AddTime { set; get; }
    }
}
