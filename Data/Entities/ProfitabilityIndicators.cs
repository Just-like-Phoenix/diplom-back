using System.ComponentModel.DataAnnotations;

namespace diplom_back.Data.Entities
{
    public class ProfitabilityIndicators
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public double ReturnOnAssets { get; set; }
        public double ReturnOnEquity { get; set; }
        public double ReturnOnInvestment { get; set; }
    }
}
