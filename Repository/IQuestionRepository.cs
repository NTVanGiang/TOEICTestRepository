﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<tb_Question> GetAll();
        tb_Question Find(int id);
        void Add(tb_Question obj);
        void Edit(tb_Question obj);
        void Delete(int id);
    }
}
