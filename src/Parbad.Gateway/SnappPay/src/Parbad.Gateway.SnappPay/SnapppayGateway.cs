﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Parbad.Abstraction;
using Parbad.Gateway.Snapppay.Internal;
using Parbad.GatewayBuilders;
using Parbad.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Parbad.Gateway.Snapppay
{
    [Gateway("Snapppay")]
    public class SnapppayGateway : GatewayBase<SnapppayGatewayAccount>
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SnapppayGatewayOptions _gatewayOptions;
        public SnapppayGateway(IGatewayAccountProvider<SnapppayGatewayAccount> accountProvider,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            SnapppayGatewayOptions gatewayOptions) : base(accountProvider)
        {
            _httpClient = httpClientFactory.CreateClient(this);
            _httpContextAccessor = httpContextAccessor;
            _gatewayOptions = gatewayOptions;
        }
        private static JsonSerializerSettings DefaultSerializerSettings => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public override async Task<IPaymentFetchResult> FetchAsync(InvoiceContext context, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(context.Payment);
            return null;
        }


        public override async Task<IPaymentRefundResult> RefundAsync(InvoiceContext context, Money amount, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(context.Payment);
            return null;
        }

        public override async Task<IPaymentRequestResult> RequestAsync(Invoice invoice, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(invoice);
            var tokenRequest = await _httpClient.GetSnapppayToken(account, _gatewayOptions);
            var token = await tokenRequest.Content.ReadAsStringAsync();

            var data = SnapppayHelper.CreateRequestModel(account, invoice);
            SnapppayHelper.AssignHeaders(_httpClient.DefaultRequestHeaders, account, token);
            var request = await _httpClient.PostJsonAsync(_gatewayOptions.ApiTokenUrl, data, DefaultSerializerSettings, cancellationToken);
            return await SnapppayHelper.CreateRequestResult(request, _httpContextAccessor.HttpContext, account);
        }

        public override async Task<IPaymentVerifyResult> VerifyAsync(InvoiceContext context, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(context.Payment);
            var httpContext = _httpContextAccessor.HttpContext;
            return null;
        }
    }
}