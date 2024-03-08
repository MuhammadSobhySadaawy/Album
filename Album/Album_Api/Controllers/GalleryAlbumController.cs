using Album.DataProviders;
using Album.Infrastructure.Helpers;
using Album.Models.API.Request;
using Album.Models.API.Response;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Album_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryAlbumController : ControllerBase
    {
        private readonly IDefaultDataProvider _dataProvider;
        protected readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GalleryAlbumController(IDefaultDataProvider dataProvider, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
            _dataProvider = dataProvider;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _dataProvider.gllaryAlbum.GetById(id);
            HostPathBase.UrlHostPathBase = _configuration["baseUrl"];
            if (result is null)
                return BadRequest("Not Album Found");
            return Ok(_mapper.Map<AlbumDto>(result));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _dataProvider.gllaryAlbum.GetAll();
            HostPathBase.UrlHostPathBase = _configuration["baseUrl"];
            if (result is null)
                return BadRequest("Not Gllary Albums Found");
            return Ok(_mapper.Map<IEnumerable<AlbumsDto>>(result));
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _dataProvider.gllaryAlbum.Delete(id);
            if (result is null)
                return BadRequest("Not Deleted");
            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(AlbumRequest request)
        {
            var result = await _dataProvider.gllaryAlbum.Save(request);
            if (result is null)
                return BadRequest("Not Save");
            return Ok(result);
        }
    }
}
