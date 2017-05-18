using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    public interface ILevelRepository
    {
        IEnumerable<tb_Level> GetAll();
        tb_Level Find(int id);
        void Add(tb_Level obj);
        void Edit(tb_Level obj);
        void Delete(int id);
    }
}
