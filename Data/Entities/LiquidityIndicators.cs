using System.ComponentModel.DataAnnotations;

namespace diplom_back.Data.Entities
{
    public class LiquidityIndicators
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public double CurrentLiquidity { get; set; }
        public double FastLiquidity { get; set; }
        public double FreeCashFlow { get; set; }
        public double AccountsRecTurnover { get; set; }
        public double ReservesTurnover { get; set; }
        public double AccountsPayTurnover { get; set; }
        public double FinancialCycle { get; set; }
    }
}
