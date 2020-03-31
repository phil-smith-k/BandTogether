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
    }
}
