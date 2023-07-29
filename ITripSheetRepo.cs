using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cabsystem.Models;
namespace Cabsystem.Repository
{
    interface ITripSheetRepo
    {
        List<TripSheet_Model> GetAllTripSheetlist();
        TripSheet_Model Edit_TripSheet_byTSId(int TSID);
        string SaveTS(TripSheet_Model ph);
        string UpdateTS(TripSheet_Model ph);
        string DeleteTS(int TSID);
        List<TripSheet_Model> TripSheet_Rpt(string FromDate,string ToDate);
    }
}
