using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using RepositoryEntity;
using ToiecTest.cores;
using Model;
using Core;
using PagedList;

namespace ToiecTest.Areas.Admin.Controllers
{
    public class SubQuestionController : Controller
    {
        readonly ISubQuestionRepository _SubQuestionsitory = new SubQuestionRepository();
        readonly IQuestionRepository _QuestionRepository = new QuestionRepository();
        readonly IAnswerRepository _AnswerRepository = new AnswerRepository();

        public ActionResult MainView()
        {
            return View();
        }
        public PartialViewResult AddUserPartialView()
        {
            return PartialView("AddUserPartialView", new tb_Account());
        }

        [HttpPost]
        public JsonResult AddUserInfo(tb_Account model)
        {
            bool isSuccess = true;
            if (ModelState.IsValid)
            {
                //isSuccess = Save data here return boolean
            }
            return Json(isSuccess);
        }
        // GET: Admin/Question
        public ActionResult Index(tb_SubQuestion obj,int page = 1, int pageSize = 10)
        {
            var id_question = Request["id_Question"];
            var lstSub = _SubQuestionsitory.GetAll().OrderBy(g => g.position).ToList();
            if (obj.id_Question != 0)
            {
                lstSub = lstSub.Where(g => g.id_Question == obj.id_Question).ToList();
            }
            if(!string.IsNullOrEmpty(obj.Desciption))
            {
                lstSub = lstSub.Where(g => HelperString.UnsignCharacter(g.Desciption.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.Desciption).ToLower().Trim())).ToList();
            }
            var array = lstSub.Select(g => g.id_Question);
            var lstQuestion = _QuestionRepository.GetAll().Where(g => g.Status && array.Contains(g.id)).ToList();
            //int question = Convert.ToInt32(id_question);
            //if(question>0)
            //{
            //    lstSub = lstSub.Where(g => g.id_Question == question).ToList();
            //    lstQuestion = lstQuestion.Where(g => g.id == question).OrderByDescending(g => g.CreateDate).ToList();
            //}
            TempData["Question"] = lstQuestion;
            TempData["SubQuestion"] = lstSub;
            var lst = lstSub.ToList();
            return View();
        }

        public ActionResult Detail(int id)
        {
            var lstAnswer = _AnswerRepository.GetAll().OrderBy(g=>g.Ordering).ToList();
            var objSubQuestion = _SubQuestionsitory.Find(id);
            lstAnswer = lstAnswer.Where(g => g.id_SubQuestion == id).ToList();
            TempData["lstAnswer"] = lstAnswer;
            return View();
        }
        
        public ActionResult Create()
        {
            var lstQuestion = _QuestionRepository.GetAll().Where(g => g.Status).OrderByDescending(g => g.CreateDate).ToList();
            TempData["Question"] = lstQuestion;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(tb_SubQuestion obj)
        {
            var lst = _SubQuestionsitory.GetAll().ToList();
            if (lst != null)
            {
                var check = lst.Where(g => HelperString.UnsignCharacter(g.Desciption.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.Desciption.ToLower().Trim()))).ToList();
                if (check.Count() > 0)
                {
                    ModelState.AddModelError("", "Tên câu hỏi con đã tồn tại");
                    return View();
                }
                try
                {
                    _SubQuestionsitory.Add(obj);
                    return RedirectToAction("Index", "SubQuestion");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Thêm mới không thành công");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm mới không thành công");
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var obj = _SubQuestionsitory.Find(id);
            var lstQuestion = _QuestionRepository.GetAll().Where(g => g.Status).OrderByDescending(g => g.CreateDate).ToList();
            TempData["Question"] = lstQuestion;
            return View(obj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tb_SubQuestion obj)
        {
            try
            {
                _SubQuestionsitory.Edit(obj);
                return RedirectToAction("Index", "SubQuestion");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _SubQuestionsitory.Delete(id);
                return RedirectToAction("Index", "SubQuestion");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }

    }
}