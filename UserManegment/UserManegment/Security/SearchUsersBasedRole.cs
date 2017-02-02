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
        //public List<Role> Role { get; set; }
        public UserInOrg UserInOrg { get; set; }
        public List<WorkTitel> WorkTitels { get; set; }
        public List<LogInRegistry> LogInRegistry { get; set; }
    }
    public class SearchUsersBasedRole
    {

        public List<UsersBaesdRoles> SearchAllUsersInOrg(int OrgId,String RollType,UserDB _db)
        {
            
            List<UsersBaesdRoles> lu = new List<UsersBaesdRoles>();
            foreach (int useringorgid in  _db.UserInOrg.Where(x => x.OrgId == OrgId).Select(x => x.Id).ToList())
            {
                UsersBaesdRoles user = new UsersBaesdRoles();
        List<WorkTitel> WorkTitels = new List<WorkTitel>();

                if (_db.Role.FirstOrDefault(x => x.UserInOrg.Id == useringorgid) != null)
                {
                    user.User = _db.User.First(z => z.Id == _db.Role.First(x => x.UserInOrg.Id == useringorgid && x.Type == RollType).UserInOrg.UserId);
                    user.LogInRegistry = _db.LogInRegistry.Where(z => z.UserInOrgId == useringorgid).ToList();
                    _db.WorkTitelPointer.Where(x => x.userInOrgId == useringorgid).ToList().ForEach(x => WorkTitels.Add(x.WorkTitel));
                    user.WorkTitels = WorkTitels;
                }
                 
            }

          

            

        
            return lu;
        }
        public List<UsersBaesdRoles> SearchAllUsersBasedJobb(String RoleType, UserDB _db)
        {
            List<UsersBaesdRoles> lu = new List<UsersBaesdRoles>();
           
            foreach ( UserInOrg userinorg in _db.Role.Where(x => x.Type == RoleType).Select(x => x.UserInOrg).ToList())
            {
                UsersBaesdRoles user = new UsersBaesdRoles();
                List<WorkTitel> WorkTitels = new List<WorkTitel>();
                user.Org = _db.ORG.First(x => x.Id == userinorg.OrgId);
                user.User = _db.User.First(x => x.Id == userinorg.UserId);
                _db.WorkTitelPointer.Where(x => x.userInOrgId == userinorg.Id).ToList().ForEach(x => WorkTitels.Add(x.WorkTitel));
                user.WorkTitels = WorkTitels;
                user.LogInRegistry = _db.LogInRegistry.Where(z => z.UserInOrgId == userinorg.Id).ToList();
                lu.Add(user);
            }
            return lu;
        }
    }
}