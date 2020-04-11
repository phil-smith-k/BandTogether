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
        public IEnumerable<SchoolDetail> BuildSchoolDetailList(ICollection<School> schools) 
        {
            var schoolDetails = schools.Select(sch =>
                new SchoolDetail(
                    sch.SchoolId, 
                    sch.SchoolName, 
                    sch.LowestGrade, 
                    sch.HighestGrade, 
                    sch.Address.StreetAddress, 
                    sch.Address.City, 
                    sch.Address.State, 
                    sch.Address.ZipCode)).ToList();

            return schoolDetails;
        }
        public void UpdateSchoolEntity(SchoolEdit model, School entity)
        {
            entity.SchoolName = model.SchoolName;
            entity.Address.StreetAddress = model.StreetAddress;
            entity.Address.City = model.City;
            entity.Address.State = model.State;
            entity.Address.ZipCode = model.ZipCode;
            entity.HighestGrade = model.HighestGradeLevel;
            entity.LowestGrade = model.LowestGradeLevel;
        }
    }
}
