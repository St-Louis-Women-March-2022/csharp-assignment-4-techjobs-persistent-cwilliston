using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistentAutograded.Data;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage ="Name is required.")]
        [StringLength(50, MinimumLength =0)]
        public string Name { get; set; }

        [Required(ErrorMessage ="EmployerId is required.")]
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        [Required]
        public List<Skill> Skills { get; set; }

        [Required(ErrorMessage ="SkillId is required")]
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
