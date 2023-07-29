using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsystem.Models
{
    public class Staff_Model
    {
        public string StaffID {get; set;}
        [Required]
        public string StfName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string AltContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Pickup { get; set; }
        [Required]
        public string DropTo { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string CompanyID { get; set; }

    }

}
