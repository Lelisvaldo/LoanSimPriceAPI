using System.Text.Json.Serialization;

namespace LoanSimPriceAPI.Models;

public class PaymentSchedule
{
    public int Id { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal TotalInterest { get; set; }
    public decimal TotalPayment { get; set; }
    public int LoanProposalId { get; set; }

    [JsonIgnore] public LoanProposal LoanProposal { get; set; }
    public ICollection<PaymentFlowSummary> PaymentScheduleDetails { get; set; } = new List<PaymentFlowSummary>();
}