using LoanSimPriceAPI.Models;
using LoanSimPriceAPI.Services.Interfaces;

namespace LoanSimPriceAPI.Services;

public class LoanSimulationService(ILoanRepository loanRepository) : ILoanSimulationService
{
    public async Task<PaymentSchedule> SimulateLoanAsync(LoanProposal proposal)
    {
        var monthlyRate = proposal.AnnualInterestRate / 12;
        var monthlyPayment = proposal.LoanAmount * (monthlyRate / (decimal)(1 - Math.Pow(1 + (double)monthlyRate, -proposal.NumberOfMonths)));

        var totalPayment = monthlyPayment * proposal.NumberOfMonths;
        var totalInterest = totalPayment - proposal.LoanAmount;

        proposal = await loanRepository.AddProposalAsync(proposal);

        var balance = proposal.LoanAmount;
        var paymentScheduleList = new List<PaymentFlowSummary>();

        for (var month = 1; month <= proposal.NumberOfMonths; month++)
        {
            var interest = balance * monthlyRate;
            var principal = monthlyPayment - interest;
            balance -= principal;

            var paymentFlow = new PaymentFlowSummary
            {
                Month = month,
                Principal = principal,
                Interest = interest,
                Balance = balance > 0 ? balance : 0,
                LoanProposalId = proposal.Id
            };

            paymentScheduleList.Add(paymentFlow);
        }

        var schedule = new PaymentSchedule
        {
            MonthlyPayment = monthlyPayment,
            TotalInterest = totalInterest,
            TotalPayment = totalPayment,
            LoanProposalId = proposal.Id,
            PaymentScheduleDetails = paymentScheduleList
        };

        await loanRepository.AddPaymentScheduleAsync(schedule);

        return schedule;
    }
}