using System.ComponentModel.DataAnnotations;

namespace Server.Resources.Saving
{
    public class SaveCompanyResource
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string FantasyName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string CompanyName { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$", ErrorMessage = "The CNPJ field must match the standard: xx.xxx.xxx/xxxx-xx")]
        public string Cnpj { get; set; }
    }
}
