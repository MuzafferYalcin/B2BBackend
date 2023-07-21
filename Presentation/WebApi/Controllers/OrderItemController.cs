using Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }


        [HttpGet("getByOrderId/{orderid}")]
        public IActionResult GetByOrderId(int orderid)
        {
            var result = _orderItemService.GetListByOrderId(orderid);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getListDto")]
        public IActionResult GetListDto(int orderid)
        {
            var result = _orderItemService.GetListDto(orderid);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
