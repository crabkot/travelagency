using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgency.Domain.Entities
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int GovermentId { get; set; }
        public bool IsBranch { get; set; }
    }
}
