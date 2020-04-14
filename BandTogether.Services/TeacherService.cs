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
        private readonly FileModelHelper _fileHelper = new FileModelHelper();

        public TeacherService() { }
        public TeacherService(string currentUserId)
        {
            _currentUser = currentUserId;
        }

        //______________________________________________READ
        public IEnumerable<TeacherListItem> GetAllTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teachers = ctx.Teachers.ToList();
                var currentUser = ctx.Teachers.Find(_currentUser);
                return _teacherHelper.GetTeacherListItems(teachers, currentUser);
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
        public IEnumerable<TeacherListItem> GetFollowersForTeacher(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Find(id);
                var currentUser = ctx.Teachers.Find(_currentUser);
                if (entity != null && currentUser != null)
                {
                    return _teacherHelper.GetTeacherListItems(entity.Followers.ToList(), currentUser);
                }
                else
                    throw new InvalidOperationException();
            }
        }
        public IEnumerable<TeacherListItem> GetFollowingForTeacher(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Find(id);
                var currentUser = ctx.Teachers.Find(_currentUser);
                if (entity != null && currentUser != null)
                {
                    return _teacherHelper.GetTeacherListItems(entity.Following.ToList(), currentUser);
                }
                else
                    throw new InvalidOperationException();
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
        public bool UpdateProfilePicture(EditProfilePicture model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Teachers.Find(model.TeacherId);
                if (entity == null)
                    return false;
                else
                {
                    if (entity.ProfilePicture == null)
                    {
                        var profilePicture = _fileHelper.BuildProfilePicture(model.Image);
                        entity.ProfilePicture = profilePicture;
                        var numberOfChanges = ctx.SaveChanges();
                        return numberOfChanges == 2;
                    }
                    else
                    {
                        var updatedPicture = _fileHelper.UpdateProfilePicture(entity.ProfilePicture, model.Image);
                        entity.ProfilePicture = updatedPicture;
                        var numberOfChanges = ctx.SaveChanges();
                        return numberOfChanges == 1;
                    }
                }
            }
        }
        public bool AddTeacherToFollowing(string teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var currentUser = ctx.Teachers.Find(_currentUser);
                var teacherToAdd = ctx.Teachers.Find(teacherId);

                if (currentUser != null && teacherToAdd != null)
                {
                    currentUser.Following.Add(teacherToAdd);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
        public bool RemoveTeacherFromFollowing(string teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var currentUser = ctx.Teachers.Find(_currentUser);
                var teacherToRemove = ctx.Teachers.Find(teacherId);

                if (currentUser != null && teacherToRemove != null)
                {
                    currentUser.Following.Remove(teacherToRemove);
                    return ctx.SaveChanges() == 1;
                }
                else
                    return false;
            }
        }
    }
}
