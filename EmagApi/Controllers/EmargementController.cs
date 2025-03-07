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
    public class EmargementController : ControllerBase
    {
        private readonly IEmargementServices emargementServices;
        private readonly IMapper mapper;

        public EmargementController( IEmargementServices emargementServices,IMapper mapper)
        {
            this.emargementServices = emargementServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emargement = await emargementServices.GetAll();
            return Ok(emargement);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var emargement = await emargementServices.GetById(id);
            if (emargement == null)
            {
                NotFound();
            }
            return Ok(emargement);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmargementDto addEmargementDto)
        {
            // Vérifier si le modèle est valide
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Log pour débogage
            Console.WriteLine($"📌 ProfesseurId={addEmargementDto.ProfesseurId}, Début={addEmargementDto.HeureDebut}, Fin={addEmargementDto.HeureFin}");

            // Vérifier si un émargement existe déjà pour ce professeur à cette période (même horaire, même matière, même site)
            var existingEmargement = await emargementServices
                .GetEmargementByDetails(
                    addEmargementDto.ProfesseurId,
                    addEmargementDto.HeureDebut,
                    addEmargementDto.HeureFin,
                    addEmargementDto.MatiereId,
                    addEmargementDto.SiteId);

            if (existingEmargement != null)
            {
                // Si un émargement existe déjà, retourner un conflit
                return Conflict("Ce professeur a déjà une séance à cette période pour la même matière et le même site.");
            }

            // Créer un nouvel émargement
            var emargement = new Emargement
            {
                ProfesseurId = addEmargementDto.ProfesseurId,
                HeureDebut = addEmargementDto.HeureDebut,
                HeureFin = addEmargementDto.HeureFin,
                MatiereId = addEmargementDto.MatiereId,
                FiliereId = addEmargementDto.FiliereId,
                SiteId = addEmargementDto.SiteId
            };

            // Ajouter l'émargement à la base de données
             await emargementServices.Add(emargement);

            // Retourner une réponse 201 Created avec l'émargement créé
            return CreatedAtAction(nameof(GetById), new { id = emargement.Id }, emargement);
        }




        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, [FromBody]EmargementDto emargementDto)
        {
            if (id != emargementDto.Id)
            {
                return BadRequest();
            }
            var existingEmargement = await emargementServices.GetById(id);
            if (existingEmargement == null)
            {
                return NotFound();
            }
            var updatedEmargement = mapper.Map(emargementDto,existingEmargement);
            await emargementServices.Update(updatedEmargement);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emargement = await emargementServices.GetById(id);
            if (emargement is null)
            {
                return NotFound();
            }

            try
            {
                await emargementServices.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite : {ex.Message}");
            }
        }

    }
}
