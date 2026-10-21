using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib
{
    public class AnalyticsService
    {
        private SaleRepository saleRepo;

        public AnalyticsService(SaleRepository repo)
        {
            saleRepo = repo;
        }

        public decimal CalculateRevenue(DateTime startDate, DateTime endDate)
        {
            var sales = saleRepo.GetSalesByPeriod(startDate, endDate);
            return sales?.Sum(s => s.TotalAmount) ?? 0;
        }

        public Dictionary<DateTime, decimal> GroupSalesByDays(DateTime startDate, DateTime endDate)
        {
            var sales = saleRepo.GetSalesByPeriod(startDate, endDate);
            if (sales == null) return new Dictionary<DateTime, decimal>();

            return sales
                .GroupBy(s => s.SaleDate.Date)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Sum(s => s.TotalAmount));
        }

        public Dictionary<string, decimal> GroupSalesByCategory(DateTime startDate, DateTime endDate)
        {
            var sales = saleRepo.GetSalesByPeriod(startDate, endDate);
            if (sales == null) return new Dictionary<string, decimal>();

            var result = new Dictionary<string, decimal>();
            foreach (var sale in sales)
            {
                foreach (var item in sale.Items)
                {
                    if (result.ContainsKey(item.Category))
                        result[item.Category] += item.TotalPrice;
                    else
                        result[item.Category] = item.TotalPrice;
                }
            }
            return result;
        }
    }
}
