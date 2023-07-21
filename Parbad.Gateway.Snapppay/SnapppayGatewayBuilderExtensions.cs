using Microsoft.Extensions.DependencyInjection;
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
        /// <param name="builder"></param>
        public static IGatewayConfigurationBuilder<SnapppayGateway> AddSnapppay(this IGatewayBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            return builder
                .AddGateway<SnapppayGateway>()
                .WithHttpClient(clientBuilder => { })
                .WithOptions(options => { });
        }

        public static IGatewayConfigurationBuilder<SnapppayGateway> WithAccounts(
            this IGatewayConfigurationBuilder<SnapppayGateway> builder,
            Action<IGatewayAccountBuilder<SnapppayGatewayAccount>> configureAccounts)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            return builder.WithAccounts(configureAccounts);
        }

        public static IGatewayConfigurationBuilder<SnapppayGateway> WithOptions(
    this IGatewayConfigurationBuilder<SnapppayGateway> builder,
    Action<SnapppayGatewayOptions> configureOptions)
        {
            builder.Services.Configure(configureOptions);

            return builder;
        }
    }
}
