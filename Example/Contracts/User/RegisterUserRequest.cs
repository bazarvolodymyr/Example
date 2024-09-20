using System.ComponentModel.DataAnnotations;

namespace Example.Contracts.User
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Password,
        [Required] string Email);
}
