using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.SnappPay.Internal
{
    public class SnappPayRequestResultModel
    {
        public string PaymentToken { get; set; }
        public string PaymentPageUrl { get; set; }
    }
}
