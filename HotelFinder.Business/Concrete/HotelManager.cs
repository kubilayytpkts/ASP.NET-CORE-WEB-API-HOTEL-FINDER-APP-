using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelManager
    {
        private IHotelrepository hotelrepository;
        public HotelManager()
        {
            hotelrepository = new HotelRepository();
        }

        public Hotel CreateHotel(Hotel hotel)
        {
           return hotelrepository.CreateHotel(hotel);
            
        }

        public void DeleteHotel(int id)
        {
             hotelrepository.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotels()
        {
            return hotelrepository.GetAllHotels();
        }

        public Hotel GetHotelsById(int id)
        {
            return hotelrepository.GetHotelById(id);
        }

        public Hotel GetHotelsByName(string name)
        {
           return hotelrepository.GetHotelsByName(name);
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return hotelrepository.UpdateHotel(hotel);
        }
    }
}
