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
using ToiecTest.BaseSecurity;

namespace ToiecTest.Areas.Admin.Controllers
{
    public class QuizController : Controller
    {
        readonly IQuizRepository _quizRepository = new QuizRepository();
        readonly IAccountRepository _accountRepository = new AccountRepository();

        // GET: Admin/Question
        public ActionResult Index(tb_Quiz obj, int page = 1, int pageSize = 10)
        {
            var lstQuiz = _quizRepository.GetAll().Where(g => g.isAdminCreate).ToList();
            var lstAccount = _accountRepository.GetAll().Where(g => g.Status && g.idQuyen==1).OrderByDescending(g => g.CreateDate).ToList();
            TempData["lstAccount"] = lstAccount;
            if (!string.IsNullOrEmpty(obj.Name))
            {
                lstQuiz = lstQuiz.Where(g => HelperString.UnsignCharacter(g.Name.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.Name).ToLower().Trim())).ToList();
            }
            if (obj.id_Account != null)
            {
                lstQuiz = lstQuiz.Where(g => g.id_Account == obj.id_Account).ToList();
            }
            foreach (var item in lstQuiz)
            {
                var itemAccount = lstAccount.FirstOrDefault(g => g.id == item.id_Account);
                if (itemAccount != null)
                {
                    item.AccountName = itemAccount.fullName;
                }
            }

            var lst = lstQuiz.ToPagedList(page, pageSize);
            return View(lst);
        }
        public ActionResult Create()
        {
            var lstAccount = _accountRepository.GetAll().Where(g => g.Status && g.idQuyen == 1).OrderByDescending(g => g.CreateDate).ToList();
            TempData["lstAccount"] = lstAccount;
            return View();
        }
        [HttpPost]
        public ActionResult Create(tb_Quiz obj)
        {
            var lst = _quizRepository.GetAll().ToList();
            if (lst != null)
            {
                obj.CreatedDate = DateTime.Now;
                obj.isAdminCreate = true;
                try
                {
                    _quizRepository.Add(obj);
                    return RedirectToAction("Index", "Quiz");
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
            var obj = _quizRepository.Find(id);
            var lstAccount = _accountRepository.GetAll().Where(g => g.Status && g.idQuyen == 1).OrderByDescending(g => g.CreateDate).ToList();
            TempData["lstAccount"] = lstAccount;
            return View(obj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tb_Quiz obj)
        {
            try
            {
                obj.CreatedDate = DateTime.Now;
                obj.isAdminCreate = true;
                _quizRepository.Edit(obj);
                return RedirectToAction("Index", "Quiz");
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
                _quizRepository.Delete(id);
                return RedirectToAction("Index", "Quiz");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }

    }
}