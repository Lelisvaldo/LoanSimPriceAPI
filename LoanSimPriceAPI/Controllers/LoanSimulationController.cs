using LoanSimPriceAPI.Models;
using LoanSimPriceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanSimPriceAPI.Controllers;

[ApiController]
[Route("api/loans/simulate")]
public class LoanSimulationController(ILoanSimulationService loanSimulationService) : ControllerBase
{
    private readonly ILoanSimulationService _loanSimulationService = loanSimulationService;

    [HttpPost]
    public async Task<IActionResult> SimulateLoan([FromBody] LoanProposal proposal)
    {
        if (proposal.LoanAmount <= 0 || proposal.AnnualInterestRate <= 0 || proposal.NumberOfMonths <= 0)
            return BadRequest("Invalid loan parameters.");

        var schedule = await _loanSimulationService.SimulateLoanAsync(proposal);
        return Ok(schedule);
    }
}