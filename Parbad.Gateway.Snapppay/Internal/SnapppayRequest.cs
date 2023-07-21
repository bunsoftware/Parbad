using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parbad.Gateway.Snapppay.Internal
{

    public class CartItem
    {
        public decimal amount { get; set; }
        public string category { get; set; }
        public int count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int commissionType { get; set; }
    }

    public class CartList
    {
        public int cartId { get; set; }
        public List<CartItem> cartItems { get; set; }
        public bool isShipmentIncluded { get; set; }
        public bool isTaxIncluded { get; set; }
        public int shippingAmount { get; set; }
        public int taxAmount { get; set; }
        public int totalAmount { get; set; }
    }

    public class SnapppayRequest
    {
        public decimal amount { get; set; }
        public List<CartList> cartList { get; set; }
        public decimal discountAmount { get; set; }
        public int externalSourceAmount { get; set; }
        public string mobile { get; set; }
        public string paymentMethodTypeDto { get; set; }
        public string returnURL { get; set; }
        public string transactionId { get; set; }
    }
}
