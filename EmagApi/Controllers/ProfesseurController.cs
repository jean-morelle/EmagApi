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
    public class ProfesseurController : ControllerBase
    {
        private readonly IProfesseurServices professeurServices;
        private readonly IMapper mapper;

        public ProfesseurController(IProfesseurServices professeurServices,IMapper mapper)
        {
            this.professeurServices = professeurServices;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProfesseursAsync()
        {
          var professeur = await professeurServices.GetAllProfesseursAsync();
            return Ok(professeur);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProfesseurByIdAsync(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            var professeur = await professeurServices.GetProfesseurByIdAsync(Id);
            return Ok(professeur);
        }
        [HttpPost]
        public async Task<IActionResult>AddNewProfesseurAsync(AddProfesseurDto professeurDto)
        {
            var professeur = mapper.Map<Professeur>(professeurDto);
            await professeurServices.AddProfesseurAsync(professeur);
            CreatedAtAction(nameof(GetProfesseurByIdAsync), new { Id = professeur.Id }, professeur);
            return Ok($"Creer avec success");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProfesseur(int id)
        {
            if (id <= 0)
            {
              return BadRequest();
            }
            var professeur = await professeurServices.GetProfesseurByIdAsync(id);
            if(professeur == null)
            {
                NotFound(id);
            }
            else
            {
                await professeurServices.DeleteProfesseurAsync(id);
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesseurAsync(int id, [FromBody] ProfesseurDto professeurDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var existingProfesseur = await professeurServices.GetProfesseurByIdAsync(id);
            if (existingProfesseur == null)
            {
                return NotFound(id);
            }

            var updatedProfesseur = mapper.Map(professeurDto, existingProfesseur);
            await professeurServices.UpdateProfesseurAsync(updatedProfesseur);

            return NoContent();
        }

    }
}
