using System.ComponentModel.DataAnnotations;

namespace StoreDashboard.Models
{
    public class MarketViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Market Name is Required")]
        [MinLength(3, ErrorMessage = "MinLength contains 3 Characters")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "Market Name is Required")]
        public string EnglishName { get; set; }
        [Required(ErrorMessage = "Market SortOrder is Required")]
        public int SortOrder { get; set; }
        public string? ImageName { get; set; }
        [Required(ErrorMessage = "Select file ")]
        public IFormFile Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
