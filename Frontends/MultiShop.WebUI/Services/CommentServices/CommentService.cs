﻿using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
		private readonly HttpClient _httpClient;

		public CommentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
		{
			var responseMessage = await _httpClient.GetAsync("Comments/CommentListByProductId/"+id);
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
			return values;
		}

		public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
		{
			await _httpClient.PostAsJsonAsync<CreateCommentDto>("Comments", createCommentDto);
		}

		public async Task DeleteCommentAsync(string id)
		{
			await _httpClient.DeleteAsync("Comments?id=" + id);
		}

		public async Task<List<ResultCommentDto>> GetAllCommentAsync()
		{
			var responseMessage = await _httpClient.GetAsync("Comments");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
			return values;
		}

		public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("Comments/" + id);

			var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
			return value;

		}

		public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
		{
			await _httpClient.PutAsJsonAsync<UpdateCommentDto>("Comments", updateCommentDto);
		}
	}
}