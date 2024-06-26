﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace diplom_back.Data.Entities
{
    [PrimaryKey(nameof(Year), nameof(RegNum))]
    public class OrganizationIndicators
    {
        [Required]
        public int? Year { get; set; }

        [Required]
        [ForeignKey(nameof(RegNum))]
        public int RegNum { get; set; }
        public Organization? Organization { get; set; }

        public Guid LiquidityIndicatorsId { get; set; }
        public LiquidityIndicators? LiquidityIndicators { get; set; }

        public Guid FinancialIndicatorsId { get; set; }
        public FinancialIndicators? FinancialIndicators { get; set; }

        public Guid ProfitabilityIndicatorsId { get; set; }
        public ProfitabilityIndicators? ProfitabilityIndicators { get; set; }
    }
}
