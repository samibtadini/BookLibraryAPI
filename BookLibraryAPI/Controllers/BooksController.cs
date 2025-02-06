using Asp.Versioning;
using AutoMapper;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Models;
using BookLibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibraryAPI.Controllers
{
    //[Route("api/books/{authorId}/booksOfAuthor")]
    [Route("api/books/v{version:apiVersion}")]
    [ApiController]
    [ApiVersion(2)]

    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookWithoutAuthorDto>>> GetBooks()
        {
            var books = await _bookRepository.GetBooksAsync();
            return Ok(_mapper.Map<IEnumerable<BookWithoutAuthorDto>>(books));
        }

        [HttpGet("{Id}", Name = "GetBookAsync")]
        public async Task<ActionResult<BookDto>> GetBookAsync(int Id)
        {
            var Book = await _bookRepository.GetBookAsync(Id);
            return Ok(_mapper.Map<BookDto>(Book));
        }


        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBookAsync(int authorId, BookForCreationDto bookForCreation)
        {
            var bookEntity = _mapper.Map<Entities.Book>(bookForCreation);
            await _bookRepository.CreateBookAysnc(authorId, bookEntity);
            var bookToReturn = _mapper.Map<BookDto>(bookEntity);
            return CreatedAtRoute("GetBookAsync",
                new
                {
                    authorId = authorId,
                    Id = bookToReturn.Id
                },
                bookToReturn
            );
        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult> UpdateBookAsync(int authorId,int bookId, BookForUpdateDto bookForUpdate)
        {
            var book = await _bookRepository.GetBookAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(bookForUpdate, book);
            await _bookRepository.UpdateBookAsync(book);
            return NoContent();
        }
        [HttpPatch("{bookId}")]
        public async Task<ActionResult> PartiallyUpdateBookAsync(int authorId, int bookId,
            JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            var book = await _bookRepository.GetBookAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            var bookToPatch = _mapper.Map<BookForUpdateDto>(book);
            patchDocument.ApplyTo(bookToPatch, (error) => ModelState.AddModelError("", error.ErrorMessage));
            if (!TryValidateModel(bookToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(bookToPatch, book);
            await _bookRepository.UpdateBookAsync(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletebookAsync(int id)
        {
            var book = await _bookRepository.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookRepository.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
