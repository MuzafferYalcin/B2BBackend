using Application.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDiscountController : ControllerBase
    {
        private readonly ICustomerDiscountService _customerDiscountService;

        public CustomerDiscountController(ICustomerDiscountService customerDiscountService)
        {
            _customerDiscountService = customerDiscountService;
        }
        [HttpGet("getList")]
        public IActionResult GetList()
        {
            var result = _customerDiscountService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpGet("getByCustomerId/{customerid}")]
        public IActionResult GetByCustomerId(int customerid)
        {
            var result = _customerDiscountService.GetByCustomerId(customerid);
            if (result.Success) 
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetAction(int id)
        {
            var result = _customerDiscountService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerDiscount customerDiscount)
        {
            var result = _customerDiscountService.Add(customerDiscount);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public IActionResult Update(CustomerDiscount customerDiscount)
        {
            var result = _customerDiscountService.Update(customerDiscount);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }


        [HttpPost("delete")]
        public IActionResult Delete(CustomerDiscount customerDiscount)
        {
            var result = _customerDiscountService.Delete(customerDiscount);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
