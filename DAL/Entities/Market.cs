using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.DAL.Entities
{
    public class Market
    {
        public int Id {  get; set; }
        [Required]  
        public string ArabicName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public int SortOrder { get; set; }
        public string? ImageName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
