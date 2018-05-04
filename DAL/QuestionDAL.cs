using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model;

namespace DAL
{
    public class QuestionDAL
    {
        public static Question GetOne(string questionid)
        {
            string sql = "select * from question where questionid=@questionid";
            return SqlHelper.GetOne<Question>(sql, new {questionid = questionid});
        }
        public static PagedTable<Question> GetPagedTable(int limit, int offset, string orderby, string orderway)
        {
            string sql = "select * from question";
           return SqlHelper.GetPagedTable<Question>(sql,limit, offset, orderby, orderway);
        }
        public static bool IsExsit(string questionid)
        {
            string sql = "select count(*) from question where questionid=@questionid";
            int res = SqlHelper.ExecuteScalar<int>(sql, new {questionid = questionid});
            return res > 0;
        }
        public static bool Add(string title, string questionid, int totalanswer, string url,string createtime)
        {
            string sql =
                "insert into question (title,questionid,totalanswer,url,createtime) values (@title,@questionid,@totalanswer,@url,@createtime)";
            int res = SqlHelper.Execute(sql,
                new
                {
                    title = title,
                    questionid = questionid,
                    totalanswer = totalanswer,
                    url = url,
                    createtime = createtime
                });
            return res > 0;
        }
    }
}
