using Parbad.Abstraction;
using Parbad.Gateway.Snapppay.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.Snapppay
{
    public static class SnapppayGatewayInvoiceBuilderExtensions
    {
        private const string SnapppayRequestKey = "SnapppayRequest";
        internal static SnapppayRequest GetSnapppayRequest(this Invoice invoice)
        {
            if (invoice == null) throw new ArgumentNullException(nameof(invoice));

            if (invoice.Properties.ContainsKey(SnapppayRequestKey))
            {
                return (SnapppayRequest)invoice.Properties[SnapppayRequestKey];
            }

            return null;
        }
    }
}
