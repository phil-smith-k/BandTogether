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
            var service = CreateTeacherService();
            if (service.UpdateProfileName(model))
            {
                return RedirectToAction("Detail/{id}");
            }
            else
            {
                return View(model);
            }
        }

        private TeacherService CreateTeacherService()
        {
            var userId = this.User.Identity.GetUserId();
            return new TeacherService(userId);
        }
    }
}