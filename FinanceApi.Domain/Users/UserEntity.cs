using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Domain.Users
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        private string _email = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email
        {
            get => _email;
            set => _email = value.ToLowerInvariant();
        }


        public string? PasswordHash { get; set; }

        public string? FirebaseUid { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string EmailLower { get; private set; } = null!;

        [Required]
        [StringLength(255)]
        public string AuthProvider { get; set; }
    }
}
