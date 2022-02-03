using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class ApplicationResponse
    {
        //Data model
        [Key]
        [Required]
        public int ApplicationId { get; set; }

        [Required(ErrorMessage = "Pleasee enter a valid title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pleasee enter a valid year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Pleasee enter a valid  director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Pleasee choose a valid  rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //build the foreign key relationship
        [Required(ErrorMessage = "Pleasee enter a valid category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
