using LoanSimPriceAPI.Models;

namespace LoanSimPriceAPI.Services.Interfaces;

public interface ILoanSimulationService
{
    Task<PaymentSchedule> SimulateLoanAsync(LoanProposal proposal);
}