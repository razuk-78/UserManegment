using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;
namespace UserManegment.Security
{
    public class Users
    {

       
        public User User { get; set; }
        public List<WorkTitel> WorkTitel { get; set; }
        public List<Role> Role { get; set; }
        public List<LogInRegistry> LogInRegistry { get; set; }
    }
    public class OrgUsersDetails
    {

        public OrgUsersDetails(int _OrgId, UserDB _Db)
        {
            this.Org = _Db.ORG.First(x => x.Id == _OrgId);
            List<int> UsersId = _Db.UserInOrg.Where(x => x.OrgId == _OrgId).Select(x => x.OrgId).ToList();

            foreach (int UserId in UsersId)
            {
                Users u = new Users();
                u.User = _Db.User.First(x => x.Id == UserId);
                u.Role = _Db.Role.Where(x => x.UserInOrg.UserId == UserId && x.UserInOrg.OrgId == this.Org.Id).ToList();
                _Db.WorkTitelPointer.Where(x => x.UserInOrg.UserId == UserId && x.UserInOrg.OrgId == this.Org.Id).Select(x => x.Id).ToList().ForEach((x)=>u.WorkTitel.Add(_Db.WorkTitel.First(z=>z.Id==x)));
                u.LogInRegistry = _Db.LogInRegistry.Where(x => x.UserInOrg.UserId == UserId && x.UserInOrg.OrgId == this.Org.Id).ToList();

                this.Users.Add(u);
            }

        }
        public ORG Org
        {
            get; private set;
        }
        public List<Users> Users { get; private set; }


    }
}