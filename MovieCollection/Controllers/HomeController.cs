using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        //constructor
        //get the inputs of the form
        private MovieApplicationContext movieContext { get; set; }

        public HomeController(MovieApplicationContext someName)
        {
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = movieContext.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(ar);
                movieContext.SaveChanges(); //add and save movies to the database
                return View("Confirmation", ar); //return a confirmation page
            }
            else //if it is invalid
            {
                ViewBag.Categories = movieContext.categories.ToList();
                return View(ar);
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = movieContext.responses
                .Include(x => x.Category)
                //.Where(x => x.Edited == false)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = movieContext.categories.ToList(); //get the record info
            var application = movieContext.responses.Single(x => x.ApplicationId == applicationid);
            return View("Movies", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            movieContext.Update(ar);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            //get the record id
            var application = movieContext.responses.Single(x => x.ApplicationId == applicationid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            movieContext.responses.Remove(ar);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}
