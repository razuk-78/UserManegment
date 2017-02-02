using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;
namespace UserManegment.Security
{
    //this class will hold all user details in all Orgs,will only be used by the class UserInAllOgrs
    public class UserInAllOrgs
    {
   public UserInAllOrgs()
        {
            WorkTitel = new List<Models.WorkTitel>();
            Role = new List<Models.Role>();
            LogInRegistry = new List<Models.LogInRegistry>();
        }
        
        public ORG Org { get; set; }
        public List<WorkTitel> WorkTitel{get;  set;}
        public List<Role> Role { get;  set; }
        public List<LogInRegistry> LogInRegistry { get;  set; }
    }
    //this class will collect all details belong to a specific user in all orgs
  public  class SearchUserInAllOrgs
    {
       public  List<UserInAllOrgs> UserDetails;
        public SearchUserInAllOrgs(int _UserId,UserDB _Db)
        {
            this.User = _Db.User.First(x => x.Id == _UserId);
            List<int> OrgIds = _Db.UserInOrg.Where(x => x.UserId == this.User.Id).Select(x => x.OrgId).ToList();
           this.UserDetails = new List<UserInAllOrgs>();
            foreach (int i in OrgIds)
            {
                UserInAllOrgs u = new UserInAllOrgs();
                u.Org= _Db.ORG.First(x => x.Id == i);
                u.Role = _Db.Role.Where(x => x.UserInOrg.UserId == this.User.Id && x.UserInOrg.OrgId == i).ToList();
                _Db.WorkTitelPointer.Where(x => x.UserInOrg.OrgId == i && x.UserInOrg.UserId == this.User.Id).Select(x => x.Id).ToList().ForEach((x) => u.WorkTitel.Add(_Db.WorkTitel.First(z => z.Id == x)));
                u.LogInRegistry = _Db.LogInRegistry.Where(x => x.UserInOrg.UserId == this.User.Id && x.UserInOrg.OrgId == i).ToList();

                this.UserDetails.Add(u);
            }
            
        }
        public User User
        {
            get;private set;
        }
        
    }
}