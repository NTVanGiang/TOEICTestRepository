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
    public class SubQuestionRepository:ISubQuestionRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_SubQuestion obj)
        {
            _entities.tb_SubQuestion.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_SubQuestion.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_SubQuestion obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_SubQuestion Find(int id)
        {
            return _entities.tb_SubQuestion.Find(id);
        }

        public IEnumerable<tb_SubQuestion> GetAll()
        {
            return _entities.tb_SubQuestion;
        }
    }
}
