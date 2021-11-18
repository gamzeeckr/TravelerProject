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
    
    public class CityController : Controller
    {
        
        CityManager cm = new CityManager(new EfCityDAL());
        // GET: City
        public ActionResult GetCityList()
        {
           var cityValues= cm.GetList();
            return View(cityValues);
        }
        [HttpGet]
        public ActionResult AddCity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCity(City city)
        {
            // doğrulama kontrollerine göre veri ekleme

            CityValidator cityValidator = new CityValidator();
            ValidationResult result = cityValidator.Validate(city);
            // categoryValidatordan gelen kurallara göre category den gelenlerin doğruluk kontrolünü gerçekleştir.

            if (result.IsValid) //sonuç geçerli ise
            {
                cm.CityAdd(city);
                return RedirectToAction("GetCityList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}