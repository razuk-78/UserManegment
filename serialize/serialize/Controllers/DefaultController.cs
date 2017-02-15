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
        

           public  IHttpActionResult Getwrite(string sms)
        {
            StreamWriter stw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/data/text.txt"),true);
            //JavaScriptSerializer js = new JavaScriptSerializer();

            //   _testData.WriteLine(js.Serialize(new person { name="razuk"})); // Write the file.
           
            stw.WriteLine(sms);
            stw.Close();
            StreamReader st = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/data/text.txt"));

            //File.AppendAllText(System.Web.HttpContext.Current.Server.MapPath("~/data/text.txt"),sms);
            string stt = st.ReadToEnd();
            st.Close();
            return Ok();
        }
        public IHttpActionResult Getread()
        {
            StreamReader st = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/data/text.txt"));

            ////File.AppendAllText(System.Web.HttpContext.Current.Server.MapPath("~/data/text.txt"),sms);
            string stt = st.ReadToEnd();
            st.Close();
            return Ok(stt);
        }
    }
}
