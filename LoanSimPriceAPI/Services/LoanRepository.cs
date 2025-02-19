using LoanSimPriceAPI.Data;
using LoanSimPriceAPI.Models;
using LoanSimPriceAPI.Services.Interfaces;

namespace LoanSimPriceAPI.Services;

public class LoanRepository(ApplicationDbContext context) : ILoanRepository
{
    public async Task<LoanProposal> AddProposalAsync(LoanProposal proposal)
    {
        context.LoanProposals.Add(proposal);
        await context.SaveChangesAsync();
        return proposal;
    }

    public async Task<PaymentSchedule> AddPaymentScheduleAsync(PaymentSchedule schedule)
    {
        context.PaymentSchedules.Add(schedule);
        await context.SaveChangesAsync();
        return schedule;
    }

    public async Task AddPaymentFlowSummaryAsync(IEnumerable<PaymentFlowSummary> paymentFlows)
    {
        context.PaymentFlowSummaries.AddRange(paymentFlows);
        await context.SaveChangesAsync();
    }
}