using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class CityManager:ICityService
    {
        ICityDAL _cityDAL;

        public CityManager(ICityDAL cityDAL)
        {
            _cityDAL = cityDAL;
        }

        public void CityAdd(City city)
        {
            _cityDAL.Insert(city);
        }

        public void CityDelete(City city)
        {
            _cityDAL.Delete(city);
        }

        public void CityUpdate(City city)
        {
            _cityDAL.Update(city);
        }

        public City GetByID(int id)
        {
            return _cityDAL.Get(x => x.CityId == id);
        }

        public List<City> GetList()
        {
            return _cityDAL.List();
        }

       
    } 
}
