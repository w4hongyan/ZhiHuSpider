using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DAL;
using HtmlAgilityPack;
using Model;


namespace ZhiHu.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PagedTable<Question> pt = QuestionDAL.GetPagedTable(100, 0, "id", "asc");
            return View(pt);
        }

        public ActionResult Question(string id)
        {
            Question question = QuestionDAL.GetOne(id);
            ViewBag.title = question.title;
            PagedTable<Answer> pt = AnswerDAL.GetPagedTable(id, 100, 0, "islater", "asc");
            //foreach (var answer in pt.rows)
            //{
            //    answer.answercontent = answer.answercontent.Replace("></svg>", string.Empty);
            //    answer.answertext=Regex.Replace(answer.answercontent, "<img[^>]*>", string.Empty);
            //}
            return View(pt);
        }
        public ActionResult Search(string id)
        {
            ViewBag.title = id;
            PagedTable<Answer> pt = AnswerDAL.SearchPagedTable(id, 100, 0, "id", "asc");
            return View("Question",pt);
        }

        public JsonResult Visited(string id)
        {
            bool res = AnswerDAL.Visited(id);
            JsonResultViewModel jr =new JsonResultViewModel();
            if (!res)
            {
                jr.status = JsonStatus.Error;
            }
            return Json(jr);
        }
        public JsonResult Later(string id)
        {
            bool res = AnswerDAL.Later(id);
            JsonResultViewModel jr = new JsonResultViewModel();
            if (!res)
            {
                jr.status = JsonStatus.Error;
            }
            return Json(jr);
        }
    }
}