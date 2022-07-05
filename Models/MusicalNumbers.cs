using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class MusicalNumbers
    {
        public int MusicalNumbersID { get; set; }

        [Range(1, 341, 
        ErrorMessage = "Hymn must be between 1 and 341")]
        [Display(Name = "Opening Hymn")]
        [Required(ErrorMessage = "Please enter an opening hymn")]
        public int OpeningHymn { get; set; }

        [Range(1, 341, 
        ErrorMessage = "Hymn must be between 1 and 341")]
        [Display(Name = "Sacrament Hymn")]
        [Required(ErrorMessage = "Please enter a sacrament hymn")]
        public int SacramentHymn { get; set; }

        [Range(1, 341, 
        ErrorMessage = "Hymn must be between 1 and 341")]
        [Display(Name = "Closing Hymn")]
        [Required(ErrorMessage = "Please enter a closing hymn")]
        public int ClosingHymn { get; set; }

        [Range(1, 341, 
        ErrorMessage = "Hymn must be between 1 and 341")]
        [Display(Name = "Intermediate Hymn")]
        public int IntermediateHymn { get; set; }
    }
}
