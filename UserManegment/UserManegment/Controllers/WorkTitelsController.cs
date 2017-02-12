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
    public class WorkTitelsController : ApiController
    {
        private UserDB db = new UserDB();

        // GET: api/WorkTitels
        public IHttpActionResult GetWorkTitel(int workid)
        {
            SearchBasedWorkTitel s = new SearchBasedWorkTitel();
            return Ok(s.SearchAllUsersBasedJobb(workid,db));
        }

        public IHttpActionResult GetWorkTitel(int workid,int orgid)
        {
            SearchBasedWorkTitel s = new SearchBasedWorkTitel();
            return Ok(s.SearchAllUsersBasedJobb(workid,orgid, db));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkTitelExists(int id)
        {
            return db.WorkTitel.Count(e => e.Id == id) > 0;
        }
    }
}