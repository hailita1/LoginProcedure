using NgonCoVenDuong.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgonCoVenDuong.Models
{
    public class UserDao
    {
        Model1 db = new Model1();

        public long Insert(tAdmin user)
        {
            db.tAdmins.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.tAdmins.Count(x => x.Username == userName && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public tAdmin GetByName(string username)
        {
            return db.tAdmins.SingleOrDefault(x => x.Username == username);
        }
    }
}