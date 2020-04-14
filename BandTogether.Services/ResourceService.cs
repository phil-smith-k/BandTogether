using BandTogether.Data;
using BandTogether.Data.Entities.ResourceClasses;
using BandTogether.Models.Interfaces;
using BandTogether.Models.ResourceModels;
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
        public IEnumerable<ResourceListItem> GetPublicFollowedResources()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teacher = ctx.Teachers.Find(_currentUser);
                if (teacher != null)
                {
                    var followingIds = teacher.Following.Select(t => t.Id);
                    var resources = ctx.Resources.ToList();
                    var teacherResources = teacher.Resources;

                    var publicResources = resources.Where(res => followingIds.Contains(res.TeacherId) && res.IsPublic);

                    var allPublicResources = publicResources.Concat(teacherResources).OrderByDescending(res => res.DateCreated).ToList();

                    return _resourceHelper.GetResourceListItems(allPublicResources);
                }
                else
                    throw new InvalidOperationException();
            }
        }
        public IResourceDetail GetResourceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Resources.Find(id);

                if (entity != null)
                {
                    var model = _resourceHelper.BuildResourceDetail(entity);
                    return model;
                }
                else
                    throw new InvalidOperationException();
            }
        }
        //____________________________________________UPDATE
        public bool UpdateResource(IResourceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Resources.Find(model.ResourceId);

                if (entity != null)
                {
                    _resourceHelper.UpdateResourceEntity(model, entity);
                    return ctx.SaveChanges() == 2;
                }
                return false;
            }
        }
        //____________________________________________DELETE
        public bool DeleteResource(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Resources.Find(id);
                if (entity != null)
                {
                    ctx.ResourceFiles.Remove(entity.File);
                    ctx.Resources.Remove(entity);
                    var numberOfChanges = ctx.SaveChanges();
                    return numberOfChanges == 3;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
