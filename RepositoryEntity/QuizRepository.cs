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
    public class QuizRepository:IQuizRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Quiz obj)
        {
            _entities.tb_Quiz.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Quiz.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Quiz obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Quiz Find(int id)
        {
            return _entities.tb_Quiz.Find(id);
        }

        public IEnumerable<tb_Quiz> GetAll()
        {
            return _entities.tb_Quiz;
        }
    }
}
