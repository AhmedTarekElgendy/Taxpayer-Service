using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Taxpayer.Domain.Enums;

namespace Taxpayer.Domain.Models
{
    public class Taxpayer
    {
 
        public int ID { get; set; }

        
        public string FirstName { get; set; }

        
        public string SecondaryName { get; set; }

        
        public string Phone { get; set; }

        
        public string Address { get; set; }

        
        public string Email { get; set; }

        public LanguageTypes Language { get; set; }

    }
}
