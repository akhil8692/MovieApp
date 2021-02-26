using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public int Pincode { get; set; }
    }
}
