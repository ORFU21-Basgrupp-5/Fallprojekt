using DAL.Models;

namespace API.DTO
{
    public class AddIncomeDTO
    {
        public DateTime IncomeDate { get; set; }
        public string IncomeDescription { get; set; }
        public int IncomeBalanceChange { get; set; }

        public int AccountId { get; set; }
        public CategoryIncome IncomeCategory { get; set; }
    }
}
