using LoanSimPriceAPI.Models;
using LoanSimPriceAPI.Services.Interfaces;

namespace LoanSimPriceAPI.Services;

public class LoanSimulationService(ILoanRepository loanRepository) : ILoanSimulationService
{
    /// <summary>
    /// Simulates a loan using the Price Table method and returns the payment schedule.
    /// </summary>
    /// <param name="proposal">Loan proposal details.</param>
    /// <returns>PaymentSchedule object containing detailed payment schedule information.</returns>
    /// <exception cref="InvalidOperationException">Thrown when an error occurs during the loan simulation.</exception>
    public async Task<PaymentSchedule> SimulateLoanAsync(LoanProposal proposal)
    {
        try
        {
            var monthlyRate = proposal.AnnualInterestRate / 12;
            var monthlyPayment = Math.Round(
                proposal.LoanAmount * (monthlyRate /
                                       (decimal)(1 - Math.Pow(1 + (double)monthlyRate, -proposal.NumberOfMonths))), 2);

            var totalPayment = Math.Round(monthlyPayment * proposal.NumberOfMonths, 2);
            var totalInterest = Math.Round(totalPayment - proposal.LoanAmount, 2);

            proposal = await loanRepository.AddProposalAsync(proposal);

            var paymentScheduleList = GeneratePaymentSchedule(
                proposal.LoanAmount, monthlyPayment, monthlyRate, proposal.NumberOfMonths, proposal.Id);

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
        catch (Exception ex)
        {
            throw new InvalidOperationException("Erro ao simular o empréstimo.", ex);
        }
    }

    /// <summary>
    /// Generates a detailed payment schedule for the loan.
    /// </summary>
    /// <param name="loanAmount">Total loan amount.</param>
    /// <param name="monthlyPayment">Fixed monthly payment amount.</param>
    /// <param name="monthlyRate">Monthly interest rate.</param>
    /// <param name="numberOfMonths">Total number of months for repayment.</param>
    /// <param name="proposalId">Loan proposal identifier.</param>
    /// <returns>A list containing detailed payment information for each installment.</returns>
    private static List<PaymentFlowSummary> GeneratePaymentSchedule(
        decimal loanAmount, decimal monthlyPayment, decimal monthlyRate, int numberOfMonths, int proposalId)
    {
        var balance = loanAmount;
        var schedule = new List<PaymentFlowSummary>();

        for (var month = 1; month <= numberOfMonths; month++)
        {
            var interest = Math.Round(balance * monthlyRate, 2);
            var principal = Math.Round(monthlyPayment - interest, 2);
            balance = Math.Round(balance - principal, 2);
            balance = balance < 0 ? 0 : balance;

            schedule.Add(new PaymentFlowSummary
            {
                Month = month,
                Principal = principal,
                Interest = interest,
                Balance = balance,
                LoanProposalId = proposalId
            });
        }

        return schedule;
    }
}