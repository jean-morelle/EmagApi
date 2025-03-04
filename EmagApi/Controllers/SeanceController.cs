using EmagApi.Application.Dtos;
using EmagApi.Domain.Models;
using EmagApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmagApi.Domain.Interface;

namespace EmagApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeanceController : ControllerBase
    {
        private readonly ISeanceServices seanceServices;
        private readonly IMapper _mapper;

        public SeanceController(ISeanceServices seanceServices, IMapper mapper)
        {
            this.seanceServices = seanceServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSeance()
        {
            var seance = await seanceServices.GetAllSeances();
            return Ok(seance);
        }

        // GET: api/seance/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeance(int id)
        {
            try
            {
                var seance = await seanceServices.GetSeanceByIdAsync(id);
                if (seance == null)
                {
                    return NotFound($"Séance avec ID {id} non trouvée.");
                }

                // Mapper l'entité Seance en SeanceDto
                var seanceDto = _mapper.Map<SeanceDto>(seance);
                return Ok(seanceDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne : {ex.Message}");
            }
        }

        // POST: api/seance
        [HttpPost]
        public async Task<IActionResult> CreateSeance([FromBody] AddSeanceDto addSeanceDto)
        {
            try
            {
                // Mapper le AddSeanceDto en entité Seance
                var seance = _mapper.Map<Seance>(addSeanceDto);
                await seanceServices.AddSeanceAsync(seance);

                return CreatedAtAction(nameof(GetSeance), new { id = seance.Id }, seance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/seance/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeance(int id, [FromBody] SeanceDto seanceDto)
        {
            if (id != seanceDto.Id)
            {
                return BadRequest("ID de la séance incorrect.");
            }

            try
            {
                // Mapper SeanceDto en entité Seance
                var seance = _mapper.Map<Seance>(seanceDto);
                await seanceServices.UpdateSeanceAsync(seance);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/seance/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeance(int id)
        {
            try
            {
                await seanceServices.DeleteSeanceAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/seance/professeur/{nom}
        //[HttpGet("professeur/{nom}")]
        //public async Task<IActionResult> GetSeancesByProfesseurName(string nom)
        //{
        //    try
        //    {
        //        var seances = await seanceServices.GetSeancesByProfesseurNameAsync(nom);

        //        if (seances == null || seances.Count == 0)
        //        {
        //            return NotFound("Aucune séance trouvée pour ce professeur.");
        //        }

        //        // Mapper la liste des Seances en une liste de SeanceDto
        //        var seancesDto = _mapper.Map<List<SeanceDto>>(seances);
        //        return Ok(seancesDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
    }
}
