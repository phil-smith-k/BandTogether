using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.TeacherModels
{
    public class TeacherListItem
    {
        public TeacherListItem() { }
        public TeacherListItem(string id, string name, string city, string state, int followers, int resources)
        {
            this.TeacherId = id;
            this.TeacherName = name;
            this.City = city;
            this.State = state;
            this.FollowerCount = followers;
            this.ResourceCount = resources;
        }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int FollowerCount { get; set; }
        public int ResourceCount { get; set; }
    }
}
