using BandTogether.Data;
using BandTogether.Models.EditProfileModels;
using BandTogether.Models.TeacherModels;
using BandTogether.Services.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Services
{
    public class TeacherService
    {
        private readonly string _currentUser;

        private readonly TeacherModelHelper _teacherHelper = new TeacherModelHelper();

        public TeacherService() { }
        public TeacherService(string currentUserId)
        {
            _currentUser = currentUserId;
        }
        //____________________________________________CREATE
        //______________________________________________READ
        public IEnumerable<TeacherListItem> GetAllTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teachers = ctx.Teachers.ToList();
                return _teacherHelper.GetTeacherListItems(teachers, _currentUser);
            }
        }
        public TeacherDetail GetTeacherById(string teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Find(teacherId);
                return _teacherHelper.GetTeacherDetailModel(entity);
            }
        }
        public EditProfileName GetProfileName(string teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Find(teacherId);
                if (entity == null)
                    throw new NullReferenceException();
                else
                    return _teacherHelper.GetEditProfileNameModel(entity);
            }
        }
        //____________________________________________UPDATE
        public bool UpdateProfileName(EditProfileName model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Find(model.TeacherId);
                if (entity == null)
                    return false;
                else
                {
                    entity.FirstName = model.FirstName;
                    entity.LastName = model.LastName;

                    return ctx.SaveChanges() == 1;
                }
            }
        }
        //____________________________________________DELETE


    }
}
