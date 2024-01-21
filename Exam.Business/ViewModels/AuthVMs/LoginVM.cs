using System.ComponentModel.DataAnnotations;

namespace Exam.Business.ViewModels.AuthVMs
{
    public class LoginVM
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
