using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IGenericService<Entity> where Entity : class, ITable, new()
    {
        void Save(Entity entity);
        void Delete(Entity entity);
        void Update(Entity entity);
        List<Entity> AllEntitys();
        Entity GetEntityById(int Id);
    }
}
