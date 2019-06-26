using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL1;

namespace BLL1
{
    public class Admin
    {
        public static bool ValidateAdmin(string Email,string Password)
        {
            return AdminDAL.ValidateAdmin(Email,Password);
        }
        public static bool RegisterAdmin(int Id, string Email, string Password)
        {
            return AdminDAL.Register(Id,Email,Password);
        }
        public static bool Update(int Id,string Password)
        {
            return AdminDAL.Update(Id, Password);
        }
        public static bool Delete(int Id)
        {
            return AdminDAL.Delete(Id);
        }
    }
}
