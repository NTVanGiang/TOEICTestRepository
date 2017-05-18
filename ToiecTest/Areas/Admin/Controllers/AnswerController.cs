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
    public class AnswerController : Controller
    {
        readonly IAnswerRepository _answerRepository = new AnswerRepository();
        readonly ISubQuestionRepository _SubQuestionsitory = new SubQuestionRepository();
        readonly IQuestionRepository _QuestionRepository = new QuestionRepository();
        
        // GET: Admin/Question
        public ActionResult Index(tb_Answer obj,int page = 1, int pageSize = 10)
        {
            var lstAnswer = _answerRepository.GetAll().OrderBy(g => g.Ordering).ToList();
            if (obj.id_SubQuestion != 0)
            {
                lstAnswer = lstAnswer.Where(g => g.id_SubQuestion == obj.id_SubQuestion).ToList();
            }
            if(!string.IsNullOrEmpty(obj.answerContent))
            {
                lstAnswer = lstAnswer.Where(g => HelperString.UnsignCharacter(g.answerContent.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.answerContent).ToLower().Trim())).ToList();
            }
            var array = lstAnswer.Select(g => g.id_SubQuestion);
            var lstSubQuestion = _SubQuestionsitory.GetAll().Where(g => g.Status && array.Contains(g.id)).ToList();
            TempData["lstSubQuestion"] = lstSubQuestion;
            TempData["lstAnswer"] = lstAnswer;
            var lst = lstAnswer.ToList();
            return View();
        }
        
        public ActionResult Create()
        {
            var lstSubQuestion = _SubQuestionsitory.GetAll().Where(g => g.Status).ToList();
            TempData["lstSubQuestion"] = lstSubQuestion;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(tb_Answer obj)
        {
            var lst = _answerRepository.GetAll().ToList();
            if (lst != null)
            {
                var check = lst.Where(g => HelperString.UnsignCharacter(g.answerContent.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.answerContent.ToLower().Trim()))).ToList();
                if (check.Count() > 0)
                {
                    ModelState.AddModelError("", "Câu trả lời đã tồn tại");
                    return View();
                }
                try
                {
                    _answerRepository.Add(obj);
                    return RedirectToAction("Index", "Answer");
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
            var obj = _answerRepository.Find(id);
            var lstSubQuestion = _SubQuestionsitory.GetAll().Where(g => g.Status).ToList();
            TempData["lstSubQuestion"] = lstSubQuestion;
            return View(obj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tb_Answer obj)
        {
            try
            {
                _answerRepository.Edit(obj);
                return RedirectToAction("Index", "Answer");
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
                _answerRepository.Delete(id);
                return RedirectToAction("Index", "Answer");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }

    }
}