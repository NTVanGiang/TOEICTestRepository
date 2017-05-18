using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    public interface ITopicRepository
    {
        IEnumerable<tb_Topic> GetAll();
        tb_Topic Find(int id);
        void Add(tb_Topic obj);
        void Edit(tb_Topic obj);
        void Delete(int id);
    }
}
