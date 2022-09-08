using MCC69APP.Context;
using MCC69APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Controllers
{
    public class RegionsController : Controller
    {
        MyContext myContext;
        public RegionsController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            var regions = myContext.Regions.ToList();
            return View(regions);
        }
        //CREATE
        //getview
        public IActionResult Create() 
        {
            
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Regions region)
        {
            myContext.Regions.Add(region);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Regions");
            return View();
        }
        //Insert

        //EDIT
        public IActionResult Edit(int id)
        {
            var data = myContext.Regions.Find(id);//harus primarykey
            //var data1 = myContext.Regions.SingleOrDefault(x => x.Id.Equals(id));//whre
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Regions regions) 
        {
            myContext.Entry(regions).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Regions");
            return View();
        }
        //Detail
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = myContext.Regions.FirstOrDefault(m => m.Id == id);
               
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        //DELETE
        public IActionResult Delete(int id)
        {
            var data = myContext.Regions.Find(id);
            
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Regions regions)
        {
            var data = myContext.Regions.Find(regions.Id);
            myContext.Regions.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Regions");
            return View();
        }
    }
}
