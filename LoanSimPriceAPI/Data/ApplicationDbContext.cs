using LoanSimPriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanSimPriceAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<LoanProposal> LoanProposals { get; set; }
    public DbSet<PaymentSchedule> PaymentSchedules { get; set; }
}