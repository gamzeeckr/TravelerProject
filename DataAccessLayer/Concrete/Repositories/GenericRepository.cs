using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
   public class GenericRepository<T>:IRepository<T> where T:class
    {
        Context db = new Context();
        DbSet<T> _db;

        public GenericRepository()
        {
            _db = db.Set<T>();
            
        }

        public void Delete(T item)
        {
            var deletedEntity = db.Entry(item);
            deletedEntity.State = EntityState.Deleted;
            //_db.Remove(item);
            db.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _db.SingleOrDefault(filter); //tek bir değer için filtreleme yaptım
        }

        public void Insert(T item)
        {
            var addedEntity = db.Entry(item);
            addedEntity.State = EntityState.Added;
            // _db.Add(item);
            db.SaveChanges();
        }

        public List<T> List()
        {
            return _db.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _db.Where(filter).ToList();
        }

        public void Update(T item)
        {
            var updatedEntity = db.Entry(item);
            updatedEntity.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
