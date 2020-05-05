using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSwitchApi.Models.DataModels
{
    public class AdminUserDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private string _email;

        public string Email
        {
            get => Email.ToLower();
            set => _email = value.ToLower();
        }

        public string HashedPassword { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
