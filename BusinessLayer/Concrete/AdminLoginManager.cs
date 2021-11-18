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
   public class AdminLoginManager:IAdminLoginService
    {
        IAdminDAL _adminDAL;

        public AdminLoginManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public Admin GetAdmin(string userName, string password)
        {
            return _adminDAL.Get(x => x.AdminUserName == userName && x.AdminPassword == password);
        }
    }
}
