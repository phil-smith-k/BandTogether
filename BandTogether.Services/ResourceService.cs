using BandTogether.Data;
using BandTogether.Models.Interfaces;
using BandTogether.Models.ResourceModels.TechniqueResourceModels;
using BandTogether.Services.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Services
{
    public class ResourceService
    {
        private readonly string _currentUser;

        private readonly ResourceModelHelper _resourceHelper = new ResourceModelHelper();


        public ResourceService() { }
        public ResourceService(string currentUserId)
        {
            _currentUser = currentUserId;
        }
        //____________________________________________CREATE
        public bool CreateResource(IResourceCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teacher = ctx.Teachers.Find(_currentUser);
                if (teacher != null)
                {
                    model.TeacherId = teacher.Id;
                    var entity = _resourceHelper.BuildResourceEntity(model);
                    ctx.Resources.Add(entity);
                    var numberOfChanges = ctx.SaveChanges();
                    return numberOfChanges == 3;
                }
                else
                    return false;
            }
        }
        //______________________________________________READ
        //____________________________________________UPDATE
        //____________________________________________DELETE
    }
}
