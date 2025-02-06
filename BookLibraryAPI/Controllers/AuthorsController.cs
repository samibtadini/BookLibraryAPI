using Asp.Versioning;
using AutoMapper;
using BookLibraryAPI.Models;
using BookLibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Route("api/v{version:apiVersion}/authors")]
    [ApiController]
    [Authorize]
    [ApiVersion(1)]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// get book id
        /// </summary>
        ///  /// <param name="Id">The id of the author to get</param>
        /// <response code="200">Returns the requested author</response>
        /// <returns>An author with or without points of interest</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAuthors(int Id)
        {
            var author = await _authorRepository.GetAuthorAsync(Id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author!));
        }
    }
}
