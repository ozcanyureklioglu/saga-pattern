using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaPattenr.Shared
{
    public sealed class InventoryChange
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

    }
}
