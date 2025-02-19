﻿namespace LoanSimPriceAPI.Models;

public class PaymentFlowSummary
{
    public int Id { get; set; }
    public int Month { get; set; }
    public decimal Principal { get; set; }
    public decimal Interest { get; set; }
    public decimal Balance { get; set; }
    public int LoanProposalId { get; set; }
    public LoanProposal LoanProposal { get; set; }
}