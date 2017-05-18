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
    public class SkillRepository:ISkillRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Skill obj)
        {
            _entities.tb_Skill.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Skill.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Skill obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Skill Find(int id)
        {
            return _entities.tb_Skill.Find(id);
        }

        public IEnumerable<tb_Skill> GetAll()
        {
            return _entities.tb_Skill;
        }
    }
}
