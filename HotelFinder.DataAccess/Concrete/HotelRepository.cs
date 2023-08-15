using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelrepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using(var hoteldbcontext=new HotelDbContext())
            {
                hoteldbcontext.Hotels.Add(hotel);
                hoteldbcontext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using(var hoteldbcontext=new HotelDbContext())
            {
                var hotel = GetHotelById(id);
                hoteldbcontext.Hotels.Remove(hotel);
                hoteldbcontext.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotels()
        {
            using(var hoteldbcontext=new HotelDbContext())
            {
              return hoteldbcontext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using(var hoteldbcontext=new HotelDbContext())
            {
              return hoteldbcontext.Hotels.Find(id);

            }
        }

        public Hotel GetHotelsByName(string name)
        {
            using(var hoteldbcontext=new HotelDbContext())
            {
                var hotelLocated = hoteldbcontext.Hotels.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());
                return hotelLocated;
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using(var hoteldbcontext=new HotelDbContext())
            {
                hoteldbcontext.Hotels.Update(hotel);
                hoteldbcontext.SaveChanges();
                return hotel;
            }
        }
    }
}
