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
    public class FiliereController : ControllerBase
    {
        private readonly IFiliereServices filiereServices;
        private readonly IMapper mapper;

        public FiliereController(IFiliereServices filiereServices,IMapper mapper) { 
            this.filiereServices = filiereServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filiere = await filiereServices.GetAll();
            return Ok(filiere);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var filiere = await filiereServices.GetById(id);
            if (filiere == null)
            {
                NotFound();
            }
            return Ok(filiere);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddFiliereDto addFiliereDto)
        {
            var filiere = mapper.Map<Filiere>(addFiliereDto);
            await filiereServices.Add(filiere);
            return CreatedAtAction(nameof(GetById), new { id = filiere.Id });
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, [FromBody] FiliereDto filiereDto)
        {
            if (id != filiereDto.Id)
            {
                return BadRequest();
            }
            var existingFiliere = await filiereServices.GetById(id);
            if (existingFiliere == null)
            {
                return NotFound();
            }
            var updatedFiliere = mapper.Map(filiereDto,existingFiliere);
            await filiereServices.Update(updatedFiliere);
            return NoContent();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var matiere = await filiereServices.GetById(id);
            if (matiere is null)
            {
                return NotFound();
            }
            else
            {
                await filiereServices.Delete(id);
            }
            return NoContent();
        }
    }
}
