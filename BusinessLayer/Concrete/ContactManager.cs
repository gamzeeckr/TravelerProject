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
   public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDAL.Insert(contact);
        }

        //public Contact ContactCount(Contact contact)
        //{
        //    return 
        //}

        public void ContactDelete(Contact contact)
        {
            _contactDAL.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDAL.Update(contact);
        }

        public Contact GetByID(int id)
        {
            return _contactDAL.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactDAL.List();
        }
    }
}
