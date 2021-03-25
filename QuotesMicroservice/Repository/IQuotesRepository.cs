using QuotesMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Repository
{
    public interface IQuotesRepository
    {
        Task<bool> CreateQuotes(Quotes quotes);
        Task<List<Quotes>> GetQuotes();
    }
}
