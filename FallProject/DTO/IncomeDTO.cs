namespace API.DTO
{
    public class IncomeDTO
    {
        public int IncomeId { get; set; }
        public DateTime IncomeDate { get; set; }
        public string IncomeDescription { get; set; }
        public int IncomeBalanceChange { get; set; }
        
        //Navigation Properties
        public int AccountId { get; set; }

        public int Id { get; set; }
    }
}
