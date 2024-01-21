using Microsoft.AspNetCore.Http;

namespace Exam.Business.Helpers
{
    public static class FileSave
    {
        public static async Task<string> SaveAndProvideNameAsync(this IFormFile file, string rootPath)
        {
            string filePath = Path.Combine("images", "members", file.FileName);

            using (FileStream fs = File.Create(Path.Combine(rootPath,filePath)))
            {
                await file.CopyToAsync(fs);
            }
            return filePath;
        }
    }
}
