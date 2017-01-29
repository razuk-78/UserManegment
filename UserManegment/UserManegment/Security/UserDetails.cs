using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;
namespace UserManegment.Security
{
    //this class will hold all user details in all Orgs,will only be used by the class UserInAllOgrs
    public class UserDetails
    {
   
        public UserDetails() { }
        public ORG Org { get; set; }
        public WorkTitel WorkTitel{get;  set;}
        public List<Role> Role { get;  set; }
        public List<LogInRegistry> LogInRegistry { get;  set; }
    }
    //this class will collect all details belong to a specific user in all orgs
  public  class UserInAllOgrs
    {
        public UserInAllOgrs(int _UserId,UserDB _Db)
        {
            this.User = _Db.User.First(x => x.Id == _UserId);
            List<int> OrgIds = _Db.UserInOrg.Where(x => x.UserId == this.User.Id).Select(x => x.OrgId).ToList();
            
            foreach (int i in OrgIds)
            {
                UserDetails u = new UserDetails();
                u.Org= _Db.ORG.First(x => x.Id == i);
                u.Role = _Db.Role.Where(x => x.UserInOrg.UserId == this.User.Id && x.UserInOrg.OrgId == i).ToList();
                u.WorkTitel = _Db.WorkTitel.First(x => x.UserInOrg.UserId == this.User.Id && x.UserInOrg.OrgId == i);
                u.LogInRegistry = _Db.LogInRegistry.Where(x => x.UserInOrg.UserId == this.User.Id && x.UserInOrg.OrgId == i).ToList();

                this.UserDetails.Add(u);
            }
            
        }
        public User User
        {
            get;private set;
        }
        public List<UserDetails> UserDetails { get; private set; }
    }
}