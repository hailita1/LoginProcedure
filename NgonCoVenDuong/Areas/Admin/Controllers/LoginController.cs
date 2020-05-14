using DocumentManagement.Model;
using NgonCoVenDuong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgonCoVenDuong.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDao userDao = new UserDao();
                //var result = userDao.Login(model.Username, model.Password);
                int result = 0;
                DbProvider db = new DbProvider();
                db.SetQuery("sp_Login",System.Data.CommandType.StoredProcedure)
                    .SetParameter("username", System.Data.SqlDbType.NVarChar, model.Username, System.Data.ParameterDirection.Input)
                    .SetParameter("password", System.Data.SqlDbType.NVarChar, model.Password, System.Data.ParameterDirection.Input)
                    .SetParameter("result", System.Data.SqlDbType.Int, DBNull.Value, System.Data.ParameterDirection.Output)
                    .ExcuteNonQuery();
                db.GetOutValue("result", out result);

                if (result == 1)
                {
                    return RedirectToAction("Index", "NgonCoVenDuong");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View();
        }
    }
}