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
    public class PartRepository:IPartRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Part obj)
        {
            _entities.tb_Part.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Part.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Part obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Part Find(int id)
        {
            return _entities.tb_Part.Find(id);
        }

        public IEnumerable<tb_Part> GetAll()
        {
            return _entities.tb_Part;
        }
    }
}
