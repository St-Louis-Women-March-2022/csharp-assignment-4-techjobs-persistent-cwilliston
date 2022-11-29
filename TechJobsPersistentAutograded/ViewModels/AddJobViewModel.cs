using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TechJobsPersistentAutograded.Data;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {
        public string Name { get; set; }
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public List<Skill> Skills { get; set; }

        public int SkillId { get; set; }


        public AddJobViewModel()
        {
            
        }
        
        
        public AddJobViewModel(List<Employer> employerList, List<Skill> skills)
        {
            Employers = new List<SelectListItem>();
            foreach (var employer in employerList)
            {
                Employers.Add(
                    new SelectListItem
                    {
                        Value = employer.Id.ToString(),
                        Text = employer.Name
                    }
                );
            }

            Skills = skills;

        }
    }
}
