using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamSuperHero.Dto;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;

namespace TeamSuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITeamServices _teamServices;

        public TeamController(IMapper mapper, ITeamServices teamServices)
        {
            _mapper = mapper;
            _teamServices = teamServices;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _mapper.Map<List<TeamDto>>(_teamServices.GetTeams());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teams);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var team = _mapper.Map<TeamDto>(_teamServices.GetTeam(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(team);
        }

        [HttpPost]
        public IActionResult Post(TeamDto team) =>
            _teamServices.CreateTeam(_mapper.Map<Team>(team)) ? Ok("Team has been created") : BadRequest("Team not created");

        [HttpPut]
        public IActionResult Put(Team team) =>
            _teamServices.UpdateTeam(team) ? Ok("Team has been updated") : BadRequest("Team not updated");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            _teamServices.DeleteTeam(id) ? Ok("Team has been removed") : BadRequest("Team not deleted");
    }
}

