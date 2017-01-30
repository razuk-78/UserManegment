using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;

namespace UserManegment.Security
{
    public class UserDetails3
    {
        public ORG Org { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public UserInOrg UserInOrg { get; set; }

        public List<LogInRegistry> LogInRegistry { get; set; }
    }
    public class SearchUsersBasedRole
    {

        public List<UserDetails3> SearchAllUsersInOrg(int OrgId,RoleEnum RolType,UserDB _db)
        {
     
           foreach(int i in  _db.UserInOrg.Where(x => x.OrgId == OrgId).Select(x => x.Id).ToList())
            {
                if (_db.Role.First(x => x.UserInOrg.Id == i) != null)
                {
                    _db.Role.First(x => x.UserInOrg.Id == i&&x.Type).UserInOrg.UserId
                }
                 
            }

          

            List<UserDetails3> lu = new List<UserDetails3>();

            foreach (WorkTitelPointer pointer in _db.WorkTitelPointer.Where(x => x.WorkTitelId == WorkTitelId).ToList())
            {
             
                u.User = _db.User.First(x => x.Id == pointer.UserInOrg.UserId);
                u.Org = _db.ORG.First(x => x.Id == pointer.UserInOrg.OrgId);
                u.Role = _db.Role.Where(x => x.UserInOrg.OrgId == u.Org.Id && x.UserInOrg.UserId == u.User.Id).ToList();
                u.LogInRegistry = _db.LogInRegistry.Where(x => x.UserInOrg.OrgId == u.Org.Id && x.UserInOrg.UserId == u.User.Id).ToList();
                lu.Add(u);
            }

            return lu;
        }
        public List<UserDetails3> SearchAllUsersBasedJobb(int WorkTitelId, int OrgId, UserDB _db)
        {
            List<UserDetails3> lu = new List<UserDetails3>();

            foreach (WorkTitelPointer pointer in _db.WorkTitelPointer.Where(x => x.WorkTitelId == WorkTitelId && x.UserInOrg.OrgId == OrgId).ToList())
            {
                var u = new UserDetails1();
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