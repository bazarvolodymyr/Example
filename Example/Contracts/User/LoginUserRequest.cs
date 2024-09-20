using System.ComponentModel.DataAnnotations;

namespace Example.Contracts.User
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}
