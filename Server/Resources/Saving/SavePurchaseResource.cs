using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Resources.Saving
{
    public class SavePurchaseResource
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Value { get; set; }

        [Required]
        public string Observation { get; set; }
    }
}
