using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TravelAgency.Domain.Abstract;
using TravelAgency.WebApi.Helpers;
using TravelAgency.WebApi.Models;

namespace TravelAgency.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgencyController : Controller
    {
        private readonly IAgencyRepository agencyRepo;
        private readonly IAgentRepository agentRepo;

        public AgencyController(IAgencyRepository _agencyRepo, IAgentRepository _agentRepo)
        {
            agencyRepo = _agencyRepo;
            agentRepo = _agentRepo;
        }

        [HttpGet]
        public IEnumerable<AgencyViewModel> Get()
        {
            IEnumerable<AgencyViewModel> agencies = agencyRepo.GetAgencies().Select(x => new AgencyViewModel() {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Country = GetCountryByGovermentId(x.GovermentId),
                IsBranch = x.IsBranch
            });

            return agencies;
        }

        [HttpPut]
        public IActionResult PutAgentToAgency(int id, [FromBody] int agentId)
        {
            try
            {
                agencyRepo.AddAgentToAgency(id, agentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [Route("generateXml")]
        [HttpPost]
        public async Task<IActionResult> GenerateXmlAsync() {

             IEnumerable<AgencyViewModel> agencies = agencyRepo.GetAgencies().Select(x => new AgencyViewModel()
             {
                 Id = x.Id,
                 Name = x.Name,
                 Email = x.Email,
                 Country = GetCountryByGovermentId(x.GovermentId),
                 IsBranch = x.IsBranch,
                 TravelAgents = agentRepo.GetAgents().ToList()
             });

             XmlHelper.CreateXmlFile(agencies.ToArray());

            
            var memory = new MemoryStream();
            using (var stream = new FileStream(XmlHelper.xmlZipFilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, "application/zip", Path.GetFileName(XmlHelper.xmlZipFilePath));
        }

        static private string GetCountryByGovermentId(int govermentId)
        {
            switch (govermentId)
            {
                case 1:
                    return "EU";
                case 2:
                    return "USA";
                default:
                    return "Other";
            }
        }
    }
}
