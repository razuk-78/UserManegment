using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManegment.Security
{
  public class RoleNames
    {
        public static string Create { get { return "create"; } private set { } }
        public static string Read
        {
            get { return "Read"; }
            private set { }
        }
        public static string Write { get { return "write"; } private set { }  }
    }
}