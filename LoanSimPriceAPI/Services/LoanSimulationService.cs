using LoanSimPriceAPI.Models;
using LoanSimPriceAPI.Services.Interfaces;

namespace LoanSimPriceAPI.Services;

public class LoanSimulationService : ILoanSimulationService
{
    private readonly ILoanRepository _loanRepository;

    public LoanSimulationService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<PaymentSchedule> SimulateLoanAsync(LoanProposal proposal)
    {
        var monthlyRate = proposal.AnnualInterestRate / 12;
        var monthlyPayment = proposal.LoanAmount * (monthlyRate / (decimal)(1 - Math.Pow(1 + (double)monthlyRate, -proposal.NumberOfMonths)));

        var totalPayment = monthlyPayment * proposal.NumberOfMonths;
        var totalInterest = totalPayment - proposal.LoanAmount;

        proposal = await _loanRepository.AddProposalAsync(proposal);

        var schedule = new PaymentSchedule
        {
            MonthlyPayment = monthlyPayment,
            TotalInterest = totalInterest,
            TotalPayment = totalPayment,
            LoanProposalId = proposal.Id
        };

        await _loanRepository.AddPaymentScheduleAsync(schedule);
        return schedule;
    }
}