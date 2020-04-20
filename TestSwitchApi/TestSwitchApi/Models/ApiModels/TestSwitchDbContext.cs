using Microsoft.EntityFrameworkCore;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.ApiModels
{
    public class TestSwitchDbContext : DbContext
    {
        public TestSwitchDbContext (DbContextOptions<TestSwitchDbContext> options)
            : base(options)
        {
        }

        public DbSet<CandidateDataModel> Candidates { get; set; }
    }
}