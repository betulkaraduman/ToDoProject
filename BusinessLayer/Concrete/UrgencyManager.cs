using BusinessLayer.Interfaces;
using DataAccessLayer.Concrete.EFCore.Repositories;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private IUrgencyDal _urgencyDal;
        public UrgencyManager(IUrgencyDal urgencyDal)
        {
            _urgencyDal = urgencyDal;
        }
        public List<Urgency> AllEntitys()
        {
            return _urgencyDal.AllEntitys();
        }

        public void Delete(Urgency entity)
        {
            _urgencyDal.Delete(entity);
        }

        public Urgency GetEntityById(int Id)
        {
            return _urgencyDal.GetEntityById(Id);
        }

        public void Save(Urgency entity)
        {
            _urgencyDal.Save(entity);
        }

        public void Update(Urgency entity)
        {
            _urgencyDal.Update(entity);
        }
    }
}
