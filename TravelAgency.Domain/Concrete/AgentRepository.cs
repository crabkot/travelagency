using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Concrete
{
    public class AgentRepository : IAgentRepository
    {
        private readonly TravelAgencyDbContext db;

        public AgentRepository(TravelAgencyDbContext context)
        {
            db = context;
        }

        public IQueryable<TravelAgent> GetAgents()
        {
            return db.TravelAgents;
        }
        
    }
}
