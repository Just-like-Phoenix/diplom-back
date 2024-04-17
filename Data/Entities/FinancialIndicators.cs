using System.ComponentModel.DataAnnotations;

namespace diplom_back.Data.Entities
{
    public class FinancialIndicators
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public double Leverage { get; set; }
        public double CoverageRatio { get; set; }
    }
}
