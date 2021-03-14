using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Resources.Saving
{
    public class SaveUserResource
    {   
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "The CPF field must match the standard: xxx.xxx.xxx-xx")]
        public string Cpf { get; set; }
    }
}
