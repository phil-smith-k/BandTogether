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
        public ActionResult CreateEnsemble(TheoryCreate model)
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

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var service = CreateResourceService();
            var model = service.GetResourceById(id);

            if (model is TechniqueDetail)
                return View("TechniqueDetail", model);
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