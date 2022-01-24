namespace API.DTO
{
    public class ExpenseDTO
    {
        public int ExpenseId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string ExpenseDescription { get; set; }
        public int ExpenseBalanceChange { get; set; }

        //Navigation Properties
        public int AccountId { get; set; }
    }
}
