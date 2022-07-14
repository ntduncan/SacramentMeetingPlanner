using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeetingProgram
    {
        public int SacramentMeetingProgramID { get; set; }
        
        [Required]
        [Display(Name = "Meeting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        [Required]
        [Display(Name = "Conducting")]
        [StringLength(50, ErrorMessage = "Field cannot exceed 50 characters")]
        public String ConductingLeader { get; set; }
        
        [Required]
        [Display(Name = "Opening Prayer")]
        [StringLength(50, ErrorMessage = "Field cannot exceed 50 characters")]
        public String OpeningPrayer { get; set; }
        

        [Required]
        [Display(Name = "Closing Prayer")]
        [StringLength(50, ErrorMessage = "Field cannot exceed 50 characters")]
        public String ClosingPrayer { get; set; }

        public ICollection<Speaker>? Speakers { get; set; }
        
        [Required]
        [Display(Name = "Opening Hymn")]
        public int OpeningHymnID { get; set; }
        public Hymn? OpeningHymn { get; set; }
        
        [Required]
        [Display(Name = "Closing Hymn")]
        public int ClosingHymnID { get; set; }
        public Hymn? ClosingHymn { get; set; }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        public int SacramentHymnID { get; set; }
        public Hymn? SacramentHymn { get; set; }
        [Display(Name = "Intermediate Hymn")]
        public int? IntermediateHymnID { get; set; }
        public Hymn? IntermediateHymn { get; set; }

    }
}
