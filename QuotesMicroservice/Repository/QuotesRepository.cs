using Microsoft.EntityFrameworkCore;
using QuotesMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Repository
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly DemoContext Context;

        public QuotesRepository(DemoContext Context)
        {
            this.Context = Context;
        }
        public async Task<bool> CreateQuotes(Quotes quotes)
        {
            Context.QuotesList.Add(quotes);
            int count = await Context.SaveChangesAsync();
            return count >= 0;
            //throw new NotImplementedException();
        }

        public async Task<List<Quotes>> GetQuotes()
        {

            var quotes = await Context.QuotesList.ToListAsync();
            return quotes;
            //throw new NotImplementedException();
        }
    }
}
