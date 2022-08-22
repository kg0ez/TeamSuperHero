using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamSuperHero.Dto;
using TeamSuperHero.Models.DataBaseModels;
using TeamSuperHero.Services.Interfaces;


namespace TeamSuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : Controller
    {
        private IComicServices _comicServices;
        private readonly IMapper _mapper;

        public ComicController(IComicServices comicServices,IMapper mapper)
        {
            _comicServices = comicServices;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Comic>))]
        public IActionResult GetComics()
        {
            var comics = _mapper.Map<List<ComicDto>>(_comicServices.GetComics());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(comics);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comic>))]
        [ProducesResponseType(400)]
        public IActionResult GetComic(int id)
        {
            if (!_comicServices.ComicExists(id))
                return NotFound();

            var comics = _mapper.Map<ComicDto>(_comicServices.GetComic(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           return Ok(comics);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Post(ComicDto comic)=>
            _comicServices.CreateComic(_mapper.Map<Comic>(comic)) ? Ok("Comic has been created") : BadRequest("Comic not created");

        [HttpPut]
        public IActionResult Put(Comic comic)=>
            _comicServices.UpdateComic(comic)? Ok("Comic has been updated") : BadRequest("Comic not updated");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)=>
            _comicServices.DeleteComic(id)? Ok("Comic has been removed"):BadRequest("Comic not deleted");
    }
}

