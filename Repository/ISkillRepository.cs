using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    public interface ISkillRepository
    {
        IEnumerable<tb_Skill> GetAll();
        tb_Skill Find(int id);
        void Add(tb_Skill obj);
        void Edit(tb_Skill obj);
        void Delete(int id);
    }
}
