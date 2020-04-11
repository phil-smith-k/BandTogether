using BandTogether.Models.EditProfileModels;
using BandTogether.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            ViewBag.Schools = CreateSchoolService().GetTeachersSchools(id).ToList();

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
                {
                    TempData["SaveResult"] = "Your name was successfully updated.";
                    return RedirectToAction("Detail", new { id = model.TeacherId });
                }
                else
                {
                    TempData["ErrorMessage"] = "Your name could not be updated.";
                    return RedirectToAction("Detail", new { id = model.TeacherId });
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Your name could not be updated.";
                return RedirectToAction("Detail", new { id = model.TeacherId });
            }
        }
        [HttpPost]
        [Route(Name = "EditProfile/EditPicture/{id}")]
        public ActionResult EditPicture(EditProfilePicture model)
        {
            model.TeacherId = this.User.Identity.GetUserId();

            if (this.ModelState.IsValid && model.Image != null)
            {
                if (IsImage(model.Image))
                {
                    var service = CreateTeacherService();
                    if (service.UpdateProfilePicture(model))
                    {
                        TempData["SaveResult"] = "Your picture was successfully updated.";
                        return RedirectToAction("Detail", new { id = model.TeacherId });
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Profile picture could not be updated.";
                        return RedirectToAction("Detail", new { id = model.TeacherId });
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Please select an image file.";
                    return RedirectToAction("Detail", new { id = model.TeacherId });
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Profile picture could not be updated.";
                return RedirectToAction("Detail", new { id = model.TeacherId });
            }
        }

        private TeacherService CreateTeacherService()
        {
            var userId = this.User.Identity.GetUserId();
            return new TeacherService(userId);
        }
        private SchoolService CreateSchoolService()
        {
            var userId = this.User.Identity.GetUserId();
            return new SchoolService(userId);
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            int ImageMinimumBytes = 512;

            if (!string.Equals(file.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(file.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(file.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(file.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(file.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(file.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            var postedFileExtension = Path.GetExtension(file.FileName);
            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            try
            {
                if (!file.InputStream.CanRead)
                {
                    return false;
                }
                if (file.ContentLength < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[ImageMinimumBytes];
                file.InputStream.Read(buffer, 0, ImageMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(file.InputStream))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                file.InputStream.Position = 0;
            }

            return true;
        }
    }
}