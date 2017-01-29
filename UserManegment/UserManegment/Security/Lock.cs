using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Filters;
using UserManegment.Controllers;
using UserManegment.Models;
using UserManegment.Security;
namespace UserManegment.Security
{
   

    public class Lock: AuthorizationFilterAttribute
    {
        String i;
        public Lock(String ii)
        {
            i = ii;
        }
      
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try

            {

                string s = actionContext.ControllerContext.Request.RequestUri.AbsoluteUri;

               string ss= HttpUtility.ParseQueryString(s).Get("http://localhost:62119/api/users?role");
                actionContext.Response = actionContext.Request
                    .CreateResponse(ss);
                
            }
            catch
            {

            }
           
           


        }

    }

}