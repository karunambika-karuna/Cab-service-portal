using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
namespace Cabsystem.Repository
{
    interface ILoginRepo
    {
        public List<Login_Model> GetAllUserList();
        Login_Model Edit_Login_ByID(int UserID);
        void SaveLogin(Login_Model ph);
        void UpdateLogin(Login_Model ph);
        void DeleteLogin(int LoginID);

        string CheckLogin(string UserName, string Password);

        
         
    }
}
