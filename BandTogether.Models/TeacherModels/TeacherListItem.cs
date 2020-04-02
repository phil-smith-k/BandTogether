using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.TeacherModels
{
    public class TeacherListItem
    {
        public TeacherListItem() { }
        public TeacherListItem(string id, string name, string city, string state, int followers, int resources, bool isFollowed)
        {
            this.TeacherId = id;
            this.TeacherName = name;
            this.City = city;
            this.State = state;
            this.FollowerCount = followers;
            this.ResourceCount = resources;
            this.IsFollowed = isFollowed;
        }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Followers")]
        public int FollowerCount { get; set; }
        [Display(Name = "Resources")]
        public int ResourceCount { get; set; }
        [UIHint("Follow")]
        [Display(Name = "Follow")]
        public bool IsFollowed { get; set; }
    }
}
