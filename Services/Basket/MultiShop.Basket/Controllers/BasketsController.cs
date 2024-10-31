﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _logginService;

        public BasketsController(IBasketService basketService, ILoginService logginService)
        {
            _basketService = basketService;
            _logginService = logginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;
            var value = await _basketService.GetBasket(_logginService.GetUserId);
            return Ok(value);

        } 
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId=_logginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki değişiklikler kaydedildi.");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_logginService.GetUserId);
            return Ok("Sepet başarıyla silindi.");
        }
    }
}
