﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomersServices;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
            
        }

        public async Task<IActionResult> Index()
        {
            var values=await _userService.GetUser();
            return View(values);
        } 
        
      
    }
}
