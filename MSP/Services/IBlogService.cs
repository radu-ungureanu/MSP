using System.Collections.Generic;
using System.Threading.Tasks;
using MSP.Services.Model;

namespace MSP.Services
{
    public interface IBlogService
    {
        Task<List<BlogEntrySummary>> GetPreviewPosts();
        Task<BlogEntry> GetPost(string url);
    }
}
