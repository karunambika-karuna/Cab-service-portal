using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsystem.Models
{
    public class Root_Model
    {
        public string RootID { get; set; }
        [Required]
        public string RootNo { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Stops { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
