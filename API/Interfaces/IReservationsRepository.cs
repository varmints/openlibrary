using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IReservationsRepository
    {
        Task<Reservation> GetReservation(int sourceUserId, int reservedBookId);
        Task<Book> GetBookWithReservations(int bookId);
        Task<IEnumerable<ReservationDto>> GetBookReservation(string predicate, int userId);
    }
}