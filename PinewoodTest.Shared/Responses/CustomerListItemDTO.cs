using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTest.Responses
{
    public class CustomerListItemDTO
    {
        public required Guid ID { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }
}
