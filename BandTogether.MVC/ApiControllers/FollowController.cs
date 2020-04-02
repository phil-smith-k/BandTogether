using BandTogether.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BandTogether.MVC.ApiControllers
{
    [Authorize]
    [RoutePrefix("api/follow")]
    public class FollowController : ApiController
    {
        [Route("{id}/follow")]
        [HttpPut]
        public bool Follow(string id)
        {
            var userId = this.User.Identity.GetUserId();
            var service = new TeacherService(userId);

            return service.AddTeacherToFollowing(id);
        }

        [Route("{id}/follow")]
        [HttpDelete]
        public bool UnFollow(string id) 
        {
            var userId = this.User.Identity.GetUserId();
            var service = new TeacherService(userId);

            return service.RemoveTeacherFromFollowing(id);
        }
    }
}
