using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace movieapplication.Models
{
    public class movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
