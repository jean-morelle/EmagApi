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
    public class MatiereController : ControllerBase
    {
        private readonly IMatiereServices matiereServices;
        private readonly IMapper mapper;

        public MatiereController(IMatiereServices matiereServices,IMapper mapper)
        {
            this.matiereServices = matiereServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var matiere = await matiereServices.GetAll();
            return Ok(matiere);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var matiere = await matiereServices.GetById(id);
            if (matiere == null)
            {
                NotFound();
            }
            return Ok(matiere);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddMatiereDto addMatiereDto)
        {
            var matiere = mapper.Map<Matiere>(addMatiereDto);
            await matiereServices.Add(matiere);
            return CreatedAtAction(nameof(GetById), new { id = matiere.Id });
        }
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, [FromBody] MatiereDto matiereDto)
        {
            if (id != matiereDto.Id)
            {
                return BadRequest();
            }
            var existingMatiere = await matiereServices.GetById(id);
            if (existingMatiere == null)
            {
                return NotFound();
            }
            var updatedMatiere= mapper.Map(matiereDto, existingMatiere);
            await matiereServices.Update(updatedMatiere);
            return NoContent();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var matiere = await matiereServices.GetById(id);
            if (matiere is null)
            {
                return NotFound();
            }
            else
            {
                await matiereServices.Delete(id);
            }
            return NoContent();
        }
    }
}
