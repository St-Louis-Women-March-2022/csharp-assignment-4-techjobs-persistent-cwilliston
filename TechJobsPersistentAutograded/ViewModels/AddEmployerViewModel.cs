using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage ="Name is required.")]
        [StringLength(50, MinimumLength = 0)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Location is required.")]
        [StringLength(50, MinimumLength=0)]
        public string Location { get; set; }

        public AddEmployerViewModel()
        {

        }
        
        public AddEmployerViewModel(string name, string location)
        {
            Name = name;
            Location = location;
        }

    }
}
