using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

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
        /// <summary>
        /// GET ALL HOTELS
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllHotels()
        {
            var getAllHotels = hotelManeger.GetAllHotels();
            if (getAllHotels.Count > 0)
            {
                return Ok(getAllHotels);//200 + data
            }
            return NotFound();//404 error
        }
        /// <summary>
        /// GET HOTELS BY IDE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelsById(int id)
        {
            var getHotelByIde = hotelManeger.GetHotelsById(id);

            if (getHotelByIde!=null)
            {
                return Ok(getHotelByIde);//200 + data
            }
            return NotFound();//404 error
        }
        /// <summary>
        /// CREATE HOTEL
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateHotel([FromBody]Hotel hotel)
        {
            var createdHotel = hotelManeger.CreateHotel(hotel);
            if(createdHotel != null)
            {
                return Ok(createdHotel);//200 + data
            }
            return BadRequest();
        }
        /// <summary>
        /// UPDATE HOTEL
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public  IActionResult UpdateHotel([FromBody]Hotel hotel) 
        {
            var updateHotel= hotelManeger.UpdateHotel(hotel);
            if(updateHotel!=null)
            {
                return Ok(updateHotel);//200 + data
            }
            return BadRequest();
        }

        /// <summary>
        /// DELETE 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteHotel(int id) 
        {
            hotelManeger.DeleteHotel(id);
            if(hotelManeger.GetHotelsById(id)==null)
            {
                return Ok("deletion successful");
            }
            return NotFound();
        }
        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelsByName(string name)
        {
            var arrivingHotel = hotelManeger.GetHotelsByName(name);
            if(arrivingHotel!=null)
            {
                return Ok(arrivingHotel);
            }
            return NotFound("the searched hotel was not found");
        }
    }

}
