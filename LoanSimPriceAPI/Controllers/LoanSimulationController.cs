using LoanSimPriceAPI.Dtos;
using LoanSimPriceAPI.Models;
using LoanSimPriceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanSimPriceAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/loans/simulate")]
public class LoanSimulationController(ILoanSimulationService loanSimulationService) : ControllerBase
{
    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> SimulateLoan([FromBody] LoanProposalDto? proposalDto)
    {
        if (proposalDto == null)
            return BadRequest("Request body cannot be null.");

        if (proposalDto.LoanAmount <= 0)
            return BadRequest("LoanAmount must be greater than zero.");

        if (proposalDto.AnnualInterestRate is <= 0 or > 1)
            return BadRequest("AnnualInterestRate must be between 0 and 1.");

        if (proposalDto.NumberOfMonths <= 0)
            return BadRequest("NumberOfMonths must be greater than zero.");

        var proposal = new LoanProposal
        {
            LoanAmount = proposalDto.LoanAmount,
            AnnualInterestRate = proposalDto.AnnualInterestRate,
            NumberOfMonths = proposalDto.NumberOfMonths
        };

        var schedule = await loanSimulationService.SimulateLoanAsync(proposal);
        return Ok(schedule);
    }
}