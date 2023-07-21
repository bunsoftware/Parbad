using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.Snapppay
{
    public static class SnapppayHttpClientExtensions
    {
        public static Task<HttpResponseMessage> GetSnapppayToken(this HttpClient httpClient, SnapppayGatewayAccount account, SnapppayGatewayOptions options)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));
            var request = new HttpRequestMessage(new HttpMethod("POST"), options.ApiTokenUrl);
            request.Headers.Add("Authorization", $"Basic base64_encode({account.ClientId} : {account.ClientSecret} )");
            request.Content = new StringContent($"grant_type=password&scope=online-merchant&username={account.UserName}&password={account.Password}");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return httpClient.SendAsync(request);
        }
    }
}
