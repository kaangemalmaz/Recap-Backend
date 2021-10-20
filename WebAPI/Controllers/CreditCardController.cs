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
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("getall")]
        //[Authorize("brand.list")]
        public IActionResult GetAll()
        {
            var result = _creditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _creditCardService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.Add(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCard creditCard)
        {
            var resultControl = _creditCardService.Get(creditCard.Id);
            if (resultControl != null)
            {
                var result = _creditCardService.Update(creditCard);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);

        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var resultControl = _creditCardService.Get(creditCard.Id);
            if (resultControl != null)
            {
                var result = _creditCardService.Delete(creditCard);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);

        }

        [HttpGet("getCreditCardByEmail")]
        public IActionResult GetCreditCardByEmail(string email)
        {
            var result = _creditCardService.GetCreditCardByEmail(email);
            return Ok(result);
        }
    }
}
