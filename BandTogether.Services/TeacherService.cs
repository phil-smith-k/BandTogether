using BandTogether.Data;
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
        //____________________________________________UPDATE
        //____________________________________________DELETE


    }
}
