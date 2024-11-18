﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserMessageStatisticsController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticsController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTotalMessageCount() 
        {
            int countMessage=await _userMessageService.GetTotalMessageCount();
            return Ok(countMessage);
        }

    }
}
