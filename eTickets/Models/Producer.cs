using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Base;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }
    }
}