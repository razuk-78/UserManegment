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
using System.Web.Script.Serialization;
using System.Web.Http.Cors;

namespace UserManegment.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UserDB db = new UserDB();

        // GET: api/Users
        
        public IHttpActionResult Getme()
        {
           
            return Ok(db.User.ToList());
        }
       
        //public IHttpActionResult GetUser(int workId,int orgId)
        //{
        //    SearchBasedWorkTitel u = new SearchBasedWorkTitel();          
        //    return Ok(u.SearchAllUsersBasedJobb(workId,orgId,db) );
        //}
        public IHttpActionResult GetUser(int userid)
        {
            SearchUserInAllOrgs u = new SearchUserInAllOrgs();
            return Ok(u.UserInAllOrgs(userid,db));
        }

  
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.User.Count(e => e.Id == id) > 0;
        }
    }
}