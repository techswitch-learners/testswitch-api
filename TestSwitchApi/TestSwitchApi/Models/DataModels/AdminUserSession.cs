using System.ComponentModel.DataAnnotations;

namespace TestSwitchApi.Models.DataModels
{
    public class AdminUserSession
    {
        [Key]
        private string Id { get; set; }
        private string AdminUserId { get; set; }
    }
}