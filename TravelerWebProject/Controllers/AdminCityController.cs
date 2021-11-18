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
    public class AdminCityController : Controller
    {
        CityManager cm = new CityManager(new EfCityDAL());
        // GET: AdminCity
        public ActionResult Index()
        {
            var cityValues = cm.GetList();
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
            CityValidator validationRules = new CityValidator();
            ValidationResult result = validationRules.Validate(city);
            if (result.IsValid)
            {
                cm.CityAdd(city);
                return RedirectToAction("Index");
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
        public ActionResult DeleteCity(int id)
        {
            var cityValue = cm.GetByID(id);
            cm.CityDelete(cityValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCity(int id)
        {
            var cityValue = cm.GetByID(id);
            //cm.CategoryUpdate(categoryValue);
            return View(cityValue);
        }

        [HttpPost]
        public ActionResult UpdateCity(City city)
        {
            cm.CityUpdate(city);
            return RedirectToAction("Index");
        }
        
        

    }
}