using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;

namespace HotelsFinder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        IHotelManager hotelManeger;
        public HotelsController()
        {
            hotelManeger = new HotelManager();     
        }
        [HttpGet]
        public List<Hotel> GetAllHotels()
        {
            return hotelManeger.GetAllHotels();
        }
        [HttpGet("{id}")]
        public Hotel GetHotelsById(int id)
        {
            return hotelManeger.GetHotelsById(id);
        }
        [HttpPost]
        public Hotel CreateHotel([FromBody]Hotel hotel)
        {
           return hotelManeger.CreateHotel(hotel);
        }
        [HttpPut]
        public Hotel UpdateHotel([FromBody]Hotel hotel) 
        {
            return hotelManeger.UpdateHotel(hotel);
        }
        [HttpDelete("{id}")]
        public void DeleteHotel(int id) 
        {
            hotelManeger.DeleteHotel(id);
        }
    }

}
