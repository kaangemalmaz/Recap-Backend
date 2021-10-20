using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // atribute
    public class BrandsController : ControllerBase
    {
        //loose coupling => zayıf bağımlılık çünkü interface ile bağlıdır.
        //burada constructor ile bağlantı üretilen brandService direk olarak metotlar tarafından erişilemediği için biz bir properti belirterek ona veriyoruz ve oradan ulaşıyoruz.
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        //[Authorize("brand.list")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var resultControl = _brandService.Get(brand.Id);
            if (resultControl != null)
            {
                var result = _brandService.Update(brand);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);
            
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var resultControl = _brandService.Get(brand.Id);
            if (resultControl != null)
            {
                var result = _brandService.Delete(brand);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);

        }
    }
}
