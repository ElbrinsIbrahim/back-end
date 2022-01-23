using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstCodeAndHelpers.Models;

namespace firstCodeAndHelpers.Controllers
{
    public class userController : Controller
    {
        // GET: user
        ITIcontext db = new ITIcontext();
        public ActionResult Index()
        {
          
            return View(db.Users.ToList());
        }
        public ActionResult create()
        {
            List<department> departments = db.Departments.ToList();
            SelectList st = new SelectList(departments, "id", "name");
            ViewBag.dept = st;

            return View();
        }
        [HttpPost]
        public ActionResult create(user s)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                List<department> departments = db.Departments.ToList();
                SelectList st = new SelectList(departments, "id", "name");
                ViewBag.dept = st;
                return View();
            }
        }
        public ActionResult edit( int id)
        {
            user s = db.Users.Where(n => n.id == id).FirstOrDefault();
            List<department> departments = db.Departments.ToList();
            ViewBag.dept = new SelectList(departments, "id", "name",s.dept_id); 
            return View(s);
        }
        [HttpPost]
        public ActionResult edit(user u)
        {
            user s = db.Users.Where(n => n.id == u.id).FirstOrDefault();
            s.name = u.name;
            s.email = u.email;
            s.age = u.age;
            s.dept_id = u.dept_id;
            s.confirmpassword = s.password;
            db.SaveChanges();


            return RedirectToAction("index");
        }
        public ActionResult login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult login( user u)
        {
            user s = db.Users.Where(n => n.email == u.email && n.password == u.password).FirstOrDefault();
            if (s != null) {
                Session.Add("user_id", s.id);
                return View("profile");
            }
            else
            {
                ViewBag.state = "email or password not valid";
                return View();
            }
            
        }
        public ActionResult profile()
        {
            return View();
        }
        public ActionResult logout()
        {
            Session["user_id"] = null;
            return RedirectToAction("login");
        }
    }
    
}