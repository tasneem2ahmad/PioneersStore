using System.ComponentModel.DataAnnotations;

namespace StoreDashboard.Models
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Feature Name is Required")]
        [MinLength(3, ErrorMessage = "MinLength contains 3 Characters")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "Feature Name is Required")]
        public string EnglishName { get; set; }
        public bool IsDelete { get; set; }
    }
}
