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
        // GET: Resource
        public ActionResult Index()
        {
            return View();
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


        private ResourceService CreateResourceService()
        {
            var userId = this.User.Identity.GetUserId();
            return new ResourceService(userId);
        }
    }
}