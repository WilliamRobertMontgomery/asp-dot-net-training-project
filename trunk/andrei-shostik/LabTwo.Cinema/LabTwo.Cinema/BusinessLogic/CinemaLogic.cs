using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using LabTwo.Cinema.DataAccess.Repository;
using LabTwo.Cinema.Entities;

namespace LabTwo.Cinema.BusinessLogic
{
    public class CinemaLogic
    {
        private readonly IRepository _repository;
        private ICrudRepository<EntityBase> _crudRepository;
        private CinemaDataContext _cinema;

        public CinemaLogic(IRepository repository, ICrudRepository<EntityBase> crudRepository)
        {
            _repository = repository;
            _crudRepository = crudRepository;
        }

        public CinemaLogic(IRepository repository)
        {
            _repository = repository;
        }

        public CinemaLogic(CinemaDataContext data)
        {
            _cinema = data;
        }

        public bool CanBuyTicket()
        {
            return _cinema.Seats.Select(elem => elem.SeatNumber).Count() <= Seat.MaxSeats;
        }

        public void BuyTicket(Film film, Visitor visitor, Cashier cashier, string seat)
        {
            var dateTime = new DateTime(2012, 7, 5);
            var order = new Order
                            {
                                OrderID = Guid.NewGuid().ToString(),
                                Visitor = visitor,
                                VisitorID = visitor.VisitorID,
                                Cashier = cashier,
                                CashierID = cashier.CashierID,
                                Film = film,
                                FilmID = film.FilmID,
                                DataSale = dateTime
                            };
            _cinema.Orders.InsertOnSubmit(order);
            //_cinema.Seats.InsertOnSubmit(new Seat { OrderID = order.OrderID, SeatNumber = seat });
            _cinema.Visitors.InsertOnSubmit(visitor);
            _cinema.SubmitChanges();
        }

        public void CreateVisitor(Visitor item)
        {
            _cinema.Visitors.InsertOnSubmit(item);
            _cinema.SubmitChanges();
        }

        public Film GetFilmByTitle(string filmTitle)
        {
            return _cinema.Films.FirstOrDefault(elem => elem.Title == filmTitle);
        }

        public IEnumerable<string> GetAllCashiers()
        {
            return _cinema.Cashiers
            .Select(elem => string.Format("{0} {1}", elem.FirstName, elem.LastName));
        }

        public Cashier GetCashierByLastName(string lastName)
        {
            return _cinema.Cashiers.FirstOrDefault(elem => elem.LastName == lastName);
        }

        public IEnumerable<string> GetAllFilms()
        {
            return _cinema.Films
                .Select(elem => string.Format("{0} {1} {2}", elem.Title, elem.Year, elem.Genre));
        }

        public IEnumerable<string> GetAllSeats()
        {
            return _cinema.Seats.Select(elem => elem.SeatNumber);
        }

        public void BookTicket()
        {
            throw new NotImplementedException();
        }
    }
}