using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UserManegment.Models;
using UserManegment.Security;


namespace UserManegment.Controllers
{
    public class UserMangementController : ApiController
    {
        private UserDB db = new UserDB();

        public IHttpActionResult GetAllUsers(int OrgId)
        {
            return Ok();
        }
        public IHttpActionResult GetAllUsers()
        {
            return Ok(db.User.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
