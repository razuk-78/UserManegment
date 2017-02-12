using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;
namespace UserManegment.Security
{
    public class UsersInOrg
    {     public UsersInOrg()
        {
            WorkTitel = new List<Models.WorkTitel>();Roles = new List<Models.Role>();User = new User();
            LogInRegistrys = new List<Models.LogInRegistry>();
        }
        public User User { get; set; }
        public List<WorkTitel> WorkTitel { get; set; }
        public List<Role> Roles { get; set; }
        public List<LogInRegistry> LogInRegistrys { get; set; }
    }
    public class SearchOrgAllUsersDetails
    {
        //All users + Roles + Worktitle + LogIN
        public List<UsersInOrg> SearchAllUsersDetails(int _OrgId, UserDB _Db)
        {
            this.Org = _Db.ORG.First(x => x.Id == _OrgId);
            List<int> UsersId = _Db.UserInOrg.Where(x => x.OrgId == _OrgId).Select(x => x.UserId).ToList();
            this.Users = new List<UsersInOrg>();
            foreach (int UserId in UsersId)
            {
                UsersInOrg u = new UsersInOrg();
                u.User = _Db.User.First(x => x.Id == UserId);
               foreach(Role r in  _Db.Role.Where(x => x.UserInOrg.UserId == UserId && x.UserInOrg.OrgId == this.Org.Id).ToList())
                {
                    u.Roles.Add(r);
                }
                _Db.WorkTitelPointer.Where(x => x.UserInOrg.UserId == UserId && x.UserInOrg.OrgId == this.Org.Id).Select(x => x.WorkTitelId).ToList().ForEach((x)=>u.WorkTitel.Add(_Db.WorkTitel.First(z=>z.Id==x)));
              foreach(LogInRegistry l in _Db.LogInRegistry.Where(x => x.UserInOrg.UserId == UserId && x.UserInOrg.OrgId == this.Org.Id).ToList())
                {
                    u.LogInRegistrys.Add(l);
                }

                this.Users.Add(u);
            }
            return this.Users;
        }
        public ORG Org
        {
            get; private set;
        }
         List<UsersInOrg> Users { get; set; }


    }
}