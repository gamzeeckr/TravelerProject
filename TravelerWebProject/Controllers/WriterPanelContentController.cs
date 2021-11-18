using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelerWebProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDAL());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string mail)
        {
            //mimariye taşınacak...
            mail = (string)Session["WriterMail"]; //session ile kişinin mail adresini yakalatıyoruz
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault(); //girilen mail database deki maile eşitse mail adresine sahip yazarın id sini select ile yakalıyor
            var contentValues = cm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
      
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            //mimariye taşınacak...
            string mail = (string)Session["WriterMail"]; //session ile kişinin mail adresini yakalatıyoruz
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerIdInfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    }
}