using BandTogether.Data.Entities;
using BandTogether.Data.Entities.File;
using BandTogether.Models.EditProfileModels;
using BandTogether.Models.TeacherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BandTogether.Services.ModelHelpers
{
    public class TeacherModelHelper
    {
        private readonly ResourceModelHelper _resourceHelper = new ResourceModelHelper();
        private readonly SchoolModelHelper _schoolHelper = new SchoolModelHelper();
        private readonly FileModelHelper _fileHelper = new FileModelHelper();

        public int GetFollowCount(ICollection<Teacher> followList)
        {
            if (followList == null)
                return 0;
            else
                return followList.Count;
        }
        public TeacherDetail GetTeacherDetailModel(Teacher entity)
        {
            var fileName = _fileHelper.GetFileName(entity.ProfilePicture);
            var contentType = _fileHelper.GetFileContentType(entity.ProfilePicture);
            var data = _fileHelper.GetFileData(entity.ProfilePicture);
            var schools = _schoolHelper.GetSchoolListItems(entity.Schools);
            var resources = _resourceHelper.GetResourceListItems(entity.Resources);
            var resourceCount = _resourceHelper.GetResourcesCount(entity.Resources);
            var followersCount = GetFollowCount(entity.Followers);
            var followingCount = GetFollowCount(entity.Following);

            return new TeacherDetail(entity.Id, entity.FirstName, entity.LastName, fileName, contentType, data, followersCount, followingCount, resourceCount, schools, resources);
        }
        public IEnumerable<TeacherListItem> GetTeacherListItems(List<Teacher> teachers, Teacher currentUser)
        {
            var teacherListItems = new List<TeacherListItem>();
            foreach (var teacher in teachers)
            {
                if (teacher.Id == currentUser.Id)
                    continue;
                else
                {
                    var fullname = $"{teacher.FirstName} {teacher.LastName}";
                    var school = teacher.Schools.FirstOrDefault()?.SchoolName ?? null;
                    var city = _schoolHelper.GetSchoolCity(teacher.Schools);
                    var state = _schoolHelper.GetSchoolState(teacher.Schools);
                    var followers = GetFollowCount(teacher.Followers);
                    var resources = _resourceHelper.GetResourcesCount(teacher.Resources);
                    var isFollowed = currentUser.Following.Contains(teacher);
                    var fileName = _fileHelper.GetFileName(teacher.ProfilePicture);
                    var content = _fileHelper.GetFileContentType(teacher.ProfilePicture);
                    var data = _fileHelper.GetFileData(teacher.ProfilePicture);

                    teacherListItems.Add(new TeacherListItem(teacher.Id, fullname, school, city, state, followers, resources, isFollowed, fileName, content, data));
                }
            }
            return teacherListItems;
        }
        public EditProfileName GetEditProfileNameModel(Teacher entity)
        {
            return new EditProfileName(entity.Id, entity.FirstName, entity.LastName);
        }
    }
}
