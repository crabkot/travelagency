using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Concrete
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly TravelAgencyDbContext db;

        public AgencyRepository(TravelAgencyDbContext context)
        {
            db = context;
        }

        public IQueryable<Agency> GetAgencies()
        {
            return db.Agencies;
        }
        public bool AddAgentToAgency(int agencyId, int agentId)
        {
            bool result = false;

            Agency dbAgency = db.Agencies.FirstOrDefault(x => x.Id == agencyId);
            TravelAgent  dbAgent = db.TravelAgents.FirstOrDefault(x => x.Id == agentId);
             

            if (dbAgency!=null && dbAgent!=null)
             {
                dbAgent.AgencyId = dbAgency.Id;

                db.Entry(dbAgent).State = EntityState.Modified;

                result = db.SaveChanges() > 0;
            }

            return result;
        }
    }
}
