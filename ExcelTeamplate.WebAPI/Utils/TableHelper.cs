using ExcelTeamplate.Model;
using ExcelTeamplate.TeamplateDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTeamplate.WebAPI.Utils
{
    public class TableHelper
    {
        private readonly TeamplateContext _context = null;

        public TableHelper(TeamplateContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据字段id或英文名称创建excel模板专属表
        /// </summary>
        /// <param name="fields">字段id或英文名称</param>
        /// <param name="isId">具体是id还是英文名称</param>
        /// <returns></returns>
        public string AddTableToDB(string[] fields,bool isId=true)
        {
            string tablename = RandomTableName();
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"CREATE TABLE [dbo].[{tablename}](");
                    sb.AppendLine($"[Id] [int] IDENTITY(1,1) PRIMARY KEY  NOT NULL,");
                    sb.AppendLine($"[AddTime] [datetime2](7) NULL,");
                    foreach (var item in fields)
                    {
                        GetFieldNameandFieldType(item, isId, out string fieldname, out string fieldtype);
                        sb.AppendLine($"{fieldname} {fieldtype} NULL,");
                    }
                    string sql = sb.ToString();
                    string sqlret = sql.Substring(0,sql.LastIndexOf(','));

                    sqlret += ")";
                    int ret = _context.Database.ExecuteSqlCommand(sqlret);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    return "";
                }
            }
           
            return tablename;
        }

        /// <summary>
        /// 获取一个随机表名
        /// </summary>
        /// <returns></returns>
        public string RandomTableName()
        {
            string ret = "";
            List<char> WordList = new List<char>() { 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            string date = DateTime.Now.ToString("yyyyMMdd");
            Random random = new Random();
            for (int i = 0; i <= 5; i++)
            {
                int index = random.Next(0, 26);
                ret += WordList[index];
            }
            ret += date;
            return ret;
        }

        /// <summary>
        /// 返回字段关键字对应的列名和类型
        /// </summary>
        /// <param name="fieldkeyword"></param>
        /// <param name="isId"></param>
        private void GetFieldNameandFieldType(string fieldkeyword,bool isId,out string fieldname,out string fieldtype)
        {
            Field field = null;
            if(isId == true)
            {
                field = _context.Fields.Where<Field>(f => f.Id == Convert.ToInt32(fieldkeyword)).FirstOrDefault<Field>();
            }
            else
            {
                field = _context.Fields.Where<Field>(f => f.FieldName == fieldkeyword).FirstOrDefault<Field>();
            }
            if(field != null)
            {
                fieldname = "[" + field.FieldName+"]";
                if(field.FieldType.ToString()=="Int" || field.FieldType.ToString() == "DateTime" || field.FieldType.ToString() == "Float" || field.FieldType.ToString() == "Text")
                {
                    fieldtype = "[" + field.FieldType.ToString().ToLower()+ "]";
                }
                else
                {
                    fieldtype = "[" + field.FieldType.ToString().ToLower() + "](" + field.FieldLength + ")";
                }
                
            }
            else
            {
                fieldname = "";
                fieldtype = "";
            }
        }
    }
}
