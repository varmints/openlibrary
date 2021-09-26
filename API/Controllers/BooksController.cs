using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class BooksController : BaseApiController
    {
        private readonly IBookRepository _bookRepository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BooksController(DataContext context, IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetUsers()
        {
            var books = await _bookRepository.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        [HttpPost("add-book")]
        public async Task<ActionResult<BookAddDto>> AddBook(BookAddDto bookAddDto)
        {
            var book = new Book
            {
                Title = bookAddDto.Title,
                Author = bookAddDto.Author,
                ReleaseDate = bookAddDto.ReleaseDate,
                ShortDescription = bookAddDto.ShortDescription,
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}/edit-book")]
        public async Task<ActionResult> UpdateBook(int id, BookUpdateDto bookUpdateDto)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            
            _mapper.Map(bookUpdateDto, book);

            _bookRepository.Update(book);

            if(await _bookRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update book");
        }
    }
}