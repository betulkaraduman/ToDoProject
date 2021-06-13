using DataAccessLayer.Concrete.EFCore.Contexts;
using DataAccessLayer.Interfaces;
using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.EFCore.Repositories
{
    public class EfGenericRepository<Entity> : IGenericDal<Entity> where Entity : class, ITable, new()
    {
        public List<Entity> AllEntitys()
        {
           using(var context=new TodoContext())
            {
               return context.Set<Entity>().ToList();
            }
        }

        public void Delete(Entity entity)
        {
            using (var context = new TodoContext())
            {
                context.Set<Entity>().Remove(entity); context.SaveChanges();
            }
        }

        public Entity GetEntityById(int Id)
        {
            using (var context = new TodoContext())
            {
                return context.Set<Entity>().Find(Id);
            }
        }

        public void Save(Entity entity)
        {
            using (var context = new TodoContext())
            {
                context.Set<Entity>().Add(entity); context.SaveChanges();
            }
        }

        public void Update(Entity entity)
        {
            using (var context = new TodoContext())
            {
                context.Set<Entity>().Update(entity); context.SaveChanges();
            }
        }
    }
}
