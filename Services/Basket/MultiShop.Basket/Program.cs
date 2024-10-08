using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using MultiShop.Basket.Settings;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

var requireAutorizePolicy=new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");//sub � �eker
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //uygulamaz�da appsetingjsondan gelcek
    opt.Audience = "ResourceBasket";//keyine sahip olanlar CatalogFullPermission","CatalogReadPermission yetkilerine sahip olacak
    opt.RequireHttpsMetadata = false;
}
);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketService, BasketService>();

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("ReddisSettings"));
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redisSettings=sp.GetRequiredService<IOptions<RedisSettings>>().Value;   
    var redis=new RedisService(redisSettings.Host,redisSettings.Port);
    redis.Connect();
    return redis;   
});


builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAutorizePolicy));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
