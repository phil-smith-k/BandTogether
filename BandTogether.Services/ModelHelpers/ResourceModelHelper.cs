using BandTogether.Data.Entities.ResourceClasses;
using BandTogether.Models.Interfaces;
using BandTogether.Models.ResourceModels;
using BandTogether.Models.ResourceModels.EnsembleResourceModels;
using BandTogether.Models.ResourceModels.TechniqueResourceModels;
using BandTogether.Models.ResourceModels.TheoryResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Services.ModelHelpers
{
    public class ResourceModelHelper
    {
        private readonly FileModelHelper _fileHelper = new FileModelHelper();

        public List<ResourceListItem> GetResourceListItems(ICollection<Resource> resources)
        {
            if (resources == null)
                return new List<ResourceListItem>();
            else
            {
                var resourceListItems = new List<ResourceListItem>();
                foreach (var res in resources)
                {
                    resourceListItems.Add(new ResourceListItem
                    {
                        ResourceId = res.ResourceId,
                        TeacherId = res.TeacherId,
                        TeacherName = $"{res.Teacher.FirstName} {res.Teacher.LastName}",
                        Title = res.Title,
                        DateCreated = res.DateCreated,
                        IsPublic = res.IsPublic
                    });
                }
                return resourceListItems;
            }
        }
        public List<TechniqueResourceListItem> GetTechniqueListItems(ICollection<Resource> resources)
        {
            if (resources == null)
                return null;
            else
            {
                var techniqueListItems = new List<TechniqueResourceListItem>();
                foreach (var res in resources)
                {
                    if (res is TechniqueResource)
                    {
                        var techRes = res as TechniqueResource;
                        techniqueListItems.Add(new TechniqueResourceListItem
                        {
                            ResourceId = techRes.ResourceId,
                            TeacherId = techRes.TeacherId,
                            TeacherName = $"{techRes.Teacher.FirstName} {techRes.Teacher.LastName}",
                            Title = techRes.Title,
                            DateCreated = techRes.DateCreated,
                            IsPublic = techRes.IsPublic,
                            GradeLevel = techRes.GradeLevel,
                            Instrument = techRes.Instrument.ToString("G"),
                            Skill = techRes.Skill.ToString("G")
                        });
                    }
                }
                return techniqueListItems;
            }
        }
        public List<EnsembleResourceListItem> GetEnsembleListItems(ICollection<Resource> resources)
        {
            if (resources == null)
                return null;
            else
            {
                var ensembleListItems = new List<EnsembleResourceListItem>();
                foreach (var res in resources)
                {
                    if (res is EnsembleResource)
                    {
                        var ensRes = res as EnsembleResource;
                        ensembleListItems.Add(new EnsembleResourceListItem
                        {
                            ResourceId = ensRes.ResourceId,
                            TeacherId = ensRes.TeacherId,
                            TeacherName = $"{ensRes.Teacher.FirstName} {ensRes.Teacher.LastName}",
                            Title = ensRes.Title,
                            DateCreated = ensRes.DateCreated,
                            IsPublic = ensRes.IsPublic,
                            GradeLevel = ensRes.GradeLevel,
                            Ensemble = ensRes.Ensemble.ToString("G"),
                            Skill = ensRes.Skill.ToString("G")
                        });
                    }
                }
                return ensembleListItems;
            }
        }
        public List<TheoryResourceListItem> GetTheoryListItems(ICollection<Resource> resources)
        {
            if (resources == null)
                return null;
            else
            {
                var theoryListItems = new List<TheoryResourceListItem>();
                foreach (var res in resources)
                {
                    if (res is TheoryResource)
                    {
                        var ensRes = res as TheoryResource;
                        theoryListItems.Add(new TheoryResourceListItem
                        {
                            ResourceId = ensRes.ResourceId,
                            TeacherId = ensRes.TeacherId,
                            TeacherName = $"{ensRes.Teacher.FirstName} {ensRes.Teacher.LastName}",
                            Title = ensRes.Title,
                            DateCreated = ensRes.DateCreated,
                            IsPublic = ensRes.IsPublic,
                            GradeLevel = ensRes.GradeLevel,
                            Topic = ensRes.Topic.ToString("G")
                        });
                    }
                }
                return theoryListItems;
            }
        }
        public int GetResourcesCount(ICollection<Resource> resources)
        {
            if (resources == null)
                return 0;
            else
                return resources.Count;
        }
        public Resource BuildResourceEntity(IResourceCreate model)
        {
            if (model is TechniqueCreate)
            {
                var techniqueResource = BuildTechniqueResource(model as TechniqueCreate);
                return techniqueResource;
            }
            else if (model is EnsembleCreate)
            {
                var ensembleResource = BuildEnsembleResource(model as EnsembleCreate);
                return ensembleResource;
            }
            else
            {
                var theoryResource = BuildTheoryResource(model as TheoryCreate);
                return theoryResource;
            }
        }

        private EnsembleResource BuildEnsembleResource(EnsembleCreate model)
        {
            var entity = new EnsembleResource();

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.DateCreated = DateTimeOffset.Now;
            entity.IsDownloadable = model.IsDownloadable;
            entity.IsPublic = model.IsPublic;
            entity.TeacherId = model.TeacherId;
            entity.File = _fileHelper.BuildResourceFile(model.File);
            entity.Ensemble = model.Ensemble;
            entity.Skill = model.Skill;
            entity.GradeLevel = model.GradeLevel;

            return entity;
        }
        private TechniqueResource BuildTechniqueResource(TechniqueCreate model)
        {
            var entity = new TechniqueResource();

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.DateCreated = DateTimeOffset.Now;
            entity.IsDownloadable = model.IsDownloadable;
            entity.IsPublic = model.IsPublic;
            entity.TeacherId = model.TeacherId;
            entity.File = _fileHelper.BuildResourceFile(model.File);
            entity.Instrument = model.Instrument;
            entity.Skill = model.Skill;
            entity.GradeLevel = model.GradeLevel;

            return entity;
        }
        private TheoryResource BuildTheoryResource(TheoryCreate model)
        {
            var entity = new TheoryResource();

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.DateCreated = DateTimeOffset.Now;
            entity.IsDownloadable = model.IsDownloadable;
            entity.IsPublic = model.IsPublic;
            entity.TeacherId = model.TeacherId;
            entity.File = _fileHelper.BuildResourceFile(model.File);
            entity.Topic = model.Topic;
            entity.GradeLevel = model.GradeLevel;

            return entity;
        }
    }
}
