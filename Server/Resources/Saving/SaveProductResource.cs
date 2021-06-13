using System.ComponentModel.DataAnnotations;

namespace Server.Resources.Saving
{
    public class SaveProductResource
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public float Value { get; set; }
        public string Observation { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}