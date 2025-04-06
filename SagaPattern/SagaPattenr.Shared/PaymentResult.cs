using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaPattenr.Shared
{
    public sealed class PaymentResult
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
