using Parbad.GatewayBuilders;
using Parbad.InvoiceBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.Snapppay
{
    public static class SnapppayGatewayBuilderExtensions
    {
        public static IGatewayConfigurationBuilder<SnapppayGateway> AddHero(this IGatewayBuilder builder)
        {
            return builder.AddGateway<SnapppayGateway>();
        }

        public static IGatewayConfigurationBuilder<SnapppayGateway> WithAccounts(this IGatewayConfigurationBuilder<SnapppayGateway> builder, Action<IGatewayAccountBuilder<SnapppayGatewayAccount>> configureAccounts)
        {
            return builder.WithAccounts(configureAccounts);
        }

        public static IInvoiceBuilder UseHero(this IInvoiceBuilder builder)
        {
            return builder.SetGateway("Hero");
        }
    }
}
