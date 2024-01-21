using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Exam.Business.ViewModels.MemberVMs
{
    public class MemberUpdateVM
    {
        [MaxLength(32)]
        public string Fullname { get; set; }
        [MaxLength(32)]
        public string Position { get; set; }
        public IFormFile? ImageFile { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
