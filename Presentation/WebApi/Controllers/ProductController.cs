using Application.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetListforCustomer/{customerId}")]
        public ActionResult GetListForCustomer(int customerId)
        {
            var result = _productService.GetListforCustomer(customerId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpGet("getforCustomer/{customerId}/product/{id}")]
        public ActionResult GetForCustomerBy(int id, int customerId)
        {
            var result = _productService.GetforCustomer(id, customerId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("getList")]
        public ActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var result = _productService.Get(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

    }
}
