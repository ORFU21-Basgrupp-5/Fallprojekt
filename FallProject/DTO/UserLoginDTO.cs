using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public record UserLoginDTO([Required] string UserName, [Required] string Password);
    
    
}
