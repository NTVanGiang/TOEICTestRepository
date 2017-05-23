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
    public class QuizDetailRepository:IQuizDetailRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_QuizDetail obj)
        {
            _entities.tb_QuizDetail.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_QuizDetail.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_QuizDetail obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_QuizDetail Find(int id)
        {
            return _entities.tb_QuizDetail.Find(id);
        }

        public IEnumerable<tb_QuizDetail> GetAll()
        {
            return _entities.tb_QuizDetail;
        }
    }
}
