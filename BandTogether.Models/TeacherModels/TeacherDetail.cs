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
        public TeacherDetail(string id, string firstName, string lastName, string fileName, string contentType, byte[] data, int followers, int following, int resourceCount, List<SchoolListItem> schools, List<ResourceListItem> resources)
        {
            this.TeacherId = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FileName = fileName;
            this.ContentType = contentType;
            this.ImageData = data;
            this.NumberOfFollowers = followers;
            this.NumberOfFollowing = following;
            this.ResourceCount = resourceCount;
            this.Schools = schools;
            this.Resources = resources;
        }

        public string TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] ImageData { get; set; }
        [Display(Name = "Followers")]
        public int NumberOfFollowers { get; set; }
        [Display(Name = "Following")]
        public int NumberOfFollowing { get; set; }
        [Display(Name = "Resources")]
        public int ResourceCount { get; set; }
        public List<SchoolListItem> Schools { get; set; } = new List<SchoolListItem>();
        public List<ResourceListItem> Resources { get; set; } = new List<ResourceListItem>();
    }
}