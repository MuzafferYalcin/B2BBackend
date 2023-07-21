using Application.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        [HttpGet("getList")]
        public IActionResult GetList() { 
            var result = _basketService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpGet("get/{id}")]
        public IActionResult GetAction(int id)
        {
            var result = _basketService.Get(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpGet("getListByCustomerId/{customerId}")]
        public IActionResult GetListByCustomerId(int customerId) {
            var result = _basketService.GetByCustomerId(customerId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(Basket basket)
        {
            var result = _basketService.Add(basket);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public IActionResult Update(Basket basket)
        {
            var result = _basketService.Update(basket);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Basket basket)
        {
            var result = _basketService.Delete(basket);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
