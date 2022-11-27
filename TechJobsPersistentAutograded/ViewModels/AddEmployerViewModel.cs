using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public AddEmployerViewModel(string name, string location)
        {
            Name = name;
            Location = location;
        }

    }
}
