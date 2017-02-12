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
    public class WriteUserController : ApiController
    {
        private UserDB db = new UserDB();

        // GET: api/WriteUser
        // 73char {"userid":5,"orgid":1,"rolestype":["read","write"],"worktitelsIds":[1,2]}
        #region FiddlerContent
        // User-Agent: Fiddler
        //  Host: localhost:62119
        //Content-type: application/json
        //Content-Length: 73
        //Accept: Application/json 
        #endregion

        public void Post([FromBody] ReceivedUserDeteails u)
        {

         WriteReceivedUserDeteails.Write(u, db);
            //return Ok(new ReceivedUserDeteails { OrgId = 1, UserId = 1, RolesType = new List<string> { "read", "write" }, WorkTitelsIds = new List<int> { 1, 2 } });
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