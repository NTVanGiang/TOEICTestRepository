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
    public class TopicRepository:ITopicRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Topic obj)
        {
            _entities.tb_Topic.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Topic.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Topic obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Topic Find(int id)
        {
            return _entities.tb_Topic.Find(id);
        }

        public IEnumerable<tb_Topic> GetAll()
        {
            return _entities.tb_Topic;
        }
    }
}
