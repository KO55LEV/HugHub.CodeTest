using System.ComponentModel.DataAnnotations;

namespace HugHub.CodeTest.Infrastructure.Models.Configuration
{
    public class QuotationSystem2Settings
    {
        [Required]
        public string QuotationSystem2Url { get; set; }

        [Required]
        public string QuotationSystem2Port { get; set; }
    }
}
