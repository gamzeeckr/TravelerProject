using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerWebProject.Models;
using PagedList;
using PagedList.Mvc;


namespace TravelerWebProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ViewModel viewModel = new ViewModel();
        Context db = new Context();
        ContactManager cm = new ContactManager(new EfContactDAL());
        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
        public ActionResult HomePage()
        {
            viewModel.Cities = db.Cities.ToList();
            viewModel.Contents = db.Contents.ToList();
            return View(viewModel);
        }
        public ActionResult GalleryPage()
        {
            viewModel.Cities = db.Cities.ToList();
            viewModel.Contents = db.Contents.ToList();
            return View(viewModel);
        }
        public ActionResult AboutMePage()
        {
            viewModel.Cities = db.Cities.ToList();
            viewModel.Contents = db.Contents.ToList();
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult ContactPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactPage(Contact contact)
        {
            ContactValidator messageValidator = new ContactValidator();
            ValidationResult results = messageValidator.Validate(contact);

            if (results.IsValid)
            {
                // gönderilen tarih bugünün tarihi
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.ContactAdd(contact);
                return RedirectToAction("HomePage");
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
        public PartialViewResult AllHeading(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p, 9);
            return PartialView(headings);
        }






    }
}