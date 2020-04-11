using BandTogether.Models.SchoolModels;
using BandTogether.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandTogether.MVC.Controllers
{
    public class SchoolController : Controller
    {
        [HttpPost]
        public ActionResult AddSchool(SchoolCreate model)
        {
            if (this.ModelState.IsValid)
            {
                var service = CreateSchoolService();
                if (service.AddSchoolToTeacher(model))
                {
                    TempData["SaveResult"] = "School was successfully removed.";
                    return RedirectToAction("Detail", "EditProfile", new { id = this.User.Identity.GetUserId() });
                }
                else
                {
                    TempData["ErrorMessage"] = "School could not be added. Try again.";
                    return RedirectToAction("Detail", new { id = model.TeacherId });
                }
            }
            else
            {
                TempData["ErrorMessage"] = "School could not be added. Try again.";
                return RedirectToAction("Detail", new { id = model.TeacherId });
            }

        }

        [HttpPost]
        public ActionResult EditSchool(SchoolEdit model)
        {
            if (this.ModelState.IsValid)
            {
                var service = CreateSchoolService();
                if (service.UpdateSchool(model))
                {
                    return RedirectToAction("Detail", "EditProfile", new { id = this.User.Identity.GetUserId() });
                }
                else
                {
                    TempData["ErrorMessage"] = "School could not be updated. Try again.";
                    return RedirectToAction("Detail", new { id = model.TeacherId });
                }
            }
            else
            {
                TempData["ErrorMessage"] = "School could not be updated. Try again.";
                return RedirectToAction("Detail", new { id = model.TeacherId });
            }
        }

        [HttpPost]
        public ActionResult DeleteSchool(int id)
        {
            var service = CreateSchoolService();
            if (service.DeleteSchool(id))
            {
                TempData["SaveResult"] = "School was successfully removed.";
                return RedirectToAction("Detail", "EditProfile", new { id = this.User.Identity.GetUserId() });
            }
            else
            {
                TempData["ErrorMessage"] = "School could not be removed.";
                return RedirectToAction("Detail", new { id = this.User.Identity.GetUserId() });
            }
        }

        private SchoolService CreateSchoolService()
        {
            var userId = this.User.Identity.GetUserId();
            return new SchoolService(userId);
        }
    }
}