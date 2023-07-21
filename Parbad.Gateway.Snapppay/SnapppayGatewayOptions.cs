using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.Snapppay
{
    public class SnapppayGatewayOptions
    {
        public string ApiRequestUrl { get; set; } = "https://api.snapppay.ir/api/online/payment/v1/token";

        public string ApiVerificationUrl { get; set; } = "https://api.snapppay.ir/api/online/payment/v1/verify";

        public string ApiTokenUrl { get; set; } = "https://api.snapppay.ir/api/online/v1/oauth/token";

    }
}
