using DAL.Models;

namespace API.DTO
{
    public class RetrieveBudgetDTO
    {
        public string BudgetName { get; set; }
        public int TotalSum { get; set; }
        public int UsedAmount { get; set; }
        public  Dictionary<string, List<string>> BudgetCategories { get; set; }
    }
}
