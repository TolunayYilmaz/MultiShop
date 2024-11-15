﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial:ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;

        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentService commentService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUser();
            int messageCount = await _messageService.GetTotalMessageCountbyRecieverId(user.Id);
            ViewBag.messageCount=messageCount; 
            int totalCommentCount = await _commentService.GetTotalCommandCount();
            ViewBag.totalCommentCount = totalCommentCount;

            return View();
        }
    } 
}
