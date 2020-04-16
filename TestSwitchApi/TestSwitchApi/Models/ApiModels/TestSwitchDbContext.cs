using Microsoft.EntityFrameworkCore;
using TestSwitchApi.DataModels;

namespace TestSwitchApi.ApiModels
{
    public class TestSwitchDbContext:DbContext
    {
        public TestSwitchDbContext (DbContextOptions<TestSwitchDbContext> options):base(options) { }
        public DbSet<CandidateDataModel> Candidate { get; set; }
    }
}