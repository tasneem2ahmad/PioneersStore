using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.DAL.Entities
{
    public class ChildDepartment
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string ArabicName { get; set; }
        [Required]

        public string EnglishName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsApproved { get; set; } = false;
        public bool IsShownUser { get; set; } = false;
        public string? Description { get; set; }
        public string? EnglishDescription { get; set; }

        public string? ImageName { get; set; }
    }
}
