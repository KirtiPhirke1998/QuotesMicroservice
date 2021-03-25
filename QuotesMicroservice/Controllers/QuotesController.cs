using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuotesMicroservice.Models;
using QuotesMicroservice.Repository;

namespace QuotesMicroservice.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesRepository repository;

        public QuotesController(IQuotesRepository repository)
        {
            this.repository = repository;
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<Quotes> GetQuotes()
        //{
        //    Policy policy = new Policy();
        //    Quotes quotes = new Quotes();
            
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:44369/api/");
        //        //HTTP GET
        //        var result = await client.GetAsync("Policy/{id}?bussinessMasterid=" + id);
               
        //        if (result.IsSuccessStatusCode)
        //        {               
        //            var jsoncontent = await result.Content.ReadAsStringAsync();
        //            policy = JsonConvert.DeserializeObject<Policy>(jsoncontent);


        //            if (policy.PropertyValue >= 0 && policy.PropertyValue <= 2)
        //            {
        //                if(policy.BussinessValue>=0 && policy.BussinessValue <= 2)
        //                {
        //                    if (policy.PropertyType == "Land")
        //                    {
        //                        quotes.QuoteInsurance = 80000;

        //                        Context.QuotesList.Add(quotes);

        //                        int count = await Context.SaveChangesAsync();

        //                        return quotes; 
        //                    }
        //                }
        //            }

        //            else if (policy.PropertyValue >= 0 && policy.PropertyValue <= 2)
        //            {
        //                if (policy.BussinessValue >= 0 && policy.BussinessValue <= 2)
        //                {
        //                    if (policy.PropertyType == "Building")
        //                    {
        //                        quotes.QuoteInsurance = 80000;

        //                        Context.QuotesList.Add(quotes);

        //                        int count = await Context.SaveChangesAsync();

        //                        return quotes;
        //                    }
        //                }
        //            }

        //            else if (policy.PropertyValue >2  && policy.PropertyValue <= 4)
        //            {
        //                if (policy.BussinessValue > 2 && policy.BussinessValue <= 4)
        //                {
        //                    if (policy.PropertyType == "Land")
        //                    {
        //                        quotes.QuoteInsurance = 40000;

        //                        Context.QuotesList.Add(quotes);

        //                        int count = await Context.SaveChangesAsync();

        //                        return quotes;
        //                    }
        //                }
        //            }

        //            else
        //            {
        //                //QuotesNotFound
        //            }


        //            //readTask.Wait();
        //        }
        //        else //web api sent error response 
        //        {
        //            //log response status here..

        //            quotes = null;

        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    return quotes;


           
        //}




        [HttpPost("CreateQuotes")]
        public async Task<ObjectResult> CreateQuotes(Quotes quote)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var Result = await repository.CreateQuotes(quote);

            if (!Result)
            {
                return new ObjectResult("Database error") { StatusCode = 500 };
            }
            return new CreatedResult("CreateQuotes", new { id = quote.id });
        }

        [HttpGet]
        public async Task<ObjectResult> GetQuotes()
        {
            return Ok(await repository.GetQuotes());

        }
    }
}