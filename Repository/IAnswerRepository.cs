using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface IAnswerRepository
    {
        IEnumerable<tb_Answer> GetAll();
        tb_Answer Find(int id);
        void Add(tb_Answer obj);
        void Edit(tb_Answer obj);
        void Delete(int id);
    }
}
