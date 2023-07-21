using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.Snapppay.Internal
{
    public class SnapppayRequestResponseModel<T>
    {
        public bool Successful { get; set; }
        public T Response { get; set; }
        public ErrorData ErrorData { get; set; }
    }

    public class ErrorData
    {
        public int errorCode { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }

    public class EligibleResponse
    {
        public bool eligible { get; set; }
        public string title_message { get; set; }
        public string description { get; set; }
    }
}
