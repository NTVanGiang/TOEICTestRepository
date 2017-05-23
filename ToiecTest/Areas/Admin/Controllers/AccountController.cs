using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryEntity;
using Model;
using Core;
using System.Web.Security;
using PagedList;
using ToiecTest.cores;
using ToiecTest.BaseSecurity;
using System.Web.Script.Serialization;
using System.Security.Claims;

namespace ToiecTest.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountRepository _accountRepository = new AccountRepository();

        // GET: Admin/Account
        [CheckLogin]
        public ActionResult Index(tb_Account obj, string CreateDate, int page = 1, int pageSize = 10)
        {
            //phân trang
            var lstAccount = _accountRepository.GetAll().ToList();
            TempData["Account"] = lstAccount;
            var lstCategory1 = lstAccount.OrderByDescending(g => g.CreateDate).ToPagedList(page, pageSize);
            //ViewBag.Category = lstCategory;
            return View(lstCategory1);
        }
        public ActionResult Search(string fullName,string username,string birthDay,int page = 1, int pageSize = 10)
        {
            var lstAccount = _accountRepository.GetAll().ToList();
            if(!string.IsNullOrEmpty(fullName))
            {
                lstAccount = lstAccount.Where(g => HelperString.UnsignCharacter(g.fullName.Trim().ToLower()).Contains(HelperString.UnsignCharacter(fullName).ToLower().Trim())).ToList();
            }
            if(!string.IsNullOrEmpty(username))
            {
                lstAccount = lstAccount.Where(g => HelperString.UnsignCharacter(g.username.Trim().ToLower()).Contains(HelperString.UnsignCharacter(username.ToLower().Trim()))).ToList();
            }
            var Ngaysinh = HelperDateTime.ConvertDate(birthDay);
            if(!string.IsNullOrEmpty(birthDay))
            {
                lstAccount = lstAccount.Where(g => Convert.ToDateTime(g.birthDay).ToString("dd/MM/yyyy") == Convert.ToDateTime(Ngaysinh).ToString("dd/MM/yyyy")).ToList();
            }
            var lst = lstAccount.OrderByDescending(g => g.CreateDate).ToPagedList(page, pageSize);
            return View("Index",lst);
        }
        [CheckLogin]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] /*Validate token vừa post lên*/
        public ActionResult Create(tb_Account obj,string birthDay)
        {
            var lst = _accountRepository.GetAll().ToList();
            if(lst!=null)
            {
                var check = lst.Where(g => HelperString.UnsignCharacter(g.username.Trim().ToLower())== HelperString.UnsignCharacter(obj.username.ToLower().Trim())).ToList();
                if (check.Count() > 0)
                {
                    ModelState.AddModelError("", "UserName đã tồn tại");
                    return View();
                    //return Json(new
                    //{
                    //    IsSuccess = false,
                    //    Messenger = string.Format("UserName đã tồn tại")
                    //}, JsonRequestBehavior.AllowGet);
                }
                //obj.birthDay = HelperDateTime.ConvertDate(birthDay);
                if (!string.IsNullOrEmpty(Request["birthDay"]))
                {
                    obj.birthDay = HelperDateTime.ConvertDate(Request["birthDay"]);
                }
                obj.CreateDate = DateTime.Now;
                try
                {
                    //if (ModelState.IsValid)  //kiểm tra form rỗng
                    //{
                        obj.password = Encryptor.MD5Hash(obj.password);
                        _accountRepository.Add(obj);
                        return RedirectToAction("Index", "Account");
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError("", "Thêm mới không thành công");
                    //    return View(obj);
                    //}
                }
                catch
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
            var obj = _accountRepository.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(tb_Account obj)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["birthDay"]))
                {
                    obj.birthDay = HelperDateTime.ConvertDate(Request["birthDay"]);
                }
                obj.CreateDate = DateTime.Now;
                _accountRepository.Edit(obj);
                return RedirectToAction("Index", "Account");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Chỉnh sửa không thành công");
                return View();
                //return Json(new
                //{
                //    IsSuccess = false,
                //    Messenger = string.Format("Chỉnh sửa thất bại")
                //}, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _accountRepository.Delete(id);
                return RedirectToAction("Index", "Account");
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Xóa không thành công");
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tb_Account obj)
        {
            if (string.IsNullOrEmpty(obj.username) || string.IsNullOrEmpty(obj.password))
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không được để trống");
                return View(obj);
            }
            var account = _accountRepository.GetAll().FirstOrDefault(u => u.password == Encryptor.MD5Hash(obj.password) && u.username.ToLower() == obj.username.ToLower());
            if (account != null)
            {

                Session["Account"] = obj;
                //phương thức có sẵn của DOT.Net
                Session["check"] = true;
                FormsAuthentication.SetAuthCookie(obj.username, obj.RememberMe);
                return RedirectToAction("Index", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                return View();
            }


            //sử dụng StoredProcedure
            //var result = _accountReponsitory.Login(obj.UserName, obj.PassWord);
            //if(result && ModelState.IsValid)
            //{
            //    FormsAuthentication.SetAuthCookie(obj.UserName, obj.RememberMe);
            //    return RedirectToAction("Index", "Account");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            //}
            //return View();
        }

        public ActionResult ChangePass(int id)
        {
            var objAccount = _accountRepository.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult ChangePass(int id, string oldpassword, string password,string confirmpassword)
        {
            var objAccount = _accountRepository.Find(id);
            if(objAccount.password!=Encryptor.MD5Hash(oldpassword))
            {
                ModelState.AddModelError("", "Mật khẩu cũ nhập vào không đúng");
                return View();
            }
            if(password==confirmpassword)
            {
                try
                {
                    objAccount.password = Encryptor.MD5Hash(password);
                    _accountRepository.Edit(objAccount);
                    return RedirectToAction("Index","Account");
                }
                catch(Exception)
                {
                    ModelState.AddModelError("", "Reset mật khẩu thất bại");
                    return View();
                }
            }
            ModelState.AddModelError("", "Reset mật khẩu thất bại");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("Account");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}