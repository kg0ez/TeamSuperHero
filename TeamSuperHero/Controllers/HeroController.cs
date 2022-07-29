using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamSuperHero.Dto;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;

namespace TeamSuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISuperHeroServices _heroServices;

        public HeroController(IMapper mapper, ISuperHeroServices superHeroServices)
        {
            _mapper = mapper;
            _heroServices = superHeroServices;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var heroes = _mapper.Map<List<SuperHeroDto>>(_heroServices.GetHeroes());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var hero = _mapper.Map<SuperHeroDto>(_heroServices.GetSuperHero(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post(SuperHeroDto hero) =>
            _heroServices.CreateHero(_mapper.Map<SuperHero>(hero)) ? Ok("SuperHero has been created") : BadRequest("SuperHero not created");

        [HttpPut]
        public IActionResult Put(SuperHero hero) =>
            _heroServices.UpdateHero(hero) ? Ok("SuperHero has been updated") : BadRequest("SuperHero not updated");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            _heroServices.DeleteHero(id) ? Ok("SuperHero has been removed") : BadRequest("SuperHero not deleted");
    }
}

