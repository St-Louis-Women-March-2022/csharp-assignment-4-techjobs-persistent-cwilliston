using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;
using TechJobsPersistentAutograded.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistentAutograded.Controllers
{

    public class HomeController : Controller

    {
        private JobRepository _repo;


        public HomeController(JobRepository repo)
        {
            _repo = repo;

        }

        public IActionResult Index()

        {
            IEnumerable<Job> jobs = _repo.GetAllJobs();


            return View(jobs);
        }


        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> employers = _repo.GetAllEmployers().ToList();
            List<Skill> skills = _repo.GetAllSkills().ToList();

            AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);
            
            return View(addJobViewModel);
        }



        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {

            if (ModelState.IsValid)
            {

                Job theJob = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = addJobViewModel.EmployerId
                };

                foreach(var skill in selectedSkills)
                {
                                        
                    JobSkill theJobSkill = new JobSkill
                    {
                        Job = theJob,
                        SkillId = Int32.Parse(skill)
                    };

                    _repo.AddNewJobSkill(theJobSkill);

                }


                _repo.AddNewJob(theJob);
                _repo.SaveChanges();

                return Redirect("Index");
            }

            return View("Add");
        }


        public IActionResult Detail(int id)
        {
            Job theJob = _repo.FindJobById(id);

            List<JobSkill> jobSkills = _repo.FindSkillsForJob(id).ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }

    }

}


