using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Models.SchoolModels
{
    public class SchoolDetail
    {
        public SchoolDetail() { }
        public SchoolDetail(int id, string name, int lowest, int highest, string street, string city, string state, string zip)
        {
            this.SchoolId = id;
            this.SchoolName = name;
            this.LowestGrade = lowest;
            this.HighestGrade = highest;
            this.StreetAddress = street;
            this.City = city;
            this.State = state;
            this.ZipCode = zip;
        }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int LowestGrade { get; set; }
        public int HighestGrade { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
