using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class QuoteService : IQuote
    {
        private readonly DernSupportDbContext _dbContext;

        public QuoteService(DernSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotesAsync()
        {
            return await _dbContext.Quotes.ToListAsync();
        }

        public async Task<Quote> GetQuoteByIdAsync(int quoteId)
        {
            return await _dbContext.Quotes.FindAsync(quoteId);
        }

        public async Task<Quote> AddQuoteAsync(QuoteDto quoteDto)
        {
            var quote = new Quote
            {
                SupportRequestId = quoteDto.SupportRequestId,
                EstimatedCost = quoteDto.EstimatedCost,
                FinalCost = quoteDto.FinalCost,
            };

            _dbContext.Quotes.Add(quote);
            await _dbContext.SaveChangesAsync();
            return quote;
        }

        public async Task<Quote> UpdateQuoteAsync(QuoteDto quoteDto, int quoteId)
        {
            var existingQuote = await _dbContext.Quotes.FindAsync(quoteId);

            if (existingQuote == null)
            {
                throw new Exception($"Quote with ID {quoteId} not found.");
            }

            if (quoteDto.EstimatedCost > 0)
            {
                existingQuote.EstimatedCost = quoteDto.EstimatedCost;
            }

            if (quoteDto.FinalCost > 0)
            {
                existingQuote.FinalCost = quoteDto.FinalCost;
            }

            await _dbContext.SaveChangesAsync();

            return existingQuote;
        }

        public async Task DeleteQuoteAsync(int quoteId)
        {
            var quote = await GetQuoteByIdAsync(quoteId);
            _dbContext.Quotes.Remove(quote);
            await _dbContext.SaveChangesAsync();
        }
    }
}
