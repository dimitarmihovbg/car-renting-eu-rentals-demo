using CarRentingEu.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentingEu.Dtos
{
    public class MembershipTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
