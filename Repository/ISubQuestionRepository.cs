using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface ISubQuestionRepository
    {
        IEnumerable<tb_SubQuestion> GetAll();
        tb_SubQuestion Find(int id);
        void Add(tb_SubQuestion obj);
        void Edit(tb_SubQuestion obj);
        void Delete(int id);
    }
}
