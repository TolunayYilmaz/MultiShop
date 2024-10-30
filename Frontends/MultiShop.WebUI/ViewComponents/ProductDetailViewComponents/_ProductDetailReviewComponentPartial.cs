﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

      

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value = await _commentService.CommentListByProductId(id);
           return View(value);



        }
    }
}
