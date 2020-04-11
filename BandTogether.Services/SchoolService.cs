using BandTogether.Data;
using BandTogether.Models.SchoolModels;
using BandTogether.Services.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Services
{
    public class SchoolService
    {
        private readonly string _currentUser;
        private readonly SchoolModelHelper _schoolHelper = new SchoolModelHelper();

        public SchoolService() { }
        public SchoolService(string currentUserId)
        {
            _currentUser = currentUserId;
        }
        //____________________________________________CREATE
        public bool AddSchoolToTeacher(SchoolCreate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var teacher = ctx.Teachers.Find(_currentUser);

                if (teacher != null)
                {
                    model.TeacherId = _currentUser;
                    var entity = _schoolHelper.BuildSchoolEntity(model);
                    teacher.Schools.Add(entity);

                    return ctx.SaveChanges() == 2;
                }
                else
                    return false;
            }
        }
        //______________________________________________READ
        public IEnumerable<SchoolDetail> GetTeachersSchools(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teacher = ctx.Teachers.Find(id);
                if (teacher != null)
                {
                    var schools = _schoolHelper.BuildSchoolDetailList(teacher.Schools);
                    return schools;
                }
                else
                {
                    return new List<SchoolDetail>();
                }
            }
        }
        //____________________________________________UPDATE
        public bool UpdateSchool(SchoolEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Schools.Find(model.SchoolId);
                if (entity != null)
                {
                    _schoolHelper.UpdateSchoolEntity(model, entity);
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }
        //____________________________________________DELETE
        public bool DeleteSchool(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var teacher = ctx.Teachers.Find(_currentUser);
                var entity = ctx.Schools.Find(id);

                if (entity != null && teacher != null)
                {
                    teacher.Schools.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
