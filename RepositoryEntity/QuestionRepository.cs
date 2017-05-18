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
    public class QuestionRepository:IQuestionRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Question obj)
        {
            _entities.tb_Question.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Question.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Question obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Question Find(int id)
        {
            return _entities.tb_Question.Find(id);
        }

        public IEnumerable<tb_Question> GetAll()
        {
            return _entities.tb_Question;
        }
    }
}
