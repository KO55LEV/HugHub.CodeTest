using System.ComponentModel.DataAnnotations;

namespace HugHub.CodeTest.Infrastructure.Models.Configuration
{
    public class QuotationSystem3Settings
    {
        [Required]
        public string QuotationSystem3Url { get; set; }

        [Required]
        public string QuotationSystem3Port { get; set; }
    }
}
