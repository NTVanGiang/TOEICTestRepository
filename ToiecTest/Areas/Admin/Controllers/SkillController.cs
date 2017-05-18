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

namespace ToiecTest.Areas.Admin.Controllers
{
    public class SkillController : Controller
    {
        readonly ISkillRepository _skillRepository = new SkillRepository();
        // GET: Admin/Skill
        public ActionResult Index()
        {
            var lstSkill = _skillRepository.GetAll().OrderBy(g=>g.Ordering).ToList();
            TempData["Skill"] = lstSkill;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tb_Skill obj)
        {
            var lst = _skillRepository.GetAll().ToList();
            if (lst != null)
            {
                var check = lst.Where(g => HelperString.UnsignCharacter(g.skillName.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.skillName.ToLower().Trim()))).ToList();
                if (check.Count() > 0)
                {
                    ModelState.AddModelError("", "Tên kỹ năng đã tồn tại");
                    return View();
                }
                try
                {
                    _skillRepository.Add(obj);
                    return RedirectToAction("Index", "Skill");
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
            var obj = _skillRepository.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(tb_Skill obj)
        {
            try
            {
                _skillRepository.Edit(obj);
                return RedirectToAction("Index", "Skill");
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
                _skillRepository.Delete(id);
                return RedirectToAction("Index", "Skill");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdatePosition(string value)
        {
            var arrValue = value.Split('|');
            foreach (var item in arrValue)
            {
                var id = item.Split(':')[0];
                var pos = item.Split(':')[1];
                var obj = _skillRepository.Find(Convert.ToInt32(id));
                obj.Ordering = Convert.ToInt32(pos);
                try
                {
                    _skillRepository.Edit(obj);

                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                    return View();
                }
            }
            return RedirectToAction("Index", "Skill");
        }

    }
}