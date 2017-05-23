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
    public class LevelController : Controller
    {
        readonly ILevelRepository _levelRepository = new LevelRepository();
        // GET: Admin/Level
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var lstLevel = _levelRepository.GetAll().OrderByDescending(g=>g.Ordering).ToPagedList(page,pageSize);
            //TempData["Level"] = lstLevel;
            return View(lstLevel);
        }
        public ActionResult Search(string levelName, int page = 1, int pageSize = 10)
        {
            var lstAccount = _levelRepository.GetAll().ToList();
            if (!string.IsNullOrEmpty(levelName))
            {
                lstAccount = lstAccount.Where(g => HelperString.UnsignCharacter(g.levelName.Trim().ToLower()).Contains(HelperString.UnsignCharacter(levelName).ToLower().Trim())).ToList();
            }
            var lst = lstAccount.OrderBy(g => g.Ordering).ToPagedList(page, pageSize);
            return View("Index", lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tb_Level obj)
        {
            var lst = _levelRepository.GetAll().ToList();
            if (lst != null)
            {
                var check = lst.Where(g => HelperString.UnsignCharacter(g.levelName.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.levelName.ToLower().Trim()))).ToList();
                if (check.Count() > 0)
                {
                    ModelState.AddModelError("", "Tên level đã tồn tại");
                    return View();
                }
                try
                {
                    _levelRepository.Add(obj);
                    return RedirectToAction("Index", "Level");
                }
                catch (Exception)
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var obj = _levelRepository.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(tb_Level obj)
        {
            try
            {
                _levelRepository.Edit(obj);
                return RedirectToAction("Index", "Level");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Cập nhật không thành công");
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _levelRepository.Delete(id);
                return RedirectToAction("Index", "Level");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }

    }
}