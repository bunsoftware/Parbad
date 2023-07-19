using Parbad.Abstraction;
using Parbad.GatewayBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parbad.Gateway.Snapppay
{
    [Gateway("Snapppay")]
    public class SnapppayGateway : GatewayBase<SnapppayGatewayAccount>
    {
        public SnapppayGateway(IGatewayAccountProvider<SnapppayGatewayAccount> accountProvider) : base(accountProvider)
        {
        }
        public async Task<IPaymentFetchResult> FetchAsync(InvoiceContext context, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(context.Payment);
        }

        public async Task<IPaymentRefundResult> RefundAsync(InvoiceContext context, Money amount, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(context.Payment);

        }

        public async Task<IPaymentRequestResult> RequestAsync(Invoice invoice, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(invoice);
        }

        public async Task<IPaymentVerifyResult> VerifyAsync(InvoiceContext context, CancellationToken cancellationToken = default)
        {
            var account = await GetAccountAsync(context.Payment);
        }
    }
}
