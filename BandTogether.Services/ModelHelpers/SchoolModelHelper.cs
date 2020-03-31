using BandTogether.Data.Entities;
using BandTogether.Models.SchoolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Services.ModelHelpers
{
    public class SchoolModelHelper
    {
        public List<SchoolListItem> GetSchoolListItems(ICollection<School> schools)
        {
            var schoolListItems = schools.Select(sch => new SchoolListItem
            {
                SchoolId = sch.SchoolId,
                SchoolName = sch.SchoolName,
                City = sch.Address.City,
                State = sch.Address.State
            });

            return schoolListItems.ToList();
        }
        public string GetSchoolCity(ICollection<School> schools)
        {
            if (schools == null)
                return "";
            else if (schools.Count == 0)
                return "";
            else
            {
                var firstSchool = schools.First();
                return firstSchool.Address.City;
            }
        }
        public string GetSchoolState(ICollection<School> schools)
        {
            if (schools == null)
                return "";
            else if (schools.Count == 0)
                return "";
            else
            {
                var firstSchool = schools.First();
                return firstSchool.Address.State;
            }
        }
    }
}
