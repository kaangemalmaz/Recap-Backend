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
    [ApiController] //atribute
    public class ColorsController : ControllerBase
    {
        //Burada manager classı loose coupling olarak ayarlanır. Zayıf bağımlılık şu yüzden sen manager classı içinde dal IColorDal 'dan zayıf bağımlılık yaratırsın ve buna injectionda dersinki mesela entityframewrok için eğer birisi senden IColorDal isterse EfColorDal ver dersin böylece ef ile zayıf bağımlılık olur sadece injection kısmını değiştirerek ef yapısını hibernet veya dapper veya inmemory ne istersen ona alabilirsin.

        //Constructor yapılar kullanılarak newlenme ihtiyacından kurtulunur ancak constructor yapılar direk olarak kullanılamayacağı için bir property verilerek onun kullanılması sağlanır. bu da _colorService şeklinde verilir. Buna naming convention denir.

        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorService.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var resultControl = _colorService.Get(color.Id);
            if (resultControl != null)
            {
                var result = _colorService.Update(color);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var resultControl = _colorService.Get(color.Id);
            if (resultControl != null)
            {
                var result = _colorService.Delete(color);
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
