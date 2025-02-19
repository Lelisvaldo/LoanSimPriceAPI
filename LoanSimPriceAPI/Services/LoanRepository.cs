using LoanSimPriceAPI.Data;
using LoanSimPriceAPI.Models;
using LoanSimPriceAPI.Services.Interfaces;

namespace LoanSimPriceAPI.Services;

public class LoanRepository : ILoanRepository
{
    private readonly ApplicationDbContext _context;

    public LoanRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<LoanProposal> AddProposalAsync(LoanProposal proposal)
    {
        _context.LoanProposals.Add(proposal);
        await _context.SaveChangesAsync();
        return proposal;
    }

    public async Task<PaymentSchedule> AddPaymentScheduleAsync(PaymentSchedule schedule)
    {
        _context.PaymentSchedules.Add(schedule);
        await _context.SaveChangesAsync();
        return schedule;
    }
}