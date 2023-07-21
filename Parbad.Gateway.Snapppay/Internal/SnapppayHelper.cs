using Parbad.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
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


       
    }
}
