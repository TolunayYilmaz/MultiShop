﻿using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SingIn(SignInDto signInDto);
    }
}
