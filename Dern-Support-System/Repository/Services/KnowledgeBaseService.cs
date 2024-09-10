using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class KnowledgeBaseService : IKnowledgeBase
    {
        private readonly DernSupportDbContext _dbContext;

        public KnowledgeBaseService(DernSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<KnowledgeBase>> GetAllKnowledgeBasesAsync()
        {
            return await _dbContext.KnowledgeBases.ToListAsync();
        }

        public async Task<KnowledgeBase> GetKnowledgeBaseByIdAsync(int knowledgeBaseId)
        {
            return await _dbContext.KnowledgeBases.FindAsync(knowledgeBaseId);
        }

        public async Task<KnowledgeBase> AddKnowledgeBaseAsync(KnowledgeBaseDto knowledgeBaseDto)
        {
            var article = new KnowledgeBase
            {
                Title = knowledgeBaseDto.Title,
                ProblemDescription = knowledgeBaseDto.ProblemDescription,
                SolutionSteps = knowledgeBaseDto.SolutionSteps,
                HardwareOrSoftware = knowledgeBaseDto.HardwareOrSoftware,
            };
            _dbContext.KnowledgeBases.Add(article);
            await _dbContext.SaveChangesAsync();
            return article;
        }

        public async Task<KnowledgeBase> UpdateKnowledgeBaseAsync(KnowledgeBaseDto knowledgeBaseDto, int articleId)
        {
            var existingArticle = await _dbContext.KnowledgeBases.FindAsync(articleId);

            if (existingArticle == null)
            {
                throw new Exception($"KnowledgeBase article with ID {articleId} not found.");
            }

            if (!string.IsNullOrEmpty(knowledgeBaseDto.Title)) existingArticle.Title = knowledgeBaseDto.Title;
            if (!string.IsNullOrEmpty(knowledgeBaseDto.ProblemDescription)) existingArticle.ProblemDescription = knowledgeBaseDto.ProblemDescription;
            if (!string.IsNullOrEmpty(knowledgeBaseDto.SolutionSteps)) existingArticle.SolutionSteps = knowledgeBaseDto.SolutionSteps;
            existingArticle.HardwareOrSoftware = knowledgeBaseDto.HardwareOrSoftware;

            await _dbContext.SaveChangesAsync();

            return existingArticle;
        }

        public async Task DeleteKnowledgeBaseAsync(int knowledgeBaseId)
        {
            var knowledgeBase = await GetKnowledgeBaseByIdAsync(knowledgeBaseId);
            _dbContext.KnowledgeBases.Remove(knowledgeBase);
            await _dbContext.SaveChangesAsync();
        }
    }
}
