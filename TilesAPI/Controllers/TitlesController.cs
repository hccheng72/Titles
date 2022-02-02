using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TitlesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitleService _titleService;
        public TitlesController(ITitleService movieService)
        {
            _titleService = movieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllTitles()
        {
            var titles = await _titleService.GetAllTitles();
            if (titles == null) return NotFound();
            return Ok(titles);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Search([FromBody] string titleName)
        {
            var searchedTitles = await _titleService.SearchByTitleName(titleName);
            return Ok(searchedTitles);
        }

        [HttpGet]
        [Route("details/{id:int}")] 
        public async Task<IActionResult> Details(int id)
        {
            var title = await _titleService.GetDetailsById(id);
            if (title == null)
            {
                return NotFound();
            }
            return Ok(title);
        }
    }
}
