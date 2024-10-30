﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {
      private readonly IProductDetailService _productDetailService;

        public _ProductDetailReviewComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
           var value=await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(value);



        }
    }
}
