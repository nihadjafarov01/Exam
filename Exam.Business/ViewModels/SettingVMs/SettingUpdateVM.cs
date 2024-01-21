using System.ComponentModel.DataAnnotations;

namespace Exam.Business.ViewModels.SettingVMs
{
    public class SettingUpdateVM
    {
        [MaxLength(32)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string Address { get; set; }
        [MaxLength(32)]
        public string PhoneNumber { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
    }
}
