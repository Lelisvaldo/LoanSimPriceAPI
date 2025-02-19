using System.Text.Json.Serialization;

namespace LoanSimPriceAPI.Models;

public class PaymentFlowSummary
{
    public int Id { get; set; }
    public int Month { get; set; }
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public decimal Balance { get; set; }
    public int LoanProposalId { get; set; }

    [JsonIgnore] public LoanProposal LoanProposal { get; set; }
    public int PaymentScheduleId { get; set; }
    [JsonIgnore] public PaymentSchedule PaymentSchedule { get; set; }
}