using BandTogether.Models.EditProfileModels;
using BandTogether.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandTogether.MVC.Controllers
{
    public class EditProfileController : Controller
    {
        // GET: EditProfile
        [HttpGet]
        [Route(Name = "EditProfile/Detail/{id}")]
        public ActionResult Detail(string id)
        {
            var service = CreateTeacherService();
            var model = service.GetTeacherById(id);
            return View(model);
        }
        [HttpGet]
        [Route(Name = "EditProfile/EditName/{id}")]
        public ActionResult EditName(string id)
        {
            var service = CreateTeacherService();
            var model = service.GetProfileName(id);
            return View(model);
        }
        [HttpPost]
        [Route(Name = "EditProfile/EditName/{id}")]
        public ActionResult EditName(EditProfileName model)
        {
            if (this.ModelState.IsValid)
            {
                var service = CreateTeacherService();
                if (service.UpdateProfileName(model))
                    return RedirectToAction("Detail", new { id = model.TeacherId });
                else
                {
                    this.ModelState.AddModelError("", "Profile name could not be updated.");
                    return View(model);
                }
            }
            else
                return View(model);
        }

        [HttpGet]
        [Route(Name = "EditProfile/EditPicture/{id}")]
        public ActionResult EditPicture(string id)
        {
            return View();
        }
        [HttpPost]
        [Route(Name = "EditProfile/EditPicture/{id}")]
        public ActionResult EditPicture(EditProfilePicture model)
        {
            model.TeacherId = this.User.Identity.GetUserId();

            if (this.ModelState.IsValid && model.Image != null)
            {
                var service = CreateTeacherService();
                if (service.UpdateProfilePicture(model))
                    return RedirectToAction("Detail", new { id = model.TeacherId });
                else
                {
                    this.ModelState.AddModelError("", "Profile picture could not be updated.");
                    return View(model);
                }
            }
            else
                return View(model);
        }

        private TeacherService CreateTeacherService()
        {
            var userId = this.User.Identity.GetUserId();
            return new TeacherService(userId);
        }
    }
}