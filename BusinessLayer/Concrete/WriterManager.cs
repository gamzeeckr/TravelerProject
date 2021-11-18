using BusinessLayer.Abstarct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class WriterManager: IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            this._writerDAL = writerDAL;
        }

        public Writer GetById(int id)
        {
            return _writerDAL.Get(x => x.WriterId == id);
        }

        public List<Writer> GetListByStatus(bool status)
        {
            return _writerDAL.List(x => x.WriterStatus == status);
        }

        public List<Writer> GetList()
        {
            return _writerDAL.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerDAL.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDAL.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDAL.Update(writer);
        }
    }
}
