using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsystem.Models
{
    public class Company_Model
    {
        public string CompanyID { get; set; }

        [Required]
        public string CompanyName { get; set; }
        [Required]


        public string ContactPerson { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Payment_Mode { get; set; }
        [Required]
        public string Payment_Type { get; set; }
      
       

        [Required]
        public string SelectedStatus { get; set; }



    }
}
