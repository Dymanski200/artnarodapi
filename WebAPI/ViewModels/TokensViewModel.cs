using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class TokensViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
