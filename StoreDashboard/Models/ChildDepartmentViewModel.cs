using System.ComponentModel.DataAnnotations;

namespace StoreDashboard.Models
{
    public class ChildDepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is Required")]
        [MinLength(3, ErrorMessage = "MinLength contains 3 Characters")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "Department Name is Required")]
        public string EnglishName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
        public bool IsShownUser { get; set; }
        public string? Description { get; set; }
        public string? EnglishDescription { get; set; }

        public string? ImageName { get; set; }
        [Required(ErrorMessage = "Select file ")]
        public IFormFile Image { get; set; }
    }
}
