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
    public class QuestionController : Controller
    {
        readonly IQuestionRepository _QuestionRepository = new QuestionRepository();
        readonly IPartRepository _partRepository = new PartRepository();
        readonly ILevelRepository _levelRepository = new LevelRepository();
        readonly ITopicRepository _topicRepository = new TopicRepository();
        // GET: Admin/Question
        public ActionResult Index(tb_Question obj, int page = 1, int pageSize = 10)
        {
            var lstQuestion = _QuestionRepository.GetAll().OrderByDescending(g => g.CreateDate).ToList();
            var lstPart = _partRepository.GetAll().Where(g => g.Status).OrderBy(g=>g.Ordering).ToList();
            TempData["Part"] = lstPart;
            var lstLevel = _levelRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Level"] = lstLevel;
            var lstTopic = _topicRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Topic"] = lstTopic;
            if (!string.IsNullOrEmpty(obj.Title))
            {
                lstQuestion = lstQuestion.Where(g => HelperString.UnsignCharacter(g.Title.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.Title).ToLower().Trim())).ToList();
            }
            if (obj.id_Part != null)
            {
                lstQuestion = lstQuestion.Where(g => g.id_Part == obj.id_Part).ToList();
            }
            if (obj.id_Level != null)
            {
                lstQuestion = lstQuestion.Where(g => g.id_Level == obj.id_Level).ToList();
            }
            if (obj.id_Topic != null)
            {
                lstQuestion = lstQuestion.Where(g => g.id_Topic == obj.id_Topic).ToList();
            }
            foreach (var item in lstQuestion)
            {
                var itemPart = lstPart.FirstOrDefault(g => g.id == item.id_Part);
                if (itemPart != null)
                {
                    item.TenPart = itemPart.partNumber;
                }
                var itemLevel = lstLevel.FirstOrDefault(g => g.id == item.id_Level);
                if (itemLevel != null)
                {
                    item.TenLevel = itemLevel.levelName;
                }
                var itemTopic = lstTopic.FirstOrDefault(g => g.id == item.id_Topic);
                if (itemTopic != null)
                {
                    item.TenTopic = itemTopic.topicName;
                }
            }

            var lst = lstQuestion.ToPagedList(page, pageSize);
            return View(lst);
        }
        //public ActionResult Search(tb_Question obj, int page = 1, int pageSize = 10)
        //{
        //    var lstQuestion = _QuestionRepository.GetAll().ToList();
        //    var lstPart = _partRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
        //    TempData["Part"] = lstPart;
        //    var lstLevel = _levelRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
        //    TempData["Level"] = lstLevel;
        //    var lstTopic = _topicRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
        //    TempData["Topic"] = lstTopic;
        //    if (!string.IsNullOrEmpty(obj.contentQuestion))
        //    {
        //        lstQuestion = lstQuestion.Where(g => HelperString.UnsignCharacter(g.contentQuestion.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.contentQuestion).ToLower().Trim())).ToList();
        //    }
        //    if(obj.id_Part!=0)
        //    {
        //        lstQuestion = lstQuestion.Where(g => g.id_Part == obj.id_Part).ToList();
        //    }
        //    if (obj.id_Level != 0)
        //    {
        //        lstQuestion = lstQuestion.Where(g => g.id_Level == obj.id_Level).ToList();
        //    }
        //    if (obj.id_Topic != 0)
        //    {
        //        lstQuestion = lstQuestion.Where(g => g.id_Topic == obj.id_Topic).ToList();
        //    }
        //    foreach (var item in lstQuestion)
        //    {
        //        var itemPart = lstPart.FirstOrDefault(g => g.id == item.id_Part);
        //        if (itemPart != null)
        //        {
        //            item.TenPart = itemPart.partNumber;
        //        }
        //        var itemLevel = lstLevel.FirstOrDefault(g => g.id == item.id_Level);
        //        if (itemLevel != null)
        //        {
        //            item.TenLevel = itemLevel.levelName;
        //        }
        //        var itemTopic = lstTopic.FirstOrDefault(g => g.id == item.id_Topic);
        //        if (itemTopic != null)
        //        {
        //            item.TenTopic = itemTopic.topicName;
        //        }
        //    }
        //    var lst = lstQuestion.OrderByDescending(g => g.CreateDate).ToPagedList(page, pageSize);
        //    return View("Index", lst);
        //}
        public ActionResult Create()
        {
            var lstPart = _partRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Part"] = lstPart;
            var lstLevel = _levelRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Level"] = lstLevel;
            var lstTopic = _topicRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Topic"] = lstTopic;
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(tb_Question obj)
        {
            var lst = _QuestionRepository.GetAll().ToList();
            if (lst != null)
            {
                //var check = lst.Where(g => HelperString.UnsignCharacter(g.contentQuestion.Trim().ToLower()).Contains(HelperString.UnsignCharacter(obj.contentQuestion.ToLower().Trim()))).ToList();
                //if (check.Count() > 0)
                //{
                //    ModelState.AddModelError("", "Tên Question đã tồn tại");
                //    return View();
                //}
                obj.CreateDate = DateTime.Now;
                try
                {
                    _QuestionRepository.Add(obj);
                    return RedirectToAction("Index", "Question");
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
            var obj = _QuestionRepository.Find(id);
            var lstPart = _partRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Part"] = lstPart;
            var lstLevel = _levelRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Level"] = lstLevel;
            var lstTopic = _topicRepository.GetAll().Where(g => g.Status).OrderBy(g => g.Ordering).ToList();
            TempData["Topic"] = lstTopic;
            return View(obj);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tb_Question obj)
        {
            try
            {
                obj.CreateDate = DateTime.Now;
                _QuestionRepository.Edit(obj);
                return RedirectToAction("Index", "Question");
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
                _QuestionRepository.Delete(id);
                return RedirectToAction("Index", "Question");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }

    }
}