using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    public interface IPartRepository
    {
        IEnumerable<tb_Part> GetAll();
        tb_Part Find(int id);
        void Add(tb_Part obj);
        void Edit(tb_Part obj);
        void Delete(int id);
    }
}
