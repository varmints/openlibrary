using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ReservationsController : BaseApiController
    {
        private readonly IUserRepository _userReppository;
        private readonly IBookRepository _bookRepository;
        private readonly IReservationsRepository _reservationsRepository;
        public ReservationsController(IUserRepository userReppository,
                                      IReservationsRepository reservationsRepository,
                                      IBookRepository bookRepository)
        {
            _reservationsRepository = reservationsRepository;
            _bookRepository = bookRepository;
            _userReppository = userReppository;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddReservation(int id)
        {
            var sourceUserId = User.GetUserId();
            var reservedBook = await _bookRepository.GetBookByIdAsync(id);

            
            return BadRequest("Failed to like user");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetBookResertions(string predicte)
        {
            var reservations = await _reservationsRepository.GetBookReservation(predicte, User.GetUserId());

            return Ok();
        }
    }
}