using Microsoft.EntityFrameworkCore;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.ApiModels
{
    public class TestSwitchDbContext : DbContext
    {
        public TestSwitchDbContext(DbContextOptions<TestSwitchDbContext> options)
            : base(options)
        {
        }

        public DbSet<CandidateDataModel> Candidates { get; set; }

        public DbSet<CandidateTestModel> CandidateTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateTestModel>()
                .HasKey(c => new { c.CandidateId, c.TestId });
        }
    }
}