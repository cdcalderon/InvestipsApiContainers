using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestipsApiContainers.Gateways.QuotesGateway.Infrastructure;
using InvestipsApiContainers.Gateways.QuotesGateway.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InvestipsApiContainers.Gateways.QuotesGateway.Services
{
    public class SignalService: ISignalService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<SignalService> _logger;

        private readonly string _remoteServiceBaseUrl;
        public SignalService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<SignalService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.SignalsUrl}/api/catalog/";
        }

        public async Task<IEnumerable<Signal>> GetGapSignals(string symbol)
        {
            var allcatalogItemsUri = ApiPaths.Signals.GetGapSignals(_remoteServiceBaseUrl, symbol);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Signal>>(dataString);

            return response;
        }

        public async Task<IEnumerable<Signal>> GetBull307StochSignal(string symbol)
        {
            var allcatalogItemsUri = ApiPaths.Signals.GetGapSignals(_remoteServiceBaseUrl, symbol);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Signal>>(dataString);

            return response;
        }

        public async Task<IEnumerable<Signal>> GetBullThreeArrowSignals(string symbol)
        {
            var allcatalogItemsUri = ApiPaths.Signals.GetGapSignals(_remoteServiceBaseUrl, symbol);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Signal>>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrands()
        {
            var getBrandsUri = ApiPaths.Signals.GetBull307StochSignals(_remoteServiceBaseUrl, "");

            var dataString = await _apiClient.GetStringAsync(getBrandsUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var brands = JArray.Parse(dataString);

            foreach (var brand in brands.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = brand.Value<string>("id"),
                    Text = brand.Value<string>("brand")
                });
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {
            var getTypesUri = ApiPaths.Signals.GeBullThreeArrowSignals(_remoteServiceBaseUrl, "");

            var dataString = await _apiClient.GetStringAsync(getTypesUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var brands = JArray.Parse(dataString);
            foreach (var brand in brands.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = brand.Value<string>("id"),
                    Text = brand.Value<string>("type")
                });
            }
            return items;
        }
    }
}
