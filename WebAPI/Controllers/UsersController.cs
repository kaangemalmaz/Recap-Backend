using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userManager;

        public UsersController(IUserService userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userManager.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userManager.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update(User user, string password)
        {
            var resultControl = _userManager.Get(user.Id);
            if (resultControl.Data != null)
            {
                var result = _userManager.Update(user, password);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);

        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var resultControl = _userManager.Get(user.Id);
            if (resultControl.Data != null)
            {
                var result = _userManager.Delete(user);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(resultControl.Message);
        }

        [HttpGet("getByMail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userManager.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateUser")]
        public IActionResult UpdateUser(UserForUpdate userForUpdate)
        {
            var resultControl = _userManager.Get(userForUpdate.Id);
            if (resultControl.Data != null)
            {
                var result = _userManager.UpdateUser(userForUpdate);
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
