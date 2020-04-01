using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BandTogether.Models.EditProfileModels
{
    public class EditProfilePicture
    {
        public string TeacherId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        public HttpPostedFileBase Image { get; set; }
    }
}
