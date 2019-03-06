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

        public DateTime AddTime { set; get; }
    }
}
