namespace RentCalculatorApi.Models;

public class YearlyRentInfo
{
    public int Year { get; set; }
    public decimal BaseRent { get; set; }
    public decimal SalesRevenue { get; set; }
    public decimal Tier1Rent { get; set; }
    public decimal Tier2Rent { get; set; }
    public decimal Tier3Rent { get; set; }
    public decimal TotalPercentageRent => Tier1Rent + Tier2Rent + Tier3Rent;
    public decimal TotalRent => BaseRent + TotalPercentageRent;

}
