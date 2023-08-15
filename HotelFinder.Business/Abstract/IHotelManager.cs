using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelManager
    {
        List<Hotel> GetAllHotels();
        Hotel GetHotelsById(int id);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        Hotel GetHotelsByName(string name);
        void DeleteHotel(int id);
    }
}
