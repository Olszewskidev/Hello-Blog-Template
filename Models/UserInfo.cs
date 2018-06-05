using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class UserInfo
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Token { get; set; }
    }
}