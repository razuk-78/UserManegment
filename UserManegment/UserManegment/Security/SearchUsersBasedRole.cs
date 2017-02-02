using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;

namespace UserManegment.Security
{
    public class UsersBaesdRoles
    {
        public ORG Org { get; set; }
        public User User { get; set; }
        public List<Role> Role { get; set; }
        public UserInOrg UserInOrg { get; set; }

        public List<LogInRegistry> LogInRegistry { get; set; }
    }
    public class SearchUsersBasedRole
    {

        public List<UsersBaesdRoles> SearchAllUsersInOrg(int OrgId,String RollType,UserDB _db)
        {
            List<UsersBaesdRoles> lu = new List<UsersBaesdRoles>();
            foreach (int useringorgid in  _db.UserInOrg.Where(x => x.OrgId == OrgId).Select(x => x.Id).ToList())
            {
                if (_db.Role.FirstOrDefault(x => x.UserInOrg.Id == useringorgid) != null)
                {
                    lu.Add(new UsersBaesdRoles { User = _db.User.First(z => z.Id == _db.Role.First(x => x.UserInOrg.Id == useringorgid && x.Type == RollType).UserInOrg.UserId) ,Org=_db.ORG.First(z=>z.Id==OrgId),LogInRegistry=_db.LogInRegistry.Where(z=>z.UserInOrg.Id==useringorgid).ToList(),});
                }
                 
            }

          

            

        
            return lu;
        }
        public List<UsersBaesdRoles> SearchAllUsersBasedJobb(int WorkTitelId, int OrgId, UserDB _db)
        {
            List<UsersBaesdRoles> lu = new List<UsersBaesdRoles>();

            foreach (WorkTitelPointer pointer in _db.WorkTitelPointer.Where(x => x.WorkTitelId == WorkTitelId && x.UserInOrg.OrgId == OrgId).ToList())
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
    }
}