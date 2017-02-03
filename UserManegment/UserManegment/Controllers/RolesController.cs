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
    public class RolesController : ApiController
    {
        private UserDB db = new UserDB();

        // GET: api/Roles
        public IHttpActionResult GetRole(string roletype)
        {
            SearchUsersBasedRole s = new SearchUsersBasedRole();
            return Ok(s.SearchAllUsersBasedJobb(roletype,db));
        }
        public IHttpActionResult GetRole(string roletype,int orgid)
        {
            SearchUsersBasedRole s = new SearchUsersBasedRole();
            return Ok(s.SearchAllUsersInOrg(orgid,roletype,db));
        }
        // GET: api/Roles/5


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(int id)
        {
            return db.Role.Count(e => e.Id == id) > 0;
        }
    }
}