using BandTogether.Models.ResourceModels;
using BandTogether.Models.SchoolModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandTogether.Models.TeacherModels
{
    public class TeacherDetail
    {
        public TeacherDetail() { }
        public TeacherDetail(string id, string firstName, string lastName, string fileName, byte[] data, int followers, int following, List<SchoolListItem> schools, List<ResourceListItem> resources)
        {
            TeacherId = id;
            FirstName = firstName;
            LastName = lastName;
            FileName = fileName;
            ImageData = data;
            NumberOfFollowers = followers;
            NumberOfFollowing = following;
            Schools = schools;
            Resources = resources;
        }

        public string TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        [Display(Name = "Followers")]
        public int NumberOfFollowers { get; set; }
        [Display(Name = "Following")]
        public int NumberOfFollowing { get; set; }
        public List<SchoolListItem> Schools { get; set; } = new List<SchoolListItem>();
        public List<ResourceListItem> Resources { get; set; } = new List<ResourceListItem>();
    }
}