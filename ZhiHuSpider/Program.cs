using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Common;
using DAL;
using HtmlAgilityPack;
using Model;
using LeanCloud;

namespace ZhiHuSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            //string html=HttpHelper.DownLoadString("https://www.zhihu.com/question/264010103/answer/278256948");
            //var htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(html);
            //var htmlbody = htmlDoc.DocumentNode.SelectSingleNode("//body");
            //Console.Write(htmlbody.OuterHtml);
            Console.WriteLine("请输入问题id：");
            string id = Console.ReadLine();
            Console.WriteLine("开始爬取");
            GetAnswer(id, 0);
            //ExportTxt("50364416");
            Console.ReadKey();
        }

        static void TestRegex()
        {
            Regex r = new Regex("<img[^>]*>");
            r.Matches(@"");
        }
        static void ExportTxt(string answerid)
        {
            StringBuilder sb = new StringBuilder();
            PagedTable<Answer> pt = AnswerDAL.GetPagedTable(answerid, 10000, 0, "id", "asc");
            foreach (var answer in pt.rows)
            {
                sb.Append(answer.answertext);
            }
            File.WriteAllText("F:\\cloud.txt", sb.ToString());
            Console.WriteLine("导出完毕");
        }
        static void UpdateAnswer(string answerid)
        {
            PagedTable<Answer> pt = AnswerDAL.GetPagedTable(answerid, 10000, 0, "id", "asc");
            foreach (var answer in pt.rows)
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(answer.answercontent);
                string text = htmlDoc.DocumentNode.InnerText;
                AnswerDAL.Update(answer.answerid, text);
            }
            Console.WriteLine("更新完毕");
        }
        static void GetAnswer(string questionid, int offset)
        {

            string url =
                "https://www.zhihu.com/api/v4/questions/" + questionid + "/answers?sort_by=default&include=data%5B%2A%5D.is_normal%2Cadmin_closed_comment%2Creward_info%2Cis_collapsed%2Cannotation_action%2Cannotation_detail%2Ccollapse_reason%2Cis_sticky%2Ccollapsed_by%2Csuggest_edit%2Ccomment_count%2Ccan_comment%2Ccontent%2Ceditable_content%2Cvoteup_count%2Creshipment_settings%2Ccomment_permission%2Ccreated_time%2Cupdated_time%2Creview_info%2Cquestion%2Cexcerpt%2Crelationship.is_authorized%2Cis_author%2Cvoting%2Cis_thanked%2Cis_nothelp%2Cupvoted_followees%3Bdata%5B%2A%5D.mark_infos%5B%2A%5D.url%3Bdata%5B%2A%5D.author.follower_count%2Cbadge%5B%3F%28type%3Dbest_answerer%29%5D.topics&limit=20&offset=" + offset;
            string html = HttpHelper.DownLoadString(url);
            PageInfo pageInfo = JsonHelper.DeserializeJsonToObject<PageInfo>(HttpUtility.HtmlDecode(html));
            if (pageInfo != null && pageInfo.data != null)
            {
                if (offset == 0)//是否第一页
                {
                    if (!QuestionDAL.IsExsit(questionid))
                    {
                        Question question = pageInfo.data[0].question;
                        QuestionDAL.Add(question.title, questionid, pageInfo.paging.totals, question.url,
                            question.created);
                    }
                }
                foreach (var dataItem in pageInfo.data)
                {
                    var oldanswer = AnswerDAL.GetOne(dataItem.id);
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(dataItem.content);
                    string text = htmlDoc.DocumentNode.InnerText;
                    if (oldanswer == null)
                    {
                        AnswerDAL.Add(questionid, dataItem.id, dataItem.content, text, dataItem.author.id,
                            dataItem.author.name, dataItem.voteup_count, dataItem.updated_time);
                    }
                    else if (oldanswer.updatetime != dataItem.updated_time)
                    {
                        AnswerDAL.Update(dataItem.id, dataItem.content, text, dataItem.voteup_count, dataItem.updated_time);
                    }
                }
            }
            Console.WriteLine("爬取问题" + questionid + "," + offset + "-" + (offset + 20) + "条");
            if (pageInfo != null && pageInfo.paging.totals > offset + 20)
            {
                Thread.Sleep(10000);
                GetAnswer(questionid, offset + 20);
            }
            else
            {
                Console.WriteLine("爬取完毕！");
            }
        }
    }

}
