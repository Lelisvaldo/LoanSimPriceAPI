namespace LoanSimPriceAPI.Models;

public class LoanProposal
{
    public int Id { get; set; }
    public decimal LoanAmount { get; set; }
    public decimal AnnualInterestRate { get; set; }
    public int NumberOfMonths { get; set; }
    public ICollection<PaymentSchedule> PaymentSchedules { get; set; } = new List<PaymentSchedule>();
}