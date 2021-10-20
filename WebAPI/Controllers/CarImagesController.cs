using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("ImagePath"))] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(formFile, carImage);
            if (result.Success) return Ok();
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("ImagePath"))] IFormFile formFile, [FromForm] CarImage carImage)
        {

            var result = _carImageService.Update(formFile, carImage);
            if (result.Success) return Ok();
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {

            var result = _carImageService.Delete(carImage);
            if (result.Success) return Ok();
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcarimage")]
        public IActionResult GetAllCarImage(int id)
        {

            var result = _carImageService.GetCarImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getCarImageByCarId")]
        public IActionResult GetCarImageByCarId(int id)
        {

            var result = _carImageService.GetCarImageByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
