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
        public WorkTitel WorkTitel { get; set; }
        public List<Role> Role { get; set; }
        public List<LogInRegistry> LogInRegistry { get; set; }
    }
    public class OrgUsersDetails
    {

        public OrgUsersDetails(int _OrgId, UserDB _Db)
        {
            this.Org = _Db.ORG.First(x => x.Id == _OrgId);
            List<int> UsersId = _Db.UserInOrg.Where(x => x.UserId == this.User.Id).Select(x => x.OrgId).ToList();

            foreach (int i in UsersId)
            {
                Users u = new Users();
                u.User = _Db.User.First(x => x.Id == i);
                u.Role = _Db.Role.Where(x => x.UserInOrg.UserId == i && x.UserInOrg.OrgId == this.Org.Id).ToList();
                u.WorkTitel = _Db.WorkTitel.First(x => x.UserInOrg.UserId == i && x.UserInOrg.OrgId == this.Org.Id);
                u.LogInRegistry = _Db.LogInRegistry.Where(x => x.UserInOrg.UserId == i && x.UserInOrg.OrgId == this.Org.Id).ToList();

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