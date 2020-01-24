using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.Services.Interfaces;
using SF.Services.Models.Genres;
using SF.WebAPI.Models.CustomValidations;
using SF.WebAPI.Models.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;

        public GenreController(IMapper mapper, IGenreService genreService)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllGenresAsync()
        {
            var genresDTO = await _genreService.GetAllGenresAsync();

            var genresViewModel = _mapper.Map<List<GenreViewModel>>(genresDTO);

            return Ok(genresViewModel);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGenreByIdAsync([GreaterThanZero] int id)
        {
            var genreDTO = await _genreService.GetGenreByIdAsync(id);

            var genreViewModel = _mapper.Map<GenreViewModel>(genreDTO);

            return Ok(genreViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenreAsync([FromBody]CreateGenreViewModel createGenreViewModel)
        {
            var createGenreDTO = _mapper.Map<CreateGenreDTO>(createGenreViewModel);

            var genreDTO = await _genreService.CreateGenreAsync(createGenreDTO);

            var genreViewModel = _mapper.Map<GenreViewModel>(genreDTO);

            return Ok(genreViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenreAsync([FromBody]UpdateGenreViewModel updateGenreViewModel)
        {
            var updateGenreDTO = _mapper.Map<UpdateGenreDTO>(updateGenreViewModel);

            var genreDTO = await _genreService.UpdateGenreAsync(updateGenreDTO);

            var genreViewModel = _mapper.Map<GenreViewModel>(genreDTO);

            return Ok(genreViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync([GreaterThanZero]int id)
        {
            await _genreService.DeleteGenreAsync(id);

            return NoContent();
        }
    }
}