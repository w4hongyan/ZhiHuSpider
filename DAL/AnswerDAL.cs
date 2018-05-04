using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model;

namespace DAL
{
    public class AnswerDAL
    {
        public static bool Visited(string answerid)
        {
            string sql = "update answer set isvisit=1,visittime=getdate() where answerid=@answerid";
            int res = SqlHelper.Execute(sql, new {answerid = answerid});
            return res > 0;
        }
        public static bool Later(string answerid)
        {
            string sql = "update answer set islater=1 where answerid=@answerid";
            int res = SqlHelper.Execute(sql, new { answerid = answerid });
            return res > 0;
        }
        public static PagedTable<Answer> SearchPagedTable(string query, int limit, int offset, string orderby, string orderway)
        {
            string sql = "select * from answer where answertext like @query";
            return SqlHelper.GetPagedTable<Answer>(sql, limit, offset, orderby, orderway, new { query = "%"+query+"%" });
        }
        public static PagedTable<Answer> GetPagedTable(string questionid,int limit, int offset, string orderby, string orderway)
        {
            string sql = "select * from answer where questionid=@questionid and (isvisit is null or isvisit=0)";
            return SqlHelper.GetPagedTable<Answer>(sql, limit, offset, orderby, orderway, new { questionid = questionid });
        }
        public static bool Add(string questionid,string answerid,string answercontent, string answertext, string authorid,string authorname,int voteup,string updatetime)
        {
            string sql =
                "insert into answer (questionid,answerid,answercontent,answertext,authorid,authorname,voteup,updatetime,isvisit,islater) values (@questionid,@answerid,@answercontent,@answertext,@authorid,@authorname,@voteup,@updatetime,0,0)";
            int res = SqlHelper.Execute(sql,
                new
                {
                    questionid = questionid,
                    answerid = answerid,
                    answercontent = answercontent,
                    answertext= answertext,
                    authorid = authorid,
                    authorname = authorname,
                    voteup = voteup,
                    updatetime = updatetime
                });
            return res > 0;
        }
        public static bool Update(string answerid, string answertext)
        {
            string sql =
                "update answer set answertext=@answertext where answerid=@answerid";
            int res = SqlHelper.Execute(sql,
                new
                {
                    answerid = answerid,
                    answertext = answertext,
                });
            return res > 0;
        }
        public static bool Update(string answerid, string answercontent, string answertext, int voteup, string updatetime)
        {
            string sql =
                "update answer set answercontent=@answercontent,answertext=@answertext,voteup=@voteup,updatetime=@updatetime,isvisit=0,islater=0 where answerid=@answerid";
            int res = SqlHelper.Execute(sql,
                new
                {
                    answerid = answerid,
                    answercontent = answercontent,
                    answertext = answertext,
                    voteup = voteup,
                    updatetime = updatetime
                });
            return res > 0;
        }
        public static Answer GetOne(string answerid)
        {
            string sql = "select * from answer where answerid=@answerid";
            return SqlHelper.GetOne<Answer>(sql, new {answerid = answerid});
        }
    }
}
