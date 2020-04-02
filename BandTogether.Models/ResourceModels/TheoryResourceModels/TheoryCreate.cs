using BandTogether.Data.Entities.Enumerations;
using BandTogether.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BandTogether.Models.ResourceModels.TheoryResourceModels
{
    public class TheoryCreate : IResourceCreate
    {
        public string TeacherId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Let others download?")]
        public bool IsDownloadable { get; set; }

        [Display(Name = "Make it public?")]
        public bool IsPublic { get; set; }

        [Required]
        [Display(Name = "File")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        [Required]
        [Display(Name = "Grade Level")]
        [Range(4, 12)]
        public int GradeLevel { get; set; }

        [Required]
        [EnumDataType(typeof(TheoryTopic))]
        public TheoryTopic Topic { get; set; }
    }
}
