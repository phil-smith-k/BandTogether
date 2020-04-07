using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Data.Entities.Enumerations
{
    public enum EnsembleType
    {
        [Display(Name = "Beginning Band")]
        BeginningBand = 1,
        [Display(Name = "Middle School Concert Band")]
        MiddleSchoolConcertBand,
        [Display(Name = "High School Concert Band")]
        HighSchoolConcertBand,
        [Display(Name = "Mariachi Band")]
        MariachiBand,
        [Display(Name = "Marching Band")]
        MarchingBand,
        [Display(Name = "Pep Band")]
        PepBand,
        [Display(Name = "Jazz Band")]
        JazzBand,
        [Display(Name = "Percussion Ensemble")]
        PercussionEnsemble,
        [Display(Name = "Brass Ensemble")]
        BrassEnsemble,
        [Display(Name = "Woodwind Ensemble")]
        WoodwindEnsemble,
        [Display(Name = "Chamber Ensemble")]
        ChamberEnsemble,
        Other
    }
}
