using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Domain.Entities;

namespace TravelAgency.WebApi.Models
{
    public class AgencyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool IsBranch { get; set; }
        public List<TravelAgent> TravelAgents{ get; set; }

}
}
