using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using Tasks = ToDo.Models.Tasks;
using Owners = ToDo.Models.Owner;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly TaskListContext _taskListDB;
        public ToDoController(TaskListContext context)
        {
            _taskListDB = context;
        }
        public ActionResult Index()
        {
            return View(_taskListDB.Tasks.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks task)
        {
           if (ModelState.IsValid)
            {
                _taskListDB.Tasks.Add(task);
                _taskListDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult CreateUser()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _taskListDB.Owners.Add(owner);
                _taskListDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _taskListDB.Owners.Contains(owner);
                //_taskListDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Tasks t = _taskListDB.Tasks.Find(id);
            return View(t);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Tasks t)
        {
            
            //if (ModelState.IsValid)
            //{
                _taskListDB.Tasks.Remove(t);
                _taskListDB.SaveChanges();
            //}
            return RedirectToAction("Index");
        }

        
        public ActionResult Update(int id)
        {
            Tasks c = _taskListDB.Tasks.Find(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Update(Tasks t)
        {
            //if (ModelState.IsValid)
            //{
                _taskListDB.Tasks.Update(t);
                _taskListDB.SaveChanges();
            //}
            return RedirectToAction("Index");
        }

    }
}
