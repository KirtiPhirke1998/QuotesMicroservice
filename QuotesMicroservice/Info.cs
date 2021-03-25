using Microsoft.OpenApi.Models;

namespace QuotesMicroservice
{
    internal class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
    }
}