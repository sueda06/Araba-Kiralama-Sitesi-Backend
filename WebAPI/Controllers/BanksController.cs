using Business.Abstract;
using Core.Entities.Concrete;
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
    public class BanksController : ControllerBase
    {
       private IBankService _ıBankService;

        public BanksController(IBankService ıBankService)
        {
            _ıBankService = ıBankService;
        }
        [HttpGet("pay")]
        public IActionResult Pay(int amount)
        {
            var result = _ıBankService.Pay(amount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycart")]
        public IActionResult GetByCart(int id)
        {
            var result = _ıBankService.GetByCart(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCart creditCart)
        {
            var result = _ıBankService.AddCreditCart(creditCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
