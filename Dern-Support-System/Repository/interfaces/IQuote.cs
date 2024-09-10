using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;

namespace Dern_Support_System.Repository.interfaces
{
    public interface IQuote
    {
        Task<IEnumerable<Quote>> GetAllQuotesAsync();
        Task<Quote> GetQuoteByIdAsync(int quoteId);
        Task<Quote> AddQuoteAsync(QuoteDto quoteDto);
        Task<Quote> UpdateQuoteAsync(QuoteDto quoteDto, int quoteId);
        Task DeleteQuoteAsync(int quoteId);
    }
}
