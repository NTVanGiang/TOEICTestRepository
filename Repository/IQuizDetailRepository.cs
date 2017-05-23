using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    public interface IQuizDetailRepository
    {
        IEnumerable<tb_QuizDetail> GetAll();
        tb_QuizDetail Find(int id);
        void Add(tb_QuizDetail obj);
        void Edit(tb_QuizDetail obj);
        void Delete(int id);
    }
}
