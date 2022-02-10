namespace API.DTO
{
    public class AddExpenseDTO
    {
        public DateTime ExpenseDate { get; set; }
        public string ExpenseDescription { get; set; }
        public int ExpenseBalanceChange { get; set; }

        public int AccountId { get; set; }

       

    }
}
