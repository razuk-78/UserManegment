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
            WorkTitels = new List<Models.WorkTitel>();
            Roles = new List<Models.Role>();
            LogInRegistrys = new List<Models.LogInRegistry>();
        }
        
        public ORG Org { get; set; }
        public List<WorkTitel> WorkTitels{get;  set;}
        public List<Role> Roles { get;  set; }
        public List<LogInRegistry> LogInRegistrys { get;  set; }
    }
    //this class will collect all details belong to a specific user in all orgs
  public  class SearchUserInAllOrgs
    {
         
        public SearchUserInAllOrgs() {
         
            this.UserDetails = new List<UserInAllOrgs>();
        }
        public List<UserInAllOrgs> UserInAllOrgs(int _UserId,UserDB _Db)
        {
           if( (this.User = _Db.User.FirstOrDefault(x => x.Id == _UserId)) != null)
            {
                List<int> OrgIds = _Db.UserInOrg.Where(x => x.UserId == this.User.Id).Select(x => x.OrgId).ToList();
                this.UserDetails = new List<UserInAllOrgs>();
                foreach (int i in OrgIds)
                {
                    UserInAllOrgs u = new UserInAllOrgs();
                    u.Org = _Db.ORG.First(x => x.Id == i);
                    foreach (Role r in _Db.Role.Where(x => x.UserInOrg.UserId == this.User.Id && x.UserInOrg.OrgId == i).ToList())
                    {
                        u.Roles.Add(r);
                    }
                    _Db.WorkTitelPointer.Where(x => x.UserInOrg.OrgId == i && x.UserInOrg.UserId == this.User.Id).Select(x => x.WorkTitelId).ToList().ForEach((x) => u.WorkTitels.Add(_Db.WorkTitel.First(z => z.Id == x)));
                    foreach (LogInRegistry l in _Db.LogInRegistry.Where(x => x.UserInOrg.UserId == this.User.Id && x.UserInOrg.OrgId == i).ToList())
                    {
                        u.LogInRegistrys.Add(l);
                    }

                    this.UserDetails.Add(u);
                }
            }
          
            return this.UserDetails;
        }
        List<UserInAllOrgs> UserDetails;
        User User;
       
        
    }
}