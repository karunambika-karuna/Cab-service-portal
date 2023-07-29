using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsystem.Models
{
    public class Vehcile_Model
    {
        public string VehicleID { get; set; }
        [Required]
        public string Vehicle_type { get; set; }
        [Required]
        public string No_of_Seats { get; set; }
        [Required]
        public string VName { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
