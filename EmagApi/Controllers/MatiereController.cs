using AutoMapper;
using EmagApi.Application.Dtos;
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

        public MatiereController(IMatiereServices matiereServices, IMapper mapper)
        {
            this.matiereServices = matiereServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMatiereAsync()
        {
            var matiere = await matiereServices.GetAllMatieresAsync();
            return Ok(matiere);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatiereByIdAsync(int id)
        {
            var matiere = await matiereServices.GetMatiereByIdAsync(id);
            return Ok(matiere);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMatiereAsync(AddMatiereDto matiereDto)
        {
            var matiere = mapper.Map<Matiere>(matiereDto);
            await matiereServices.AddMatiereAsync(matiere);
            return Ok("Matiere ajouter avec success");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatiere(int id)
        {
            var matiere = await matiereServices.GetMatiereByIdAsync(id);
            if (matiere is null)
            {
                NotFound();
            }
            else
            {
                await matiereServices.DeleteMatiereAsync(id);
                return Ok($"{id} supprimer avec success");
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatiereAsync(int id, MatiereDto matiereDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var existingMatiere = await matiereServices.GetMatiereByIdAsync(id);
            if (existingMatiere == null)
            {
                return NotFound();
            }

            // Map the DTO onto the existing entity
            mapper.Map(matiereDto, existingMatiere);
            await matiereServices.UpdateMatiereAsync(existingMatiere);

            return Ok("Matiere modifiée avec succès");
        }

    }
}
