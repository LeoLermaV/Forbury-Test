using Microsoft.AspNetCore.Mvc;
using RentCalculatorApi.Models;


namespace RentCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentCalculatorController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<YearlyRentInfo>> CalculateRent([FromBody] TenantInfo tenantInfo)
        {
            var yearlyRents = CalculateYearlyRents(tenantInfo);
            return Ok(yearlyRents);
        }

        private List<YearlyRentInfo> CalculateYearlyRents(TenantInfo tenantInfo)
        {
            List<YearlyRentInfo> yearlyRents = new List<YearlyRentInfo>();

            decimal currentSales = tenantInfo.YearOneSales;
            for (int year = 1; year <= 10; year++)
            {
                decimal baseRent = year <= 5 ? tenantInfo.BaseRentFirstFiveYears : tenantInfo.BaseRentLastFiveYears;
                decimal salesThresholdTier1 = baseRent / 0.08m; // Tier 1 start
                decimal salesThresholdTier2 = baseRent / 0.04m; // Tier 2 start
                decimal salesThresholdTier3 = baseRent / 0.02m; // Tier 3 start

                decimal tier1Rent = 0, tier2Rent = 0, tier3Rent = 0;

                // Calculate Tier 1 Rent
                if (currentSales > salesThresholdTier1)
                {
                    tier1Rent = Math.Min(currentSales, salesThresholdTier2) - salesThresholdTier1;
                    tier1Rent = tier1Rent * tenantInfo.Tier1Rate / 100;
                }

                // Calculate Tier 2 Rent
                if (currentSales > salesThresholdTier2)
                {
                    tier2Rent = Math.Min(currentSales, salesThresholdTier3) - salesThresholdTier2;
                    tier2Rent = tier2Rent * tenantInfo.Tier2Rate / 100;
                }

                // Calculate Tier 3 Rent
                if (currentSales > salesThresholdTier3)
                {
                    tier3Rent = (currentSales - salesThresholdTier3) * tenantInfo.Tier3Rate / 100;
                }

                yearlyRents.Add(new YearlyRentInfo
                {
                    Year = year,
                    BaseRent = baseRent,
                    SalesRevenue = currentSales,
                    Tier1Rent = tier1Rent,
                    Tier2Rent = tier2Rent,
                    Tier3Rent = tier3Rent
                });

                // Project sales for the next year
                currentSales *= 1 + tenantInfo.AnnualSalesGrowth / 100;
            }

            return yearlyRents;
        }
    }
}
