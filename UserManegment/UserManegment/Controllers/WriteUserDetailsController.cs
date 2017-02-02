using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManegment.Security;
using UserManegment.Models;
namespace UserManegment.Controllers
{
    public class WriteUserDetailsController : ApiController
    {
        UserDB _db = new UserDB();
        // GET: api/WriteUserDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WriteUserDetails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WriteUserDetails
        public void Post(ReceivedUserDeteails user)
        {

        }

        // PUT: api/WriteUserDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WriteUserDetails/5
        public void Delete(int id)
        {
        }
    }
}
