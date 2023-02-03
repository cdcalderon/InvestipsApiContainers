using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public class VettedSignalsService : IVettedSignalService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<SignalService> _logger;
        private readonly string _remoteServiceBaseUrl;
        private readonly string _getVettedSignalsUrl;

        public VettedSignalsService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<SignalService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.SignalsUrl}";
            _getVettedSignalsUrl = $"{_remoteServiceBaseUrl}/api/vetted/";
        }

        public async Task<IEnumerable<VettedSignal>> GetVettedSignals(long from, long to)
        {
            var vettedSignalsUri = ApiPaths.Signals.GetVettedSignals(_getVettedSignalsUrl, from, to);

            var dataString = await _apiClient.GetStringAsync(vettedSignalsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<VettedSignal>>(dataString);

            return response;
        }
    }
}
