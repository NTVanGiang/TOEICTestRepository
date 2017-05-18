using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface IAccountRepository
    {
        IEnumerable<tb_Account> GetAll();
        tb_Account Find(int id);
        void Add(tb_Account obj);
        void Edit(tb_Account obj);
        void Delete(int id);
        bool Login(string userName, string passWord);
    }
}
