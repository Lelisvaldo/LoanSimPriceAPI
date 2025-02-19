using LoanSimPriceAPI.Models;

namespace LoanSimPriceAPI.Services.Interfaces;

public interface ILoanRepository
{
    Task<LoanProposal> AddProposalAsync(LoanProposal proposal);
    Task<PaymentSchedule> AddPaymentScheduleAsync(PaymentSchedule schedule);
    Task AddPaymentFlowSummaryAsync(IEnumerable<PaymentFlowSummary> paymentFlows);
}