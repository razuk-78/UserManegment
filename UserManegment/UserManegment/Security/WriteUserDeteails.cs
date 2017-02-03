using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManegment.Models;
namespace UserManegment.Security
{
    public class ReceivedUserDeteails
    {
        public int UserId { get; set; }
        public int OrgId { get; set; }
       public List<int> WorkTitelsIds { get; set; }
        public List<string> RolesType { get; set; }
    }
    public class WriteReceivedUserDeteails
    {
        
        public static void Write(ReceivedUserDeteails user,UserDB _db)
        {
            UserInOrg userinorg;
            if(_db.User.FirstOrDefault(x=>x.Id==user.UserId)==null)
            {
                throw new Exception("the user is not exist");
            }
            if ((userinorg = _db.UserInOrg.FirstOrDefault(x => x.UserId == user.UserId && x.OrgId == user.OrgId)) == null)
            {
                _db.UserInOrg.Add(new UserInOrg { OrgId = user.OrgId, UserId = user.UserId });
                _db.SaveChanges();
                userinorg = _db.UserInOrg.FirstOrDefault(x => x.UserId == user.UserId && x.OrgId == user.OrgId);
             user.RolesType.ForEach(z => _db.UserInOrg.First(x => x.Id == userinorg.Id).Roles.Add(new Role { Type = z }));
            _db.SaveChanges();
            user.WorkTitelsIds.ForEach(z => _db.UserInOrg.First(x => x.Id == userinorg.Id).WorkTitelPointer.Add(new WorkTitelPointer { WorkTitelId = z }));
            _db.SaveChanges();
            }else
            {
                throw new Exception("the user alredy exist");
            }
            
        }


        public static void Edite(ReceivedUserDeteails user, UserDB _db)
        {
            UserInOrg userinorg;
            if ((userinorg = _db.UserInOrg.FirstOrDefault(x => x.UserId == user.UserId && x.OrgId == user.OrgId)) != null)
            {
                
                userinorg = _db.UserInOrg.FirstOrDefault(x => x.UserId == user.UserId && x.OrgId == user.OrgId);
               
              foreach(Role r in _db.UserInOrg.Find(userinorg.Id).Roles)
                {
                    _db.UserInOrg.Find(userinorg.Id).Roles.Remove(r);
                    _db.SaveChanges();
                }
                foreach (WorkTitelPointer w in _db.UserInOrg.Find(userinorg.Id).WorkTitelPointer)
                {
                    _db.UserInOrg.Find(userinorg.Id).WorkTitelPointer.Remove(w);
                    _db.SaveChanges();
                }
                user.RolesType.ForEach(z => _db.UserInOrg.First(x => x.Id == userinorg.Id).Roles.Add(new Role { Type = z }));
                _db.SaveChanges();
                user.WorkTitelsIds.ForEach(z => _db.UserInOrg.First(x => x.Id == userinorg.Id).WorkTitelPointer.Add(new WorkTitelPointer { WorkTitelId = z }));
                _db.SaveChanges();


            }
            else
            {
                throw new Exception("the user is not exist");
            }

        }
        public static void DeleteOrg(int OrgId,UserDB _db)
        {
            foreach (UserInOrg r in _db.UserInOrg.Where(x=>x.OrgId==OrgId).ToList())
            {
                _db.UserInOrg.Remove(r);
                _db.SaveChanges();
            }
        }
        public static void DeleteUserInOrg(int userId,int OrgId, UserDB _db)
        {
            UserInOrg RemoveUser = _db.UserInOrg.First(x => x.UserId == userId && x.OrgId == OrgId);
            _db.UserInOrg.Remove(RemoveUser);
            _db.SaveChanges();
        }

        public static void DeleteWorkTitle(int WorkTitleId, UserDB _db)
        {
            WorkTitel DeleteWorkTitel = _db.WorkTitel.Find(WorkTitleId);
            _db.WorkTitel.Remove(DeleteWorkTitel);
                _db.SaveChanges();
          
        }
    }
}