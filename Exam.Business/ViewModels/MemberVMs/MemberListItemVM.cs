using System.ComponentModel.DataAnnotations;

namespace Exam.Business.ViewModels.MemberVMs
{
    public class MemberListItemVM
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
