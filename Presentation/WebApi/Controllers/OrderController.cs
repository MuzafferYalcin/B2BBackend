using Application.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetByIdDto(id);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpGet("getByCustomerId/{customerid}")]
        public IActionResult GetByCustomerId(int customerid)
        {
            var result = _orderService.GetByCustomerId(customerid);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }


        [HttpGet("getList")]
        public IActionResult GetList()
        {
            var result = _orderService.GetAll();
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("add/{customerId}")]
        public IActionResult Add(int customerId)
        {
            var result = _orderService.Add(customerId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Order order)
        {
            var result = _orderService.Delete(order);
            if (result.Success)
                return Ok(result);

            return BadRequest(result.Message);
        }


    }
}
