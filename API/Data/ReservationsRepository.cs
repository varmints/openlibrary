using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Data
{
    public class ReservationsRepository : IReservationsRepository
    {
        private readonly DataContext _context;
        public ReservationsRepository(DataContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ReservationDto>> GetBookReservation(string predicate, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookWithReservations(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservation> GetReservation(int sourceUserId, int reservedBookId)
        {
            return await _context.Reservations.FindAsync(sourceUserId, reservedBookId);
        }
    }
}