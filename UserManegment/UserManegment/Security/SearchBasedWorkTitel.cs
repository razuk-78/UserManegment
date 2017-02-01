using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;
namespace UserManegment.Security
{
    public class UsersBaedWorks
    {

        public UsersBaedWorks() { }
        public ORG Org { get; set; }
        public User User { get; set; }
        public List<Role> Role { get; set; }
        public List<LogInRegistry> LogInRegistry { get; set; }
    }
    public class SearchBasedWorkTitel
    {
       //All orgs + user + Role
        public List< UsersBaedWorks> SearchAllUsersBasedJobb(int WorkTitelId,UserDB _db)
        {
            List<UsersBaedWorks> lu = new List<UsersBaedWorks>();
          
        foreach ( WorkTitelPointer pointer in _db.WorkTitelPointer.Where(x => x.WorkTitelId == WorkTitelId).ToList())
            {
                var u = new UsersBaedWorks();
                u.User= _db.User.First(x => x.Id == pointer.UserInOrg.UserId);
                u.Org = _db.ORG.First(x => x.Id == pointer.UserInOrg.OrgId);
                u.Role = _db.Role.Where(x => x.UserInOrg.OrgId == u.Org.Id && x.UserInOrg.UserId == u.User.Id).ToList();
                u.LogInRegistry= _db.LogInRegistry.Where(x => x.UserInOrg.OrgId == u.Org.Id && x.UserInOrg.UserId == u.User.Id).ToList();
                lu.Add(u);
            }

            return lu;
        }

        //All users
        public List< UsersBaedWorks> SearchAllUsersBasedJobb(int WorkTitelId,int OrgId,UserDB _db)
        {
            List<UsersBaedWorks> lu = new List<UsersBaedWorks>();

            foreach (WorkTitelPointer pointer in _db.WorkTitelPointer.Where(x => x.WorkTitelId == WorkTitelId&&x.UserInOrg.OrgId== OrgId).ToList())
            {
                var u = new UsersBaedWorks();
                u.User = _db.User.First(x => x.Id == pointer.UserInOrg.UserId);
                u.Org = _db.ORG.First(x => x.Id == OrgId);
                u.Role = _db.Role.Where(x => x.UserInOrg.OrgId == OrgId && x.UserInOrg.UserId == u.User.Id).ToList();
                u.LogInRegistry = _db.LogInRegistry.Where(x => x.UserInOrg.OrgId == OrgId && x.UserInOrg.UserId == u.User.Id).ToList();
                lu.Add(u);
            }
            return lu;
        }


        //All users in all WorkTitle


    }
}