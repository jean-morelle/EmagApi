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

        public FiliereController(IFiliereServices filiereServices , IMapper mapper)
        {
            this.filiereServices = filiereServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFiliere()
        {
            var filiere = await filiereServices.GetAllFiliereAsync();
            return Ok(filiere);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFiliereById(int id)
        {
            var filiere = await filiereServices.GetFiliereByIdAsync(id);
            return Ok(filiere);
        }
        [HttpPost]
        public async Task<IActionResult> AddFiliere(AddFiliereDto filiereDto)
        {
            if (filiereDto == null)
            {
                return BadRequest("Filiere data is required.");
            }

            var filiere = mapper.Map<Filiere>(filiereDto);
            await filiereServices.AddFiliereAsync(filiere);
            CreatedAtAction(nameof(GetFiliereById), new { id = filiere.Id }, filiere);
            return Ok($"Créé avec succès: {filiere}");
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFiliere(int id, FiliereDto filiereDto)
        {
            if (id <= 0)
            {
                return BadRequest("L'identifiant de la filière est invalide.");
            }

            var existingFiliere = await filiereServices.GetFiliereByIdAsync(id);
            if (existingFiliere == null)
            {
                return NotFound("Filière non trouvée.");
            }

            // Mettre à jour les propriétés de l'entité existante sans toucher à l'ID
            mapper.Map(filiereDto, existingFiliere);

            await filiereServices.UpdateFiliereAsync(existingFiliere);

            return Ok(new { message = "Modifié avec succès", filiere = existingFiliere });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiliereAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var filiere = await filiereServices.GetFiliereByIdAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }

            await filiereServices.DeleteFiliereAsync(id);
            return Ok($"{id} supprimé avec succès");
        }

    }
}
