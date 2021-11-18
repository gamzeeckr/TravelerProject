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
    public class DomesticController : Controller
    {
        ViewModel viewModel = new ViewModel();
        Context db = new Context();
        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
       
       
        // GET: Domestic
        public ActionResult Index(int id = 0)
        {
            var list = hm.GetListByCityID(id);
            //var cityList = cm.GetList();
           
            return View(list);
            
        }
        
        public PartialViewResult Menu()
        {
            viewModel.Cities = db.Cities.ToList();
            viewModel.Contents = db.Contents.ToList();
            return PartialView(viewModel);
        }
       
    }
}