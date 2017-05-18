using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using System.Data.Entity;

namespace RepositoryEntity
{
    public class LevelRepository:ILevelRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Level obj)
        {
            _entities.tb_Level.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Level.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Level obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Level Find(int id)
        {
            return _entities.tb_Level.Find(id);
        }

        public IEnumerable<tb_Level> GetAll()
        {
            return _entities.tb_Level;
        }
    }
}
