using DiscountAPI.Models;
using DiscountAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _discountService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Discount discount)
        {
            var result = await _discountService.Save(discount);
            return Ok(result);
        }
    }
}
