namespace Exam.Core.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
