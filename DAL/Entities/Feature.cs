using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.DAL.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        [Required] 
        public string ArabicName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        public bool IsDelete { get; set; }

    }
}
