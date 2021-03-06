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
   public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public Message GetByID(int id)
        {
            return _messageDAL.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string mail)
        {
            return _messageDAL.List(x => x.ReceiverMail == mail);
        }

        public List<Message> GetListSendbox(string mail)
        {
            return _messageDAL.List(x => x.SenderMail == mail);
        }

        public void MessageAdd(Message message)
        {
            _messageDAL.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDAL.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDAL.Update(message);
        }
    }
}
