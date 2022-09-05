using CRUDController.Data;
using CRUDController.Interfaces;
using M6HW3RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;

namespace M6HW3RazorPages.Controllers
{
    public class CRUDController : Controller, ICRUD
    {
        public Provider provider = new Provider();
        private readonly Random _random = new Random();

        [HttpGet]
        public ViewResult List()
        {
            return View(provider.GetList());
        }

        [HttpGet]
        public ViewResult Create()
        {
            var user = new CreateUserParameters() { Job = "teacher", Name = "MAX", Id = Provider.Mylist.Count + 1, Salary = 1032 };
            return View(provider.Create(user));
        }

        [HttpPost("{id}")]
        // GET: CRUD/update?id=2
        public ActionResult Update([FromBody] int id)
        {
            if (id > 0 && id < Provider.Mylist.Count)
            {
                Provider.Mylist[id].Name = " changed by user";
            }

            return View(provider.GetList());
        }

        [HttpGet]
        public ActionResult Update()
        {
            if(Provider.Mylist.Count > 0) 
            {
                Provider.Mylist[_random.Next(0, Provider.Mylist.Count)].Name = " changed by user";
                return View(provider.GetList());
            }

            return RedirectToAction("Error");

        }

        [HttpDelete("{id}")]
        // Delete: CRUD/Delete?id=2
        public ActionResult Delete([FromBody] int id)
        {
            if (id > 0 && id < Provider.Mylist.Count)
            {
                Provider.Mylist.RemoveAt(id);
            }

            return View(provider.GetList());
        }

        [HttpGet]
        public ActionResult Delete()
        {
            if(Provider.Mylist.Count > 0) 
            { 
                Provider.Mylist.RemoveAt(_random.Next(0, Provider.Mylist.Count));
                return View(provider.GetList());
            }
            return RedirectToAction("Error" , "Home");
        }

    }
}
