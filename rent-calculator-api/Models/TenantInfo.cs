namespace RentCalculatorApi.Models;

  public class TenantInfo
    {
        public decimal YearOneSales { get; set; }
        public decimal BaseRentFirstFiveYears { get; set; }
        public decimal BaseRentLastFiveYears { get; set; }
        public decimal Tier1Rate { get; set; }
        public decimal Tier2Rate { get; set; }
        public decimal Tier3Rate { get; set; }
        public decimal AnnualSalesGrowth { get; set; }
    }