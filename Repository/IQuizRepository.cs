using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    public interface IQuizRepository
    {
        IEnumerable<tb_Quiz> GetAll();
        tb_Quiz Find(int id);
        void Add(tb_Quiz obj);
        void Edit(tb_Quiz obj);
        void Delete(int id);
    }
}
