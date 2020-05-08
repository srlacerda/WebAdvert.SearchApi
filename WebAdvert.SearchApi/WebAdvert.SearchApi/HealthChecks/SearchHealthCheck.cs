using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAdvert.SearchApi.Services;

namespace WebAdvert.SearchApi.HealthChecks
{
    public class SearchHealthCheck : IHealthCheck
    {
        private readonly ISearchService _searchService;
        public SearchHealthCheck(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var isSearchOk = await _searchService.CheckHealthAsync();
            return new HealthCheckResult(isSearchOk ? HealthStatus.Healthy : HealthStatus.Unhealthy);
        }
    }
}
