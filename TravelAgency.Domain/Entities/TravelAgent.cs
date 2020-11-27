using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgency.Domain.Entities
{
    public class TravelAgent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int? AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}
