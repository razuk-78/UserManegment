using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace serialize.Controllers
{
    public class person
    {
        public string name { get; set; }
    }
    public class DefaultController : ApiController
    {
        

           public  IHttpActionResult Getwrite(string a)
        {
            StreamWriter _testData = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/data/text.txt"));
          JavaScriptSerializer js = new JavaScriptSerializer();
            
             _testData.WriteLine(js.Serialize(new person { name="razuk"})); // Write the file.
            _testData.Close();
           
            StreamReader st = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/data/text.txt"));
            string stt = st.ReadToEnd();
            st.Close();
            return Ok(stt);
        }
    }
}
