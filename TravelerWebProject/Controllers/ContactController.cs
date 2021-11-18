using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelerWebProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDAL());
        ContactValidator cv = new ContactValidator();

        //MessageManager mm = new MessageManager(new EfMessageDAL());
        
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {
            var count1 = cm.GetList().Count().ToString();
            ViewBag.c = count1;
            //var count2 = mm.GetListInbox().Count().ToString();
            //ViewBag.c2 = count2;
            return PartialView();
        }
       
    }
}