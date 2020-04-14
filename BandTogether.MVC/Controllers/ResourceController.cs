using BandTogether.Models.Interfaces;
using BandTogether.Models.ResourceModels.EnsembleResourceModels;
using BandTogether.Models.ResourceModels.TechniqueResourceModels;
using BandTogether.Models.ResourceModels.TheoryResourceModels;
using BandTogether.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandTogether.MVC.Controllers
{
    [Authorize]
    public class ResourceController : Controller
    {
        public ActionResult NewsFeed()
        {
            var service = CreateResourceService();
            var model = service.GetPublicFollowedResources();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateTechnique()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTechnique(TechniqueCreate model)
        {
            if (this.ModelState.IsValid)
            {
                var service = CreateResourceService();
                if (service.CreateResource(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "Resource could not be uploaded.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult CreateEnsemble()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEnsemble(EnsembleCreate model)
        {
            if (this.ModelState.IsValid)
            {
                var service = CreateResourceService();
                if (service.CreateResource(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "Resource could not be uploaded.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult CreateTheory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTheory(TheoryCreate model)
        {
            if (this.ModelState.IsValid)
            {
                var service = CreateResourceService();
                if (service.CreateResource(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "Resource could not be uploaded.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult File(int id)
        {
            var service = CreateFileService();

            var file = service.GetFileById(id);

            return File(file.Data, file.ContentType);
        }

        public ActionResult EditTechnique(TechniqueEdit model)
        {
            var service = CreateResourceService();
            if (service.UpdateResource(model))
            {
                return RedirectToAction("Detail", new { id = model.ResourceId });
            }
            else
            {
                return RedirectToAction("Detail", new { id = model.ResourceId });
            }

        }
        public ActionResult EditEnsemble(EnsembleEdit model)
        {
            var service = CreateResourceService();
            if (service.UpdateResource(model))
            {
                return RedirectToAction("Detail", new { id = model.ResourceId });
            }
            else
            {
                return RedirectToAction("Detail", new { id = model.ResourceId });
            }

        }
        public ActionResult EditTheory(TheoryEdit model)
        {
            var service = CreateResourceService();
            if (service.UpdateResource(model))
            {
                return RedirectToAction("Detail", new { id = model.ResourceId });
            }
            else
            {
                return RedirectToAction("Detail", new { id = model.ResourceId });
            }

        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var service = CreateResourceService();
            var model = service.GetResourceById(id);


            if (model is TechniqueDetail)
            {
                var technique = (TechniqueDetail)model;
                var file = File(technique.FileData, technique.ContentType);
                ViewBag.File = file;
                return View("TechniqueDetail", model);
            }
            else if (model is EnsembleDetail)
                return View("EnsembleDetail", model);
            else
                return View("TheoryDetail", model);
        }

        [HttpGet]
        public ActionResult Download(int id)
        {
            var service = CreateFileService();
            var file = service.GetFileById(id);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = file.FileName,
                Inline = false,
            };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(file.Data, file.ContentType);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var service = CreateResourceService();
            if (service.DeleteResource(id))
            {
                return RedirectToAction("Detail", "Teacher", new { id = this.User.Identity.GetUserId() });
            }
            else
            {
                return RedirectToAction("Detail", "Teacher", new { id = this.User.Identity.GetUserId() });
            }
        }

        private ResourceService CreateResourceService()
        {
            var userId = this.User.Identity.GetUserId();
            return new ResourceService(userId);
        }
        private FileService CreateFileService()
        {
            var userId = this.User.Identity.GetUserId();
            return new FileService(userId);
        }
    }
}