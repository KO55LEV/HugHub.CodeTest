using System.ComponentModel.DataAnnotations;

namespace HugHub.CodeTest.Infrastructure.Models.Configuration
{
    public class QuotationSystem1Settings
    {
        [Required]
        public string QuotationSystem1Url { get; set; }

        [Required]
        public string QuotationSystem1Port { get; set; }
    }
}
