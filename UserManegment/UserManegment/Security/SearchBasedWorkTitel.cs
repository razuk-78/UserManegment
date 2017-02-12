using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;
namespace UserManegment.Security
{
    public class UsersBasedWorks
    {

        public UsersBasedWorks()
        {
            Roles = new List<Models.Role>();
            LogInRegistrys = new List<Models.LogInRegistry>();
        }
        public ORG Org { get; set; }
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public List<LogInRegistry> LogInRegistrys { get; set; }
    }
    public class SearchBasedWorkTitel
    {
       //All orgs + user + Role
        public List< UsersBasedWorks> SearchAllUsersBasedJobb(int WorkTitelId,UserDB _db)
        {
            List<UsersBasedWorks> lu = new List<UsersBasedWorks>();
          
        foreach ( WorkTitelPointer pointer in _db.WorkTitelPointer.Where(x => x.WorkTitelId == WorkTitelId).ToList())
            {
                var u = new UsersBasedWorks();
                u.User= _db.User.First(x => x.Id == pointer.UserInOrg.UserId);
                u.Org = _db.ORG.First(x => x.Id == pointer.UserInOrg.OrgId);
                foreach(Role r in _db.Role.Where(x => x.UserInOrg.OrgId == u.Org.Id && x.UserInOrg.UserId == u.User.Id).ToList())
                {
                    u.Roles.Add(r);
                }
                foreach(LogInRegistry l in _db.LogInRegistry.Where(x => x.UserInOrg.OrgId == u.Org.Id && x.UserInOrg.UserId == u.User.Id).ToList())
                {
                    u.LogInRegistrys.Add(l);
                }
                lu.Add(u);
            }

            return lu;
        }

        //All users
        public List< UsersBasedWorks> SearchAllUsersBasedJobb(int WorkTitelId,int OrgId,UserDB _db)
        {
            List<UsersBasedWorks> lu = new List<UsersBasedWorks>();

            foreach (WorkTitelPointer pointer in _db.WorkTitelPointer.Where(x => x.WorkTitelId == WorkTitelId&&x.UserInOrg.OrgId== OrgId).ToList())
            {
                var u = new UsersBasedWorks();
                u.User = _db.User.First(x => x.Id == pointer.UserInOrg.UserId);
                u.Org = _db.ORG.First(x => x.Id == OrgId);
                u.Roles = _db.Role.Where(x => x.UserInOrg.OrgId == OrgId && x.UserInOrg.UserId == u.User.Id).ToList();
                u.LogInRegistrys = _db.LogInRegistry.Where(x => x.UserInOrg.OrgId == OrgId && x.UserInOrg.UserId == u.User.Id).ToList();
                lu.Add(u);
            }
            return lu;
        }


        //All users in all WorkTitle


    }
}