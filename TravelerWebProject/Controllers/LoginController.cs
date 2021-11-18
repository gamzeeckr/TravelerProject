using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TravelerWebProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AdminLoginManager alm = new AdminLoginManager(new EfAdminDAL());
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDAL());
        WriterManager wm = new WriterManager(new EfWriterDAL());
        WriterValidator writerValidator = new WriterValidator();
        // GET: Login
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var adminUserInfo = alm.GetAdmin(admin.AdminUserName, admin.AdminPassword);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCity");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //Context c = new Context();
            //var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            // mimariye taşıdık
            var writerUserInfo = wlm.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("WriterProfile", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
        [HttpGet]
        public ActionResult WriterSignUp()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult WriterSignUp(Writer writer)
        {
            //validasyon işlemleri
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                //yazar resim ekleme
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string extension = Path.GetExtension(Request.Files[0].FileName);
                    string path = "~/Image/" + fileName + extension;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    writer.WriterImage = "/Image/" + fileName + extension;
                }
                wm.WriterAdd(writer);
                return RedirectToAction("WriterLogin");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        
    }
}