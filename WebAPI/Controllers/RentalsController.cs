using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var resultControl = _rentalService.Get(rental.Id);
            if (resultControl != null)
            {
                var result = _rentalService.Update(rental);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);

        }

        [HttpPost("updateActiveFlag")]
        public IActionResult UpdateActiveFlag(Rental rental)
        {
            var result = _rentalService.UpdateActiveFlag(rental.CustomerId, rental.CarId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var resultControl = _rentalService.Get(rental.Id);
            if (resultControl != null)
            {
                var result = _rentalService.Delete(rental);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);
        }




        [HttpGet("getRentalList")]
        public IActionResult GetRentalList()
        {
            var result = _rentalService.GetRentalList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("checkRental")]
        public IActionResult CheckRental(DateTime rentDate, DateTime returnDate, int carId)
        {
            var result = _rentalService.CheckRental(rentDate, returnDate, carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
