using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Parbad.Abstraction;
using Parbad.Gateway.SnappPay.Internal;
using Parbad.Internal;
using Parbad.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.Snapppay.Internal
{
    public class SnapppayHelper
    {
        public static SnapppayRequest CreateRequestModel(SnapppayGatewayAccount account, Invoice invoice)
        {
            var snapppayRequest = invoice.GetSnapppayRequest();

            return new()
            {
                amount = invoice.Amount,
                returnURL = invoice.CallbackUrl,
                mobile = snapppayRequest.mobile,
                discountAmount = snapppayRequest.discountAmount,
                externalSourceAmount = snapppayRequest.externalSourceAmount,
                paymentMethodTypeDto = snapppayRequest.paymentMethodTypeDto,
                transactionId = snapppayRequest.transactionId,
                cartList = snapppayRequest.cartList

            };
        }
        public static void AssignHeaders(HttpRequestHeaders headers, SnapppayGatewayAccount account, string token)
        {
            headers.AddOrUpdate("Authorization", token);
        }

        public static async Task<PaymentRequestResult> CreateRequestResult(
                   HttpResponseMessage responseMessage,
                   HttpContext httpContext,
                   SnapppayGatewayAccount account)
        {
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwaitFalse();

            if (!responseMessage.IsSuccessStatusCode)
            {
                var errorModel = JsonConvert.DeserializeObject<SnappPayErroreResponseModel>(response);

                return PaymentRequestResult.Failed(errorModel.ToString(), account.Name);
            }

            var result = JsonConvert.DeserializeObject<SnapppayResponseModel<SnappPayRequestResultModel>>(response);

            return PaymentRequestResult.SucceedWithRedirect(account.Name, httpContext, result.Response.PaymentPageUrl);
        }

    }
}
