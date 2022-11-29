﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistentAutograded.Data;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistentAutograded.Controllers
{
    public class EmployerController : Controller
    {

        private JobRepository _repo;


        public EmployerController(JobRepository repo)
        {
            _repo = repo;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Employer> employers = _repo.GetAllEmployers();

            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel viewModel = new AddEmployerViewModel();

            return View(viewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {

                Employer theEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };

                _repo.AddNewEmployer(theEmployer);
                _repo.SaveChanges();

                return Redirect("/Employer");

            }
            
            
            return View("Add", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            Employer theEmployer = _repo.FindEmployerById(id);
            


            return View(theEmployer);
        }
    }
}

