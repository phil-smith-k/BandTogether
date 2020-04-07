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
        private readonly AddressModelHelper _addressHelper = new AddressModelHelper();

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
        public School BuildSchoolEntity(SchoolCreate model)
        {
            var entity = new School();

            entity.SchoolName = model.SchoolName;
            entity.Address = _addressHelper.BuildAddress(model);
            entity.LowestGrade = model.LowestGradeLevel;
            entity.HighestGrade = model.HighestGradeLevel;
            entity.TeacherId = model.TeacherId;

            return entity;
        }
    }
}
