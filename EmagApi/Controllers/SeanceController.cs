using EmagApi.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using EmagApi.Application.Dtos;
using EmagApi.Domain.Models;
using AutoMapper;

namespace EmagApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
        private readonly ISeanceServices seanceServices;
        private readonly IMapper mapper;

        public SeanceController(ISeanceServices seanceServices,IMapper  mapper)
        {
            this.seanceServices = seanceServices;
            this.mapper = mapper;
        }
        [HttpGet("{professeurId}")]
        public async Task<IActionResult> GetSeancesByProfesseurIdAsync(int professeurId)
        {
            try
            {
                var seances = await seanceServices.GetSeancesByProfesseurIdAsync(professeurId);

                if (seances == null || !seances.Any())
                {
                    return NotFound("Aucune séance trouvée pour ce professeur.");
                }

                return Ok(seances);  // Retourner les séances trouvées
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);  // Gérer l'exception de validation d'ID
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);  // Gérer le cas où aucune séance n'est trouvée
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne est survenue : " + ex.Message);  // Gestion des autres erreurs
            }
        }
        [HttpGet("name/{professeurName}")]
        public async Task<IActionResult> GetSeancesByProfesseurNameAsync(string professeurName)
        {
            try
            {
                var seances = await seanceServices.GetSeancesByProfesseurNameAsync(professeurName);
                if (seances == null || !seances.Any())
                {
                    return NotFound("Aucune séance trouvée pour ce professeur.");
                }

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(seances, options);

                return Ok(json);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Une erreur interne est survenue : " + ex.Message);
            }
        }

        [HttpGet("{Seance}/{id}")]
        public async Task<IActionResult>GetSeanceByIdAsync(int id)
        {
            var session = await seanceServices.GetSeanceByIdAsync(id);
            return Ok(session);
        }
        [HttpPost]
        public async Task<IActionResult>AddSeancesAsync(AddSeanceDto addSeanceDto)
        {
            var seance = mapper.Map<Seance>(addSeanceDto);
            await seanceServices.AddSeanceAsync(seance);
            //  return CreatedAtAction(nameof(GetSeanceByIdAsync), new { id = seance.Id }, seance);
            return Ok("Seance ajouter avec success");
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteSeanceAsync(int id)
        {
            var seance = await seanceServices.GetSeanceByIdAsync(id);
            if (seance is null)
            {
                return NotFound();
            }
            else
            {
                await seanceServices.DeleteSeanceAsync(id);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateSeanceAsync(int id,SeanceDto seanceDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var existingSeance = await seanceServices.GetSeanceByIdAsync(id);
            if (existingSeance is null)
            {
                return NotFound();
            }
            else
            {
                var updateSeance = mapper.Map(seanceDto,existingSeance);
                await seanceServices.UpdateSeanceAsync(updateSeance);
                return NoContent();
            }
        }
    }
}




