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
    public class AnswerRepository:IAnswerRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Answer obj)
        {
            _entities.tb_Answer.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Answer.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Answer obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Answer Find(int id)
        {
            return _entities.tb_Answer.Find(id);
        }

        public IEnumerable<tb_Answer> GetAll()
        {
            return _entities.tb_Answer;
        }
    }
}
