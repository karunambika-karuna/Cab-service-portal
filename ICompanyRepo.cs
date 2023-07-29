using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
namespace Cabsystem.Repository
{
    interface ICompanyRepo
    {
        List<Company_Model> GetAllCompanylist();
        Company_Model Edit_Company_byCmpId(int CompanyID);
        string SaveCompany(Company_Model ph);
        string UpdateCompany(Company_Model ph);
        string DeleteCompany(int CompanyID);
        
        List<Dropdownlist> ddlCompanylist();
    }




}
