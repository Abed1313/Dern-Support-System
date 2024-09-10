using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;

namespace Dern_Support_System.Repository.interfaces
{
    public interface IKnowledgeBase
    {
        Task<IEnumerable<KnowledgeBase>> GetAllKnowledgeBasesAsync();
        Task<KnowledgeBase> GetKnowledgeBaseByIdAsync(int knowledgeBaseId);
        Task<KnowledgeBase> AddKnowledgeBaseAsync(KnowledgeBaseDto knowledgeBaseDto);
        Task<KnowledgeBase> UpdateKnowledgeBaseAsync(KnowledgeBaseDto knowledgeBaseDto, int articleId);
        Task DeleteKnowledgeBaseAsync(int knowledgeBaseId);
    }
}
