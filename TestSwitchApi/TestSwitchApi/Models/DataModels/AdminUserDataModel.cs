using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSwitchApi.Models.DataModels
{
    public class AdminUserDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email
        {
            get => Email;
            set => Email.ToLower();
        }

        public string HashedPassword { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}