using AutoMapper;
using EmagApi.Application.Dtos;
using EmagApi.Application.Services;
using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmagApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteServices siteServices;
        private readonly IMapper mapper;

        public SiteController(ISiteServices siteServices,IMapper mapper)
        {
            this.siteServices = siteServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var site = await siteServices.GetAll();
            return Ok(site);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var site = await siteServices.GetById(id);
            if (site == null)
            {
                NotFound();
            }
            return Ok(site);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSiteDto addSiteDto)
        {
            var site = mapper.Map<Site>(addSiteDto);
            await siteServices.Add(site);
            return CreatedAtAction(nameof(GetById), new { id = site.Id });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SiteDto siteDto)
        {
            if (siteDto == null || id != siteDto.Id)
            {
                return BadRequest("Invalid site data.");
            }

            var existingSite = await siteServices.GetById(id);
            if (existingSite == null)
            {
                return NotFound();
            }

            mapper.Map(siteDto, existingSite); // Mise à jour de l'entité existante
            await siteServices.Update(existingSite);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Dedlete(int id)
        {
            var site = await siteServices.GetById(id);
            if (site is null)
            {
                return NotFound();
            }
            {
                await siteServices.Delete(id);
            }
            return NoContent();
        }
    }
}
