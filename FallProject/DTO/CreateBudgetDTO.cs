using DAL.Models;

namespace API.DTO
{
    public class CreateBudgetDTO
    {
        public string Name { get; set; }
        public int TotalSum { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Dictionary<CategoryExpense, int> CategoriesAndAmount { get; set; }

    }
}
