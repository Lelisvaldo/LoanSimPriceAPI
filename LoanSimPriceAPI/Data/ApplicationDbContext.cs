using LoanSimPriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanSimPriceAPI.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<LoanProposal> LoanProposals { get; set; }
    public DbSet<PaymentSchedule> PaymentSchedules { get; set; }
    public DbSet<PaymentFlowSummary> PaymentFlowSummaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LoanProposal>(entity =>
        {
            entity.Property(e => e.LoanAmount).HasPrecision(18, 2);
            entity.Property(e => e.AnnualInterestRate).HasPrecision(18, 4);

            entity.HasMany(e => e.PaymentSchedules)
                .WithOne(e => e.LoanProposal)
                .HasForeignKey(e => e.LoanProposalId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PaymentSchedule>(entity =>
        {
            entity.Property(e => e.MonthlyPayment).HasPrecision(18, 2);
            entity.Property(e => e.TotalInterest).HasPrecision(18, 2);
            entity.Property(e => e.TotalPayment).HasPrecision(18, 2);

            entity.HasMany(e => e.PaymentScheduleDetails)
                .WithOne(e => e.PaymentSchedule)
                .HasForeignKey(e => e.PaymentScheduleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PaymentFlowSummary>(entity =>
        {
            entity.Property(e => e.Principal).HasPrecision(18, 2);
            entity.Property(e => e.Interest).HasPrecision(18, 2);
            entity.Property(e => e.Balance).HasPrecision(18, 2);

            entity.HasOne(e => e.LoanProposal)
                .WithMany()
                .HasForeignKey(e => e.LoanProposalId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

}