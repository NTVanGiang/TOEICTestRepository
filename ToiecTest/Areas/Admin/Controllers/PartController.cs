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
    public class PartController : Controller
    {
        readonly IPartRepository _partRepository = new PartRepository();
        readonly ISkillRepository _skillRepository = new SkillRepository();
        // GET: Admin/Part
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var lstPart = _partRepository.GetAll().OrderBy(g => g.Ordering).ToList();
            var lstSkill = _skillRepository.GetAll().Where(g=>g.Status).ToList();
            TempData["Skill"] = lstSkill;
            foreach (var item in lstPart)
            {
                var itemSkill = lstSkill.FirstOrDefault(g => g.id == item.id_Skill);
                {
                    item.TenSkill = itemSkill.skillName;
                }
            }
            var lst = lstPart.ToPagedList(page, pageSize);
            return View(lst);
        }
        public ActionResult Search(string partNumber, int id_Skill, int page = 1, int pageSize = 10)
        {
            var lstSkill = _skillRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Skill"] = lstSkill;
            var lstPart = _partRepository.GetAll().OrderBy(g => g.Ordering).ToList();
            if (!string.IsNullOrEmpty(partNumber))
            {
                lstPart = lstPart.Where(g => HelperString.UnsignCharacter(g.partNumber.Trim().ToLower()).Contains(HelperString.UnsignCharacter(partNumber).ToLower().Trim())).ToList();
            }
            if (id_Skill!=0)
            {
                lstPart = lstPart.Where(g => g.id_Skill == id_Skill).ToList();
            }
            foreach (var item in lstPart)
            {
                var itemSkill = lstSkill.FirstOrDefault(g => g.id == item.id_Skill && g.Status);
                if (itemSkill != null)
                {
                    item.TenSkill = itemSkill.skillName;
                }
            }
            var lst = lstPart.ToPagedList(page, pageSize);
            return View("Index",lst);
        }
        public ActionResult Create()
        {
            var lstSkill = _skillRepository.GetAll().ToList();
            TempData["Skill"] = lstSkill;
            return View();
        }
        [HttpPost]
        public ActionResult Create(tb_Part obj)
        {
            var lst = _partRepository.GetAll().ToList();
            if (lst != null)
            {
                var check = lst.Where(g => HelperString.UnsignCharacter(g.partNumber.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.partNumber.ToLower().Trim()))).ToList();
                if (check.Count() > 0)
                {
                    ModelState.AddModelError("", "Tên part đã tồn tại");
                    var lstSkill = _skillRepository.GetAll().ToList();
                    TempData["Skill"] = lstSkill;
                    return View();
                }
                try
                {
                    _partRepository.Add(obj);
                    return RedirectToAction("Index", "Part");
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
            var obj = _partRepository.Find(id);
            var lstSkill = _skillRepository.GetAll().ToList();
            TempData["Skill"] = lstSkill;
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(tb_Part obj)
        {
            try
            {
                _partRepository.Edit(obj);
                return RedirectToAction("Index", "Part");
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
                _partRepository.Delete(id);
                return RedirectToAction("Index", "Part");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }

    }
}