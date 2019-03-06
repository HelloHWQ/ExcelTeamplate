using ExcelTeamplate.Model.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelTeamplate.Model
{
    public class Attach
    {
        public int Id { set; get; }

        /// <summary>
        /// 业务主键
        /// </summary>
        public int BId { set; get; }

        public string FileName { set; get; }

        public string FilePath { set; get; }

        public string ClientIP { set; get; }

        /// <summary>
        /// 定义枚举类型 -1：文件上传失败 0：文件上传成功了但是没有进行导入 1：上传且导入成功
        /// </summary>
        public FileState FileState { set; get; }

        public double FileSize { set; get; }

        public DateTime AddTime { set; get; }
    }
}
