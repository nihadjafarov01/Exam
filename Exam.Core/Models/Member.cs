using Exam.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Exam.Core.Models
{
    public class Member : BaseModel
    {
        [MaxLength(32)]
        public string Fullname { get; set; }
        [MaxLength(32)]
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
    }
}
