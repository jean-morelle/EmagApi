using AutoMapper;
using EmagApi.Application.Dtos;
using EmagApi.Application.Services;
using EmagApi.Domain.Interface;
using EmagApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
        public async Task<IActionResult> GetAll()
        {
            var professeur = await professeurServices.GetAll();
            return Ok(professeur);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfesseurById(int id)
        {
            var professeur = await professeurServices.GetById(id);
            if (professeur == null)
            {
                NotFound();
            }
            return Ok(professeur);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProfesseurDto addProfesseurDto)
        {
            var professeur = mapper.Map<Professeur>(addProfesseurDto);
            await professeurServices.Add(professeur);
            // var createdProfesseur = await professeurServices.Add(professeur);
            return Ok("Creer avec succes");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProfesseurDto professeurDto)
        {
            if (id != professeurDto.Id)
            {
                return BadRequest();
            }

            var existingProfesseur = await professeurServices.GetById(id);
            if (existingProfesseur == null)
            {
                return NotFound();
            }

            var updatedProfesseur = mapper.Map(professeurDto, existingProfesseur);
            await professeurServices.Update(updatedProfesseur);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Professeur>> Delete(int id)
        {
            var professeur = await professeurServices.GetById(id);

            if (professeur == null)
            {
                return NotFound(new { message = "Professeur non trouvé" });
            }
            await professeurServices.Delete(id);

            return Ok(new { message = "Professeur supprimé", data = professeur });
        }
    }
}
    

