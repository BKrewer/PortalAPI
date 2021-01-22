using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalAPI.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo deve ser preenchido com um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo senha deve ter no mínimo 6 caracteres")]
        public string Password { get; set; }
        
        [Compare("Password")]
        [MinLength(6, ErrorMessage = "O campo senha deve ter no mínimo 6 caracteres")]
        public string ConfirmPassword { get; set; }

        public int Status { get; set; }
        public string Role { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Donation> Donations { get; set; }

        public User()
        {
            Status = 1;
            Role = "user";
        }
    }
}
