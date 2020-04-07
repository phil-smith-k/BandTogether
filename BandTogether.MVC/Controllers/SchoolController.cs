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
                    return RedirectToAction("Detail", "EditProfile", new { id = this.User.Identity.GetUserId() });
                }
                else
                {
                    return Json(new
                    {
                        status = "failure",
                        formErrors = this.ModelState.Select(kvp => new { key = kvp.Key, errors = kvp.Value.Errors.Select(e => e.ErrorMessage) })
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = "failure",
                    formErrors= this.ModelState.Select(kvp => new { key = kvp.Key, errors = kvp.Value.Errors.Select(e => e.ErrorMessage)})
                });
            }

        }
        private SchoolService CreateSchoolService()
        {
            var userId = this.User.Identity.GetUserId();
            return new SchoolService(userId);
        }
    }
}