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
    public class TopicController : Controller
    {
        readonly ITopicRepository _topicRepository = new TopicRepository();
        // GET: Admin/Topic
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var lstTopic = _topicRepository.GetAll().OrderBy(g=>g.Ordering).ToPagedList(page, pageSize);
            //TempData["Topic"] = lstTopic;
            return View(lstTopic);
        }
        public ActionResult Search(string topicName, int page = 1, int pageSize = 10)
        {
            var lstAccount = _topicRepository.GetAll().ToList();
            if (!string.IsNullOrEmpty(topicName))
            {
                lstAccount = lstAccount.Where(g => HelperString.UnsignCharacter(g.topicName.Trim().ToLower()).Contains(HelperString.UnsignCharacter(topicName).ToLower().Trim())).ToList();
            }
            var lst = lstAccount.OrderBy(g => g.Ordering).ToPagedList(page, pageSize);
            return View("Index", lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tb_Topic obj)
        {
            var lst = _topicRepository.GetAll().ToList();
            if (lst != null)
            {
                var check = lst.Where(g => HelperString.UnsignCharacter(g.topicName.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.topicName.ToLower().Trim()))).ToList();
                if (check.Count() > 0)
                {
                    ModelState.AddModelError("", "Tên chủ đề đã tồn tại");
                    return View();
                }
                try
                {
                    _topicRepository.Add(obj);
                    return RedirectToAction("Index", "Topic");
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
            var obj = _topicRepository.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(tb_Topic obj)
        {
            try
            {
                _topicRepository.Edit(obj);
                return RedirectToAction("Index", "Topic");
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
                _topicRepository.Delete(id);
                return RedirectToAction("Index", "Topic");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }

    }
}