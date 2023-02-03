using System.Collections.Generic;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.DTOs;
using InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public class WeeklyZigzagFibPremiumSignalService : IWeeklyZigzagFibPremiumSignalService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<SignalService> _logger;

        private readonly string _getWeeklyZigZagFibPremiumSignalByIdUrl;
        private readonly string _publishWeeklyZigZagFibPremiumSignals;

        public WeeklyZigzagFibPremiumSignalService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<SignalService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _getWeeklyZigZagFibPremiumSignalByIdUrl = $"{_settings.Value.SignalsUrl}/api/weeklyzigzagfibpremium";
            _publishWeeklyZigZagFibPremiumSignals = $"{_settings.Value.SignalsUrl}/api/publishweeklyzigzagfibpremiumsignals";
            _publishWeeklyZigZagFibPremiumSignals = $"{_settings.Value.SignalsUrl}/api/getpublishedzigzagfibpremiumsignals";
        }

        public async Task<ZigZagFiboSignal> GetWeeklyZigZagFibPremiumSignalById(int signalId)
        {
            var fiboSignalsBySymbolUri = ApiPaths.Signals.GetWeeklyZigZagFibPremiumSignalById(_getWeeklyZigZagFibPremiumSignalByIdUrl, signalId);

            var dataString = await _apiClient.GetStringAsync(fiboSignalsBySymbolUri);

            var response = JsonConvert.DeserializeObject<ZigZagFiboSignal>(dataString);

            return response;
        }

        public async Task<int> PublishWeeklyZigZagFibPremiumSignals(IEnumerable<DTOs.PublishSignal> publishSignals)
        {
            var fiboSignalsBySymbolUri = ApiPaths.Signals.PublishWeeklyZigZagFibPremiumSignals(_publishWeeklyZigZagFibPremiumSignals);

            var response = await _apiClient.PutAsync(fiboSignalsBySymbolUri, publishSignals);

            var dataString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(dataString);
        }

        public async Task<IEnumerable<DisplaySignalSignal>> GetWeeklyZigzagFibPremiumDisplaySignals()
        {
            var fiboSignalsBySymbolUri = ApiPaths.Signals.BaseUrl(_publishWeeklyZigZagFibPremiumSignals);

            var dataString = await _apiClient.GetStringAsync(fiboSignalsBySymbolUri);

            return JsonConvert.DeserializeObject<IEnumerable<DisplaySignalSignal>>(dataString);
        }
    }
}
