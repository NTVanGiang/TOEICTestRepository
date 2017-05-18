using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using System.Data.SqlClient;
using System.Data.Entity;

namespace RepositoryEntity
{
    public class AccountRepository:IAccountRepository
    {
        readonly ToiecTestEntities _entities = new ToiecTestEntities();

        public void Add(tb_Account obj)
        {
            _entities.tb_Account.Add(obj);
            _entities.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = Find(id);
            _entities.tb_Account.Remove(obj);
            _entities.SaveChanges();
        }

        public void Edit(tb_Account obj)
        {
            _entities.Entry(obj).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public tb_Account Find(int id)
        {
            return _entities.tb_Account.Find(id);
        }

        public IEnumerable<tb_Account> GetAll()
        {
            return _entities.tb_Account;
        }
        public bool Login(string userName, string passWord)
        {
            //truyền tham số vào bằng cách khởi tọa object
            object[] sqlParams =
             {
                new SqlParameter("@UserName",userName), new SqlParameter("@PassWord",passWord)
            };
            //gọi thủ tục trả về với kiểu dữ liệu boolean: tên thủ tục, UserName,PassWord
            // trả về một giá trị duy nhất sử dụng SingleOrDefaul
            var res1 = _entities.Database.SqlQuery<bool>("sp_Account_Login @UserName,@PassWord", sqlParams).SingleOrDefault();
            return res1;
        }
    }
}
