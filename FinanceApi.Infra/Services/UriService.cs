using FinanceApi.Infra.Shared.Http.Filter;
using FinanceApi.Infra.Shared.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace FinanceApi.Infra.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var endpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "$skip", filter.Skip.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "$top", filter.Top.ToString());
            return new Uri(modifiedUri);
        }
    }
}
