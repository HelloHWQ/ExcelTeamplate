using ExcelTeamplate.Model.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelTeamplate.Model
{
    public class Field
    {
        public int Id { set; get; }

        public string FieldName { set; get; }

        public string FieldText { set; get; }

        public FieldType FieldType { set; get; }

        public int FieldLength { set; get; }

        public bool FieldRequired { set; get; }

        /// <summary>
        /// 是否使用
        /// </summary>
        public bool FieldState { set; get; }

        public DateTime AddTime { set; get; }
    }
}
