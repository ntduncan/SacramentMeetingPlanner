using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

    public class SacramentMeetingPlannerContext : DbContext
    {
        public SacramentMeetingPlannerContext (DbContextOptions<SacramentMeetingPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlanner.Models.SacramentMeetingProgram>? SacramentMeetingProgram { get; set; }

        public DbSet<SacramentMeetingPlanner.Models.Hymn>? Hymn { get; set; }
        
        public DbSet<SacramentMeetingPlanner.Models.Speaker>? Speaker { get; set; }
    }
