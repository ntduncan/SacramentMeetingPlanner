using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }
        public int SacramentMeetingProgramID { get; set; }

        [Required]
        [Display(Name = "Speaker Name")]
        [StringLength(50, ErrorMessage = "Field cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Speaker Topic")]
        [StringLength(50, ErrorMessage = "Field cannot exceed 50 characters")]
        public string Topic { get; set; }
        
    }
}
