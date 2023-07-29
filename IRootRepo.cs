using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
namespace Cabsystem.Repository
{
    interface IRootRepo
    {
        List<Root_Model> GetAllRootlist();
        Root_Model Edit_Root_byID(int RootID);
        string SaveRoot(Root_Model ph);
        string UpdateRoot(Root_Model ph);
        string DeleteRoot(int RootID);
        List<Dropdownlist> Getddl_RootNolist();

            
    }
}
