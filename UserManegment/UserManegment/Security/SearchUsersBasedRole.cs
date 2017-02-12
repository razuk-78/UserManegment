using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;

namespace UserManegment.Security
{
    public class UsersBaesdRoles
    {
        public UsersBaesdRoles() {
            WorkTitels = new List<Models.WorkTitel>();
            User = new User();
            LogInRegistry = new List<Models.LogInRegistry>();
        }
       public ORG Org { get; set; }
        public User User { get; set; }
        public List<WorkTitel> WorkTitels { get; set; }
        public List<LogInRegistry> LogInRegistry { get; set; }
    }
    public class SearchUsersBasedRole
    {

        public List<UsersBaesdRoles> SearchAllUsersInOrg(int OrgId,String RollType,UserDB _db)
        {
            
            List<UsersBaesdRoles> lu = new List<UsersBaesdRoles>();
            foreach (UserInOrg useringorg in  _db.UserInOrg.Where(x => x.OrgId == OrgId).ToList())
            {
                UsersBaesdRoles u = new UsersBaesdRoles();
    

                if (_db.Role.FirstOrDefault(x => x.UserInOrg.OrgId == useringorg.OrgId&&x.UserInOrg.UserId==useringorg.UserId&&x.Type==RollType) != null)
                {
                  
                    u.User = _db.User.FirstOrDefault(x => x.Id == useringorg.UserId);
                foreach(LogInRegistry l in  _db.LogInRegistry.Where(z => z.UserInOrg.Id == useringorg.Id).ToList())
                    {
                        u.LogInRegistry.Add(l);
                    }
                    _db.WorkTitelPointer.Where(x => x.UserInOrg.Id == useringorg.Id).ToList().ForEach(x => u.WorkTitels.Add(x.WorkTitel));
                  
                }
                lu.Add(u);
            }    
            return lu;
        }
        public List<UsersBaesdRoles> SearchAllUsersBasedJobb(String RoleType, UserDB _db)
        {
            List<UsersBaesdRoles> lu = new List<UsersBaesdRoles>();
           
            foreach ( UserInOrg userinorg in _db.Role.Where(x => x.Type == RoleType).Select(x => x.UserInOrg).ToList())
            {
                UsersBaesdRoles u = new UsersBaesdRoles();
                
                u.Org = _db.ORG.First(x => x.Id == userinorg.OrgId);
                u.User = _db.User.First(x => x.Id == userinorg.UserId);
                _db.WorkTitelPointer.Where(x => x.userInOrgId == userinorg.Id).ToList().ForEach(x => u.WorkTitels.Add(x.WorkTitel));
                
               
               
                foreach(LogInRegistry l in  _db.LogInRegistry.Where(z => z.UserInOrg.Id == userinorg.Id).ToList())
                {
                    u.LogInRegistry.Add(l);
                }
               
                lu.Add(u);
            }
            return lu;
        }
    }
}