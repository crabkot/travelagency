using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Abstract
{
    public interface IAgencyRepository
    {
        IQueryable<Agency> GetAgencies();
        bool AddAgentToAgency(int agencyId, int agentId);
    }
}
