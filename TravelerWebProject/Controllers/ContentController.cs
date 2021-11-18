using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerWebProject.Models;

namespace TravelerWebProject.Controllers
{
    [AllowAnonymous]
    public class ContentController : Controller
    {
        ViewModel viewModel = new ViewModel();
        Context db = new Context();
        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
        // GET: Content
        public ActionResult Index()
        {
            viewModel.Cities = db.Cities.ToList();
            viewModel.Contents = db.Contents.ToList();
            return View(viewModel);
        }
        public ActionResult ContentPage(int id = 0)
        {
            var content = hm.GetByID(id);
            return View(content);
        }
    }
}