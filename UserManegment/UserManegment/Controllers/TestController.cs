using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManegment.Security;

namespace UserManegment.Controllers
{
    public class TestController : ApiController
    {
     
       public IHttpActionResult Getaccept()
        {
            
            return Ok("you have  access");
        }
        public IHttpActionResult Postreject()
        {

            return Ok("you have no access");
        }
    }
}
