namespace LoanSimPriceAPI.Dtos;

public class LoanProposalDto
{
    public decimal LoanAmount { get; set; }
    public decimal AnnualInterestRate { get; set; }
    public int NumberOfMonths { get; set; }
}