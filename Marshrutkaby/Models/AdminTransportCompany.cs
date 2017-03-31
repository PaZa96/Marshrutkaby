using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Marshrutkaby.Models
{
    public class AdminTransportCompany
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public int IdTransportCompany { get; set; }

        
    }
}