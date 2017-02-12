using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UserManegment.Models;
using UserManegment.Security;
namespace UserManegment.Controllers
{
    public class ORGsController : ApiController
    {
        private UserDB db = new UserDB();

        // GET: api/ORGs
        public IHttpActionResult GetORG(int orgid)
        {
            SearchOrgAllUsersDetails s = new SearchOrgAllUsersDetails();
            return Ok(s.SearchAllUsersDetails(orgid,db));
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORGExists(int id)
        {
            return db.ORG.Count(e => e.Id == id) > 0;
        }
    }
}